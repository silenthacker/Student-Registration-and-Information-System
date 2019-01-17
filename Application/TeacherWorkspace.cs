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
    public partial class TeacherWorkspace : MaterialForm
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        FeedbackForm feedbackform;

        SQLConnectionConfig sqlconnectionconfig;
        ChangePasswordRequiredForm changepasswordrequiredform;

        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;
        GetCurrentSchoolYear getcurrentschoolyear;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;

        string ShowFeebBackFormOrNot;
        private string UserID, TeacherID;
        string str1, str2, sqlquery1, returnstring,
            Call_Method_Stored_Procedure, CurrentSchoolYear;

        protected string StringHandler;

        //SYSTEM SETTINGS
        ServerManualConnectionForm servermanualconnectionform;

        //STUDENTS
        StudentFullDetailsForm studentfulldetailsform;
        StudentAverageForm_Teacher studentaverageform_teacher;
        StudentAverageForm_Student studentaverageform_ron;

        //REPORTS
        StudentReportForm studentreport;
        GradeReportForm gradereport;
        EnrollmentReportForm enrollmentreport;

        //TRANSACTIONS
        ListOfSystemObjectsForm listofSysObjects;

        //ACCOUNT
        AboutUniversity aboutuniversity;
        AboutUniversityHS aboutuniversityhs;
        AboutSystemDevelopers aboutsystemdev;

        ChangeUsernameForm changeusernameform;
        ChangePasswordForm changepasswordform;
        AccountInformationForm accountinformation;
        ChangeSecurityCodeForm changesecuritycodeform;

        ImportStudentDataForm importform;
        AddStudentForm addstudentform;
        DisableStudentForm disablestudentform;

        public TeacherWorkspace()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal900, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void TeacherWorkspace_Load(object sender, EventArgs e)
        {
            bunifuCards2.Select();
            opacityform = new OpacityForm();
            TeacherNameLabel.Text = "";

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
                TeacherID = registrykey.GetValue("Teacher ID").ToString();
                UserID = registrykey.GetValue("User ID").ToString();
                
                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                //INNER EXCEPTION 1
                try
                {
                    //INIT TEACHER NAME
                    LoadTeacherName();
                    
                    //INIT SCHOOL YEAR DROPDOWN
                    LoadSchoolYearList();

                    //INIT SECTION DROPDOWN
                    LoadHandledSections();

                    //INIT SUBJECTS DROPDOWN
                    Init_Subjects_List() ;  
                    
                    //LOAD STUDENT RECORDS
                    LoadStudentRecords();

                    //DONT MIND THIS !!
                    Hide_Not_Related_Subject_Columns();
                    
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
                    
                    //CUSTOM CODES
                    MessageLabel.Text = "";
                    Time_And_Date_Label.Text = "";
                    Timer.Enabled = true;

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
                    showFeedbackFormOnStartupToolStripMenuItem.Image = Properties.Resources.wex;
                else
                    showFeedbackFormOnStartupToolStripMenuItem.Image = Properties.Resources.wch;

                if (VirtualData2.Equals("False"))
                    showSecurityFormOnStartupToolStripMenuItem.Image = Properties.Resources.wex;
                else
                    showSecurityFormOnStartupToolStripMenuItem.Image = Properties.Resources.wch;
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private bool isNumber(string data)
        {
            try
            {
                long.Parse(data);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        private void StudentLoadGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //EXCEPTION 2
            try
            {
                opacityform = new OpacityForm();
                Point index = StudentLoadGridView.CurrentCellAddress;

                //INNER EXCEPTION 2
                try
                {
                    DataGridViewRow VirtualGridRow = StudentLoadGridView.CurrentRow;
                    DataGridViewCell VirtualGridCell = StudentLoadGridView.CurrentCell;
                    
                    if (StudentLoadGridView.CurrentRow != null)
                    {
                        if (isNumber(VirtualGridCell.Value.ToString().Trim()) == false)
                        {
                            darkeropacityform = new DarkerOpacityForm();
                            notificationwindow = new NotificationWindow();

                            notificationwindow.CaptionText = "STUDENT REGISTRATION & INFORMATION SYSTEM";
                            notificationwindow.MsgImage.Image = Properties.Resources.error;
                            notificationwindow.MessageText = "OPPS, YOU ENTERED AN INVALID VALUE !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                            
                            //RESTORE SECURITY STATE
                            SectionDropdown_onItemSelected(sender, e);
                            StudentLoadGridView.Rows[index.Y].Cells[index.X].Selected = true;
                        }

                        else if (long.Parse(VirtualGridCell.Value.ToString().Trim()) > 100 || long.Parse(VirtualGridCell.Value.ToString().Trim()) < 70)
                        {
                            darkeropacityform = new DarkerOpacityForm();
                            notificationwindow = new NotificationWindow();

                            notificationwindow.CaptionText = "STUDENT REGISTRATION & INFORMATION SYSTEM";
                            notificationwindow.MsgImage.Image = Properties.Resources.error;
                            notificationwindow.MessageText = "OPPS, YOU CAN ONLY ENTER VALUES\nBETWEEN 70 - 100 !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();

                            //RESTORE SECURITY STATE
                            SectionDropdown_onItemSelected(sender, e);
                            StudentLoadGridView.Rows[index.Y].Cells[index.X].Selected = true;
                        }
                        
                        else
                        {
                            //CALL THE STORED PROCEDURE IN THE SERVER
                            sqlcommand = new SqlCommand(Call_Method_Stored_Procedure, sqlconnection);
                            sqlcommand.CommandType = CommandType.StoredProcedure;
                            
                            sqlcommand.Parameters.AddWithValue("@student_id", VirtualGridRow.Cells["STUDENTID"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["STUDENTID"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@student_name", VirtualGridRow.Cells["ColumnStudentName"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnStudentName"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@gender", VirtualGridRow.Cells["ColumnGender"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnGender"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@grade_level", VirtualGridRow.Cells["ColumnStudentGradeLevel"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnStudentGradeLevel"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@section", VirtualGridRow.Cells["ColumnStudentSection"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnStudentSection"].Value.ToString().Trim());

                            sqlcommand.Parameters.AddWithValue("@filipino", VirtualGridRow.Cells["FilipinoColumn"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["FilipinoColumn"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@english", VirtualGridRow.Cells["EnglishColumn"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["EnglishColumn"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@mathematics", VirtualGridRow.Cells["MathematicsColumn"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["MathematicsColumn"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@science", VirtualGridRow.Cells["ScienceColumn"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ScienceColumn"].Value.ToString().Trim());
                            
                            sqlcommand.Parameters.AddWithValue("@ap", VirtualGridRow.Cells["APColumn"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["APColumn"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@tle", VirtualGridRow.Cells["TLEColumn"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["TLEColumn"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@mapeh", VirtualGridRow.Cells["MapehColumn"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["MapehColumn"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@esp", VirtualGridRow.Cells["ESPColumn"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ESPColumn"].Value.ToString().Trim());
                            sqlcommand.Parameters.AddWithValue("@school_year", VirtualGridRow.Cells["ColumnSchoolYear"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnSchoolYear"].Value.ToString().Trim());

                            //UPDATE OLD RECORDS SHIT !
                            sqlcommand.ExecuteNonQuery();
                        }
                    }
                }

                catch (Exception)
                {
                    darkeropacityform = new DarkerOpacityForm();
                    notificationwindow = new NotificationWindow();

                    notificationwindow.CaptionText = "STUDENT REGISTRATION & INFORMATION SYSTEM";
                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                    notificationwindow.MessageText = "AN ERROR OCCURED WHILE UPLOADING\nTHE GRADES PLEASE TRY AGAIN LATER !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();

                    //RESTORE SECURITY STATE
                    SectionDropdown_onItemSelected(sender, e);
                    StudentLoadGridView.Rows[index.Y].Cells[index.X].Selected = true;
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Teacher Workspace Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void Enable_GridView_For_Uploading()
        {
            STUDENTID.ReadOnly = true;
            ColumnStudentName.ReadOnly = true;
            ColumnStudentGradeLevel.ReadOnly = true;
            ColumnGender.ReadOnly = true;
            ColumnStudentSection.ReadOnly = true;

            FilipinoColumn.ReadOnly = false;
            EnglishColumn.ReadOnly = false;
            MathematicsColumn.ReadOnly = false;
            ScienceColumn.ReadOnly = false;

            APColumn.ReadOnly = false;
            TLEColumn.ReadOnly = false;
            MapehColumn.ReadOnly = false;
            ESPColumn.ReadOnly = false;

            ColumnSchoolYear.ReadOnly = true;
        }
        
        private void SystemTimer_Tick(object sender, EventArgs e)
        {
            GradingDropdown_onItemSelected(sender, e);
        }

        private void Hide_Not_Related_Subject_Columns()
        {
            try
            {
                //ENGLISH
                SubjectsDropdown.selectedIndex = 0;
                if (SubjectsDropdown.selectedValue.ToString() == "")
                {
                    EnglishColumn.Visible = false;
                }

                //MATHEMATICS
                SubjectsDropdown.selectedIndex = 1;
                if (SubjectsDropdown.selectedValue.ToString() == "")
                {
                    MathematicsColumn.Visible = false;
                }

                //SCIENCE
                SubjectsDropdown.selectedIndex = 2;
                if (SubjectsDropdown.selectedValue.ToString() == "")
                {
                    ScienceColumn.Visible = false;
                }

                //FILIPINO
                SubjectsDropdown.selectedIndex = 3;
                if (SubjectsDropdown.selectedValue.ToString() == "")
                {
                    FilipinoColumn.Visible = false;
                }

                //MAPEH
                SubjectsDropdown.selectedIndex = 4;
                if (SubjectsDropdown.selectedValue.ToString() == "")
                {
                    MapehColumn.Visible = false;
                }

                //AP
                SubjectsDropdown.selectedIndex = 5;
                if (SubjectsDropdown.selectedValue.ToString() == "")
                {
                    APColumn.Visible = false;
                }

                //ESP
                SubjectsDropdown.selectedIndex = 6;
                if (SubjectsDropdown.selectedValue.ToString() == "")
                {
                    ESPColumn.Visible = false;
                }

                //TLE
                SubjectsDropdown.selectedIndex = 7;
                if (SubjectsDropdown.selectedValue.ToString() == "")
                {
                    TLEColumn.Visible = false;
                }
            }

            catch (Exception) {
                //DO NOTHING SHIT !
            }
        }

        private void Init_Subjects_List()
        {
            string localvariablestring = "SELECT * FROM [Tbl.HandledSubjects] WHERE [TEACHER ID] = '" + TeacherID + "'";
            sqlcommand = new SqlCommand(localvariablestring, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                int index = 2;
                for (int iterator = 0; iterator < 8; iterator++)
                {
                    SubjectsDropdown.AddItem(sqldatareader.GetString(index));
                    index++;
                }
            }
            sqldatareader.Close();
        }

        private void RemoveSpacesInSubjects()
        {
            int index = 2;
            for (int iterator = 0; iterator < 8; iterator++)
            {
                SubjectsDropdown.RemoveItem("");
                index++;
            }
        }
        
        private void LoadTeacherName()
        {
            sqlquery1 = "SELECT [FIRST NAME], [LAST NAME] FROM [Tbl.Teachers] WHERE [USER ID] = '" + UserID + "'";
            sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                str1 = sqldatareader.GetString(0);
                str2 = sqldatareader.GetString(1);

                if (str1.Length + str2.Length > 16) {
                    TeacherNameLabel.Text = str1 + " " + str2.Remove(1, str2.Length - 1) + ".";
                }

                else {
                    TeacherNameLabel.Text = str1 + " " + str2;
                }
            }
            sqldatareader.Close();
        }

        DataTable UniversalTable;
        private void LoadStudentRecords()
        {
            try
            {
                string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE [SECTION] = '" + 
                    SectionDropdown.selectedValue.ToString() + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
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

        private void LoadSchoolYearList()
        {
            //LOAD SCHOOL YEAR LIST
            string localvariablestring = "SELECT [SCHOOL YEAR] FROM [Tbl.SchoolYear]";
            sqlcommand = new SqlCommand(localvariablestring, sqlconnection);
            SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

            SchoolYearDropdown.Clear();
            while (sqldatareader2.Read())
            {
                SchoolYearDropdown.AddItem(sqldatareader2.GetString(0));
            }
            sqldatareader2.Close();
            SchoolYearDropdown.selectedIndex = 0;
        }

        private void LoadHandledSections()
        {
            //LOAD SECTION LIST
            string localvariablestring = "SELECT * FROM [Tbl.AssignedSections] WHERE [TEACHER ID] = '" + TeacherID + "'";
            sqlcommand = new SqlCommand(localvariablestring, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            SectionDropdown.Clear();
            while (sqldatareader.Read())
            {
                int index = 2;
                for (int iterator = 0; iterator < 10; iterator++)
                {
                    SectionDropdown.AddItem(sqldatareader.GetString(index));
                    index++;
                }
            }
            sqldatareader.Close();
            SectionDropdown.selectedIndex = 0;

            try
            {
                RemoveSpaceInSections();
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }

        private void RemoveSpaceInSections()
        {
            int index = 2;
            for (int iterator = 0; iterator < 10; iterator++)
            {
                SectionDropdown.RemoveItem("");
                index++;
            }
        }

        //RELOAD
        private void RefreshPicture_Click(object sender, EventArgs e)
        {
            LoadSchoolYearList();
            LoadHandledSections();
        }
        
        //SORT
        private void GradingDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                Hide_Not_Related_Subject_Columns();
                getcurrentschoolyear = new GetCurrentSchoolYear();
                CurrentSchoolYear = getcurrentschoolyear.GetCurrentSchoolYearData();

                string TempString = "SELECT VALUE FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG100'";
                sqlcommand = new SqlCommand(TempString, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();
                
                while (sqldatareader.Read())
                {
                    returnstring = sqldatareader.GetString(0);
                }
                sqldatareader.Close();

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 0)
                {
                    if (returnstring.Equals("1FG") && SchoolYearDropdown.selectedValue.ToString().Equals(CurrentSchoolYear)) {
                        Enable_GridView_For_Uploading();
                        StudentLoadGridView.ReadOnly = false;

                        Call_Method_Stored_Procedure = "INSERT_INTO_1ST_GRADING_TABLE";
                    }

                    if (returnstring.Equals("2SG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("3TG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("4FG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("0")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 1)
                {
                    if (returnstring.Equals("1FG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("2SG") && SchoolYearDropdown.selectedValue.ToString().Equals(CurrentSchoolYear)) {
                        Enable_GridView_For_Uploading();
                        StudentLoadGridView.ReadOnly = false;

                        Call_Method_Stored_Procedure = "INSERT_INTO_2ND_GRADING_TABLE";
                    }

                    if (returnstring.Equals("3TG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("4FG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("0")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 2)
                {
                    if (returnstring.Equals("1FG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("2SG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("3TG") && SchoolYearDropdown.selectedValue.ToString().Equals(CurrentSchoolYear)) {
                        Enable_GridView_For_Uploading();
                        StudentLoadGridView.ReadOnly = false;

                        Call_Method_Stored_Procedure = "INSERT_INTO_3RD_GRADING_TABLE";
                    }

                    if (returnstring.Equals("4FG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("0")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 3)
                {
                    if (returnstring.Equals("1FG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("2SG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("3TG")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    if (returnstring.Equals("4FG") && SchoolYearDropdown.selectedValue.ToString().Equals(CurrentSchoolYear)) {
                        Enable_GridView_For_Uploading();
                        StudentLoadGridView.ReadOnly = false;

                        Call_Method_Stored_Procedure = "INSERT_INTO_4RTH_GRADING_TABLE";
                    }

                    if (returnstring.Equals("0")) {
                        StudentLoadGridView.ReadOnly = true;
                    }

                    string centerquery = "SELECT * FROM [Tbl.FourthGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }
            }

            catch (Exception) {
                //DO NOTHING SHIT !
            }
        }

        //SORT
        private void SectionDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                Hide_Not_Related_Subject_Columns();

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 1)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 2)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 3)
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

            catch (Exception) {
                //DO NOTHING SHIT !
            }
        }

        //SORT
        private void SchoolYearDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                Hide_Not_Related_Subject_Columns();

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 0)
                {
                    string centerquery = "SELECT * FROM [Tbl.FirstGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 1)
                {
                    string centerquery = "SELECT * FROM [Tbl.SecondGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 2)
                {
                    string centerquery = "SELECT * FROM [Tbl.ThirdGradingStudentLoad] WHERE SECTION = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";
                    sqldataadapter = new SqlDataAdapter(centerquery, sqlconnection);
                    UniversalTable = new DataTable();

                    sqldataadapter.Fill(UniversalTable);
                    StudentLoadGridView.AutoGenerateColumns = false;
                    StudentLoadGridView.DataSource = UniversalTable;
                }

                //SORT BY BOTH SECTION AND SCHOOL YEAR
                if (GradingDropdown.selectedIndex == 3)
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

            catch (Exception) {
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

        //STUDENT
        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:
            if (StudentLoadGridView.Visible == false)
            {
                StudentLoadGridView.Visible = true;
                bunifuCards2.Select();
            }

            else if (StudentLoadGridView.Visible == true)
            {
                StudentLoadGridView.Visible = false;
            }
        }

        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string VerifyQuery1 = "SELECT [PMS-01] FROM [Tbl.Permissions] WHERE [USER ID] = '" + UserID + "'";
                sqlcommand = new SqlCommand(VerifyQuery1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    StringHandler = sqldatareader.GetString(0);
                }
                sqldatareader.Close();

                if (StringHandler.Equals("ALLOW"))
                {
                    opacityform = new OpacityForm();
                    importform = new ImportStudentDataForm();

                    opacityform.Show();
                    importform.ShowDialog();

                    opacityform.Hide();
                }

                else if (StringHandler.Equals("DENY"))
                {
                    darkeropacityform = new DarkerOpacityForm();
                    notificationwindow = new NotificationWindow();

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                    notificationwindow.MessageText = "OPPS, YOU DON'T HAVE THE\nPERMISSION TO MAKE THIS JOB !";

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
        
        //REGISTRATION
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string VerifyQuery2 = "SELECT [PMS-02] FROM [Tbl.Permissions] WHERE [USER ID] = '" + UserID + "'";
                sqlcommand = new SqlCommand(VerifyQuery2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    StringHandler = sqldatareader.GetString(0);
                }
                sqldatareader.Close();

                if (StringHandler.Equals("ALLOW"))
                {
                    opacityform = new OpacityForm();
                    addstudentform = new AddStudentForm();

                    opacityform.Show();
                    addstudentform.ShowDialog();

                    opacityform.Hide();
                }

                else if (StringHandler.Equals("DENY"))
                {
                    darkeropacityform = new DarkerOpacityForm();
                    notificationwindow = new NotificationWindow();

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                    notificationwindow.MessageText = "OPPS, YOU DON'T HAVE THE\nPERMISSION TO MAKE THIS JOB !";

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

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string VerifyQuery3 = "SELECT [PMS-03] FROM [Tbl.Permissions] WHERE [USER ID] = '" + UserID + "'";
                sqlcommand = new SqlCommand(VerifyQuery3, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    StringHandler = sqldatareader.GetString(0);
                }
                sqldatareader.Close();

                if (StringHandler.Equals("ALLOW"))
                {
                    opacityform = new OpacityForm();
                    disablestudentform = new DisableStudentForm();

                    opacityform.Show();
                    disablestudentform.ShowDialog();

                    opacityform.Hide();
                }

                else if (StringHandler.Equals("DENY"))
                {
                    darkeropacityform = new DarkerOpacityForm();
                    notificationwindow = new NotificationWindow();

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                    notificationwindow.MessageText = "OPPS, YOU DON'T HAVE THE\nPERMISSION TO MAKE THIS JOB !";

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

        //REPORTS
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            studentreport = new StudentReportForm();

            opacityform.Show();
            studentreport.ShowDialog();

            opacityform.Hide();
        }

        private void gradeReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            gradereport = new GradeReportForm();

            opacityform.Show();
            gradereport.ShowDialog();

            opacityform.Hide();
        }

        private void enrollmentReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            enrollmentreport = new EnrollmentReportForm();

            opacityform.Show();
            enrollmentreport.ShowDialog();

            opacityform.Hide();
        }

        //TRANSACTIONS
        private void listOfStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            listofSysObjects = new ListOfSystemObjectsForm();
            listofSysObjects.TabControl.SelectedIndex = 0;
            listofSysObjects.TabControl.TabPages.RemoveAt(1);
            listofSysObjects.TabControl.TabPages.RemoveAt(1);

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

        private void bukidnonStateUniversityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            aboutuniversity = new AboutUniversity();

            opacityform.Show();
            aboutuniversity.ShowDialog();

            opacityform.Hide();
        }

        private void secondarySchoolLaboratoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            aboutuniversityhs = new AboutUniversityHS();

            opacityform.Show();
            aboutuniversityhs.ShowDialog();

            opacityform.Hide();
        }

        private void studentRegistrationAndGradingSystemToolStripMenuItem_Click(object sender, EventArgs e)
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
            MaximizeTopButton.BackColor = Color.FromArgb(39, 44, 51);
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
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            string TemporaryString = string.Format("{0:dddd}", DateTime.Now).ToUpper();
            if (TemporaryString.Equals("MONDAY")) {
                MessageLabel.Text = "HOW ARE YOU ?, IT'S " + string.Format("{0:dddd}", DateTime.Now).ToUpper();
            }

            else if (TemporaryString.Equals("TUESDAY")) {
                MessageLabel.Text = "GOOD DAY !, IT'S " + string.Format("{0:dddd}", DateTime.Now).ToUpper();
            }

            else if (TemporaryString.Equals("WEDNESDAY")) {
                MessageLabel.Text = "ALRIGHT !, IT'S " + string.Format("{0:dddd}", DateTime.Now).ToUpper();
            }

            else if (TemporaryString.Equals("THURSDAY")) {
                MessageLabel.Text = "HELLO, IT'S " + string.Format("{0:dddd}", DateTime.Now).ToUpper();
            }

            else if (TemporaryString.Equals("FRIDAY")) {
                MessageLabel.Text = "THANK GOD !, IT'S " + string.Format("{0:dddd}", DateTime.Now).ToUpper();
            }

            else if (TemporaryString.Equals("SATURDAY")) {
                MessageLabel.Text = "GREAT !, IT'S " + string.Format("{0:dddd}", DateTime.Now).ToUpper();
            }

            else if (TemporaryString.Equals("SUNDAY")) {
                MessageLabel.Text = "HEY, IT'S " + string.Format("{0:dddd}", DateTime.Now).ToUpper();
            }

            Time_And_Date_Label.Text = string.Format("{0:MMMM dd, yyyy '-' hh:mm tt}", DateTime.Now).ToUpper();
        }

        private void studentAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            studentaverageform_teacher = new StudentAverageForm_Teacher();

            opacityform.Show();
            studentaverageform_teacher.ShowDialog();

            opacityform.Hide();
        }

        private void viewStudentAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void securityCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            changesecuritycodeform = new ChangeSecurityCodeForm();

            opacityform.Show();
            changesecuritycodeform.ShowDialog();

            opacityform.Hide();
        }

        private void showFeedbackFormOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
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
                    showFeedbackFormOnStartupToolStripMenuItem.Image = Properties.Resources.wch;

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
                    showFeedbackFormOnStartupToolStripMenuItem.Image = Properties.Resources.wex;

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

        private void showSecurityFormOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
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
                    showSecurityFormOnStartupToolStripMenuItem.Image = Properties.Resources.wch;

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
                    showSecurityFormOnStartupToolStripMenuItem.Image = Properties.Resources.wex;

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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshPicture_Click(sender, e);
        }
        
        private void MenuStrip_MouseHover(object sender, EventArgs e)
        {
            Show_Form_Endicators();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
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
        
        private void TeacherWorkspace_FormClosing(object sender, FormClosingEventArgs e)
        {
            opacityform = new OpacityForm();

            //EXCEPTION 2
            try
            {
                opacityform.Show();

                var UserWantsToExit = MessageBox.Show("ARE YOU SURE TO CLOSE THIS WINDOW ?\nPRESS NO TO CANCEL.",
                    "PLEASE CONFIRM.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
