using System;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class AddStudentForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;

        ResetControlState Reseter;
        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;

        int NewStudentID, NewUserID;
        private string CurrentSchoolYear;
        string str1, str2, str3, str4;
        string sqlquery1, sqlquery2, sqlquery3, sqlquery5;
        

        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2 , (Y_Coordinate / 2) + 25);

            SubmitButton.Select();
            BirthdayPicker.Value = DateTime.Now;

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

                DataTable datatable = new DataTable();
                sqlconnection.Open();

                //INNER EXCEPTION 1
                try
                {
                    //INIT STUDENT ID
                    AssignNewStudentID();

                    //INIT NEW USER ID
                    AssignNewUserID();
                    
                    //GET CURRENT SCHOOL YEAR
                    GetCurrentSchoolYear();

                    //INIT SECTION DROPDOWN
                    RetrieveSectionList();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.StackTrace.ToString(), "@Add Student Form Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.StackTrace.ToString(), "@Add Student Form Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        private void AssignNewStudentID()
        {
            sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Students]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST STUDENT ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                sqlquery2 = "SELECT [STUDENT ID] FROM [Tbl.Students]";
                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    str1 = sqldatareader.GetString(0);

                    NewStudentID = int.Parse(str1) + 1;
                    StudentIDTextbox.Text = NewStudentID.ToString();
                    UsernameTextbox.Text = NewStudentID.ToString();
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW STUDENT ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                sqlquery3 = "SELECT VALUE FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'STUDENT ID'";
                sqlcommand = new SqlCommand(sqlquery3, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    str2 = sqldatareader2.GetString(0);

                    NewStudentID = int.Parse(str2);
                    StudentIDTextbox.Text = NewStudentID.ToString();
                    UsernameTextbox.Text = NewStudentID.ToString();
                }
                sqldatareader2.Close();
            }
        }

        private void AssignNewUserID()
        {
            sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Users]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST USER ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                sqlquery2 = "SELECT [USER ID] FROM [Tbl.Users]";
                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    str3 = sqldatareader.GetString(0);

                    NewUserID = int.Parse(str3) + 1;
                    UserIDTextbox.Text = NewUserID.ToString();
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW USER ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                sqlquery3 = "SELECT VALUE FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'USER ID'";
                sqlcommand = new SqlCommand(sqlquery3, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    str4 = sqldatareader2.GetString(0);

                    NewUserID = int.Parse(str4);
                    UserIDTextbox.Text = NewUserID.ToString();
                }
                sqldatareader2.Close();
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

        private void RetrieveSectionList()
        {
            sqlquery5 = "SELECT TOP 10 [SECTION NAME] FROM [Tbl.Sections] WHERE [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";
            sqlcommand = new SqlCommand(sqlquery5, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                SectionDropdown.AddItem(sqldatareader.GetString(0));
            }
            sqldatareader.Close();
            SectionDropdown.selectedIndex = 0;
        }
        
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 2
            try
            {
                opacityform = new OpacityForm();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                if (LRNTextbox.Text.Trim().Length < 1 || FirstNameTextbox.Text.Trim().Length <1 || MiddleNameTextbox.Text.Trim().Length < 1 || 
                    LastNameTextbox.Text.Trim().Length < 1 || PresentAddressTextbox.Text.Trim().Length < 1 || PlaceOfBirthTextbox.Text.Trim().Length < 1 ||
                    BloodTypeTextbox.Text.Trim().Length < 1 || ReligionTextbox.Text.Trim().Length < 1 || EmailAddressTextbox.Text.Trim().Length < 1 || 
                    MobileNumberTextbox.Text.Trim().Length < 1 || SectionDropdown.selectedIndex == 0 || FathersNameTextbox.Text.Trim().Length < 1 ||
                    FathersOccupationTextbox.Text.Trim().Length < 1 || FathersContactNumberTextbox.Text.Trim().Length < 1 ||
                    FathersAddressTextbox.Text.Trim().Length < 1 || MothersNameTextbox.Text.Trim().Length < 1 || MothersOccupationTextbox.Text.Trim().Length < 1 ||
                    MothersContactNumberTextbox.Text.Trim().Length < 1 || MothersAddressTextbox.Text.Trim().Length < 1 || PasswordTextbox.Text.Trim().Length < 1 ||
                    ConfirmPasswordTextbox.Text.Trim().Length < 1)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE THE REQUIRED\nINFORMATIONS BEING ASK !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (!EmailAddressTextbox.Text.Trim().Contains("@") || !EmailAddressTextbox.Text.Trim().Contains(".com"))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE A VALID EMAIL ADDRESS !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
                
                else if (MobileNumberTextbox.Text.Trim().Length < 11 || MobileNumberTextbox.Text.Trim().Length > 11)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PHONE NUMBER MUST BE 11-DIGITS LONG !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (FathersContactNumberTextbox.Text.Trim().Length < 11 || FathersContactNumberTextbox.Text.Trim().Length > 11)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "YOUR FATHERS PHONE NUMBER MUST BE\n11-DIGITS LONG !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (MothersContactNumberTextbox.Text.Trim().Length < 11 || MothersContactNumberTextbox.Text.Trim().Length > 11)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "YOUR MOTHERS PHONE NUMBER MUST BE\n11-DIGITS LONG !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (isNumber(MobileNumberTextbox.Text.Trim()) == false)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PHONE NUMBER CONTAINS AN INVALID\nCHARACTER !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (isNumber(FathersContactNumberTextbox.Text.Trim()) == false)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "YOUR FATHERS PHONE NUMBER CONTAINS\nAN INVALID CHARACTER !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (isNumber(MothersContactNumberTextbox.Text.Trim()) == false)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "YOUR MOTHERS PHONE NUMBER CONTAINS\nAN INVALID CHARACTER !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (!PasswordTextbox.Text.Trim().Equals(ConfirmPasswordTextbox.Text.Trim()) ||
                    !ConfirmPasswordTextbox.Text.Trim().Equals(PasswordTextbox.Text.Trim()))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE CONFIRM YOUR PASSWORD !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (PasswordTextbox.Text.Trim().Length < 8 || ConfirmPasswordTextbox.Text.Trim().Length < 8)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "YOUR PASSWORD IS TOO SHORT, MAKE IT\n8-CHARACTERS OR ABOVE LONG !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else
                {
                    //INNER EXCEPTION 22
                    try
                    {
                        string query1, query2, query3, query4, query5, query6, query7, query8, query9, query10;
                        string OldMaxStudents, OldEnrolled; int NewEnrolledCount;

                        string FullName = LastNameTextbox.Text.Trim() + ", " + FirstNameTextbox.Text.Trim() + " " 
                            + MiddleNameTextbox.Text.Trim().Remove(1, MiddleNameTextbox.Text.Trim().Length - 1) + ".";

                        //CHECK IF THE SECTION IS FULL OR NOT
                        query1 = "SELECT [MAXIMUM STUDENTS], ENROLLED FROM [Tbl.Sections] WHERE [SECTION NAME] = '" + 
                            SectionDropdown.selectedValue.ToString() + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";
                        sqlcommand = new SqlCommand(query1, sqlconnection);
                        SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                        while (sqldatareader.Read())
                        {
                            OldMaxStudents = sqldatareader.GetString(0);
                            OldEnrolled = sqldatareader.GetString(1);
                            NewEnrolledCount = int.Parse(OldEnrolled) + 1;

                            if (!OldEnrolled.Equals(OldMaxStudents) || !OldMaxStudents.Equals(OldEnrolled)) {
                                sqldatareader.Close();

                                //VALIDATE STUDENT REGISTRATION
                                string VerifyQuery = "SELECT COUNT(*) FROM [Tbl.Students] WHERE [FIRST NAME] = '" +
                                    FirstNameTextbox.Text.Trim() + "' AND [MIDDLE NAME] = '" + MiddleNameTextbox.Text.Trim() +
                                    "' AND [LAST NAME] = '" + LastNameTextbox.Text.Trim() + "'";

                                sqldataadapter = new SqlDataAdapter(VerifyQuery, sqlconnection);
                                DataTable VirtualTable = new DataTable();
                                sqldataadapter.Fill(VirtualTable);
                                
                                if (VirtualTable.Rows[0][0].ToString() == "0")
                                {
                                    //INSERT INTO STUDENTS TABLE
                                    query2 = "INSERT INTO [Tbl.Students]([STUDENT ID], [USER ID], LRN, [FIRST NAME], [MIDDLE NAME], [LAST NAME], [GRADE LEVEL]," +
                                        "SECTION, GENDER, [BIRTH DATE], [PRESENT ADDRESS], [PLACE OF BIRTH], [BLOOD TYPE], RELIGION, [INDIGINOUS GROUP]," +
                                        "[EMAIL ADDRESS], [MOBILE NUMBER]) VALUES(@studentid, @userid, @lrn, @firstname, @middlename, @lastname, @gradelevel," +
                                        "@section, @gender, @birthdate, @presentaddress, @placeofbirth, @bloodtype, @religion, @indiginousgroup, @emailaddress," +
                                        "@mobilenumber)";
                                    sqlcommand = new SqlCommand(query2, sqlconnection);
                                    sqlcommand.Parameters.AddWithValue("@studentid", NewStudentID.ToString());
                                    sqlcommand.Parameters.AddWithValue("@userid", NewUserID.ToString());
                                    sqlcommand.Parameters.AddWithValue("@lrn", LRNTextbox.Text.Trim());

                                    sqlcommand.Parameters.AddWithValue("@firstname", FirstNameTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@middlename", MiddleNameTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@lastname", LastNameTextbox.Text.Trim());

                                    sqlcommand.Parameters.AddWithValue("@gradelevel", GradeLevelDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@section", SectionDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@gender", GenderDropdown.selectedValue.ToString());

                                    sqlcommand.Parameters.AddWithValue("@birthdate", BirthdayPicker.Value.ToLongDateString().ToString());
                                    sqlcommand.Parameters.AddWithValue("@presentaddress", PresentAddressTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@placeofbirth", PlaceOfBirthTextbox.Text.Trim());

                                    sqlcommand.Parameters.AddWithValue("@bloodtype", BloodTypeTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@religion", ReligionTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@indiginousgroup", IndiginousGroupTextbox.Text.Trim() == "" ? "None" :
                                        IndiginousGroupTextbox.Text.Trim());

                                    sqlcommand.Parameters.AddWithValue("@emailaddress", EmailAddressTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@mobilenumber", MobileNumberTextbox.Text.Trim());
                                    sqlcommand.ExecuteNonQuery();

                                    //INSERT INTO FAMILY BACKGROUND TABLE
                                    query3 = "INSERT INTO [Tbl.FamilyBackgrounds]([STUDENT ID], [FATHERS NAME], [FATHERS OCCUPATION], [FATHERS CONTACT NUMBER]," +
                                        "[FATHERS ADDRESS], [MOTHERS NAME], [MOTHERS OCCUPATION], [MOTHERS CONTACT NUMBER], [MOTHERS ADDRESS]) VALUES(@studentid," +
                                        "@fathersname, @fatheroccupation, @fathersnumber, @fathersaddress, @mothername, @motheroccupation, @mothernumber, @motheraddress)";
                                    sqlcommand = new SqlCommand(query3, sqlconnection);
                                    sqlcommand.Parameters.AddWithValue("@studentid", NewStudentID.ToString());

                                    sqlcommand.Parameters.AddWithValue("@fathersname", FathersNameTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@fatheroccupation", FathersOccupationTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@fathersnumber", FathersContactNumberTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@fathersaddress", FathersAddressTextbox.Text.Trim());

                                    sqlcommand.Parameters.AddWithValue("@mothername", MothersNameTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@motheroccupation", MothersOccupationTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@mothernumber", MothersContactNumberTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@motheraddress", MothersAddressTextbox.Text.Trim());
                                    sqlcommand.ExecuteNonQuery();

                                    //INSERT INTO USERS TABLE
                                    query4 = "INSERT INTO [Tbl.Users]([USER ID], USERNAME, PASSWORD, [ACCOUNT STATUS], [ACCOUNT TYPE], [LAST LOGIN]," +
                                        "[IS PWD CHANGED], [SITUATION STATUS]) VALUES(@userid, @username, @password, @accountstatus, @account_type, @last_login, @ispwdchanged, @stat)";
                                    sqlcommand = new SqlCommand(query4, sqlconnection);
                                    sqlcommand.Parameters.AddWithValue("@userid", NewUserID.ToString());
                                    sqlcommand.Parameters.AddWithValue("@username", cryptography.Encrypt(NewStudentID.ToString()));
                                    sqlcommand.Parameters.AddWithValue("@password", cryptography.Encrypt(PasswordTextbox.Text));
                                    sqlcommand.Parameters.AddWithValue("@accountstatus", "Active");

                                    sqlcommand.Parameters.AddWithValue("@account_type", "Student");
                                    sqlcommand.Parameters.AddWithValue("@last_login", "NO LOGIN HISTORY");
                                    sqlcommand.Parameters.AddWithValue("@ispwdchanged", "False");
                                    sqlcommand.Parameters.AddWithValue("@stat", "0");
                                    sqlcommand.ExecuteNonQuery();

                                    //UPDATE SECTIONS TABLE --> ENROLLED
                                    query5 = "UPDATE [Tbl.Sections] SET ENROLLED = @enrolled WHERE [SECTION NAME] = @section_nane" + 
                                        " AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                                    sqlcommand = new SqlCommand(query5, sqlconnection);
                                    sqlcommand.Parameters.AddWithValue("@enrolled", NewEnrolledCount.ToString());
                                    sqlcommand.Parameters.AddWithValue("@section_nane", SectionDropdown.selectedValue.ToString());
                                    sqlcommand.ExecuteNonQuery();

                                    //INSERT INTO STUDENT LOAD TABLE --> 1st Grading
                                    query6 = "INSERT INTO [Tbl.FirstGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                                        "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid1g, @studentname1g," +
                                        "@gender1g, @gradelevel1g, @section1g, @sb11g, @sb21g, @sb31g, @sb41g, @sb51g, @sb61g, @sb71g, @sb81g, @schoolyear1g)";
                                    sqlcommand = new SqlCommand(query6, sqlconnection);

                                    sqlcommand.Parameters.AddWithValue("@studentid1g", NewStudentID.ToString());
                                    sqlcommand.Parameters.AddWithValue("@studentname1g", FullName);
                                    sqlcommand.Parameters.AddWithValue("@gender1g", GenderDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@gradelevel1g", GradeLevelDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@section1g", SectionDropdown.selectedValue.ToString());

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
                                    query7 = "INSERT INTO [Tbl.SecondGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                                        "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid2g, @studentname2g," +
                                        "@gender2g, @gradelevel2g, @section2g, @sb12g, @sb22g, @sb32g, @sb42g, @sb52g, @sb62g, @sb72g, @sb82g, @schoolyear2g)";
                                    sqlcommand = new SqlCommand(query7, sqlconnection);

                                    sqlcommand.Parameters.AddWithValue("@studentid2g", NewStudentID.ToString());
                                    sqlcommand.Parameters.AddWithValue("@studentname2g", FullName);
                                    sqlcommand.Parameters.AddWithValue("@gender2g", GenderDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@gradelevel2g", GradeLevelDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@section2g", SectionDropdown.selectedValue.ToString());

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
                                    query8 = "INSERT INTO [Tbl.ThirdGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                                        "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid3g, @studentname3g," +
                                        "@gender3g, @gradelevel3g, @section3g, @sb13g, @sb23g, @sb33g, @sb43g, @sb53g, @sb63g, @sb73g, @sb83g, @schoolyear3g)";
                                    sqlcommand = new SqlCommand(query8, sqlconnection);

                                    sqlcommand.Parameters.AddWithValue("@studentid3g", NewStudentID.ToString());
                                    sqlcommand.Parameters.AddWithValue("@studentname3g", FullName);
                                    sqlcommand.Parameters.AddWithValue("@gender3g", GenderDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@gradelevel3g", GradeLevelDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@section3g", SectionDropdown.selectedValue.ToString());

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
                                    query9 = "INSERT INTO [Tbl.FourthGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                                        "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid4g, @studentname4g," +
                                        "@gender4g, @gradelevel4g, @section4g, @sb14g, @sb24g, @sb34g, @sb44g, @sb54g, @sb64g, @sb74g, @sb84g, @schoolyear4g)";
                                    sqlcommand = new SqlCommand(query9, sqlconnection);

                                    sqlcommand.Parameters.AddWithValue("@studentid4g", NewStudentID.ToString());
                                    sqlcommand.Parameters.AddWithValue("@studentname4g", FullName);
                                    sqlcommand.Parameters.AddWithValue("@gender4g", GenderDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@gradelevel4g", GradeLevelDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@section4g", SectionDropdown.selectedValue.ToString());

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
                                    query10 = "INSERT INTO [Tbl.StudentAverages]([STUDENT ID], [STUDENT NAME], LRN, [GRADE LEVEL], SECTION, " +
                                        "[FIRST GRADING], [SECOND GRADING], [THIRD GRADING], [FOURTH GRADING], GPA, [SCHOOL YEAR]) " +
                                        "VALUES(@sid, @studname, @lrn, @glevel, @section, @fga, @sga, @tga, @ffga, @gpa, @schoolyear)";
                                    sqlcommand = new SqlCommand(query10, sqlconnection);

                                    sqlcommand.Parameters.AddWithValue("@sid", NewStudentID.ToString());
                                    sqlcommand.Parameters.AddWithValue("@studname", FullName);
                                    sqlcommand.Parameters.AddWithValue("@lrn", LRNTextbox.Text.Trim());
                                    sqlcommand.Parameters.AddWithValue("@glevel", GradeLevelDropdown.selectedValue.ToString());
                                    sqlcommand.Parameters.AddWithValue("@section", SectionDropdown.selectedValue.ToString());

                                    sqlcommand.Parameters.AddWithValue("@fga", "");
                                    sqlcommand.Parameters.AddWithValue("@sga", "");
                                    sqlcommand.Parameters.AddWithValue("@tga", "");
                                    sqlcommand.Parameters.AddWithValue("@ffga", "");
                                    sqlcommand.Parameters.AddWithValue("@gpa", "");
                                    sqlcommand.Parameters.AddWithValue("@schoolyear", CurrentSchoolYear);
                                    sqlcommand.ExecuteNonQuery();

                                    notificationwindow.CaptionText = "REGISTRATION SUCCESS !";
                                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                                    notificationwindow.MessageText = FirstNameTextbox.Text.Trim().ToUpper() + " " +
                                        LastNameTextbox.Text.Trim().ToUpper() + " " + "WAS\nREGISTERED SUCCESSFULLY !";

                                    darkeropacityform.Show();
                                    notificationwindow.ShowDialog();
                                    darkeropacityform.Hide();

                                    sqlconnection.Close();
                                    DialogResult = DialogResult.OK;
                                }

                                else if (int.Parse(VirtualTable.Rows[0][0].ToString()) > 0)
                                {
                                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                                    notificationwindow.MessageText = "THIS STUDENT IS ALREADY REGISTERED !";

                                    darkeropacityform.Show();
                                    notificationwindow.ShowDialog();
                                    darkeropacityform.Hide();
                                }
                            }

                            else {
                                sqldatareader.Close();
                                notificationwindow.CaptionText = "MESSAGE CONTENT";
                                notificationwindow.MsgImage.Image = Properties.Resources.error;
                                notificationwindow.MessageText = "SECTION " + SectionDropdown.selectedValue.ToString() + "IS ALREADY FULL !";

                                darkeropacityform.Show();
                                notificationwindow.ShowDialog();
                                darkeropacityform.Hide();
                            }

                            break;
                        }
                        sqldatareader.Close();
                    }

                    catch (Exception exception)
                    {
                        opacityform.Show();
                        MessageBox.Show(exception.StackTrace.ToString() + exception.Message, "@Add Student Form Inner Exception 22",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.StackTrace.ToString(), "@Add Student Form Exception 2",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
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

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Reseter = new ResetControlState();
            Reseter.Student_ResetAllControlState(this);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void StudentIDTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void AddStudentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void GradeLevelDropdown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void ResetButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void PasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text.Trim().Length >= 1)
            {
                ShowPasswordImg1.Visible = true;
            }

            else if (PasswordTextbox.Text.Trim().Length < 1)
            {
                ShowPasswordImg1.Visible = false;
            }
        }
        
        private void ConfirmPasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (ConfirmPasswordTextbox.Text.Trim().Length >= 1)
            {
                ShowPasswordImg2.Visible = true;
            }

            else if (ConfirmPasswordTextbox.Text.Trim().Length < 1)
            {
                ShowPasswordImg2.Visible = false;
            }
        }

        private void ShowPasswordImg1_Click(object sender, EventArgs e)
        {
            //SHOW
            if (PasswordTextbox.isPassword == true)
            {
                PasswordTextbox.isPassword = false;
                ShowPasswordImg1.Image = Properties.Resources.Hide;
            }

            //HIDE
            else if (PasswordTextbox.isPassword == false)
            {
                PasswordTextbox.isPassword = true;
                ShowPasswordImg1.Image = Properties.Resources.Show;
            }
        }

        private void ShowPasswordImg1_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg1.Size = new Size(22, 22);
        }

        private void ShowPasswordImg1_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg1.Size = new Size(20, 20);
        }

        private void ShowPasswordImg2_Click(object sender, EventArgs e)
        {
            //SHOW
            if (ConfirmPasswordTextbox.isPassword == true)
            {
                ConfirmPasswordTextbox.isPassword = false;
                ShowPasswordImg2.Image = Properties.Resources.Hide;
            }

            //HIDE
            else if (ConfirmPasswordTextbox.isPassword == false)
            {
                ConfirmPasswordTextbox.isPassword = true;
                ShowPasswordImg2.Image = Properties.Resources.Show;
            }
        }

        private void ShowPasswordImg2_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg2.Size = new Size(22, 22);
        }

        private void ShowPasswordImg2_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg2.Size = new Size(20, 20);
        }
    }
}
