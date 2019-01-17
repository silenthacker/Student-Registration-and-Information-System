using System;
using System.IO;
using System.Data;
using System.Drawing;

using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Diagnostics.CodeAnalysis;
using System.Deployment.Application;
namespace Application
{
    public partial class StudentAverageForm_Student : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;

        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;

        DataTable datatable;
        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;
        
        private string studentid, userid, CurrentSchoolYear;
        
        public string StudentID
        {
            get
            {
                return studentid;
            }

            set
            {
                studentid = value;
            }
        }

        public string UserID
        {
            get
            {
                return userid;
            }

            set
            {
                userid = value;
            }
        }

        public StudentAverageForm_Student()
        {
            InitializeComponent();
        }

        private void StudentAverageForm_RON_Load(object sender, EventArgs e)
        {
            //EXCEPTION 1
            try
            {
                variables = new Variables();
                opacityform = new OpacityForm();
                cryptography = new Cryptography();
                sqlconnectionconfig = new SQLConnectionConfig();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string tempdata = registrykey.GetValue("SQLServerConnectionString").ToString();

                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                //INNER EXCEPTION 1
                try
                {
                    GetCurrentSchoolYear();
                    GetSchoolYearList();

                    Retrieve_Account_Picture();
                    Retrieve_StudentName_StudentID();
                    Retrive_StudentLRN_Section_GradeLevel();

                    Populate_DataGridView();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Student Average Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Student Average Form Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
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

        private void GetSchoolYearList()
        {
            try
            {
                string RetrieveQuery = "SELECT [SCHOOL YEAR] FROM [Tbl.SchoolYear]";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    SchoolYearDropdown.AddItem(sqldatareader.GetString(0));
                }
                sqldatareader.Close();
                SchoolYearDropdown.selectedIndex = 0;
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }

        private void Retrieve_Account_Picture()
        {
            try
            {
                string RetrieveQuery = "SELECT [FILE NAME], [PICTURE] FROM [Tbl.Photos] WHERE [USER ID] = '" + UserID + "'";
                sqldataadapter = new SqlDataAdapter(RetrieveQuery, sqlconnection);
                DataTable ImageTable = new DataTable();
                sqldataadapter.Fill(ImageTable);

                ImageGridView.AutoGenerateColumns = false;
                ImageGridView.DataSource = ImageTable;

                foreach (DataRow row in ImageTable.Rows)
                {
                    byte[] ImageArray = (byte[])row[1];
                    StudentPicture.Image = Image.FromStream(new MemoryStream(ImageArray));
                }
            }

            catch (Exception)
            {
                //DON'T DISPLAY ANYTHING SHIT !
            }
        }

        private void Retrieve_StudentName_StudentID()
        {
            try
            {
                string RetrieveQuery = "SELECT [STUDENT ID], [STUDENT NAME] FROM [Tbl.FirstGradingStudentLoad] WHERE [STUDENT ID] = '" + StudentID + "'";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    StudentIDButton.Text = "STUDENT ID: " + sqldatareader.GetString(0).ToUpper();
                    StudentNameTextbox.Text = sqldatareader.GetString(1).ToUpper();
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DON'T DISPLAY ANYTHING SHIT !
            }
        }

        private void Retrive_StudentLRN_Section_GradeLevel()
        {
            try
            {
                string RetrieveQuery = "SELECT [LRN], [GRADE LEVEL], [SECTION] FROM [Tbl.Students] WHERE [STUDENT ID] = '" + StudentID + "'";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();
                
                while (sqldatareader.Read())
                {
                    LRNTextbox.Text = sqldatareader.GetString(0);
                    GradeLevelDropdown.AddItem(sqldatareader.GetString(1).ToUpper());
                    SectionDropdown.AddItem(sqldatareader.GetString(2).ToUpper());
                }
                sqldatareader.Close();

                GradeLevelDropdown.selectedIndex = 0;
                SectionDropdown.selectedIndex = 0;
            }

            catch (Exception)
            {
                //DON'T DISPLAY ANYTHING SHIT !
            }
        }

        private void SchoolYearDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                string RetrieveQuery = "SELECT * FROM [Tbl.StudentAverages] WHERE [STUDENT ID] = '" +
                    StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

                SqlDataAdapter sqldataadapter = new SqlDataAdapter(RetrieveQuery, sqlconnection);
                datatable = new DataTable();
                sqldataadapter.Fill(datatable);

                StudentAverageGridview.DataSource = datatable;
                StudentAverageGridview.AutoGenerateColumns = false;
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
                notificationwindow.CaptionText = "STUDENT REGISTRATION & INFORMATION SYSTEM";
                notificationwindow.MsgImage.Image = Properties.Resources.error;
                notificationwindow.MessageText = "NO RECORDS FOUND !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }
        }

        private void Populate_DataGridView()
        {
            try
            {
                string RetrieveQuery = "SELECT * FROM [Tbl.StudentAverages] WHERE [STUDENT ID] = '" +
                    StudentID + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";
                SqlDataAdapter sqldataadapter = new SqlDataAdapter(RetrieveQuery, sqlconnection);
                datatable = new DataTable();
                sqldataadapter.Fill(datatable);
                
                StudentAverageGridview.DataSource = datatable;
                StudentAverageGridview.AutoGenerateColumns = false;
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }
        
        private void StudentAverageForm_RON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }
    }
}
