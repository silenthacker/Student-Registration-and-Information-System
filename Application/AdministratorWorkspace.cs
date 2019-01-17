using System;
using System.Data;
using MaterialSkin;
using System.Drawing;
using Microsoft.Win32;

using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class AdministratorWorkspace : MaterialForm
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        FeedbackForm feedbackform;

        SQLConnectionConfig sqlconnectionconfig;
        ChangePasswordRequiredForm changepasswordrequiredform;

        DarkerOpacityForm darkeropacityform;
        NotificationWindow notificationwindow;
        //NotYetAvailableForm notyetavailableform;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;
        
        string str1, str2, sqlquery1;
        string ShowFeebBackFormOrNot, isActive;
        private string UserID, StudentUserID, CurrentSchoolYear;

        //SYSTEM SETTINGS
        ServerManualConnectionForm servermanualconnectionform;
        OtherSettingsForm gradingSysSettings;
        //SystemLogForm systemlogform;

        //STUDENT
        ImportStudentDataForm importform;
        ManageStudentsForm managestudentsform;
        StudentFullDetailsForm studentfulldetailsform;
        StudentAverageForm_Admin studentaverageform;
        StudentAverageForm_Student studentaverageform_ron;

        //REGISTRATION
        AddTeacherForm addteacherform;
        DisableTeacherForm disableteacherform;
        ManageTeachersForm manageteachersform;

        //ENROLLMENT
        AddStudentForm addstudentform;
        AddSectionForm addsectionform;
        AddSchoolYearForm addschoolyearform;
        DisableStudentForm disablestudentform;

        //REPORTS
        StudentReportForm studentreportform;
        GradeReportForm gradereportform;
        EnrollmentReportForm enrollmentreportform;

        //TRANSACTIONS
        ListOfSystemObjectsForm listofSysObjects;

        //ACCOUNT
        AboutUniversity aboutuniversity;
        AboutUniversityHS aboutuniversityhs;
        AboutSystemDevelopers aboutsystemdev;

        ChangeUsernameForm changeusernameform;
        ChangePasswordForm changepasswordform;
        AccountInformationForm accountinformation;
        AccountPermissionsForm accountpermissionsform;
        ChangeSecurityCodeForm changesecuritycodeform;

        public AdministratorWorkspace()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal900, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
                
        private void AdministratorWorkspace_Load(object sender, EventArgs e)
        {
            bunifuCards1.Select();
            opacityform = new OpacityForm();
            AdministratorNameLabel.Text = "";

            LiveUpdateLabel.Text = "OFF";
            LiveUpdateLabel.ForeColor = Color.Black;
            pictureBox2.Visible = false;

            //EXCEPTION 1
            try
            {
                variables = new Variables();
                cryptography = new Cryptography();
                sqlconnectionconfig = new SQLConnectionConfig();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string tempdata = registrykey.GetValue("SQLServerConnectionString").ToString();
                ShowFeebBackFormOrNot = registrykey.GetValue("Show Feedback Form").ToString();
                UserID = registrykey.GetValue("User ID").ToString();
                
                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);

                //INNER EXCEPTION 1
                try
                {
                    sqlconnection.Open();
                    GetCurrentSchoolYear();
                    LoadAdministratorName();

                    //INIT SECTIONS
                    LoadSectionList();
                    
                    //INIT SCHOOL YEAR
                    LoadSchoolYearList();
                   
                    //LOAD SOME DATA INTO OUR TABLE
                    KeepAliveLoad_StudentLoadTable();
                    
                    //SET CUSTOM THEMES
                    MenuStrip.Renderer = new MyCustomRenderer(new CustomProfessionalColors());
                    GridContextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomContextMenuStripRender());

                    //SHOW [PASSWORD MUST BE CHANGE FORM] FOR USERS HAVING NO LOGIN HISTORY
                    string wildcardquery = "SELECT [IS PWD CHANGED] FROM [Tbl.Users] WHERE [USER ID] = '" + UserID + "'";
                    sqlcommand = new SqlCommand(wildcardquery, sqlconnection);
                    SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                    while (sqldatareader2.Read())
                    {
                        string ShowPasswordMustBeChangedForm = sqldatareader2.GetString(0);
                        if (ShowPasswordMustBeChangedForm.Equals("False"))
                        {
                            opacityform.Show();
                            changepasswordrequiredform = new ChangePasswordRequiredForm();
                            changepasswordrequiredform.ShowDialog();
                            opacityform.Hide();
                        }

                        //SHOW [FEDDBACK FORM] IF CERTAIN CONDITIONS ARE TRUE
                        if (ShowFeebBackFormOrNot.Equals("True")) 
                        {
                            feedbackform = new FeedbackForm();
                            feedbackform.Show();
                        }
                    }
                    sqldatareader2.Close();

                    //INIT TOOLSTRIP IMAGES
                    Show_Form_Endicators();
                    GradingDropdown_onItemSelected(sender, e);
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@MainForm Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@MainForm Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }
        
        private void Show_Form_Endicators()
        {
            try
            {
                variables = new Variables();
                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string VirtualData = registrykey.GetValue("Show Feedback Form").ToString();
                string VirtualData2 = registrykey.GetValue("Show Security Form").ToString();

                if (VirtualData.Equals("False"))
                    systemLogsToolStripMenuItem.Image = Properties.Resources.wex;
                else
                    systemLogsToolStripMenuItem.Image = Properties.Resources.wch;

                if (VirtualData2.Equals("False"))
                    clearSystemLogsToolStripMenuItem.Image = Properties.Resources.wex;
                else
                    clearSystemLogsToolStripMenuItem.Image = Properties.Resources.wch;
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void SystemTimer_Tick(object sender, EventArgs e)
        {
            GradingDropdown_onItemSelected(sender, e);
        }

        private void LoadAdministratorName()
        {
            sqlquery1 = "SELECT [FIRST NAME], [LAST NAME] FROM [Tbl.Teachers] WHERE [USER ID] = '" + UserID + "'";
            sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                str1 = sqldatareader.GetString(0);
                str2 = sqldatareader.GetString(1);

                if (str1.Length + str2.Length > 16) {
                    AdministratorNameLabel.Text = str1 + " " + str2.Remove(1, str2.Length - 1) + ".";
                }

                else {
                    AdministratorNameLabel.Text = str1 + " " + str2;
                }
            }
            sqldatareader.Close();
        }

        DataTable UniversalTable;
        private void KeepAliveLoad_StudentLoadTable()
        {
            try
            {
                string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                    CurrentSchoolYear + "' ORDER BY [STUDENT ID]";

                sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                UniversalTable = new DataTable();

                sqldataadapter.Fill(UniversalTable);
                StudentLoadGridView.AutoGenerateColumns = false;
                StudentLoadGridView.DataSource = UniversalTable;
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !   
            }
        }
        
        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                if (SystemTimer.Enabled == true)
                {
                    darkeropacityform = new DarkerOpacityForm();
                    notificationwindow = new NotificationWindow();

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "OPPS, PLEASE TURN OFF\nLIVE UPDATES WHILE SEARCHING !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (SystemTimer.Enabled == false)
                {
                    DataView dataview = UniversalTable.DefaultView;
                    dataview.RowFilter = string.Format("[STUDENT ID] like '%{0}%'", SearchTextBox.Text.Trim());
                    StudentLoadGridView.DataSource = dataview.ToTable();
                }
            }
        }

        private void GetCurrentSchoolYear()
        {
            try
            {
                string TempQuery = "SELECT [CURRENT SCHOOL YEAR] FROM [Tbl.CurrentSchoolYear]";
                sqlcommand = new SqlCommand(TempQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    CurrentSchoolYear = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }

        private void LoadSectionList()
        {
            //LOAD SECTION LIST
            string localvariablestring = "SELECT TOP 10 [SECTION NAME] FROM [Tbl.Sections] WHERE [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";
            sqlcommand = new SqlCommand(localvariablestring, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            SectionDropdown.AddItem("ALL SECTIONS");
            while (sqldatareader.Read())
            {
                SectionDropdown.AddItem(sqldatareader.GetString(0));
            }
            sqldatareader.Close();
            SectionDropdown.selectedIndex = 0;
        }

        private void LoadSchoolYearList()
        {
            //LOAD SCHOOL YEAR LIST
            string localvariablestring = "SELECT [SCHOOL YEAR] FROM [Tbl.SchoolYear]";
            sqlcommand = new SqlCommand(localvariablestring, sqlconnection);
            SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

            SchoolYearDropdown.AddItem("ALL SCHOOL YEAR");
            while (sqldatareader2.Read())
            {
                SchoolYearDropdown.AddItem(sqldatareader2.GetString(0));
            }
            sqldatareader2.Close();
            SchoolYearDropdown.selectedIndex = 0;
        }
        
        //REFRESH
        private void RefreshPicture_Click(object sender, EventArgs e)
        {
            try
            {
                //REMOVE OLD SECTION AND SCHOOL YEAR DATA
                SectionDropdown.Clear();
                SchoolYearDropdown.Clear();

                //INIT NEW SECTION AND SCHOOL YEAR DATA
                LoadSectionList();
                LoadSchoolYearList();
            }

            catch (Exception) {
                //DO NOTHING SHIT !
            }
        }

        //SORT
        private void GradingDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                //DISPLAY ALL BY FIRST GRADING TABLE
                if (GradingDropdown.selectedIndex == 0 && SectionDropdown.selectedIndex == 0 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 0 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 0 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //DISPLAY ALL BY SECOND GRADING TABLE
                if (GradingDropdown.selectedIndex == 1 && SectionDropdown.selectedIndex == 0 && 
                    SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 1 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE [SCHOOL YEAR] = '" + 
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 1 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 1)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //DISPLAY ALL BY THIRD GRADING TABLE
                if (GradingDropdown.selectedIndex == 2 && SectionDropdown.selectedIndex == 0 &&
                    SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 2 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 2 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 2)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //DISPLAY ALL BY FOURTH GRADING TABLE
                if (GradingDropdown.selectedIndex == 3 && SectionDropdown.selectedIndex == 0 &&
                    SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 3 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 3 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 3)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }
        
        //SORT
        private void SectionDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                //DISPLAY ALL BY FIRST GRADING TABLE
                if (GradingDropdown.selectedIndex == 0 && SectionDropdown.selectedIndex == 0 &&
                    SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 0 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 0 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //DISPLAY ALL BY SECOND GRADING TABLE
                if (GradingDropdown.selectedIndex == 1 && SectionDropdown.selectedIndex == 0 &&
                    SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] + ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 1 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 1 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 1)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //DISPLAY ALL BY THIRD GRADING TABLE
                if (GradingDropdown.selectedIndex == 2 && SectionDropdown.selectedIndex == 0 &&
                    SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 2 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 2 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 2)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //DISPLAY ALL BY FOURTH GRADING TABLE
                if (GradingDropdown.selectedIndex == 3 && SectionDropdown.selectedIndex == 0 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 3 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 3 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 3)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }
        
        //SORT
        private void SchoolYearDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                //DISPLAY ALL BY FIRST GRADING TABLE
                if (GradingDropdown.selectedIndex == 0 && SectionDropdown.selectedIndex == 0 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 0 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 0 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //DISPLAY ALL BY SECOND GRADING TABLE
                if (GradingDropdown.selectedIndex == 1 && SectionDropdown.selectedIndex == 0 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 1 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 1 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 1)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //DISPLAY ALL BY THIRD GRADING TABLE
                if (GradingDropdown.selectedIndex == 2 && SectionDropdown.selectedIndex == 0 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 2 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 2 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 2)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //DISPLAY ALL BY FOURTH GRADING TABLE
                if (GradingDropdown.selectedIndex == 3 && SectionDropdown.selectedIndex == 0 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 3 && SectionDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                        SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY SECTION
                else if (GradingDropdown.selectedIndex == 3 && SchoolYearDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                else if (GradingDropdown.selectedIndex == 3)
                {
                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE SECTION = '" +
                        SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }

        //SYSTEM SETTINGS
        private void sQLServerConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                opacityform = new OpacityForm();
                opacityform.Show();

                string WarningMessage = "MODIFYING YOUR SERVER CONNECTION MIGHT CAUSE SYSTEM UNSTABILITY !, " + 
                   "IT IS RECOMMENDED TO CONTACT YOUR SYSTEM ADMINISTRATOR OR REFER TO THE SYSTEM MANUAL." + 
                   "\n\nDO YOU WANT TO PROCEED ANYWAY ?";

                var UserWantToOverrideServerConnection = MessageBox.Show(WarningMessage, "SYSTEM SETTINGS", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (UserWantToOverrideServerConnection == DialogResult.No || 
                    UserWantToOverrideServerConnection == DialogResult.Cancel)
                {
                    opacityform.Hide();
                }

                else if (UserWantToOverrideServerConnection == DialogResult.Yes)
                {
                    servermanualconnectionform = new ServerManualConnectionForm();
                    servermanualconnectionform.ShowDialog();
                    opacityform.Hide();
                }
            }

            catch (Exception) {
                //DON'T DISPLAY ANYTHING SHIT !
            }
        }

        private void gradingSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlquery1 = "SELECT COUNT(*) FROM [Tbl.SchoolYear]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                opacityform = new OpacityForm();
                gradingSysSettings = new OtherSettingsForm();

                opacityform.Show();
                gradingSysSettings.ShowDialog();

                opacityform.Hide();
            }

            else if (datatable.Rows[0][0].ToString() == "0")
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.warning;
                notificationwindow.MessageText = "NOTHING TO SET HERE !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }   
        }

        private void systemLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                variables = new Variables();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string VirtualData = registrykey.GetValue("Show Feedback Form").ToString();

                RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                if (VirtualData.Equals("False"))
                {
                    updateregistrykey.SetValue("Show Feedback Form", "True");
                    systemLogsToolStripMenuItem.Image = Properties.Resources.wch;

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                    notificationwindow.MessageText = "FEEDBACK FORM WILL BE SHOWN\nDURING STARTUP !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
                
                else if (VirtualData.Equals("True"))
                {
                    updateregistrykey.SetValue("Show Feedback Form", "False");
                    systemLogsToolStripMenuItem.Image = Properties.Resources.wex;

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "FEEDBACK FORM WILL NOT BE SHOWN\nDURING STARTUP !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void clearSystemLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                variables = new Variables();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string VirtualData = registrykey.GetValue("Show Security Form").ToString();

                RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                if (VirtualData.Equals("False"))
                {
                    updateregistrykey.SetValue("Show Security Form", "True");
                    clearSystemLogsToolStripMenuItem.Image = Properties.Resources.wch;

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                    notificationwindow.MessageText = "SECURITY FORM WILL BE SHOWN\nDURING STARTUP !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
                
                else if (VirtualData.Equals("True"))
                {
                    updateregistrykey.SetValue("Show Security Form", "False");
                    clearSystemLogsToolStripMenuItem.Image = Properties.Resources.wex;

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "SECURITY FORM WILL NOT BE SHOWN\nDURING STARTUP !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        //STUDENT
        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StudentLoadGridView.Visible == false)
            {
                StudentLoadGridView.Visible = true;
                bunifuCards1.Select();
            }

            else if (StudentLoadGridView.Visible == true)
            {
                StudentLoadGridView.Visible = false;
            }
        }

        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Sections]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            string sqlquery2 = "SELECT COUNT(*) FROM [Tbl.SchoolYear]";
            sqldataadapter = new SqlDataAdapter(sqlquery2, sqlconnection);
            DataTable datatable2 = new DataTable();
            sqldataadapter.Fill(datatable2);

            if (int.Parse(datatable.Rows[0][0].ToString()) > 0 && int.Parse(datatable2.Rows[0][0].ToString()) > 0)
            {
                opacityform = new OpacityForm();
                importform = new ImportStudentDataForm();

                opacityform.Show();
                importform.ShowDialog();

                opacityform.Hide();
            }

            else if (datatable2.Rows[0][0].ToString() == "0")
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.warning;
                notificationwindow.MessageText = "BEFORE YOU CAN IMPORT,\nPLEASE CREATE A SCHOOL YEAR !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }

            else if (datatable.Rows[0][0].ToString() == "0")
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.warning;
                notificationwindow.MessageText = "THERE IS NO SECTIONS CREATED !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }
        }

        //REGISTRATION
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Sections]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            string sqlquery2 = "SELECT COUNT(*) FROM [Tbl.SchoolYear]";
            sqldataadapter = new SqlDataAdapter(sqlquery2, sqlconnection);
            DataTable datatable2 = new DataTable();
            sqldataadapter.Fill(datatable2);

            if (int.Parse(datatable.Rows[0][0].ToString()) > 0 && int.Parse(datatable2.Rows[0][0].ToString()) > 0)
            {
                opacityform = new OpacityForm();
                addteacherform = new AddTeacherForm();

                opacityform.Show();
                addteacherform.ShowDialog();

                opacityform.Hide();
            }
            
            else if (datatable2.Rows[0][0].ToString() == "0")
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.warning;
                notificationwindow.MessageText = "WE ARE UNABLE TO CONTINUE !\nPLEASE CREATE A SCHOOL YEAR FIRST.";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }

            else if (datatable.Rows[0][0].ToString() == "0")
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.warning;
                notificationwindow.MessageText = "WE CAN'T FIND ANY SECTIONS !\n";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }
        }

        private void disableTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            disableteacherform = new DisableTeacherForm();

            opacityform.Show();
            disableteacherform.ShowDialog();

            opacityform.Hide();
        }

        //ENROLLMENT
        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Sections]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            string sqlquery2 = "SELECT COUNT(*) FROM [Tbl.SchoolYear]";
            sqldataadapter = new SqlDataAdapter(sqlquery2, sqlconnection);
            DataTable datatable2 = new DataTable();
            sqldataadapter.Fill(datatable2);

            if (int.Parse(datatable.Rows[0][0].ToString()) > 0 && int.Parse(datatable2.Rows[0][0].ToString()) > 0)
            {
                opacityform = new OpacityForm();
                addstudentform = new AddStudentForm();

                opacityform.Show();
                addstudentform.ShowDialog();

                opacityform.Hide();
            }

            else if (datatable2.Rows[0][0].ToString() == "0")
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.warning;
                notificationwindow.MessageText = "PLEASE CREATE A SCHOOL YEAR BEFORE\nADDING A STUDENT !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }

            else if (datatable.Rows[0][0].ToString() == "0")
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.warning;
                notificationwindow.MessageText = "SCHOOL YEAR IS SET BUT\nTHERE IS NO SECTIONS CREATED !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }
        }

        private void createNewSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlquery1 = "SELECT COUNT(*) FROM [Tbl.SchoolYear]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            string sqlquery2 = "SELECT COUNT(*) FROM [Tbl.CurrentSchoolYear]";
            sqldataadapter = new SqlDataAdapter(sqlquery2, sqlconnection);
            DataTable datatable2 = new DataTable();
            sqldataadapter.Fill(datatable2);

            if (int.Parse(datatable.Rows[0][0].ToString()) > 0 && int.Parse(datatable2.Rows[0][0].ToString()) > 0)
            {
                opacityform = new OpacityForm();
                addsectionform = new AddSectionForm();

                opacityform.Show();
                addsectionform.ShowDialog();

                opacityform.Hide();
            }

            else if (datatable.Rows[0][0].ToString() == "0")
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.warning;
                notificationwindow.MessageText = "WE CAN'T CREATE A SECTION BECUASE\nTHERE IS NO SCHOOL YEAR !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }

            else if (datatable2.Rows[0][0].ToString() == "0")
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.warning;
                notificationwindow.MessageText = "PLEASE SET THE CURRENT SCHOOL YEAR !\nUNDER SYSTEM SETTINGS.";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }
        }
        
        private void newSchoolYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            addschoolyearform = new AddSchoolYearForm();

            opacityform.Show();
            addschoolyearform.ShowDialog();

            opacityform.Hide();
        }

        private void disableStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            disablestudentform = new DisableStudentForm();

            opacityform.Show();
            disablestudentform.ShowDialog();

            opacityform.Hide();
        }

        //REPORTS
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            studentreportform = new StudentReportForm();

            opacityform.Show();
            studentreportform.ShowDialog();

            opacityform.Hide();
        }

        private void gradeReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            gradereportform = new GradeReportForm();

            opacityform.Show();
            gradereportform.ShowDialog();

            opacityform.Hide();
        }

        private void enrollmentReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            enrollmentreportform = new EnrollmentReportForm();

            opacityform.Show();
            enrollmentreportform.ShowDialog();

            opacityform.Hide();
        }

        //TRANSACTION
        private void listOfStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            listofSysObjects = new ListOfSystemObjectsForm();
            listofSysObjects.TabControl.SelectedIndex = 0;

            opacityform.Show();
            listofSysObjects.ShowDialog();

            opacityform.Hide();
        }

        private void listOfTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            listofSysObjects = new ListOfSystemObjectsForm();
            listofSysObjects.TabControl.SelectedIndex = 1;

            opacityform.Show();
            listofSysObjects.ShowDialog();

            opacityform.Hide();
        }

        private void listOfUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            listofSysObjects = new ListOfSystemObjectsForm();
            listofSysObjects.TabControl.SelectedIndex = 2;

            opacityform.Show();
            listofSysObjects.ShowDialog();

            opacityform.Hide();
        }

        //ACCOUNT
        private void accountInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            accountinformation = new AccountInformationForm();

            opacityform.Show();
            accountinformation.ShowDialog();

            opacityform.Hide();
        }

        private void changeUsernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            changeusernameform = new ChangeUsernameForm();

            opacityform.Show();
            changeusernameform.ShowDialog();

            opacityform.Hide();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            changepasswordform = new ChangePasswordForm();

            opacityform.Show();
            changepasswordform.ShowDialog();

            opacityform.Hide();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bukSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            aboutuniversity = new AboutUniversity();

            opacityform.Show();
            aboutuniversity.ShowDialog();

            opacityform.Hide();
        }

        private void secondarySchoolLaboratorySSLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            aboutuniversityhs = new AboutUniversityHS();

            opacityform.Show();
            aboutuniversityhs.ShowDialog();

            opacityform.Hide();
        }

        private void systemDevelopersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            aboutsystemdev = new AboutSystemDevelopers();

            opacityform.Show();
            aboutsystemdev.ShowDialog();

            opacityform.Hide();
        }

        private void CloseTopButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseTopButton_MouseHover(object sender, EventArgs e)
        {
            CloseTopButton.BackColor = Color.FromArgb(39, 44, 51);
            CloseTopButton.Image = Properties.Resources.Close_Button_Hover;
        }

        private void CloseTopButton_MouseLeave(object sender, EventArgs e)
        {
            CloseTopButton.Image = Properties.Resources.Close_Button;
        }

        private void MinimizeTopButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeTopButton_MouseHover(object sender, EventArgs e)
        {
            MinimizeTopButton.BackColor = Color.FromArgb(39, 44, 51);
            MinimizeTopButton.Image = Properties.Resources.Minimized_Button_Hover;
        }

        private void MinimizeTopButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeTopButton.Image = Properties.Resources.Minimized_Button;
        }

        private void MaximizeTopButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void MaximizeTopButton_MouseHover(object sender, EventArgs e)
        {
            MaximizeTopButton.BackColor = Color.FromArgb(39, 44, 51);
            MaximizeTopButton.Image = Properties.Resources.Miximized_Button_Hover;
        }
        
        private void MaximizeTopButton_MouseLeave(object sender, EventArgs e)
        {
            MaximizeTopButton.Image = Properties.Resources.Miximized_Button;
        }
        
        private void RefreshPicture_MouseHover(object sender, EventArgs e)
        {
            RefreshPicture.Size = new Size(37, 37);
        }
        
        private void RefreshPicture_MouseLeave(object sender, EventArgs e)
        {
            RefreshPicture.Size = new Size(35, 35);
        }
        
        private void ImportImage_Click(object sender, EventArgs e)
        {
            importFromExcelToolStripMenuItem_Click(sender, e);
        }
        
        private void ImportImage_MouseHover(object sender, EventArgs e)
        {
            ImportImage.Size = new Size(37, 37);
        }
        
        private void ImportImage_MouseLeave(object sender, EventArgs e)
        {
            ImportImage.Size = new Size(35, 35);
        }
        
        private void AddTeacherImage_Click(object sender, EventArgs e)
        {
            addToolStripMenuItem_Click(sender, e);
        }
        
        private void AddTeacherImage_MouseHover(object sender, EventArgs e)
        {
            AddTeacherImage.Size = new Size(37, 37);
        }
        
        private void AddTeacherImage_MouseLeave(object sender, EventArgs e)
        {
            AddTeacherImage.Size = new Size(35, 35);
        }
        
        private void AddStudentImage_Click(object sender, EventArgs e)
        {
            addStudentToolStripMenuItem_Click(sender, e);
        }
        
        private void AddStudentImage_MouseHover(object sender, EventArgs e)
        {
            AddStudentImage.Size = new Size(37, 37);
        }

        private void yesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTimer.Enabled = true;
            LiveUpdateLabel.Text = "ON";
            LiveUpdateLabel.ForeColor = Color.LimeGreen;
        }

        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTimer.Enabled = false;
            LiveUpdateLabel.Text = "OFF";
            LiveUpdateLabel.ForeColor = Color.Black;
        }

        private void accountPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:
            opacityform = new OpacityForm();
            accountpermissionsform = new AccountPermissionsForm();
            
            opacityform.Show();
            accountpermissionsform.ShowDialog();

            opacityform.Hide();
        }

        private void studentAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:
            opacityform = new OpacityForm();
            studentaverageform = new StudentAverageForm_Admin();

            opacityform.Show();
            studentaverageform.ShowDialog();

            opacityform.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //VIEW STUDENT DETAILS
            opacityform = new OpacityForm();
            studentfulldetailsform = new StudentFullDetailsForm();

            studentfulldetailsform.Restricted = true;
            DataGridViewRow CurrentRow = StudentLoadGridView.CurrentRow;
            studentfulldetailsform.StudentID = CurrentRow.Cells["STUDENTID"].Value.ToString();

            try
            {
                string RetrieveQuery = "SELECT [USER ID] FROM [Tbl.Students] WHERE [STUDENT ID] = '" + 
                    CurrentRow.Cells["STUDENTID"].Value.ToString() + "'";

                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    studentfulldetailsform.UserID = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }

            opacityform.Show();
            studentfulldetailsform.ShowDialog();

            opacityform.Hide();
        }
        
        private void viewStudentAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //VIEW STUDENT (ONLY) AVERAGE
            opacityform = new OpacityForm();
            studentaverageform_ron = new StudentAverageForm_Student();
            
            try
            {
                DataGridViewRow CurrentRow = StudentLoadGridView.CurrentRow;
                studentaverageform_ron.StudentID = CurrentRow.Cells["STUDENTID"].Value.ToString();

                string RetrieveQuery = "SELECT [USER ID] FROM [Tbl.Students] WHERE [STUDENT ID] = '" +
                    CurrentRow.Cells["STUDENTID"].Value.ToString() + "'";

                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    studentaverageform_ron.UserID = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }

            opacityform.Show();
            studentaverageform_ron.ShowDialog();

            opacityform.Hide();
        }

        private void sECURITYCODEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            changesecuritycodeform = new ChangeSecurityCodeForm();

            opacityform.Show();
            changesecuritycodeform.ShowDialog();

            opacityform.Hide();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshPicture_Click(sender, e);
        }

        private void manageStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            managestudentsform = new ManageStudentsForm();

            opacityform.Show();
            managestudentsform.ShowDialog();

            opacityform.Hide();
        }

        private void manageTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            manageteachersform = new ManageTeachersForm();

            opacityform.Show();
            manageteachersform.ShowDialog();

            opacityform.Hide();
        }

        private void MenuStrip_MouseHover(object sender, EventArgs e)
        {
            Show_Form_Endicators();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //DISABLED STUDENT ACCOUNT
            try
            {
                opacityform = new OpacityForm();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                //TODO:
                DataGridViewRow CurrentRow = StudentLoadGridView.CurrentRow;
                string RetrieveQuery = "SELECT [USER ID] FROM [Tbl.Students] WHERE [STUDENT ID] = '" + 
                    CurrentRow.Cells["STUDENTID"].Value.ToString() + "'";

                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    StudentUserID = sqldatareader.GetString(0);
                }
                sqldatareader.Close();

                string VerifyQuery = "SELECT [ACCOUNT STATUS] FROM [Tbl.Users] WHERE [USER ID] = '" + StudentUserID + "'";
                sqlcommand = new SqlCommand(VerifyQuery, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    isActive = sqldatareader2.GetString(0);
                }
                sqldatareader2.Close();

                if (isActive.Equals("Active"))
                {
                    opacityform.Show();
                    var UserWantToContinue = MessageBox.Show("ARE YOU SURE TO DISABLE THIS STUDENT ?, THIS STUDENT CANNOT LOGIN ANYMORE" + 
                        " UNLESS YOU ENABLE IT BACK !\n\nDO YOU WANT TO PROCEED ANYWAY ?", "ARE YOU SURE ?",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (UserWantToContinue == DialogResult.No || UserWantToContinue == DialogResult.Cancel)
                    {
                        opacityform.Hide();
                    }

                    else if (UserWantToContinue == DialogResult.Yes)
                    {
                        opacityform.Hide();
                        string alterquery1 = "UPDATE [Tbl.Users] SET [ACCOUNT STATUS] = @accountstatus WHERE [USER ID] = '" +
                                    StudentUserID + "'";

                        sqlcommand = new SqlCommand(alterquery1, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@accountstatus", "Disabled");
                        sqlcommand.ExecuteNonQuery();

                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.check;
                        notificationwindow.MessageText = "USER ACCOUNT IS NOW DISABLED !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();
                    }
                }

                else if (isActive.Equals("Disabled"))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                    notificationwindow.MessageText = "USER ACCOUNT IS ALREADY DISABLED !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
            }

            catch (Exception ex)
            {
                //DON'T DO ANYTHING BITCH !
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //ENABLED STUDENT ACCOUNT
            try
            {
                opacityform = new OpacityForm();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                //TODO:
                DataGridViewRow CurrentRow = StudentLoadGridView.CurrentRow;
                string RetrieveQuery = "SELECT [USER ID] FROM [Tbl.Students] WHERE [STUDENT ID] = '" + 
                    CurrentRow.Cells["STUDENTID"].Value.ToString() + "'";

                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    StudentUserID = sqldatareader.GetString(0);
                }
                sqldatareader.Close();

                string VerifyQuery = "SELECT [ACCOUNT STATUS] FROM [Tbl.Users] WHERE [USER ID] = '" + StudentUserID + "'";
                sqlcommand = new SqlCommand(VerifyQuery, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    isActive = sqldatareader2.GetString(0);
                }
                sqldatareader2.Close();

                if (isActive.Equals("Active"))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                    notificationwindow.MessageText = "USER ACCOUNT IS ALREADY ENABLED !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (isActive.Equals("Disabled"))
                {
                    string alterquery1 = "UPDATE [Tbl.Users] SET [ACCOUNT STATUS] = @accountstatus WHERE [USER ID] = '" + 
                        StudentUserID + "'";

                    sqlcommand = new SqlCommand(alterquery1, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@accountstatus", "Active");
                    sqlcommand.ExecuteNonQuery();

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                    notificationwindow.MessageText = "USER ACCOUNT IS NOW ENABLED !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
            }

            catch (Exception ex)
            {
                //DON'T DO ANYTHING BITCH !
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        private void AddStudentImage_MouseLeave(object sender, EventArgs e)
        {
            AddStudentImage.Size = new Size(35, 35);
        }

        private void AdministratorWorkspace_FormClosing(object sender, FormClosingEventArgs e)
        {
            opacityform = new OpacityForm();
            
            //EXCEPTION 2
            try
            {
                opacityform.Show();

                var UserWantsToExit = MessageBox.Show("ARE YOU SURE TO CLOSE THIS WINDOW ?\nPRESS NO TO CANCEL.",
                    "ARE YOU SURE ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (UserWantsToExit == DialogResult.No)
                {
                    opacityform.Hide();
                    e.Cancel = true;
                }

                else if (UserWantsToExit == DialogResult.Yes)
                {
                    LoginForm loginform = new LoginForm();
                    opacityform.Hide();

                    //RESTORE ACCOUNT SITUATION STATUS
                    string UpdateQuery = "UPDATE [Tbl.Users] SET [SITUATION STATUS] = @situationstatus WHERE [USER ID] = '" + UserID + "'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@situationstatus", "0");
                    sqlcommand.ExecuteNonQuery();
                    sqlconnection.Close();

                    e.Cancel = false;
                    loginform.Show();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@MainForm Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }
    }
}
