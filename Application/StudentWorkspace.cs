using System;
using System.IO;
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
    public partial class StudentWorkspace : MaterialForm
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;

        GetSpecifiedPrefix getspecifiedprefix;
        ChangePasswordRequiredForm changepasswordrequiredform;

        StudentEditDetailsForm studenteditdetailsform;
        StudentFullDetailsForm studentfulldetailsform;
        StudentSettingsForm studentsettingsform;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;

        int NewPhotoID;
        private string ImageFilename, temp111, temp222, temp333;
        private string UserID, StudentID, CurrentSchoolYear;
        string str1, str2, str3, Photos_id_prefix;

        public StudentWorkspace()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal900, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void _1_StudentWorkspace_Load(object sender, EventArgs e)
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
                StudentID = registrykey.GetValue("Student ID").ToString();
                UserID = registrykey.GetValue("User ID").ToString();

                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                //INNER EXCEPTION 1
                try
                {
                    //INIT STUDENT NAME //LOAD ACCOUNT PHOTO
                    LoadStudentName(); LoadAccountImage();

                    //INIT PERSONAL INFO //INIT PHOTO ID
                    LoadPersonalInfo(); Init_PhotoID(); 

                    //INIT STUDENT CARD
                    Init_Subjects();

                    //INIT SCHOOL YEAR //Populate School Year Dropdown
                    GetCurrentSchoolYear(); GetSchoolYearList();

                    //INIT 1ST GRADING GRADES //INIT 2ND GRADING GRADES
                    Init_FirstGrading_Grades(); Init_SecondGrading_Grades();
                    
                    //INIT 3RD GRADING GRADES //INIT 4RTH GRADING GRADES
                    Init_ThirdGrading_Grades(); Init_FourthGrading_Grades();

                    //COMPUTE FINAL GRADES SHIT ! //COMPUTE GRADING AVERAGES //COMPUTE AVERAGE SHIT !
                    Compute_Final_Grades(); Compute_Grading_Average(); Compute_General_Average();

                    //SHOW [PASSWORD MUST BE CHANGE FORM] FOR USERS HAVING NO LOGIN HISTORY
                    string wildcardquery = "SELECT [IS PWD CHANGED] FROM [Tbl.Users] WHERE [USER ID] = '" + UserID + "'";
                    sqlcommand = new SqlCommand(wildcardquery, sqlconnection);
                    SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                    while (sqldatareader.Read())
                    {
                        string ShowPasswordMustBeChangedForm = sqldatareader.GetString(0);
                        if (ShowPasswordMustBeChangedForm.Equals("False"))
                        {
                            opacityform.Show();
                            changepasswordrequiredform = new ChangePasswordRequiredForm();
                            changepasswordrequiredform.ShowDialog();
                            opacityform.Hide();
                        }
                    }
                    sqldatareader.Close();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Student Workspace Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Student Workspace Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void LoadStudentName()
        {
            string sqlquery1 = "SELECT [FIRST NAME], [MIDDLE NAME], [LAST NAME] FROM [Tbl.Students] WHERE [USER ID] = '" + UserID + "'";
            sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                str1 = sqldatareader.GetString(0);
                str2 = sqldatareader.GetString(1);
                str3 = sqldatareader.GetString(2);

                if (str1.Length + str3.Length > 16) {
                    StudentNameLabel.Text = str1 + " " + str3.Remove(1, str3.Length - 1) + ".";
                }

                else {
                    StudentNameLabel.Text = str1 + " " + str3;
                }

                StudentFullNameLabel.Text = (str1 + " " + str2 + " " + str3).ToUpper();
            }
            sqldatareader.Close();
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
                    CurrentSchoolYearLabel.Text = CurrentSchoolYear;
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }

        private void LoadAccountImage()
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
                    StudentPhoto.Image = Image.FromStream(new MemoryStream(ImageArray));
                }
            }

            catch (Exception)
            {
                //DON'T DISPLAY ANYTHING SHIT !
            }
        }

        private void LoadPersonalInfo()
        {
            string TempQuery = "SELECT [LRN], [GRADE LEVEL], [SECTION], [GENDER], [BIRTH DATE]," +
                "[PRESENT ADDRESS], [EMAIL ADDRESS], [MOBILE NUMBER] FROM [Tbl.Students] WHERE [STUDENT ID] = '" + StudentID + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                LRNTextbox.Text = "LRN: " + sqldatareader.GetString(0);
                GradeLevel_SectionNameLabel.Text = sqldatareader.GetString(1) + " - " + sqldatareader.GetString(2);
                GenderLabel.Text = sqldatareader.GetString(3);
                BirthdayLabel.Text = sqldatareader.GetString(4);

                PresentAddressLabel.Text = sqldatareader.GetString(5);
                EmailAddressLabel.Text = sqldatareader.GetString(6);
                PhoneNumberLabel.Text = sqldatareader.GetString(7);
            }
            sqldatareader.Close();

            UserIDTextbox.Text = "USER ID: " + UserID.ToString();
            StudentIDTextbox.Text = "STUDENT ID: " + StudentID.ToString();
        }

        private void Init_PhotoID()
        {
            //PHOTOS
            getspecifiedprefix = new GetSpecifiedPrefix();
            Photos_id_prefix = getspecifiedprefix.GetPictureIDPrefix();

            string wildcardquery3 = "SELECT COUNT(*) FROM [Tbl.Photos]";
            sqldataadapter = new SqlDataAdapter(wildcardquery3, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST PICTURE ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                string universal_set5 = "SELECT [PICTURE ID] FROM [Tbl.Photos]";
                sqlcommand = new SqlCommand(universal_set5, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    temp111 = sqldatareader.GetString(0);

                    temp333 = temp111.Remove(0, Photos_id_prefix.Length);
                    NewPhotoID = int.Parse(temp333) + 1;
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW PICTURE ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                string universal_set6 = "SELECT SUFFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'PICTURE ID'";
                sqlcommand = new SqlCommand(universal_set6, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    temp222 = sqldatareader.GetString(0);

                    //temp3 = temp2.Remove(0, Photos_id_prefix.Length);
                    NewPhotoID = int.Parse(temp222);
                }
                sqldatareader.Close();
            }
        }

        private void ChoosePhotoRaisedButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 2
            try
            {
                opacityform = new OpacityForm();
                OpenFileDialog OFD = new OpenFileDialog();

                OFD.RestoreDirectory = true;
                OFD.Multiselect = false;

                OFD.Title = "Choose your photo";
                OFD.InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\Pictures";
                OFD.Filter = "Image File (*.jpg;*.png;*.bmp;*.gif)|*.jpg;*.png;*.bmp;*.gif";

                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    ImageFilename = OFD.FileName;
                    Bitmap bitmap = new Bitmap(ImageFilename);
                    StudentPhoto.Image = bitmap;

                    FileStream filestream = new FileStream(@ImageFilename, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[filestream.Length];

                    filestream.Read(imgByteArr, 0, Convert.ToInt32(filestream.Length));
                    filestream.Close();

                    string TempQuery0 = "SELECT COUNT(*) FROM [Tbl.Photos] WHERE [USER ID] = '" + UserID + "'";
                    sqldataadapter = new SqlDataAdapter(TempQuery0, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    //Update
                    if (datatable.Rows[0][0].ToString() == "1")
                    {
                        string TempQuery = "UPDATE [Tbl.Photos] SET [FILE NAME] = @filename, PICTURE = @picture WHERE [USER ID] = '" + UserID + "'";
                        sqlcommand = new SqlCommand(TempQuery, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@filename", ImageFilename.ToString());
                        sqlcommand.Parameters.AddWithValue("@picture", imgByteArr);
                        sqlcommand.ExecuteNonQuery();
                    }

                    //INSERT
                    else if (datatable.Rows[0][0].ToString() == "0")
                    {
                        string TempQuery = "INSERT INTO [Tbl.Photos]([PICTURE ID], [USER ID], [FILE NAME], PICTURE) VALUES(@pictureid, @userid, @filename, @picture)";
                        sqlcommand = new SqlCommand(TempQuery, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@pictureid", Photos_id_prefix + NewPhotoID.ToString());
                        sqlcommand.Parameters.AddWithValue("@userid", UserID.ToString());
                        sqlcommand.Parameters.AddWithValue("@filename", ImageFilename.ToString());
                        sqlcommand.Parameters.AddWithValue("@picture", imgByteArr);
                        sqlcommand.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Student Workspace Form Exception 2",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void Init_Subjects()
        {
            string[,] GradesAndStuff; GradesAndStuff = new string[12, 8];
            string[] Subjects = {"      FILIPINO", "      ENGLISH", "      MATHEMATICS", "      SCIENCE",
                "      ARALING PANLIPUNAN", "      TLE", "      MAPEH", "      ESP"};

            //TODO: INIT SUBJECTS
            for (int i = 0; i < Subjects.Length; i++) {
                GradesAndStuff[0, i] = Subjects[i];
            }

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[0].Cells[0].Value = GradesAndStuff[0, 0];

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[1].Cells[0].Value = GradesAndStuff[0, 1];

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[2].Cells[0].Value = GradesAndStuff[0, 2];

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[3].Cells[0].Value = GradesAndStuff[0, 3];

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[4].Cells[0].Value = GradesAndStuff[0, 4];

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[5].Cells[0].Value = GradesAndStuff[0, 5];

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[6].Cells[0].Value = GradesAndStuff[0, 6];

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[7].Cells[0].Value = GradesAndStuff[0, 7];

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows.Add();

            //POPULATE THE REMAINING SPACES IN THE BUTTOM
            for (int populate = 0; populate < 30; populate++)
            {
                StudentGradeGridView.Rows.Add();
            }
            
            StudentGradeGridView.Rows[9].Cells[0].Value = "      GRADING AVERAGE:";
            StudentGradeGridView.Rows[9].DefaultCellStyle.Font = new Font("SF UI Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[11].Cells[0].Value = "      TOTAL NO. OF UNITS:";
            StudentGradeGridView.Rows[11].Cells[1].Value = "------";
            StudentGradeGridView.Rows[11].DefaultCellStyle.Font = new Font("SF UI Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);

            StudentGradeGridView.Rows.Add();
            StudentGradeGridView.Rows[12].Cells[0].Value = "      GENERAL WEIGHTED AVERAGE:";
            StudentGradeGridView.Rows[12].Cells[1].Selected = true;
            StudentGradeGridView.Rows[12].DefaultCellStyle.Font = new Font("SF UI Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);

            //INIT: RATING STANDARDS
            StudentGradeGridView.Rows[14].DefaultCellStyle.Font = new Font("SF UI Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);

            string spaces = "      ";
            string[] Descriptors = {spaces+"DESCRIPTORS", spaces+"OUTSTANDING", spaces+"VERY STATISFACTORY", spaces+"SATISFACTORY",
                spaces+"FAIRLY STATISFACTORY", spaces+"DID NOT MEET EXPECTATIONS"};
            string[] Grading_Scale = { "GRADING SCALE", "90 - 100", "85 - 89", "80 - 84", "75 - 79", "BELOW 75" };
            string[] Remarks = { "REMARKS", "PASSED", "PASSED", "PASSED", "PASSED", "FAILED !" };

            int Row1 = 14;
            for (int i = 0; i < Descriptors.Length; i++, Row1++) {
                StudentGradeGridView.Rows[Row1].Cells[0].Value = Descriptors[i];
            }

            int Row2 = 14, Column = 1;
            for (int j = 0; j < Grading_Scale.Length; j++, Row2++) {
                StudentGradeGridView.Rows[Row2].Cells[Column].Value = Grading_Scale[j];
            }

            int Row3 = 14, Column1 = 2;
            for (int k = 0; k < Remarks.Length; k++, Row3++) {
                StudentGradeGridView.Rows[Row3].Cells[Column1].Value = Remarks[k];
            }

            //SHOW DEVELOPERS INFORMATION
            StudentGradeGridView.Rows[41].DefaultCellStyle.Font = new Font("SF UI Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            for (int columns = 0; columns < 8; columns++)
                StudentGradeGridView.Rows[41].Cells[columns].Value = spaces + "PTLE SOLUTIONS.";
        }
        
        private void Compute_Filipino_Grades()
        {
            try
            {
                double firstG, secondG, thirdG, fourthG, Final_Grade;

                //FILIPINO
                if (StudentGradeGridView.Rows[0].Cells[1].Value != DBNull.Value && StudentGradeGridView.Rows[0].Cells[2].Value != DBNull.Value &&
                    StudentGradeGridView.Rows[0].Cells[3].Value != DBNull.Value && StudentGradeGridView.Rows[0].Cells[4].Value != DBNull.Value)
                {
                    firstG = double.Parse(StudentGradeGridView.Rows[0].Cells[1].Value.ToString());
                    secondG = double.Parse(StudentGradeGridView.Rows[0].Cells[2].Value.ToString());
                    thirdG = double.Parse(StudentGradeGridView.Rows[0].Cells[3].Value.ToString());
                    fourthG = double.Parse(StudentGradeGridView.Rows[0].Cells[4].Value.ToString());

                    Final_Grade = ((firstG + secondG + thirdG + fourthG) / 4);
                    if (Final_Grade.ToString().Length == 2)
                        StudentGradeGridView.Rows[0].Cells[5].Value = Final_Grade + ".00";
                    else
                        StudentGradeGridView.Rows[0].Cells[5].Value = string.Format("{0:0.00}", Final_Grade);

                    if (Final_Grade > 74)
                    {
                        StudentGradeGridView.Rows[0].Cells[7].Value = "PASSED";

                        if (Final_Grade > 89)
                            StudentGradeGridView.Rows[0].Cells[6].Value = "OUTSTANDING";

                        else if (Final_Grade > 84)
                            StudentGradeGridView.Rows[0].Cells[6].Value = "VERY STATISFACTORY";

                        else if (Final_Grade > 79)
                            StudentGradeGridView.Rows[0].Cells[6].Value = "SATISFACTORY";

                        else if (Final_Grade > 74)
                            StudentGradeGridView.Rows[0].Cells[6].Value = "FAIRLY SATISFACTORY";
                    }

                    else
                    {
                        StudentGradeGridView.Rows[0].Cells[7].Value = "FAILED";
                        StudentGradeGridView.Rows[0].Cells[6].Value = "DID NOT MEET EXPECTATIONS";
                    }
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_English_Grades()
        {
            try
            {
                double firstG, secondG, thirdG, fourthG, Final_Grade;

                //ENGLISH
                if (StudentGradeGridView.Rows[1].Cells[1].Value != DBNull.Value && StudentGradeGridView.Rows[1].Cells[2].Value != DBNull.Value &&
                    StudentGradeGridView.Rows[1].Cells[3].Value != DBNull.Value && StudentGradeGridView.Rows[1].Cells[4].Value != DBNull.Value)
                {
                    firstG = double.Parse(StudentGradeGridView.Rows[1].Cells[1].Value.ToString());
                    secondG = double.Parse(StudentGradeGridView.Rows[1].Cells[2].Value.ToString());
                    thirdG = double.Parse(StudentGradeGridView.Rows[1].Cells[3].Value.ToString());
                    fourthG = double.Parse(StudentGradeGridView.Rows[1].Cells[4].Value.ToString());

                    Final_Grade = ((firstG + secondG + thirdG + fourthG) / 4);
                    if (Final_Grade.ToString().Length == 2)
                        StudentGradeGridView.Rows[1].Cells[5].Value = Final_Grade + ".00";
                    else
                        StudentGradeGridView.Rows[1].Cells[5].Value = string.Format("{0:0.00}", Final_Grade);

                    if (Final_Grade > 74)
                    {
                        StudentGradeGridView.Rows[1].Cells[7].Value = "PASSED";

                        if (Final_Grade > 89)
                            StudentGradeGridView.Rows[1].Cells[6].Value = "OUTSTANDING";

                        else if (Final_Grade > 84)
                            StudentGradeGridView.Rows[1].Cells[6].Value = "VERY STATISFACTORY";

                        else if (Final_Grade > 79)
                            StudentGradeGridView.Rows[1].Cells[6].Value = "SATISFACTORY";

                        else if (Final_Grade > 74)
                            StudentGradeGridView.Rows[1].Cells[6].Value = "FAIRLY SATISFACTORY";
                    }

                    else
                    {
                        StudentGradeGridView.Rows[1].Cells[7].Value = "FAILED";
                        StudentGradeGridView.Rows[1].Cells[6].Value = "DID NOT MEET EXPECTATIONS";
                    }
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_Mathematics_Grades()
        {
            try
            {
                double firstG, secondG, thirdG, fourthG, Final_Grade;

                //MATHEMATICS
                if (StudentGradeGridView.Rows[2].Cells[1].Value != DBNull.Value && StudentGradeGridView.Rows[2].Cells[2].Value != DBNull.Value &&
                    StudentGradeGridView.Rows[2].Cells[3].Value != DBNull.Value && StudentGradeGridView.Rows[2].Cells[4].Value != DBNull.Value)
                {
                    firstG = double.Parse(StudentGradeGridView.Rows[2].Cells[1].Value.ToString());
                    secondG = double.Parse(StudentGradeGridView.Rows[2].Cells[2].Value.ToString());
                    thirdG = double.Parse(StudentGradeGridView.Rows[2].Cells[3].Value.ToString());
                    fourthG = double.Parse(StudentGradeGridView.Rows[2].Cells[4].Value.ToString());

                    Final_Grade = ((firstG + secondG + thirdG + fourthG) / 4);
                    if (Final_Grade.ToString().Length == 2)
                        StudentGradeGridView.Rows[2].Cells[5].Value = Final_Grade + ".00";
                    else
                        StudentGradeGridView.Rows[2].Cells[5].Value = string.Format("{0:0.00}", Final_Grade);

                    if (Final_Grade > 74)
                    {
                        StudentGradeGridView.Rows[2].Cells[7].Value = "PASSED";

                        if (Final_Grade > 89)
                            StudentGradeGridView.Rows[2].Cells[6].Value = "OUTSTANDING";

                        else if (Final_Grade > 84)
                            StudentGradeGridView.Rows[2].Cells[6].Value = "VERY STATISFACTORY";

                        else if (Final_Grade > 79)
                            StudentGradeGridView.Rows[2].Cells[6].Value = "SATISFACTORY";

                        else if (Final_Grade > 74)
                            StudentGradeGridView.Rows[2].Cells[6].Value = "FAIRLY SATISFACTORY";
                    }

                    else
                    {
                        StudentGradeGridView.Rows[2].Cells[7].Value = "FAILED";
                        StudentGradeGridView.Rows[2].Cells[6].Value = "DID NOT MEET EXPECTATIONS";
                    }
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_Science_Grades()
        {
            try
            {
                double firstG, secondG, thirdG, fourthG, Final_Grade;

                //SCIENCE
                if (StudentGradeGridView.Rows[3].Cells[1].Value != DBNull.Value && StudentGradeGridView.Rows[3].Cells[2].Value != DBNull.Value &&
                    StudentGradeGridView.Rows[3].Cells[3].Value != DBNull.Value && StudentGradeGridView.Rows[3].Cells[4].Value != DBNull.Value)
                {
                    firstG = double.Parse(StudentGradeGridView.Rows[3].Cells[1].Value.ToString());
                    secondG = double.Parse(StudentGradeGridView.Rows[3].Cells[2].Value.ToString());
                    thirdG = double.Parse(StudentGradeGridView.Rows[3].Cells[3].Value.ToString());
                    fourthG = double.Parse(StudentGradeGridView.Rows[3].Cells[4].Value.ToString());

                    Final_Grade = ((firstG + secondG + thirdG + fourthG) / 4);
                    if (Final_Grade.ToString().Length == 2)
                        StudentGradeGridView.Rows[3].Cells[5].Value = Final_Grade + ".00";
                    else
                        StudentGradeGridView.Rows[3].Cells[5].Value = string.Format("{0:0.00}", Final_Grade);

                    if (Final_Grade > 74)
                    {
                        StudentGradeGridView.Rows[3].Cells[7].Value = "PASSED";

                        if (Final_Grade > 89)
                            StudentGradeGridView.Rows[3].Cells[6].Value = "OUTSTANDING";

                        else if (Final_Grade > 84)
                            StudentGradeGridView.Rows[3].Cells[6].Value = "VERY STATISFACTORY";

                        else if (Final_Grade > 79)
                            StudentGradeGridView.Rows[3].Cells[6].Value = "SATISFACTORY";

                        else if (Final_Grade > 74)
                            StudentGradeGridView.Rows[3].Cells[6].Value = "FAIRLY SATISFACTORY";
                    }

                    else
                    {
                        StudentGradeGridView.Rows[3].Cells[7].Value = "FAILED";
                        StudentGradeGridView.Rows[3].Cells[6].Value = "DID NOT MEET EXPECTATIONS";
                    }
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_AP_Grades()
        {
            try
            {
                double firstG, secondG, thirdG, fourthG, Final_Grade;

                //AP
                if (StudentGradeGridView.Rows[4].Cells[1].Value != DBNull.Value && StudentGradeGridView.Rows[4].Cells[2].Value != DBNull.Value &&
                    StudentGradeGridView.Rows[4].Cells[3].Value != DBNull.Value && StudentGradeGridView.Rows[4].Cells[4].Value != DBNull.Value)
                {
                    firstG = double.Parse(StudentGradeGridView.Rows[4].Cells[1].Value.ToString());
                    secondG = double.Parse(StudentGradeGridView.Rows[4].Cells[2].Value.ToString());
                    thirdG = double.Parse(StudentGradeGridView.Rows[4].Cells[3].Value.ToString());
                    fourthG = double.Parse(StudentGradeGridView.Rows[4].Cells[4].Value.ToString());

                    Final_Grade = ((firstG + secondG + thirdG + fourthG) / 4);
                    if (Final_Grade.ToString().Length == 2)
                        StudentGradeGridView.Rows[4].Cells[5].Value = Final_Grade + ".00";
                    else
                        StudentGradeGridView.Rows[4].Cells[5].Value = string.Format("{0:0.00}", Final_Grade);

                    if (Final_Grade > 74)
                    {
                        StudentGradeGridView.Rows[4].Cells[7].Value = "PASSED";

                        if (Final_Grade > 89)
                            StudentGradeGridView.Rows[4].Cells[6].Value = "OUTSTANDING";

                        else if (Final_Grade > 84)
                            StudentGradeGridView.Rows[4].Cells[6].Value = "VERY STATISFACTORY";

                        else if (Final_Grade > 79)
                            StudentGradeGridView.Rows[4].Cells[6].Value = "SATISFACTORY";

                        else if (Final_Grade > 74)
                            StudentGradeGridView.Rows[4].Cells[6].Value = "FAIRLY SATISFACTORY";
                    }

                    else
                    {
                        StudentGradeGridView.Rows[4].Cells[7].Value = "FAILED";
                        StudentGradeGridView.Rows[4].Cells[6].Value = "DID NOT MEET EXPECTATIONS";
                    }
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_TLE_Grades()
        {
            try
            {
                double firstG, secondG, thirdG, fourthG, Final_Grade;

                //TLE
                if (StudentGradeGridView.Rows[5].Cells[1].Value != DBNull.Value && StudentGradeGridView.Rows[5].Cells[2].Value != DBNull.Value &&
                    StudentGradeGridView.Rows[5].Cells[3].Value != DBNull.Value && StudentGradeGridView.Rows[5].Cells[4].Value != DBNull.Value)
                {
                    firstG = double.Parse(StudentGradeGridView.Rows[5].Cells[1].Value.ToString());
                    secondG = double.Parse(StudentGradeGridView.Rows[5].Cells[2].Value.ToString());
                    thirdG = double.Parse(StudentGradeGridView.Rows[5].Cells[3].Value.ToString());
                    fourthG = double.Parse(StudentGradeGridView.Rows[5].Cells[4].Value.ToString());

                    Final_Grade = ((firstG + secondG + thirdG + fourthG) / 4);
                    if (Final_Grade.ToString().Length == 2)
                        StudentGradeGridView.Rows[5].Cells[5].Value = Final_Grade + ".00";
                    else
                        StudentGradeGridView.Rows[5].Cells[5].Value = string.Format("{0:0.00}", Final_Grade);

                    if (Final_Grade > 74)
                    {
                        StudentGradeGridView.Rows[5].Cells[7].Value = "PASSED";

                        if (Final_Grade > 89)
                            StudentGradeGridView.Rows[5].Cells[6].Value = "OUTSTANDING";

                        else if (Final_Grade > 84)
                            StudentGradeGridView.Rows[5].Cells[6].Value = "VERY STATISFACTORY";

                        else if (Final_Grade > 79)
                            StudentGradeGridView.Rows[5].Cells[6].Value = "SATISFACTORY";

                        else if (Final_Grade > 74)
                            StudentGradeGridView.Rows[5].Cells[6].Value = "FAIRLY SATISFACTORY";
                    }

                    else
                    {
                        StudentGradeGridView.Rows[5].Cells[7].Value = "FAILED";
                        StudentGradeGridView.Rows[5].Cells[6].Value = "DID NOT MEET EXPECTATIONS";
                    }
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_Mapeh_Grades()
        {
            try
            {
                double firstG, secondG, thirdG, fourthG, Final_Grade;

                //MAPEH
                if (StudentGradeGridView.Rows[6].Cells[1].Value != DBNull.Value && StudentGradeGridView.Rows[6].Cells[2].Value != DBNull.Value &&
                    StudentGradeGridView.Rows[6].Cells[3].Value != DBNull.Value && StudentGradeGridView.Rows[6].Cells[4].Value != DBNull.Value)
                {
                    firstG = double.Parse(StudentGradeGridView.Rows[6].Cells[1].Value.ToString());
                    secondG = double.Parse(StudentGradeGridView.Rows[6].Cells[2].Value.ToString());
                    thirdG = double.Parse(StudentGradeGridView.Rows[6].Cells[3].Value.ToString());
                    fourthG = double.Parse(StudentGradeGridView.Rows[6].Cells[4].Value.ToString());

                    Final_Grade = ((firstG + secondG + thirdG + fourthG) / 4);
                    if (Final_Grade.ToString().Length == 2)
                        StudentGradeGridView.Rows[6].Cells[5].Value = Final_Grade + ".00";
                    else
                        StudentGradeGridView.Rows[6].Cells[5].Value = string.Format("{0:0.00}", Final_Grade);

                    if (Final_Grade > 74)
                    {
                        StudentGradeGridView.Rows[6].Cells[7].Value = "PASSED";

                        if (Final_Grade > 89)
                            StudentGradeGridView.Rows[6].Cells[6].Value = "OUTSTANDING";

                        else if (Final_Grade > 84)
                            StudentGradeGridView.Rows[6].Cells[6].Value = "VERY STATISFACTORY";

                        else if (Final_Grade > 79)
                            StudentGradeGridView.Rows[6].Cells[6].Value = "SATISFACTORY";

                        else if (Final_Grade > 74)
                            StudentGradeGridView.Rows[6].Cells[6].Value = "FAIRLY SATISFACTORY";
                    }

                    else
                    {
                        StudentGradeGridView.Rows[6].Cells[7].Value = "FAILED";
                        StudentGradeGridView.Rows[6].Cells[6].Value = "DID NOT MEET EXPECTATIONS";
                    }
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_ESP_Grades()
        {
            try
            {
                double firstG, secondG, thirdG, fourthG, Final_Grade;

                //ESP
                if (StudentGradeGridView.Rows[7].Cells[1].Value != DBNull.Value && StudentGradeGridView.Rows[7].Cells[2].Value != DBNull.Value &&
                    StudentGradeGridView.Rows[7].Cells[3].Value != DBNull.Value && StudentGradeGridView.Rows[7].Cells[4].Value != DBNull.Value)
                {
                    firstG = double.Parse(StudentGradeGridView.Rows[7].Cells[1].Value.ToString());
                    secondG = double.Parse(StudentGradeGridView.Rows[7].Cells[2].Value.ToString());
                    thirdG = double.Parse(StudentGradeGridView.Rows[7].Cells[3].Value.ToString());
                    fourthG = double.Parse(StudentGradeGridView.Rows[7].Cells[4].Value.ToString());

                    Final_Grade = ((firstG + secondG + thirdG + fourthG) / 4);
                    if (Final_Grade.ToString().Length == 2)
                        StudentGradeGridView.Rows[7].Cells[5].Value = Final_Grade + ".00";
                    else
                        StudentGradeGridView.Rows[7].Cells[5].Value = string.Format("{0:0.00}", Final_Grade);

                    if (Final_Grade > 74)
                    {
                        StudentGradeGridView.Rows[7].Cells[7].Value = "PASSED";

                        if (Final_Grade > 89)
                            StudentGradeGridView.Rows[7].Cells[6].Value = "OUTSTANDING";

                        else if (Final_Grade > 84)
                            StudentGradeGridView.Rows[7].Cells[6].Value = "VERY STATISFACTORY";

                        else if (Final_Grade > 79)
                            StudentGradeGridView.Rows[7].Cells[6].Value = "SATISFACTORY";

                        else if (Final_Grade > 74)
                            StudentGradeGridView.Rows[7].Cells[6].Value = "FAIRLY SATISFACTORY";
                    }

                    else
                    {
                        StudentGradeGridView.Rows[7].Cells[7].Value = "FAILED";
                        StudentGradeGridView.Rows[7].Cells[6].Value = "DID NOT MEET EXPECTATIONS";
                    }
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_Final_Grades()
        {
            try
            {
                Compute_Filipino_Grades();
            }

            catch (Exception)
            {
                Compute_English_Grades();
            }


            try
            {
                Compute_English_Grades();
            }

            catch (Exception)
            {
                Compute_Mathematics_Grades();
            }


            try
            {
                Compute_Mathematics_Grades();
            }

            catch (Exception)
            {
                Compute_Science_Grades();
            }


            try
            {
                Compute_Science_Grades();
            }

            catch (Exception)
            {
                Compute_AP_Grades();
            }


            try
            {
                Compute_AP_Grades();
            }

            catch (Exception)
            {
                Compute_TLE_Grades();
            }


            try
            {
                Compute_TLE_Grades();
            }

            catch (Exception)
            {
                Compute_Mapeh_Grades();
            }


            try
            {
                Compute_Mapeh_Grades();
            }

            catch (Exception)
            {
                Compute_ESP_Grades();
            }

            try
            {
                Compute_ESP_Grades();
            }

            catch (Exception)
            {
                //Compute_Filipino_Grades();
            }
        }

        private void Compute_First_Grading_Average()
        {
            try
            {
                string Grading_Average; double Filipino, English, Mathematics, Science, Ap, Tle, Mapeh, Esp;

                //FIRST GRADING
                if (StudentGradeGridView.Rows[0].Cells[1].Value != null && StudentGradeGridView.Rows[1].Cells[1].Value != null
                    && StudentGradeGridView.Rows[2].Cells[1].Value != null && StudentGradeGridView.Rows[3].Cells[1].Value != null
                    && StudentGradeGridView.Rows[4].Cells[1].Value != null && StudentGradeGridView.Rows[5].Cells[1].Value != null
                    && StudentGradeGridView.Rows[6].Cells[1].Value != null && StudentGradeGridView.Rows[7].Cells[1].Value != null)
                {
                    Filipino = double.Parse(StudentGradeGridView.Rows[0].Cells[1].Value.ToString());
                    English = double.Parse(StudentGradeGridView.Rows[1].Cells[1].Value.ToString());
                    Mathematics = double.Parse(StudentGradeGridView.Rows[2].Cells[1].Value.ToString());

                    Science = double.Parse(StudentGradeGridView.Rows[3].Cells[1].Value.ToString());
                    Ap = double.Parse(StudentGradeGridView.Rows[4].Cells[1].Value.ToString());
                    Tle = double.Parse(StudentGradeGridView.Rows[5].Cells[1].Value.ToString());

                    Mapeh = double.Parse(StudentGradeGridView.Rows[6].Cells[1].Value.ToString());
                    Esp = double.Parse(StudentGradeGridView.Rows[7].Cells[1].Value.ToString());

                    Grading_Average = ((Filipino + English + Mathematics + Science + Ap + Tle + Mapeh + Esp) / 8).ToString();
                    if (Grading_Average.Length == 2)
                        StudentGradeGridView.Rows[9].Cells[1].Value = Grading_Average + ".000 %";
                    else if (Grading_Average.Length > 6)
                        StudentGradeGridView.Rows[9].Cells[1].Value = Grading_Average.Remove(6, Grading_Average.Length - 6) + " %";
                    else
                        StudentGradeGridView.Rows[9].Cells[1].Value = string.Format("{0:0.000} %", double.Parse(Grading_Average));

                    //INSERT DATA INTO OUR TABLE BULLSHIT !
                    string UpdateQuery = "UPDATE [Tbl.StudentAverages] SET [FIRST GRADING] = '" + StudentGradeGridView.Rows[9].Cells[1].Value.ToString() +
                        "' WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.ExecuteNonQuery();
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_Second_Grading_Average()
        {
            try
            {
                string Grading_Average; double Filipino, English, Mathematics, Science, Ap, Tle, Mapeh, Esp;

                //SECOND GRADING
                if (StudentGradeGridView.Rows[0].Cells[2].Value != null && StudentGradeGridView.Rows[1].Cells[2].Value != null
                    && StudentGradeGridView.Rows[2].Cells[2].Value != null && StudentGradeGridView.Rows[3].Cells[2].Value != null
                    && StudentGradeGridView.Rows[4].Cells[2].Value != null && StudentGradeGridView.Rows[5].Cells[2].Value != null
                    && StudentGradeGridView.Rows[6].Cells[2].Value != null && StudentGradeGridView.Rows[7].Cells[2].Value != null)
                {
                    Filipino = double.Parse(StudentGradeGridView.Rows[0].Cells[2].Value.ToString());
                    English = double.Parse(StudentGradeGridView.Rows[1].Cells[2].Value.ToString());
                    Mathematics = double.Parse(StudentGradeGridView.Rows[2].Cells[2].Value.ToString());

                    Science = double.Parse(StudentGradeGridView.Rows[3].Cells[2].Value.ToString());
                    Ap = double.Parse(StudentGradeGridView.Rows[4].Cells[2].Value.ToString());
                    Tle = double.Parse(StudentGradeGridView.Rows[5].Cells[2].Value.ToString());

                    Mapeh = double.Parse(StudentGradeGridView.Rows[6].Cells[2].Value.ToString());
                    Esp = double.Parse(StudentGradeGridView.Rows[7].Cells[2].Value.ToString());

                    Grading_Average = ((Filipino + English + Mathematics + Science + Ap + Tle + Mapeh + Esp) / 8).ToString();
                    if (Grading_Average.Length == 2)
                        StudentGradeGridView.Rows[9].Cells[2].Value = Grading_Average + ".000 %";
                    else if (Grading_Average.Length > 6)
                        StudentGradeGridView.Rows[9].Cells[2].Value = Grading_Average.Remove(6, Grading_Average.Length - 6) + " %";
                    else
                        StudentGradeGridView.Rows[9].Cells[2].Value = string.Format("{0:0.000} %", double.Parse(Grading_Average));

                    //INSERT DATA INTO OUR TABLE BULLSHIT !
                    string UpdateQuery = "UPDATE [Tbl.StudentAverages] SET [SECOND GRADING] = '" + StudentGradeGridView.Rows[9].Cells[2].Value.ToString() +
                        "' WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.ExecuteNonQuery();
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_Third_Grading_Average()
        {
            try
            {
                string Grading_Average; double Filipino, English, Mathematics, Science, Ap, Tle, Mapeh, Esp;

                //THIRD GRADING
                if (StudentGradeGridView.Rows[0].Cells[3].Value != null && StudentGradeGridView.Rows[1].Cells[3].Value != null
                    && StudentGradeGridView.Rows[2].Cells[3].Value != null && StudentGradeGridView.Rows[3].Cells[3].Value != null
                    && StudentGradeGridView.Rows[4].Cells[3].Value != null && StudentGradeGridView.Rows[5].Cells[3].Value != null
                    && StudentGradeGridView.Rows[6].Cells[3].Value != null && StudentGradeGridView.Rows[7].Cells[3].Value != null)
                {
                    Filipino = double.Parse(StudentGradeGridView.Rows[0].Cells[3].Value.ToString());
                    English = double.Parse(StudentGradeGridView.Rows[1].Cells[3].Value.ToString());
                    Mathematics = double.Parse(StudentGradeGridView.Rows[2].Cells[3].Value.ToString());

                    Science = double.Parse(StudentGradeGridView.Rows[3].Cells[3].Value.ToString());
                    Ap = double.Parse(StudentGradeGridView.Rows[4].Cells[3].Value.ToString());
                    Tle = double.Parse(StudentGradeGridView.Rows[5].Cells[3].Value.ToString());

                    Mapeh = double.Parse(StudentGradeGridView.Rows[6].Cells[3].Value.ToString());
                    Esp = double.Parse(StudentGradeGridView.Rows[7].Cells[3].Value.ToString());

                    Grading_Average = ((Filipino + English + Mathematics + Science + Ap + Tle + Mapeh + Esp) / 8).ToString();
                    if (Grading_Average.Length == 2)
                        StudentGradeGridView.Rows[9].Cells[3].Value = Grading_Average + ".000 %";
                    else if (Grading_Average.Length > 6)
                        StudentGradeGridView.Rows[9].Cells[3].Value = Grading_Average.Remove(6, Grading_Average.Length - 6) + " %";
                    else
                        StudentGradeGridView.Rows[9].Cells[3].Value = string.Format("{0:0.000} %", double.Parse(Grading_Average));

                    //INSERT DATA INTO OUR TABLE BULLSHIT !
                    string UpdateQuery = "UPDATE [Tbl.StudentAverages] SET [THIRD GRADING] = '" + StudentGradeGridView.Rows[9].Cells[3].Value.ToString() +
                        "' WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.ExecuteNonQuery();
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_Fourth_Grading_Average()
        {
            try
            {
                string Grading_Average; double Filipino, English, Mathematics, Science, Ap, Tle, Mapeh, Esp;

                //FOURTH GRADING
                if (StudentGradeGridView.Rows[0].Cells[4].Value != null && StudentGradeGridView.Rows[1].Cells[4].Value != null
                    && StudentGradeGridView.Rows[2].Cells[4].Value != null && StudentGradeGridView.Rows[3].Cells[4].Value != null
                    && StudentGradeGridView.Rows[4].Cells[4].Value != null && StudentGradeGridView.Rows[5].Cells[4].Value != null
                    && StudentGradeGridView.Rows[6].Cells[4].Value != null && StudentGradeGridView.Rows[7].Cells[4].Value != null)
                {
                    Filipino = double.Parse(StudentGradeGridView.Rows[0].Cells[4].Value.ToString());
                    English = double.Parse(StudentGradeGridView.Rows[1].Cells[4].Value.ToString());
                    Mathematics = double.Parse(StudentGradeGridView.Rows[2].Cells[4].Value.ToString());

                    Science = double.Parse(StudentGradeGridView.Rows[3].Cells[4].Value.ToString());
                    Ap = double.Parse(StudentGradeGridView.Rows[4].Cells[4].Value.ToString());
                    Tle = double.Parse(StudentGradeGridView.Rows[5].Cells[4].Value.ToString());

                    Mapeh = double.Parse(StudentGradeGridView.Rows[6].Cells[4].Value.ToString());
                    Esp = double.Parse(StudentGradeGridView.Rows[7].Cells[4].Value.ToString());

                    Grading_Average = ((Filipino + English + Mathematics + Science + Ap + Tle + Mapeh + Esp) / 8).ToString();

                    if (Grading_Average.Length == 2)
                        StudentGradeGridView.Rows[9].Cells[4].Value = Grading_Average + ".000 %";
                    else if (Grading_Average.Length > 6)
                        StudentGradeGridView.Rows[9].Cells[4].Value = Grading_Average.Remove(6, Grading_Average.Length - 6) + " %";
                    else
                        StudentGradeGridView.Rows[9].Cells[4].Value = string.Format("{0:0.000} %", double.Parse(Grading_Average));

                    //INSERT DATA INTO OUR TABLE BULLSHIT !
                    string UpdateQuery = "UPDATE [Tbl.StudentAverages] SET [FOURTH GRADING] = '" + StudentGradeGridView.Rows[9].Cells[4].Value.ToString() +
                        "' WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.ExecuteNonQuery();
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Compute_Grading_Average()
        {
            try
            {
                Compute_First_Grading_Average();
            }

            catch (Exception)
            {
                Compute_Second_Grading_Average();
            }


            try
            {
                Compute_Second_Grading_Average();
            }

            catch (Exception)
            {
                Compute_Third_Grading_Average();
            }


            try
            {
                Compute_Third_Grading_Average();
            }

            catch (Exception)
            {
                Compute_Fourth_Grading_Average();
            }


            try
            {
                Compute_Fourth_Grading_Average();
            }

            catch (Exception)
            {
                //Compute_First_Grading_Average();
            }
        }

        //GPA
        private void Compute_General_Average()
        {
            try
            {
                if (StudentGradeGridView.Rows[0].Cells[5].Value != null && StudentGradeGridView.Rows[1].Cells[5].Value != null &&
                    StudentGradeGridView.Rows[2].Cells[5].Value != null && StudentGradeGridView.Rows[3].Cells[5].Value != null &&
                    StudentGradeGridView.Rows[4].Cells[5].Value != null && StudentGradeGridView.Rows[5].Cells[5].Value != null &&
                    StudentGradeGridView.Rows[6].Cells[5].Value != null && StudentGradeGridView.Rows[7].Cells[5].Value != null)
                {
                    double Fil_Final_Grade = double.Parse(StudentGradeGridView.Rows[0].Cells[5].Value.ToString());
                    double Eng_Final_Grade = double.Parse(StudentGradeGridView.Rows[1].Cells[5].Value.ToString());

                    double Mat_Final_Grade = double.Parse(StudentGradeGridView.Rows[2].Cells[5].Value.ToString());
                    double Sci_Final_Grade = double.Parse(StudentGradeGridView.Rows[3].Cells[5].Value.ToString());

                    double AP_Final_Grade = double.Parse(StudentGradeGridView.Rows[4].Cells[5].Value.ToString());
                    double TLE_Final_Grade = double.Parse(StudentGradeGridView.Rows[5].Cells[5].Value.ToString());

                    double Map_Final_Grade = double.Parse(StudentGradeGridView.Rows[6].Cells[5].Value.ToString());
                    double ESP_Final_Grade = double.Parse(StudentGradeGridView.Rows[7].Cells[5].Value.ToString());

                    string GeneralAverage = ((Fil_Final_Grade + Eng_Final_Grade + Mat_Final_Grade + Sci_Final_Grade +
                        AP_Final_Grade + TLE_Final_Grade + Map_Final_Grade + ESP_Final_Grade) / 8).ToString();
                    
                    //DISPLAY GENERAL AVERAGE
                    if (GeneralAverage.Length == 2)
                        StudentGradeGridView.Rows[12].Cells[1].Value = GeneralAverage + ".000 %";
                    else if (GeneralAverage.Length > 6)
                        StudentGradeGridView.Rows[12].Cells[1].Value = GeneralAverage.Remove(6, GeneralAverage.Length - 6) + " %";
                    else
                        StudentGradeGridView.Rows[12].Cells[1].Value = string.Format("{0:0.000} %", double.Parse(GeneralAverage));

                    //INSERT DATA INTO OUR TABLE BULLSHIT !
                    string UpdateQuery = "UPDATE [Tbl.StudentAverages] SET [GPA] = '" + StudentGradeGridView.Rows[12].Cells[1].Value.ToString() +
                        "' WHERE [STUDENT ID] = '" + StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.ExecuteNonQuery();
                }
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }

        private void Init_FirstGrading_Grades()
        {
            try
            {
                Populate_Fil_1stGrad();
                Populate_Eng_1stGrad();
                Populate_Math_1stGrad();

                Populate_Scie_1stGrad();
                Populate_AP_1stGrad();
                Populate_TLE_1stGrad();

                Populate_Map_1stGrad();
                Populate_ESP_1stGrad();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }
        
        private void Init_SecondGrading_Grades()
        {
            try
            {
                Populate_Fil_2ndGrad();
                Populate_Eng_2ndGrad();
                Populate_Math_2ndGrad();

                Populate_Scie_2ndGrad();
                Populate_AP_2ndGrad();
                Populate_TLE_2ndGrad();

                Populate_Map_2ndGrad();
                Populate_ESP_2ndGrad();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        private void Init_ThirdGrading_Grades()
        {
            try
            {
                Populate_Fil_3rdGrad();
                Populate_Eng_3rdGrad();
                Populate_Math_3rdGrad();

                Populate_Scie_3rdGrad();
                Populate_AP_3rdGrad();
                Populate_TLE_3rdGrad();

                Populate_Map_3rdGrad();
                Populate_ESP_3rdGrad();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        private void Init_FourthGrading_Grades()
        {
            try
            {
                Populate_Fil_4rthGrad();
                Populate_Eng_4rthGrad();
                Populate_Math_4rthGrad();

                Populate_Scie_4rthGrad();
                Populate_AP_4rthGrad();
                Populate_TLE_4rthGrad();

                Populate_Map_4rthGrad();
                Populate_ESP_4rthGrad();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        //1ST GRADING
        string _1stGradingTable = "[Tbl.FirstGradingStudentLoad]";
        private void Populate_Fil_1stGrad()
        {
            string TempQuery = "SELECT FILIPINO FROM " + _1stGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[0].Cells[1].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Eng_1stGrad()
        {
            string TempQuery = "SELECT ENGLISH FROM " + _1stGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[1].Cells[1].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Math_1stGrad()
        {
            string TempQuery = "SELECT MATHEMATICS FROM " + _1stGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[2].Cells[1].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Scie_1stGrad()
        {
            string TempQuery = "SELECT SCIENCE FROM " + _1stGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[3].Cells[1].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_AP_1stGrad()
        {
            string TempQuery = "SELECT AP FROM " + _1stGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[4].Cells[1].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_TLE_1stGrad()
        {
            string TempQuery = "SELECT TLE FROM " + _1stGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[5].Cells[1].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Map_1stGrad()
        {
            string TempQuery = "SELECT MAPEH FROM " + _1stGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[6].Cells[1].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_ESP_1stGrad()
        {
            string TempQuery = "SELECT ESP FROM " + _1stGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[7].Cells[1].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        //2ND GRADING
        string _2ndGradingTable = "[Tbl.SecondGradingStudentLoad]";
        private void Populate_Fil_2ndGrad()
        {
            string TempQuery = "SELECT FILIPINO FROM " + _2ndGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[0].Cells[2].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Eng_2ndGrad()
        {
            string TempQuery = "SELECT ENGLISH FROM " + _2ndGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[1].Cells[2].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Math_2ndGrad()
        {
            string TempQuery = "SELECT MATHEMATICS FROM " + _2ndGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[2].Cells[2].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Scie_2ndGrad()
        {
            string TempQuery = "SELECT SCIENCE FROM " + _2ndGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[3].Cells[2].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_AP_2ndGrad()
        {
            string TempQuery = "SELECT AP FROM " + _2ndGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[4].Cells[2].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_TLE_2ndGrad()
        {
            string TempQuery = "SELECT TLE FROM " + _2ndGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[5].Cells[2].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Map_2ndGrad()
        {
            string TempQuery = "SELECT MAPEH FROM " + _2ndGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[6].Cells[2].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_ESP_2ndGrad()
        {
            string TempQuery = "SELECT ESP FROM " + _2ndGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[7].Cells[2].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        //3RD GRADING
        string _3rdGradingTable = "[Tbl.ThirdGradingStudentLoad]";
        private void Populate_Fil_3rdGrad()
        {
            string TempQuery = "SELECT FILIPINO FROM " + _3rdGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[0].Cells[3].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Eng_3rdGrad()
        {
            string TempQuery = "SELECT ENGLISH FROM " + _3rdGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[1].Cells[3].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Math_3rdGrad()
        {
            string TempQuery = "SELECT MATHEMATICS FROM " + _3rdGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[2].Cells[3].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Scie_3rdGrad()
        {
            string TempQuery = "SELECT SCIENCE FROM " + _3rdGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[3].Cells[3].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_AP_3rdGrad()
        {
            string TempQuery = "SELECT AP FROM " + _3rdGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[4].Cells[3].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_TLE_3rdGrad()
        {
            string TempQuery = "SELECT TLE FROM " + _3rdGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[5].Cells[3].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Map_3rdGrad()
        {
            string TempQuery = "SELECT MAPEH FROM " + _3rdGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[6].Cells[3].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_ESP_3rdGrad()
        {
            string TempQuery = "SELECT ESP FROM " + _3rdGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[7].Cells[3].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        //4RTH GRADING
        string _4rthGradingTable = "[Tbl.FourthGradingStudentLoad]";
        private void Populate_Fil_4rthGrad()
        {
            string TempQuery = "SELECT FILIPINO FROM " + _4rthGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[0].Cells[4].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Eng_4rthGrad()
        {
            string TempQuery = "SELECT ENGLISH FROM " + _4rthGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[1].Cells[4].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Math_4rthGrad()
        {
            string TempQuery = "SELECT MATHEMATICS FROM " + _4rthGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[2].Cells[4].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Scie_4rthGrad()
        {
            string TempQuery = "SELECT SCIENCE FROM " + _4rthGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[3].Cells[4].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_AP_4rthGrad()
        {
            string TempQuery = "SELECT AP FROM " + _4rthGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[4].Cells[4].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_TLE_4rthGrad()
        {
            string TempQuery = "SELECT TLE FROM " + _4rthGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[5].Cells[4].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_Map_4rthGrad()
        {
            string TempQuery = "SELECT MAPEH FROM " + _4rthGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[6].Cells[4].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
        }

        private void Populate_ESP_4rthGrad()
        {
            string TempQuery = "SELECT ESP FROM " + _4rthGradingTable + " WHERE [STUDENT ID] = '" +
                StudentID + "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "'";

            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                StudentGradeGridView.Rows[7].Cells[4].Value = sqldatareader.GetString(0).ToString();
            }
            sqldatareader.Close();
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
            MaximizeTopButton.Image = Properties.Resources.Miximized_Button_Hover;
        }

        private void MaximizeTopButton_MouseLeave(object sender, EventArgs e)
        {
            MaximizeTopButton.Image = Properties.Resources.Miximized_Button;
        }

        private void MinimizeTopButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeTopButton_MouseHover(object sender, EventArgs e)
        {
            MinimizeTopButton.Image = Properties.Resources.Minimized_Button_Hover;
        }

        private void MinimizeTopButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeTopButton.Image = Properties.Resources.Minimized_Button;
        }

        private void CloseTopButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseTopButton_MouseHover(object sender, EventArgs e)
        {
            CloseTopButton.Image = Properties.Resources.Close_Button_Hover;
        }

        private void CloseTopButton_MouseLeave(object sender, EventArgs e)
        {
            CloseTopButton.Image = Properties.Resources.Close_Button;
        }
        
        private void _1_StudentWorkspace_FormClosing(object sender, FormClosingEventArgs e)
        {
            opacityform = new OpacityForm();

            //EXCEPTION 3
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
                MessageBox.Show(exception.Message.ToString(), "@Student Workspace Exception 3",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }
        
        private void EditInfopicture_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            studenteditdetailsform = new StudentEditDetailsForm();

            opacityform.Show();
            studenteditdetailsform.ShowDialog();

            opacityform.Hide();
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

        private void Clear_Contents_And_Prepare_For_New()
        {
            try
            {
                int Iterator = 0, row = 0, OldData = 10;
                for (Iterator = 0; Iterator < OldData; Iterator++)
                {
                    StudentGradeGridView.Rows[row].Cells[1].Value = DBNull.Value;
                    StudentGradeGridView.Rows[row].Cells[2].Value = DBNull.Value;
                    StudentGradeGridView.Rows[row].Cells[3].Value = DBNull.Value;
                    StudentGradeGridView.Rows[row].Cells[4].Value = DBNull.Value;

                    StudentGradeGridView.Rows[row].Cells[5].Value = DBNull.Value;
                    StudentGradeGridView.Rows[row].Cells[6].Value = DBNull.Value;
                    StudentGradeGridView.Rows[row].Cells[7].Value = DBNull.Value;
                    row++;
                }
                StudentGradeGridView.Rows[12].Cells[1].Value = DBNull.Value;
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        private void SchoolYearDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                Clear_Contents_And_Prepare_For_New();

                Init_FirstGrading_Grades(); Init_SecondGrading_Grades();
                Init_ThirdGrading_Grades(); Init_FourthGrading_Grades();

                 //COMPUTE FINAL GRADES //COMPUTE GRADING AVERAGE //COMPUTE GENERAL AVERAGE
                Compute_Final_Grades(); Compute_Grading_Average(); Compute_General_Average();
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void EditInfopicture_MouseHover(object sender, EventArgs e)
        {
            EditInfopicture.Size = new Size(35, 35);
        }

        private void EditInfopicture_MouseLeave(object sender, EventArgs e)
        {
            EditInfopicture.Size = new Size(33, 33);
        }

        private void ShowFullInfopicture_Click(object sender, EventArgs e)
        {
            RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
            opacityform = new OpacityForm();

            studentfulldetailsform = new StudentFullDetailsForm();
            studentfulldetailsform.StudentID = registrykey.GetValue("Student ID").ToString();
            studentfulldetailsform.UserID = registrykey.GetValue("User ID").ToString();
            studentfulldetailsform.Restricted = false;

            opacityform.Show();
            studentfulldetailsform.ShowDialog();

            opacityform.Hide();
        }

        private void ShowFullInfopicture_MouseHover(object sender, EventArgs e)
        {
            ShowFullInfopicture.Size = new Size(35, 35);
        }

        private void ShowFullInfopicture_MouseLeave(object sender, EventArgs e)
        {
            ShowFullInfopicture.Size = new Size(33, 33);
        }

        private void Settingspicture_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            studentsettingsform = new StudentSettingsForm();

            opacityform.Show();
            studentsettingsform.ShowDialog();

            opacityform.Hide();
        }

        private void Settingspicture_MouseHover(object sender, EventArgs e)
        {
            Settingspicture.Size = new Size(35, 35);
        }

        private void Settingspicture_MouseLeave(object sender, EventArgs e)
        {
            Settingspicture.Size = new Size(33, 33);
        }
    }
}
