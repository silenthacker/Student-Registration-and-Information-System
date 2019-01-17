using System;
using System.IO;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class AddTeacherForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        ResetControlState Reseter;

        SQLConnectionConfig sqlconnectionconfig;
        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;
        GetSpecifiedPrefix getspecifiedprefix;

        SqlConnection sqlconnection;
        SqlCommand sqlcommand;
        SqlDataAdapter sqldataadapter;

        int IncNewTeacherID, IncNewUserID;
        private bool NoChoosenPicture = true;
        string ImageFilename, str1, str2, str3, str4, CurrentSchoolYear;

        string sqlquery1, sqlquery2, sqlquery3, sqlquery4;
        int NewAssignedID, NewHandledSubjectID, NewPhotoID, NewPermissionID;
        string Assigned_id_prefix, Handled_Subject_prefix, Photos_id_prefix, Permission_id_prefix;
        string temp1, temp2, temp3, temp11, temp22, temp33, temp111, temp222, temp333;

        public AddTeacherForm()
        {
            InitializeComponent();
        }
        
        private void AddTeacherForm_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, Y_Coordinate / 2);

            SubmitButton.Select();
            BirthdayPicker.Value = DateTime.Now;

            //EXCEPTION 1
            try
            {
                variables = new Variables();
                opacityform = new OpacityForm();
                cryptography = new Cryptography();

                sqlconnectionconfig = new SQLConnectionConfig();
                getspecifiedprefix = new GetSpecifiedPrefix();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string tempdata = registrykey.GetValue("SQLServerConnectionString").ToString();
                
                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();
                
                //INNER EXCEPTION 1
                try
                {
                    //INIT ID'S TEACHER ID //USER ID
                    Init_TeacherID(); Init_UserID();
                    
                    //HANDLED ID //ASSIGNED ID //PHOTO ID //PERMISSION ID
                    Init_HandledID(); Init_AssignedID(); Init_PhotoID(); Init_PermissionsID();
                    
                    //GET CURRENT SCHOOL YEAR //LOAD GRIDVIEW RECORDS //LOAD SECTION DROPDOWN
                    GetCurrentSchoolYear(); RetriveSectionData(); LoadSectionsList();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Add Teacher Form Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString() + exception.StackTrace, "@Add Teacher Form Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }
        
        private void Init_TeacherID()
        {
            sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Teachers]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST TEACHER ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                sqlquery2 = "SELECT [TEACHER ID] FROM [Tbl.Teachers]";
                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    str1 = sqldatareader.GetString(0);

                    IncNewTeacherID = int.Parse(str1) + 1;
                    TeacherIDTextbox.Text = IncNewTeacherID.ToString();
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW TEACHER ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                sqlquery3 = "SELECT VALUE FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'TEACHER ID'";
                sqlcommand = new SqlCommand(sqlquery3, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    str2 = sqldatareader2.GetString(0);

                    IncNewTeacherID = int.Parse(str2);
                    TeacherIDTextbox.Text = IncNewTeacherID.ToString();
                }
                sqldatareader2.Close();
            }
        }

        private void Init_UserID()
        {
            sqlquery4 = "SELECT COUNT(*) FROM [Tbl.Users]";
            sqldataadapter = new SqlDataAdapter(sqlquery4, sqlconnection);
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

                    IncNewUserID = int.Parse(str3) + 1;
                    UserIDTextbox.Text = IncNewUserID.ToString();
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

                    IncNewUserID = int.Parse(str4);
                    UserIDTextbox.Text = IncNewUserID.ToString();
                }
                sqldatareader2.Close();
            }
        }

        private void Init_HandledID()
        {
            //HANDLED SUBJECTS
            Handled_Subject_prefix = getspecifiedprefix.GetHandledIDPrefix();
            string wildcardquery1 = "SELECT COUNT(*) FROM [Tbl.HandledSubjects]";
            sqldataadapter = new SqlDataAdapter(wildcardquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST HANDLED ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                string universal_set1 = "SELECT [HANDLE ID] FROM [Tbl.HandledSubjects]";
                sqlcommand = new SqlCommand(universal_set1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    temp1 = sqldatareader.GetString(0);

                    temp3 = temp1.Remove(0, Handled_Subject_prefix.Length);
                    NewHandledSubjectID = int.Parse(temp3) + 1;
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW HANDLED ID 
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                string universal_set2 = "SELECT SUFFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'HANDLE ID'";
                sqlcommand = new SqlCommand(universal_set2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    temp2 = sqldatareader.GetString(0);

                    //temp3 = temp2.Remove(0, Handled_Subject_prefix.Length);
                    NewHandledSubjectID = int.Parse(temp2);
                }
                sqldatareader.Close();
            }
        }

        private void Init_AssignedID()
        {
            //ASSIGNED SECTIONS
            Assigned_id_prefix = getspecifiedprefix.GetAssignedIDPrefix();
            string wildcardquery2 = "SELECT COUNT(*) FROM [Tbl.AssignedSections]";
            sqldataadapter = new SqlDataAdapter(wildcardquery2, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST ASSIGNED ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                string universal_set3 = "SELECT [ASSIGN ID] FROM [Tbl.AssignedSections]";
                sqlcommand = new SqlCommand(universal_set3, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    temp11 = sqldatareader.GetString(0);

                    temp33 = temp11.Remove(0, Assigned_id_prefix.Length);
                    NewAssignedID = int.Parse(temp33) + 1;
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW ASSIGNED ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                string universal_set4 = "SELECT SUFFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'ASSIGN ID'";
                sqlcommand = new SqlCommand(universal_set4, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    temp22 = sqldatareader.GetString(0);

                    //temp3 = temp2.Remove(0, Assigned_id_prefix.Length);
                    NewAssignedID = int.Parse(temp22);
                }
                sqldatareader.Close();
            }
        }

        private void Init_PhotoID()
        {
            //PHOTOS
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

        private void Init_PermissionsID()
        {
            //PERMISSIONS
            Permission_id_prefix = getspecifiedprefix.GetPermissionIDPrefix();
            string wildcardquery3 = "SELECT COUNT(*) FROM [Tbl.Permissions]";
            sqldataadapter = new SqlDataAdapter(wildcardquery3, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST PERMISSION ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                string universal_set7 = "SELECT [PERMISSION ID] FROM [Tbl.Permissions]";
                sqlcommand = new SqlCommand(universal_set7, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    temp111 = sqldatareader.GetString(0);

                    temp333 = temp111.Remove(0, Permission_id_prefix.Length);
                    NewPermissionID = int.Parse(temp333) + 1;
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW PERMISSION ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                string universal_set8 = "SELECT SUFFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'PERMISSION ID'";
                sqlcommand = new SqlCommand(universal_set8, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    temp222 = sqldatareader.GetString(0);

                    //temp3 = temp2.Remove(0, Permission_id_prefix.Length);
                    NewPermissionID = int.Parse(temp222);
                }
                sqldatareader.Close();
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

            catch (Exception) {
                //DO NOTHING SHIT !
            }
        }

        private void Init_FirstIndex_Dropdowns()
        {
            Handled_Sec1_Dropdown.AddItem("NOT SET");
            Handled_Sec2_Dropdown.AddItem("NOT SET");
            Handled_Sec3_Dropdown.AddItem("NOT SET");

            Handled_Sec4_Dropdown.AddItem("NOT SET");
            Handled_Sec5_Dropdown.AddItem("NOT SET");
            Handled_Sec6_Dropdown.AddItem("NOT SET");
            Handled_Sec7_Dropdown.AddItem("NOT SET");

            Handled_Sec8_Dropdown.AddItem("NOT SET");
            Handled_Sec9_Dropdown.AddItem("NOT SET");
            Handled_Sec10_Dropdown.AddItem("NOT SET");
        }

        private void Select_Dropdown_Index()
        {
            Handled_Sec1_Dropdown.selectedIndex = 0;
            Handled_Sec2_Dropdown.selectedIndex = 0;
            Handled_Sec3_Dropdown.selectedIndex = 0;

            Handled_Sec4_Dropdown.selectedIndex = 0;
            Handled_Sec5_Dropdown.selectedIndex = 0;
            Handled_Sec6_Dropdown.selectedIndex = 0;
            Handled_Sec7_Dropdown.selectedIndex = 0;

            Handled_Sec8_Dropdown.selectedIndex = 0;
            Handled_Sec9_Dropdown.selectedIndex = 0;
            Handled_Sec10_Dropdown.selectedIndex = 0;
        }

        private void LoadSectionsList()
        {
            try
            {
                Bunifu.Framework.UI.BunifuDropdown VirtualDropdown;
                VirtualDropdown = new Bunifu.Framework.UI.BunifuDropdown();

                string RetrieveQuery = "SELECT TOP 10 [SECTION NAME] FROM [Tbl.Sections] WHERE [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                Init_FirstIndex_Dropdowns();
                Select_Dropdown_Index();

                while (sqldatareader.Read())
                {
                    VirtualDropdown.AddItem(sqldatareader.GetString(0));
                }
                sqldatareader.Close();

                VirtualDropdown.selectedIndex = 0;
                Handled_Sec1_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());

                VirtualDropdown.selectedIndex = 1;
                Handled_Sec2_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());

                VirtualDropdown.selectedIndex = 2;
                Handled_Sec3_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());

                VirtualDropdown.selectedIndex = 3;
                Handled_Sec4_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());

                VirtualDropdown.selectedIndex = 4;
                Handled_Sec5_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());

                VirtualDropdown.selectedIndex = 5;
                Handled_Sec6_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());

                VirtualDropdown.selectedIndex = 6;
                Handled_Sec7_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());

                VirtualDropdown.selectedIndex = 7;
                Handled_Sec8_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());

                VirtualDropdown.selectedIndex = 8;
                Handled_Sec9_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());

                VirtualDropdown.selectedIndex = 9;
                Handled_Sec10_Dropdown.AddItem(VirtualDropdown.selectedValue.ToString());
            }

            catch (Exception)
            {
                //DONT DISPLAY ANYTHING SHIT !
            }
        }

        private void RetriveSectionData()
        {
            //EXCEPTION 2
            try
            {
                sqlquery4 = "SELECT TOP 10 [SECTION ID], [SECTION NAME], [MAXIMUM STUDENTS]," +
                    " [ENROLLED], [SCHOOL YEAR] FROM [Tbl.Sections] WHERE [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                sqldataadapter = new SqlDataAdapter(sqlquery4, sqlconnection);
                DataTable datatable = new DataTable();

                sqldataadapter.Fill(datatable);
                ListofSectionsGridview.AutoGenerateColumns = false;
                ListofSectionsGridview.DataSource = datatable;

                int value = 1, _row = 0;
                foreach (DataRow row in datatable.Rows)
                {
                    ListofSectionsGridview.Rows[_row].Cells[0].Value = value + ".";
                    value++; _row++;
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Add Section Form Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 3
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

                    AccountPhoto.Image = bitmap;
                    NoChoosenPicture = false;
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Add Teacher Form Exception 3",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 3
            try
            {
                opacityform = new OpacityForm();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();
                
                if (FirstNameTextbox.Text.Trim().Length < 1 || MiddleNameTextbox.Text.Trim().Length < 1 || LastNameTextbox.Text.Trim().Length < 1
                    || BloodTypeTextbox.Text.Trim().Length < 1 || PresentAddressTextbox.Text.Trim().Length < 1 || ReligionTextbox.Text.Trim().Length < 1 
                    || EmailAddressTextbox.Text.Trim().Length < 1 || MobileNumberTextbox.Text.Trim().Length < 1 || UserNameTextbox.Text.Trim().Length < 1 
                    || PasswordTextbox.Text.Trim().Length < 1 || ConfirmPasswordTextbox.Text.Trim().Length < 1)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE THE REQUIRED\nINFORMATIONS BEING ASK !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (English_CheckBox.Checked == false && Science_CheckBox.Checked == false && Math_CheckBox.Checked == false 
                    && Filipino_CheckBox.Checked == false && AP_CheckBox.Checked == false && Mapeh_CheckBox.Checked == false
                    && TLE_CheckBox.Checked == false && ESP_CheckBox.Checked == false)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE SELECT ATLEAST ONE ASSIGNED\nSUBJECT !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (Handled_Sec1_Dropdown.selectedIndex == 0 && Handled_Sec2_Dropdown.selectedIndex == 0 &&
                    Handled_Sec3_Dropdown.selectedIndex == 0 && Handled_Sec4_Dropdown.selectedIndex == 0 &&
                    Handled_Sec5_Dropdown.selectedIndex == 0 && Handled_Sec6_Dropdown.selectedIndex == 0 &&
                    Handled_Sec7_Dropdown.selectedIndex == 0 && Handled_Sec8_Dropdown.selectedIndex == 0 && 
                    Handled_Sec9_Dropdown.selectedIndex == 0 && Handled_Sec10_Dropdown.selectedIndex == 0)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE SELECT ATLEAST ONE ASSIGNED\nSECTION !";

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
                
                else if (isNumber(MobileNumberTextbox.Text.Trim()) == false)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PHONE NUMBER CONTAIN AN INVALID\nCHARACTERS !";

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
                
                else if (NoChoosenPicture == true)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE YOUR PROFILE PICTURE !\nLOWER LEFT IN ACCOUNT DETAILS.";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else
                {
                    //INNER EXCEPTION 33
                    try
                    {
                        //CHECK IF THE NEW USERNAME IS ALREADY TAKEN BY ANOTHER USER
                        string wildcardquery = "SELECT COUNT(*) FROM [Tbl.Users] WHERE USERNAME = '" + 
                            cryptography.Encrypt(UserNameTextbox.Text.Trim()) + "'";

                        sqldataadapter = new SqlDataAdapter(wildcardquery, sqlconnection);
                        DataTable datatable = new DataTable();
                        sqldataadapter.Fill(datatable);

                        //OPPS, USERNAME IS ALREADY TAKEN
                        if (datatable.Rows[0][0].ToString() == "1")
                        {
                            notificationwindow.CaptionText = "OPERATION ABORTED !";
                            notificationwindow.MsgImage.Image = Properties.Resources.error;
                            notificationwindow.MessageText = "OPPS, USERNAME IS ALREADY TAKEN,\nTRY A DIFFERENT ONE !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }

                        //YEAH, USERNAME IS NOT YET TAKEN
                        else if (datatable.Rows[0][0].ToString() == "0")
                        {
                            //CHECK TEACHER VALIDITY
                            string VerifyQuery = "SELECT COUNT(*) FROM [Tbl.Teachers] WHERE [FIRST NAME] = '" +
                                FirstNameTextbox.Text.Trim() + "' AND [MIDDLE NAME] = '" + MiddleNameTextbox.Text.Trim() +
                                "' AND [LAST NAME] = '" + LastNameTextbox.Text.Trim() + "'";

                            sqldataadapter = new SqlDataAdapter(VerifyQuery, sqlconnection);
                            DataTable VirtualTable = new DataTable();
                            sqldataadapter.Fill(VirtualTable);
                            
                            if (VirtualTable.Rows[0][0].ToString() == "0")
                            {
                                //CHECK TEACHER STUFFS VALIDITY

                                /**
                                //FIRST SECTION --> SUBJECT ENGLISH
                                string VerifyQuery1 = "SELECT COUNT(*) FROM [Tbl.TeachersDataTable] WHERE ";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery1, sqlconnection);
                                DataTable DataTable1 = new DataTable();
                                sqldataadapter.Fill(DataTable1);

                                string VerifyQuery2 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery2, sqlconnection);
                                DataTable DataTable2 = new DataTable();
                                sqldataadapter.Fill(DataTable2);

                                string VerifyQuery3 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery3, sqlconnection);
                                DataTable DataTable3 = new DataTable();
                                sqldataadapter.Fill(DataTable3);

                                string VerifyQuery4 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery4, sqlconnection);
                                DataTable DataTable4 = new DataTable();
                                sqldataadapter.Fill(DataTable4);

                                string VerifyQuery5 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery5, sqlconnection);
                                DataTable DataTable5 = new DataTable();
                                sqldataadapter.Fill(DataTable5);

                                string VerifyQuery6 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery6, sqlconnection);
                                DataTable DataTable6 = new DataTable();
                                sqldataadapter.Fill(DataTable6);

                                string VerifyQuery7 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery7, sqlconnection);
                                DataTable DataTable7 = new DataTable();
                                sqldataadapter.Fill(DataTable7);

                                string VerifyQuery8 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery8, sqlconnection);
                                DataTable DataTable8 = new DataTable();
                                sqldataadapter.Fill(DataTable8);

                                string VerifyQuery9 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery9, sqlconnection);
                                DataTable DataTable9 = new DataTable();
                                sqldataadapter.Fill(DataTable9);

                                string VerifyQuery10 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery10, sqlconnection);
                                DataTable DataTable10 = new DataTable();
                                sqldataadapter.Fill(DataTable10);

                                //FIRST SECTION --> SUBJECT SCIENCE
                                string VerifyQuery11 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery11, sqlconnection);
                                DataTable DataTable11 = new DataTable();
                                sqldataadapter.Fill(DataTable11);

                                string VerifyQuery12 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery12, sqlconnection);
                                DataTable DataTable12 = new DataTable();
                                sqldataadapter.Fill(DataTable12);

                                string VerifyQuery13 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery13, sqlconnection);
                                DataTable DataTable13 = new DataTable();
                                sqldataadapter.Fill(DataTable13);

                                string VerifyQuery14 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery14, sqlconnection);
                                DataTable DataTable14 = new DataTable();
                                sqldataadapter.Fill(DataTable14);

                                string VerifyQuery15 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery15, sqlconnection);
                                DataTable DataTable15 = new DataTable();
                                sqldataadapter.Fill(DataTable15);

                                string VerifyQuery16 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery16, sqlconnection);
                                DataTable DataTable16 = new DataTable();
                                sqldataadapter.Fill(DataTable16);

                                string VerifyQuery17 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery17, sqlconnection);
                                DataTable DataTable17 = new DataTable();
                                sqldataadapter.Fill(DataTable17);

                                string VerifyQuery18 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery18, sqlconnection);
                                DataTable DataTable18 = new DataTable();
                                sqldataadapter.Fill(DataTable18);

                                string VerifyQuery19 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery19, sqlconnection);
                                DataTable DataTable19 = new DataTable();
                                sqldataadapter.Fill(DataTable19);

                                string VerifyQuery20 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery20, sqlconnection);
                                DataTable DataTable20 = new DataTable();
                                sqldataadapter.Fill(DataTable20);

                                //FIRST SECTION --> SUBJECT MATHEMATICS
                                string VerifyQuery21 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery21, sqlconnection);
                                DataTable DataTable21 = new DataTable();
                                sqldataadapter.Fill(DataTable21);

                                string VerifyQuery22 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery22, sqlconnection);
                                DataTable DataTable22 = new DataTable();
                                sqldataadapter.Fill(DataTable22);

                                string VerifyQuery23 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery23, sqlconnection);
                                DataTable DataTable23 = new DataTable();
                                sqldataadapter.Fill(DataTable23);

                                string VerifyQuery24 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery24, sqlconnection);
                                DataTable DataTable24 = new DataTable();
                                sqldataadapter.Fill(DataTable24);

                                string VerifyQuery25 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery25, sqlconnection);
                                DataTable DataTable25 = new DataTable();
                                sqldataadapter.Fill(DataTable25);

                                string VerifyQuery26 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery26, sqlconnection);
                                DataTable DataTable26 = new DataTable();
                                sqldataadapter.Fill(DataTable26);

                                string VerifyQuery27 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery27, sqlconnection);
                                DataTable DataTable27 = new DataTable();
                                sqldataadapter.Fill(DataTable27);

                                string VerifyQuery28 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery28, sqlconnection);
                                DataTable DataTable28 = new DataTable();
                                sqldataadapter.Fill(DataTable28);

                                string VerifyQuery29 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery29, sqlconnection);
                                DataTable DataTable29 = new DataTable();
                                sqldataadapter.Fill(DataTable29);

                                string VerifyQuery30 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery30, sqlconnection);
                                DataTable DataTable30 = new DataTable();
                                sqldataadapter.Fill(DataTable30);

                                //FIRST SECTION --> SUBJECT FILIPINO
                                string VerifyQuery31 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery31, sqlconnection);
                                DataTable DataTable31 = new DataTable();
                                sqldataadapter.Fill(DataTable31);

                                string VerifyQuery32 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery32, sqlconnection);
                                DataTable DataTable32 = new DataTable();
                                sqldataadapter.Fill(DataTable32);

                                string VerifyQuery33 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery33, sqlconnection);
                                DataTable DataTable33 = new DataTable();
                                sqldataadapter.Fill(DataTable33);

                                string VerifyQuery34 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery34, sqlconnection);
                                DataTable DataTable34 = new DataTable();
                                sqldataadapter.Fill(DataTable34);

                                string VerifyQuery35 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery35, sqlconnection);
                                DataTable DataTable35 = new DataTable();
                                sqldataadapter.Fill(DataTable35);

                                string VerifyQuery36 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery36, sqlconnection);
                                DataTable DataTable36 = new DataTable();
                                sqldataadapter.Fill(DataTable36);

                                string VerifyQuery37 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery37, sqlconnection);
                                DataTable DataTable37 = new DataTable();
                                sqldataadapter.Fill(DataTable37);

                                string VerifyQuery38 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery38, sqlconnection);
                                DataTable DataTable38 = new DataTable();
                                sqldataadapter.Fill(DataTable38);

                                string VerifyQuery39 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery39, sqlconnection);
                                DataTable DataTable39 = new DataTable();
                                sqldataadapter.Fill(DataTable39);

                                string VerifyQuery40 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery40, sqlconnection);
                                DataTable DataTable40 = new DataTable();
                                sqldataadapter.Fill(DataTable40);

                                //FIRST SECTION --> SUBJECT ARALING PANLIPUNAN
                                string VerifyQuery41 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery41, sqlconnection);
                                DataTable DataTable41 = new DataTable();
                                sqldataadapter.Fill(DataTable41);

                                string VerifyQuery42 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery42, sqlconnection);
                                DataTable DataTable42 = new DataTable();
                                sqldataadapter.Fill(DataTable42);

                                string VerifyQuery43 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery43, sqlconnection);
                                DataTable DataTable43 = new DataTable();
                                sqldataadapter.Fill(DataTable43);

                                string VerifyQuery44 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery44, sqlconnection);
                                DataTable DataTable44 = new DataTable();
                                sqldataadapter.Fill(DataTable44);

                                string VerifyQuery45 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery45, sqlconnection);
                                DataTable DataTable45 = new DataTable();
                                sqldataadapter.Fill(DataTable45);

                                string VerifyQuery46 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery46, sqlconnection);
                                DataTable DataTable46 = new DataTable();
                                sqldataadapter.Fill(DataTable46);

                                string VerifyQuery47 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery47, sqlconnection);
                                DataTable DataTable47 = new DataTable();
                                sqldataadapter.Fill(DataTable47);

                                string VerifyQuery48 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery48, sqlconnection);
                                DataTable DataTable48 = new DataTable();
                                sqldataadapter.Fill(DataTable48);

                                string VerifyQuery49 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery49, sqlconnection);
                                DataTable DataTable49 = new DataTable();
                                sqldataadapter.Fill(DataTable49);

                                string VerifyQuery50 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery50, sqlconnection);
                                DataTable DataTable50 = new DataTable();
                                sqldataadapter.Fill(DataTable50);

                                //FIRST SECTION --> SUBJECT MAPEH
                                string VerifyQuery51 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery51, sqlconnection);
                                DataTable DataTable51 = new DataTable();
                                sqldataadapter.Fill(DataTable51);

                                string VerifyQuery52 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery52, sqlconnection);
                                DataTable DataTable52 = new DataTable();
                                sqldataadapter.Fill(DataTable52);

                                string VerifyQuery53 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery53, sqlconnection);
                                DataTable DataTable53 = new DataTable();
                                sqldataadapter.Fill(DataTable53);

                                string VerifyQuery54 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery54, sqlconnection);
                                DataTable DataTable54 = new DataTable();
                                sqldataadapter.Fill(DataTable54);

                                string VerifyQuery55 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery55, sqlconnection);
                                DataTable DataTable55 = new DataTable();
                                sqldataadapter.Fill(DataTable55);

                                string VerifyQuery56 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery56, sqlconnection);
                                DataTable DataTable56 = new DataTable();
                                sqldataadapter.Fill(DataTable56);

                                string VerifyQuery57 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery57, sqlconnection);
                                DataTable DataTable57 = new DataTable();
                                sqldataadapter.Fill(DataTable57);

                                string VerifyQuery58 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery58, sqlconnection);
                                DataTable DataTable58 = new DataTable();
                                sqldataadapter.Fill(DataTable58);

                                string VerifyQuery59 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery59, sqlconnection);
                                DataTable DataTable59 = new DataTable();
                                sqldataadapter.Fill(DataTable59);

                                string VerifyQuery60 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery60, sqlconnection);
                                DataTable DataTable60 = new DataTable();
                                sqldataadapter.Fill(DataTable60);

                                //FIRST SECTION --> SUBJECT TLE
                                string VerifyQuery61 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery61, sqlconnection);
                                DataTable DataTable61 = new DataTable();
                                sqldataadapter.Fill(DataTable61);

                                string VerifyQuery62 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery62, sqlconnection);
                                DataTable DataTable62 = new DataTable();
                                sqldataadapter.Fill(DataTable62);

                                string VerifyQuery63 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery63, sqlconnection);
                                DataTable DataTable63 = new DataTable();
                                sqldataadapter.Fill(DataTable63);

                                string VerifyQuery64 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery64, sqlconnection);
                                DataTable DataTable64 = new DataTable();
                                sqldataadapter.Fill(DataTable64);

                                string VerifyQuery65 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery65, sqlconnection);
                                DataTable DataTable65 = new DataTable();
                                sqldataadapter.Fill(DataTable65);

                                string VerifyQuery66 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery66, sqlconnection);
                                DataTable DataTable66 = new DataTable();
                                sqldataadapter.Fill(DataTable66);

                                string VerifyQuery67 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery67, sqlconnection);
                                DataTable DataTable67 = new DataTable();
                                sqldataadapter.Fill(DataTable67);

                                string VerifyQuery68 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery68, sqlconnection);
                                DataTable DataTable68 = new DataTable();
                                sqldataadapter.Fill(DataTable68);

                                string VerifyQuery69 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery69, sqlconnection);
                                DataTable DataTable69 = new DataTable();
                                sqldataadapter.Fill(DataTable69);

                                string VerifyQuery70 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery70, sqlconnection);
                                DataTable DataTable70 = new DataTable();
                                sqldataadapter.Fill(DataTable70);

                                //FIRST SECTION --> SUBJECT ESP
                                string VerifyQuery71 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery71, sqlconnection);
                                DataTable DataTable71 = new DataTable();
                                sqldataadapter.Fill(DataTable71);

                                string VerifyQuery72 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery72, sqlconnection);
                                DataTable DataTable72 = new DataTable();
                                sqldataadapter.Fill(DataTable72);

                                string VerifyQuery73 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery73, sqlconnection);
                                DataTable DataTable73 = new DataTable();
                                sqldataadapter.Fill(DataTable73);

                                string VerifyQuery74 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery74, sqlconnection);
                                DataTable DataTable74 = new DataTable();
                                sqldataadapter.Fill(DataTable74);

                                string VerifyQuery75 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery75, sqlconnection);
                                DataTable DataTable75 = new DataTable();
                                sqldataadapter.Fill(DataTable75);

                                string VerifyQuery76 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery76, sqlconnection);
                                DataTable DataTable76 = new DataTable();
                                sqldataadapter.Fill(DataTable76);

                                string VerifyQuery77 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery77, sqlconnection);
                                DataTable DataTable77 = new DataTable();
                                sqldataadapter.Fill(DataTable77);

                                string VerifyQuery78 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery78, sqlconnection);
                                DataTable DataTable78 = new DataTable();
                                sqldataadapter.Fill(DataTable78);

                                string VerifyQuery79 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery79, sqlconnection);
                                DataTable DataTable79 = new DataTable();
                                sqldataadapter.Fill(DataTable79);

                                string VerifyQuery80 = "";
                                sqldataadapter = new SqlDataAdapter(VerifyQuery80, sqlconnection);
                                DataTable DataTable80 = new DataTable();
                                sqldataadapter.Fill(DataTable80);
                                */

                                //INSERT INTO TEACHER'S TABLE
                                string query1, query2, query3, query4, query5, query6, query7;
                                query1 = "INSERT INTO [Tbl.Teachers]([TEACHER ID], [USER ID], [FIRST NAME], [MIDDLE NAME], [LAST NAME]," +
                                    "GENDER, [BIRTH DATE], [PRESENT ADDRESS], RELIGION, [BLOOD TYPE], [EMAIL ADDRESS], [MOBILE NUMBER])" +
                                    "VALUES(@teacherid, @userid, @firstname, @middlename, @lastname, @gender, @birthdate, @presentaddress," +
                                    "@religion, @bloodtype, @emailaddress, @mobilenumber)";

                                sqlcommand = new SqlCommand(query1, sqlconnection);
                                sqlcommand.Parameters.AddWithValue("@teacherid", IncNewTeacherID.ToString());
                                sqlcommand.Parameters.AddWithValue("@userid", IncNewUserID.ToString());
                                sqlcommand.Parameters.AddWithValue("@firstname", FirstNameTextbox.Text.Trim());

                                sqlcommand.Parameters.AddWithValue("@middlename", MiddleNameTextbox.Text.Trim());
                                sqlcommand.Parameters.AddWithValue("@lastname", LastNameTextbox.Text.Trim());
                                sqlcommand.Parameters.AddWithValue("@gender", GenderDropdown.selectedValue.ToString());

                                sqlcommand.Parameters.AddWithValue("@birthdate", BirthdayPicker.Value.ToLongDateString().ToString());
                                sqlcommand.Parameters.AddWithValue("@presentaddress", PresentAddressTextbox.Text.Trim());
                                sqlcommand.Parameters.AddWithValue("@religion", ReligionTextbox.Text.Trim());

                                sqlcommand.Parameters.AddWithValue("@bloodtype", BloodTypeTextbox.Text.Trim());
                                sqlcommand.Parameters.AddWithValue("@emailaddress", EmailAddressTextbox.Text.Trim());
                                sqlcommand.Parameters.AddWithValue("@mobilenumber", MobileNumberTextbox.Text.Trim());
                                sqlcommand.ExecuteNonQuery();

                                //INSERT INTO USER'S TABLE
                                query2 = "INSERT INTO [Tbl.Users]([USER ID], USERNAME, PASSWORD, [ACCOUNT STATUS], [ACCOUNT TYPE], [LAST LOGIN]," +
                                    "[IS PWD CHANGED], [SITUATION STATUS]) VALUES(@userid, @username, @password, @accountstatus, @account_type, @last_login, @ispwschanged, @stat)";

                                sqlcommand = new SqlCommand(query2, sqlconnection);
                                sqlcommand.Parameters.AddWithValue("@userid", IncNewUserID.ToString());
                                sqlcommand.Parameters.AddWithValue("@username", cryptography.Encrypt(UserNameTextbox.Text));
                                sqlcommand.Parameters.AddWithValue("@password", cryptography.Encrypt(PasswordTextbox.Text));
                                sqlcommand.Parameters.AddWithValue("@accountstatus", "Active");

                                sqlcommand.Parameters.AddWithValue("@account_type", AccountTypeDropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@last_login", "NO LOGIN HISTORY");
                                sqlcommand.Parameters.AddWithValue("@ispwschanged", "False");
                                sqlcommand.Parameters.AddWithValue("@stat", "0");
                                sqlcommand.ExecuteNonQuery();

                                //INSERT INTO HANDLED SUBJECT'S TABLE
                                query3 = "INSERT INTO [Tbl.HandledSubjects]([HANDLE ID], [TEACHER ID], ENGLISH, MATHEMATICS, SCIENCE, FILIPINO, MAPEH," +
                                    "[ARALING PANLIPUNAN], ESP, TLE)" + "VALUES(@handleid, @teacherid, @english, @mathematics, @science, @filipino, @mapeh, @ap, @esp, @tle)";

                                sqlcommand = new SqlCommand(query3, sqlconnection);
                                sqlcommand.Parameters.AddWithValue("@handleid", Handled_Subject_prefix + NewHandledSubjectID.ToString());
                                sqlcommand.Parameters.AddWithValue("@teacherid", IncNewTeacherID.ToString());
                                sqlcommand.Parameters.AddWithValue("@english", English_CheckBox.Checked == true ? "English" : "");
                                sqlcommand.Parameters.AddWithValue("@mathematics", Math_CheckBox.Checked == true ? "Mathematics" : "");

                                sqlcommand.Parameters.AddWithValue("@science", Science_CheckBox.Checked == true ? "Science" : "");
                                sqlcommand.Parameters.AddWithValue("@filipino", Filipino_CheckBox.Checked == true ? "Filipino" : "");
                                sqlcommand.Parameters.AddWithValue("@mapeh", Mapeh_CheckBox.Checked == true ? "Mapeh" : "");

                                sqlcommand.Parameters.AddWithValue("@ap", AP_CheckBox.Checked == true ? "Araling Panlipunan" : "");
                                sqlcommand.Parameters.AddWithValue("@esp", ESP_CheckBox.Checked == true ? "Edukasyon sa Pagpapakatao" : "");
                                sqlcommand.Parameters.AddWithValue("@tle", TLE_CheckBox.Checked == true ? "Technology Livelihood Education" : "");
                                sqlcommand.ExecuteNonQuery();

                                //INSERT INTO ASSIGNED SECTION'S TABLE
                                query4 = "INSERT INTO [Tbl.AssignedSections]([ASSIGN ID], [TEACHER ID], [ASSIGNED SECTION 1], [ASSIGNED SECTION 2], [ASSIGNED SECTION 3]," +
                                    "[ASSIGNED SECTION 4], [ASSIGNED SECTION 5], [ASSIGNED SECTION 6], [ASSIGNED SECTION 7], [ASSIGNED SECTION 8], [ASSIGNED SECTION 9]," +
                                    "[ASSIGNED SECTION 10]) VALUES(@assignid, @teacherid, @asc1, @asc2, @asc3, @asc4, @asc5, @asc6, @asc7, @asc8, @asc9, @asc10)";

                                sqlcommand = new SqlCommand(query4, sqlconnection);
                                sqlcommand.Parameters.AddWithValue("@assignid", Assigned_id_prefix + NewAssignedID.ToString());
                                sqlcommand.Parameters.AddWithValue("@teacherid", IncNewTeacherID.ToString());

                                sqlcommand.Parameters.AddWithValue("@asc1", Handled_Sec1_Dropdown.selectedIndex == 0 ? "" : Handled_Sec1_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@asc2", Handled_Sec2_Dropdown.selectedIndex == 0 ? "" : Handled_Sec2_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@asc3", Handled_Sec3_Dropdown.selectedIndex == 0 ? "" : Handled_Sec3_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@asc4", Handled_Sec4_Dropdown.selectedIndex == 0 ? "" : Handled_Sec4_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@asc5", Handled_Sec5_Dropdown.selectedIndex == 0 ? "" : Handled_Sec5_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@asc6", Handled_Sec6_Dropdown.selectedIndex == 0 ? "" : Handled_Sec6_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@asc7", Handled_Sec7_Dropdown.selectedIndex == 0 ? "" : Handled_Sec7_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@asc8", Handled_Sec8_Dropdown.selectedIndex == 0 ? "" : Handled_Sec8_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@asc9", Handled_Sec9_Dropdown.selectedIndex == 0 ? "" : Handled_Sec9_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@asc10", Handled_Sec10_Dropdown.selectedIndex == 0 ? "" : Handled_Sec10_Dropdown.selectedValue.ToString());
                                sqlcommand.ExecuteNonQuery();

                                //INSERT INTO USERS'S PHOTO TABLE
                                FileStream filestream = new FileStream(@ImageFilename, FileMode.Open, FileAccess.Read);
                                byte[] imgByteArr = new byte[filestream.Length];

                                filestream.Read(imgByteArr, 0, Convert.ToInt32(filestream.Length));
                                filestream.Close();

                                query5 = "INSERT INTO [Tbl.Photos]([PICTURE ID], [USER ID], [FILE NAME], PICTURE) VALUES(@pictureid, @userid, @filename, @picture)";
                                sqlcommand = new SqlCommand(query5, sqlconnection);
                                sqlcommand.Parameters.AddWithValue("@pictureid", Photos_id_prefix + NewPhotoID.ToString());
                                sqlcommand.Parameters.AddWithValue("@userid", IncNewUserID.ToString());
                                sqlcommand.Parameters.AddWithValue("@filename", ImageFilename.ToString());
                                sqlcommand.Parameters.AddWithValue("@picture", imgByteArr);
                                sqlcommand.ExecuteNonQuery();

                                //INSERT INTO PERMISSIONS TABLE
                                query6 = "INSERT INTO [Tbl.Permissions]([PERMISSION ID], [USER ID], [TEACHER ID], [PMS-01], [PMS-02], [PMS-03]) VALUES(@pmsid, @uid, @tid, @pms01, @pms02, @pms03)";
                                sqlcommand = new SqlCommand(query6, sqlconnection);
                                sqlcommand.Parameters.AddWithValue("@pmsid", Permission_id_prefix + NewPermissionID.ToString());
                                sqlcommand.Parameters.AddWithValue("@uid", IncNewUserID.ToString());
                                sqlcommand.Parameters.AddWithValue("@tid", IncNewTeacherID.ToString());

                                sqlcommand.Parameters.AddWithValue("@pms01", "DENY");
                                sqlcommand.Parameters.AddWithValue("@pms02", "DENY");
                                sqlcommand.Parameters.AddWithValue("@pms03", "DENY");
                                sqlcommand.ExecuteNonQuery();

                                //INSERT INTO TEACHERS DATA TABLE
                                query7 = "INSERT INTO [Tbl.TeachersDataTable]([TEACHER ID], [USER ID], [AS1], [AS2], [AS3], [AS4], [AS5], [AS6], [AS7], [AS8], [AS9], [AS10]," +
                                    "[HS1], [HS2], [HS3], [HS4], [HS5], [HS6], [HS7], [HS8]) VALUES(@tid, @uid, @as1, @as2, @as3, @as4, @as5, @as6, @as7, @as8, @as9, @as10," +
                                    "@hs1, @hs2, @hs3, @hs4, @hs5, @hs6, @hs7, @hs8)";
                                
                                sqlcommand = new SqlCommand(query7, sqlconnection);
                                sqlcommand.Parameters.AddWithValue("@tid", IncNewTeacherID.ToString());
                                sqlcommand.Parameters.AddWithValue("@uid", IncNewUserID.ToString());

                                sqlcommand.Parameters.AddWithValue("@as1", Handled_Sec1_Dropdown.selectedIndex == 0 ? "" : Handled_Sec1_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@as2", Handled_Sec2_Dropdown.selectedIndex == 0 ? "" : Handled_Sec2_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@as3", Handled_Sec3_Dropdown.selectedIndex == 0 ? "" : Handled_Sec3_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@as4", Handled_Sec4_Dropdown.selectedIndex == 0 ? "" : Handled_Sec4_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@as5", Handled_Sec5_Dropdown.selectedIndex == 0 ? "" : Handled_Sec5_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@as6", Handled_Sec6_Dropdown.selectedIndex == 0 ? "" : Handled_Sec6_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@as7", Handled_Sec7_Dropdown.selectedIndex == 0 ? "" : Handled_Sec7_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@as8", Handled_Sec8_Dropdown.selectedIndex == 0 ? "" : Handled_Sec8_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@as9", Handled_Sec9_Dropdown.selectedIndex == 0 ? "" : Handled_Sec9_Dropdown.selectedValue.ToString());
                                sqlcommand.Parameters.AddWithValue("@as10", Handled_Sec10_Dropdown.selectedIndex == 0 ? "" : Handled_Sec10_Dropdown.selectedValue.ToString());

                                sqlcommand.Parameters.AddWithValue("@hs1", English_CheckBox.Checked == true ? "English" : "");
                                sqlcommand.Parameters.AddWithValue("@hs2", Math_CheckBox.Checked == true ? "Mathematics" : "");
                                sqlcommand.Parameters.AddWithValue("@hs3", Science_CheckBox.Checked == true ? "Science" : "");
                                sqlcommand.Parameters.AddWithValue("@hs4", Filipino_CheckBox.Checked == true ? "Filipino" : "");
                                sqlcommand.Parameters.AddWithValue("@hs5", Mapeh_CheckBox.Checked == true ? "Mapeh" : "");
                                sqlcommand.Parameters.AddWithValue("@hs6", AP_CheckBox.Checked == true ? "Araling Panlipunan" : "");
                                sqlcommand.Parameters.AddWithValue("@hs7", ESP_CheckBox.Checked == true ? "Edukasyon sa Pagpapakatao" : "");
                                sqlcommand.Parameters.AddWithValue("@hs8", TLE_CheckBox.Checked == true ? "Technology Livelihood Education" : "");
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

                            else if (VirtualTable.Rows[0][0].ToString() == "1") 
                            {
                                notificationwindow.CaptionText = "MESSAGE CONTENT";
                                notificationwindow.MsgImage.Image = Properties.Resources.error;
                                notificationwindow.MessageText = "THIS TEACHER IS ALREADY REGISTERED !";

                                darkeropacityform.Show();
                                notificationwindow.ShowDialog();
                                darkeropacityform.Hide();
                            }
                        }
                    }

                    catch (Exception exception)
                    {
                        opacityform.Show();
                        MessageBox.Show(exception.Message.ToString(), "@Add Teacher Form Inner Exception 33",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Add Teacher Form Exception 3",
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        private void ResetButton_Click(object sender, EventArgs e)
        {
            Reseter = new ResetControlState();
            Reseter.Teacher_ResetAllControlState(this);

            Handled_Sec1_Dropdown.selectedIndex = 0;
            Handled_Sec2_Dropdown.selectedIndex = 0;
            Handled_Sec3_Dropdown.selectedIndex = 0;
            Handled_Sec4_Dropdown.selectedIndex = 0;
            Handled_Sec5_Dropdown.selectedIndex = 0;
            Handled_Sec6_Dropdown.selectedIndex = 0;
            Handled_Sec7_Dropdown.selectedIndex = 0;
            Handled_Sec8_Dropdown.selectedIndex = 0;
            Handled_Sec9_Dropdown.selectedIndex = 0;
            Handled_Sec10_Dropdown.selectedIndex = 0;
        }

        private void UserIDTextbox_KeyDown(object sender, KeyEventArgs e)
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

                if (PasswordTextbox.Text.Trim().Length < 8)
                {
                    PasswordPercentage.Size = new Size(80, 10);
                    PasswordPercentage.LineColor = Color.Red;
                    PasswordPercentageLabel.Text = "WEAK !";

                    PasswordPercentage.Visible = true;
                    PasswordPercentageLabel.Visible = true;
                }

                else if (PasswordTextbox.Text.Trim().Length < 12)
                {
                    PasswordPercentage.Size = new Size(130, 10);
                    PasswordPercentage.LineColor = Color.SteelBlue;
                    PasswordPercentageLabel.Text = "MEDIUM !";

                    PasswordPercentage.Visible = true;
                    PasswordPercentageLabel.Visible = true;
                }

                else
                {
                    PasswordPercentage.Size = new Size(223, 10);
                    PasswordPercentage.LineColor = Color.LimeGreen;
                    PasswordPercentageLabel.Text = "STRONG !";

                    PasswordPercentage.Visible = true;
                    PasswordPercentageLabel.Visible = true;
                }
            }

            else if (PasswordTextbox.Text.Trim().Length < 1)
            {
                ShowPasswordImg1.Visible = false;
                PasswordPercentage.Visible = false;
                PasswordPercentageLabel.Visible = false;
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

        private void ESP_CheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            BrowseButton_Click(sender, e);
        }

        private void Handled_Sec10_Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void bunifuFlatButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
        
        private void ShowPasswordImg1_Click(object sender, EventArgs e)
        {
            //SHOW
            if (PasswordTextbox.isPassword == true)
            {
                ShowPasswordImg1.Image = Properties.Resources.Hide;
                PasswordTextbox.isPassword = false;
            }

            //HIDE
            else if (PasswordTextbox.isPassword == false)
            {
                ShowPasswordImg1.Image = Properties.Resources.Show;
                PasswordTextbox.isPassword = true;
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
                ShowPasswordImg2.Image = Properties.Resources.Hide;
                ConfirmPasswordTextbox.isPassword = false;
            }

            //HIDE
            else if (ConfirmPasswordTextbox.isPassword == false)
            {
                ShowPasswordImg2.Image = Properties.Resources.Show;
                ConfirmPasswordTextbox.isPassword = true;
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

        private void AddTeacherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlconnection.Close();
            e.Cancel = false;
        }
    }
}
