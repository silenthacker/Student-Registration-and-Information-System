using System;
using System.Data;
using System.Drawing;
using Microsoft.Win32;

using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Application
{
    public partial class StudentSettingsForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;

        SQLConnectionConfig sqlconnectionconfig;
        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;

        SqlConnection sqlconnection;
        SqlCommand sqlcommand;
        SqlDataAdapter sqldataadapter;

        private string CurrentSchoolYear, StudentID, GradeLevel, OldEnrolledCount,
            INDICATOR, MaxStudents, EnrolledCount, FullName, Gender, Lrn;

        public StudentSettingsForm()
        {
            InitializeComponent();
        }
        
        private void StudentSettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                variables = new Variables();
                opacityform = new OpacityForm();
                cryptography = new Cryptography();

                sqlconnectionconfig = new SQLConnectionConfig();
                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string tempdata = registrykey.GetValue("SQLServerConnectionString").ToString();
                StudentID = registrykey.GetValue("Student ID").ToString();

                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                try
                {
                    GetCurrentSchoolYear();
                    Populate_Section_Gridview();

                    Get_Old_Student_Data(); Fill_New_SectionDropdown(); Determine_Student_GradeLevel_And_Set_For_Identifier();
                    ListofSections_GroupBox.Text = "LIST OF SECTIONS FOR THE SCHOOL YEAR: " + CurrentSchoolYear;
                    Enable_Disable_Update_Button();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Student Settings Form Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Student Settings Form Exception 1",
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

        private void Get_Old_Student_Data()
        {
            try
            {
                string sqlquery1 = "SELECT [GRADE LEVEL], [SECTION] FROM [Tbl.Students] WHERE [STUDENT ID] = '" + StudentID + "'";
                sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    OldGradeLevelDropdown.AddItem(sqldatareader.GetString(0));
                    GradeLevel = sqldatareader.GetString(0);
                    OldSectionDropdown.AddItem(sqldatareader.GetString(1));
                }

                OldGradeLevelDropdown.selectedIndex = 0;
                OldSectionDropdown.selectedIndex = 0;
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //NOTHING'S HERE DUDE !
            }
        }

        private void Fill_New_SectionDropdown()
        {
            try
            {
                string sqlquery1 = "SELECT TOP 10 [SECTION NAME] FROM [Tbl.Sections] WHERE [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";
                sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    NewSectionDropdown.AddItem(sqldatareader.GetString(0));
                }

                NewSectionDropdown.selectedIndex = 0;
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //NOTHING'S HERE DUDE !
            }
        }

        private void Determine_Student_GradeLevel_And_Set_For_Identifier()
        {
            try
            {
                if (GradeLevel.Equals("Grade 7"))
                {
                    NewGradeLevelDropdown.AddItem("Grade 8");
                    NewGradeLevelDropdown.AddItem("Grade 9");
                    NewGradeLevelDropdown.AddItem("Grade 10");
                }

                else if (GradeLevel.Equals("Grade 8"))
                {
                    NewGradeLevelDropdown.AddItem("Grade 9");
                    NewGradeLevelDropdown.AddItem("Grade 10");
                }

                else if (GradeLevel.Equals("Grade 9"))
                {
                    NewGradeLevelDropdown.AddItem("Grade 10");
                }

                else if (GradeLevel.Equals("Grade 10"))
                {
                    NewSectionDropdown.Enabled = false;
                    NewGradeLevelDropdown.Enabled = false;
                }

                NewGradeLevelDropdown.selectedIndex = 0;
            }

            catch (Exception)
            {
                //NOTHING'S HERE DUDE !
            }
        }

        private void Enable_Disable_Update_Button()
        {
            try
            {
                //SEG101
                if (GradeLevel.Equals("Grade 7"))
                {
                    string sqlquery1 = "SELECT VALUE FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG101'";
                    sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                    SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                    while (sqldatareader.Read())
                    {
                        INDICATOR = sqldatareader.GetString(0);
                        if (INDICATOR.Equals("1"))
                        {
                            UpdateButton.Enabled = true;
                            UpdateButton.Cursor = Cursors.Default;
                        }

                        else
                        {
                            UpdateButton.Enabled = false;
                            UpdateButton.Cursor = Cursors.No;
                        }
                    }
                    sqldatareader.Close();
                }

                //SEG102
                else if (GradeLevel.Equals("Grade 8"))
                {
                    string sqlquery1 = "SELECT VALUE FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG102'";
                    sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                    SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                    while (sqldatareader.Read())
                    {
                        INDICATOR = sqldatareader.GetString(0);
                        if (INDICATOR.Equals("1"))
                        {
                            UpdateButton.Enabled = true;
                            UpdateButton.Cursor = Cursors.Default;
                        }

                        else
                        {
                            UpdateButton.Enabled = false;
                            UpdateButton.Cursor = Cursors.No;
                        }
                    }
                    sqldatareader.Close();
                }

                //SEG103
                else if (GradeLevel.Equals("Grade 9"))
                {
                    string sqlquery1 = "SELECT VALUE FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG103'";
                    sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                    SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                    while (sqldatareader.Read())
                    {
                        INDICATOR = sqldatareader.GetString(0);
                        if (INDICATOR.Equals("1"))
                        {
                            UpdateButton.Enabled = true;
                            UpdateButton.Cursor = Cursors.Default;
                        }

                        else
                        {
                            UpdateButton.Enabled = false;
                            UpdateButton.Cursor = Cursors.No;
                        }
                    }
                    sqldatareader.Close();
                }

                //SEG104
                else if (GradeLevel.Equals("Grade 10"))
                {
                    string sqlquery1 = "SELECT VALUE FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG104'";
                    sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                    SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                    while (sqldatareader.Read())
                    {
                        INDICATOR = sqldatareader.GetString(0);
                        if (INDICATOR.Equals("1"))
                        {
                            UpdateButton.Enabled = true;
                            UpdateButton.Cursor = Cursors.Default;
                        }

                        else
                        {
                            UpdateButton.Enabled = false;
                            UpdateButton.Cursor = Cursors.No;
                        }
                    }
                    sqldatareader.Close();
                }
            }

            catch (Exception)
            {
                //NOTHING'S HERE DUDE !
            }
        }

        private void Populate_Section_Gridview()
        {
            try
            {
                string sqlquery1 = "SELECT TOP 10 [SECTION ID], [SECTION NAME], [MAXIMUM STUDENTS]," +
                    " [ENROLLED], [SCHOOL YEAR] FROM [Tbl.Sections] WHERE [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
                DataTable datatable = new DataTable();

                sqldataadapter.Fill(datatable);
                ListofSectionsGridview.AutoGenerateColumns = false;
                ListofSectionsGridview.DataSource = datatable;
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        private void Set_Refers()
        {
            try
            {
                string RetrieveQuery1 = "SELECT [STUDENT NAME], [GENDER] FROM [Tbl.FirstGradingStudentLoad] WHERE [STUDENT ID] = '" + StudentID + "'";
                sqlcommand = new SqlCommand(RetrieveQuery1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    FullName = sqldatareader.GetString(0);
                    Gender = sqldatareader.GetString(1);
                }
                sqldatareader.Close();

                string RetrieveQuery2 = "SELECT [LRN] FROM [Tbl.Students] WHERE [STUDENT ID] = '" + StudentID + "'";
                sqlcommand = new SqlCommand(RetrieveQuery2, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    Lrn = sqldatareader2.GetString(0);
                }
                sqldatareader2.Close();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        private void BullShit()
        {
            try
            {
                string VerifyQuery = "SELECT [ENROLLED] FROM [Tbl.Sections] WHERE [SECTION NAME] = '" +
                    OldSectionDropdown.selectedValue.ToString() + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                sqlcommand = new SqlCommand(VerifyQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    OldEnrolledCount = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //THERES NOTHING HERE DUDE !
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                string VerifyQuery = "SELECT [MAXIMUM STUDENTS], [ENROLLED] FROM [Tbl.Sections] WHERE [SECTION NAME] = '" +
                    NewSectionDropdown.selectedValue.ToString() + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";
                sqlcommand = new SqlCommand(VerifyQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    MaxStudents = sqldatareader.GetString(0);
                    EnrolledCount = sqldatareader.GetString(1);
                }
                sqldatareader.Close();

                if (EnrolledCount.Equals(MaxStudents) || MaxStudents.Equals(EnrolledCount))
                {
                    notificationwindow.CaptionText = "UPDATE FAILED !";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = NewSectionDropdown.selectedValue.ToString().ToUpper() + " IS ALREADY FULL !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (!EnrolledCount.Equals(MaxStudents) || !MaxStudents.Equals(EnrolledCount))
                {
                    string VerifyQuery2 = "SELECT COUNT(*) FROM [Tbl.FirstGradingStudentLoad] WHERE [STUDENT ID] = '" +
                        StudentID + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(VerifyQuery2, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);
                    
                    //INSERT
                    if (datatable.Rows[0][0].ToString() == "0")
                    {
                        Set_Refers();

                        //UPDATE [Tbl.Students]
                        string UpdateQuery1 = "UPDATE [Tbl.Students] SET [GRADE LEVEL] = @glevel, [SECTION] = @section" +
                            " WHERE [STUDENT ID] = '" + StudentID + "'";

                        sqlcommand = new SqlCommand(UpdateQuery1, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@glevel", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section", NewSectionDropdown.selectedValue.ToString());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.Sections] --> Iterate Enrolled Count
                        string UpdateQuery2 = "UPDATE [Tbl.Sections] SET [ENROLLED] = @enrolled" +
                            " WHERE [SECTION NAME] = @sname AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                        sqlcommand = new SqlCommand(UpdateQuery2, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@enrolled", (long.Parse(EnrolledCount) + 1).ToString());
                        sqlcommand.Parameters.AddWithValue("@sname", NewSectionDropdown.selectedValue.ToString());
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO STUDENT LOAD TABLE --> 1st Grading
                        string query6 = "INSERT INTO [Tbl.FirstGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                            "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid1g, @studentname1g," +
                            "@gender1g, @gradelevel1g, @section1g, @sb11g, @sb21g, @sb31g, @sb41g, @sb51g, @sb61g, @sb71g, @sb81g, @schoolyear1g)";
                        sqlcommand = new SqlCommand(query6, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@studentid1g", StudentID);
                        sqlcommand.Parameters.AddWithValue("@studentname1g", FullName);
                        sqlcommand.Parameters.AddWithValue("@gender1g", Gender);
                        sqlcommand.Parameters.AddWithValue("@gradelevel1g", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section1g", NewSectionDropdown.selectedValue.ToString());

                        sqlcommand.Parameters.AddWithValue("@sb11g", "");
                        sqlcommand.Parameters.AddWithValue("@sb21g", "");
                        sqlcommand.Parameters.AddWithValue("@sb31g", "");
                        sqlcommand.Parameters.AddWithValue("@sb41g", "");
                        sqlcommand.Parameters.AddWithValue("@sb51g", "");
                        sqlcommand.Parameters.AddWithValue("@sb61g", "");
                        sqlcommand.Parameters.AddWithValue("@sb71g", "");
                        sqlcommand.Parameters.AddWithValue("@sb81g", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear1g", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO STUDENT LOAD TABLE --> 2nd Grading
                        string query7 = "INSERT INTO [Tbl.SecondGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                            "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid2g, @studentname2g," +
                            "@gender2g, @gradelevel2g, @section2g, @sb12g, @sb22g, @sb32g, @sb42g, @sb52g, @sb62g, @sb72g, @sb82g, @schoolyear2g)";
                        sqlcommand = new SqlCommand(query7, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@studentid2g", StudentID);
                        sqlcommand.Parameters.AddWithValue("@studentname2g", FullName);
                        sqlcommand.Parameters.AddWithValue("@gender2g", Gender);
                        sqlcommand.Parameters.AddWithValue("@gradelevel2g", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section2g", NewSectionDropdown.selectedValue.ToString());

                        sqlcommand.Parameters.AddWithValue("@sb12g", "");
                        sqlcommand.Parameters.AddWithValue("@sb22g", "");
                        sqlcommand.Parameters.AddWithValue("@sb32g", "");
                        sqlcommand.Parameters.AddWithValue("@sb42g", "");
                        sqlcommand.Parameters.AddWithValue("@sb52g", "");
                        sqlcommand.Parameters.AddWithValue("@sb62g", "");
                        sqlcommand.Parameters.AddWithValue("@sb72g", "");
                        sqlcommand.Parameters.AddWithValue("@sb82g", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear2g", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO STUDENT LOAD TABLE --> 3rd Grading
                        string query8 = "INSERT INTO [Tbl.ThirdGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                            "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid3g, @studentname3g," +
                            "@gender3g, @gradelevel3g, @section3g, @sb13g, @sb23g, @sb33g, @sb43g, @sb53g, @sb63g, @sb73g, @sb83g, @schoolyear3g)";
                        sqlcommand = new SqlCommand(query8, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@studentid3g", StudentID);
                        sqlcommand.Parameters.AddWithValue("@studentname3g", FullName);
                        sqlcommand.Parameters.AddWithValue("@gender3g", Gender);
                        sqlcommand.Parameters.AddWithValue("@gradelevel3g", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section3g", NewSectionDropdown.selectedValue.ToString());

                        sqlcommand.Parameters.AddWithValue("@sb13g", "");
                        sqlcommand.Parameters.AddWithValue("@sb23g", "");
                        sqlcommand.Parameters.AddWithValue("@sb33g", "");
                        sqlcommand.Parameters.AddWithValue("@sb43g", "");
                        sqlcommand.Parameters.AddWithValue("@sb53g", "");
                        sqlcommand.Parameters.AddWithValue("@sb63g", "");
                        sqlcommand.Parameters.AddWithValue("@sb73g", "");
                        sqlcommand.Parameters.AddWithValue("@sb83g", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear3g", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO STUDENT LOAD TABLE --> 4rth Grading
                        string query9 = "INSERT INTO [Tbl.FourthGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                            "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid4g, @studentname4g," +
                            "@gender4g, @gradelevel4g, @section4g, @sb14g, @sb24g, @sb34g, @sb44g, @sb54g, @sb64g, @sb74g, @sb84g, @schoolyear4g)";
                        sqlcommand = new SqlCommand(query9, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@studentid4g", StudentID);
                        sqlcommand.Parameters.AddWithValue("@studentname4g", FullName);
                        sqlcommand.Parameters.AddWithValue("@gender4g", Gender);
                        sqlcommand.Parameters.AddWithValue("@gradelevel4g", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section4g", NewSectionDropdown.selectedValue.ToString());

                        sqlcommand.Parameters.AddWithValue("@sb14g", "");
                        sqlcommand.Parameters.AddWithValue("@sb24g", "");
                        sqlcommand.Parameters.AddWithValue("@sb34g", "");
                        sqlcommand.Parameters.AddWithValue("@sb44g", "");
                        sqlcommand.Parameters.AddWithValue("@sb54g", "");
                        sqlcommand.Parameters.AddWithValue("@sb64g", "");
                        sqlcommand.Parameters.AddWithValue("@sb74g", "");
                        sqlcommand.Parameters.AddWithValue("@sb84g", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear4g", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO [Tbl.StudentAverages]
                        string query10 = "INSERT INTO [Tbl.StudentAverages]([STUDENT ID], [STUDENT NAME], LRN, [GRADE LEVEL], SECTION, " +
                            "[FIRST GRADING], [SECOND GRADING], [THIRD GRADING], [FOURTH GRADING], GPA, [SCHOOL YEAR]) " +
                            "VALUES(@sid, @studname, @lrn, @glevel, @section, @fga, @sga, @tga, @ffga, @gpa, @schoolyear)";
                        sqlcommand = new SqlCommand(query10, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@sid", StudentID);
                        sqlcommand.Parameters.AddWithValue("@studname", FullName);
                        sqlcommand.Parameters.AddWithValue("@lrn", Lrn);
                        sqlcommand.Parameters.AddWithValue("@glevel", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section", NewSectionDropdown.selectedValue.ToString());

                        sqlcommand.Parameters.AddWithValue("@fga", "");
                        sqlcommand.Parameters.AddWithValue("@sga", "");
                        sqlcommand.Parameters.AddWithValue("@tga", "");
                        sqlcommand.Parameters.AddWithValue("@ffga", "");
                        sqlcommand.Parameters.AddWithValue("@gpa", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        notificationwindow.CaptionText = "UPDATE SUCCESS !";
                        notificationwindow.MsgImage.Image = Properties.Resources.check;
                        notificationwindow.MessageText = "YOUR NEW GRADE LEVEL AND SECTION:\n" +
                            NewGradeLevelDropdown.selectedValue.ToString().ToUpper() + " - " + NewSectionDropdown.selectedValue.ToString().ToUpper();

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        sqlconnection.Close();
                        DialogResult = DialogResult.OK;
                    }

                    //UPDATE
                    else if (datatable.Rows[0][0].ToString() == "1")
                    {
                        BullShit();

                        //UPDATE [Tbl.Students]
                        string AlterQuery1 = "UPDATE [Tbl.Students] SET [GRADE LEVEL] = @glevel, [SECTION] = @section" +
                            " WHERE [STUDENT ID] = '" + StudentID + "'";

                        sqlcommand = new SqlCommand(AlterQuery1, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@glevel", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section", NewSectionDropdown.selectedValue.ToString());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.Section] --> DECRIMENT OLD SECTION
                        string AlterQuery2 = "UPDATE [Tbl.Sections] SET [ENROLLED] = @enrolled WHERE [SECTION NAME] = '" +
                            OldSectionDropdown.selectedValue.ToString() + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                        sqlcommand = new SqlCommand(AlterQuery2, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@enrolled", (long.Parse(OldEnrolledCount) - 1).ToString());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.Section] --> INCRIMENT NEW SECTION
                        string AlterQuery3 = "UPDATE [Tbl.Sections] SET [ENROLLED] = @enrolled WHERE [SECTION NAME] = '" +
                            NewSectionDropdown.selectedValue.ToString() + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                        sqlcommand = new SqlCommand(AlterQuery3, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@enrolled", (long.Parse(EnrolledCount) + 1).ToString());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.FirstGradingStudentLoad]
                        string AlterQuery4 = "UPDATE [Tbl.FirstGradingStudentLoad] SET [GRADE LEVEL] = @glevel, [SECTION] = @section" +
                            " WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                        sqlcommand = new SqlCommand(AlterQuery4, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@glevel", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section", NewSectionDropdown.selectedValue.ToString());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.SecondGradingStudentLoad]
                        string AlterQuery5 = "UPDATE [Tbl.SecondGradingStudentLoad] SET [GRADE LEVEL] = @glevel, [SECTION] = @section" +
                            " WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                        sqlcommand = new SqlCommand(AlterQuery5, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@glevel", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section", NewSectionDropdown.selectedValue.ToString());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.ThirdGradingStudentLoad]
                        string AlterQuery6 = "UPDATE [Tbl.ThirdGradingStudentLoad] SET [GRADE LEVEL] = @glevel, [SECTION] = @section" +
                            " WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                        sqlcommand = new SqlCommand(AlterQuery6, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@glevel", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section", NewSectionDropdown.selectedValue.ToString());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.FourthGradingStudentLoad]
                        string AlterQuery7 = "UPDATE [Tbl.FourthGradingStudentLoad] SET [GRADE LEVEL] = @glevel, [SECTION] = @section" +
                            " WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                        sqlcommand = new SqlCommand(AlterQuery7, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@glevel", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section", NewSectionDropdown.selectedValue.ToString());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.StudentAverages]
                        string AlterQuery8 = "UPDATE [Tbl.StudentAverages] SET [GRADE LEVEL] = @glevel, [SECTION] = @section" +
                            " WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                        sqlcommand = new SqlCommand(AlterQuery8, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@glevel", NewGradeLevelDropdown.selectedValue.ToString());
                        sqlcommand.Parameters.AddWithValue("@section", NewSectionDropdown.selectedValue.ToString());
                        sqlcommand.ExecuteNonQuery();

                        notificationwindow.CaptionText = "UPDATE SUCCESS !";
                        notificationwindow.MsgImage.Image = Properties.Resources.check;
                        notificationwindow.MessageText = "YOUR NEW GRADE LEVEL AND SECTION:\n" +
                            NewGradeLevelDropdown.selectedValue.ToString().ToUpper() + " - " + NewSectionDropdown.selectedValue.ToString().ToUpper();

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        sqlconnection.Close();
                        DialogResult = DialogResult.OK;
                    }
                }
            }

            catch (Exception)
            {
                throw;
                //DON'T DO ANYTHING BITCH !
            }
        }

        private void SectionDropdown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }
    }
}
