using System;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class AccountInformationForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;

        SQLConnectionConfig sqlconnectionconfig;
        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;
        private string UserID, TeacherID;
        protected string ImageFilename, CurrentSchoolYear, indicator;

        public AccountInformationForm()
        {
            InitializeComponent();
        }

        private void AccountInformationForm_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2));
            
            //EXCEPTION 1
            try
            {
                variables = new Variables();
                opacityform = new OpacityForm();
                cryptography = new Cryptography();
                sqlconnectionconfig = new SQLConnectionConfig();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string tempdata = registrykey.GetValue("SQLServerConnectionString").ToString();
                TeacherID = registrykey.GetValue("Teacher ID").ToString();
                UserID = registrykey.GetValue("User ID").ToString();

                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                //INNER EXCEPTION 1
                try
                {
                    RetrievePersonalInformation();
                    RetrieveAccountInformation();
                    LoadAccountImage();
                    GetCurrentSchoolYear();

                    Init_1();
                    RetrieveHandledSubjects();

                    Init_2();
                    RetrieveAssignedSections();

                    LoadSectionsList();
                    Where_to_Check_Checkboxes();
                    Enable_DisAble_Update_Buttons();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "Account Information Form Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "Account Information Form Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void RetrievePersonalInformation()
        {
            string RetrieveQuery = "SELECT * FROM [Tbl.Teachers] WHERE [USER ID] = '" + UserID + "'";
            sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                TeacherIDTextbox.Text = sqldatareader.GetString(0);
                UserIDTextbox.Text = sqldatareader.GetString(1);
                FirstNameTextbox.Text = sqldatareader.GetString(2);
                MiddleNameTextbox.Text = sqldatareader.GetString(3);

                LastNameTextbox.Text = sqldatareader.GetString(4);
                GenderTextbox.Text = sqldatareader.GetString(5);
                BirthDateTextbox.Text = sqldatareader.GetString(6);
                PresentAddressTextbox.Text = sqldatareader.GetString(7);

                ReligionTextbox.Text = sqldatareader.GetString(8);
                BloodTypeTextbox.Text = sqldatareader.GetString(9);
                EmailAddressTextbox.Text = sqldatareader.GetString(10);
                MobileNumberTextbox.Text = sqldatareader.GetString(11);

                if ((FirstNameTextbox.Text.Trim() + MiddleNameTextbox.Text.Trim() + LastNameTextbox.Text.Trim()).Length > 25)
                    Namelabel.Text = (FirstNameTextbox.Text + " " + LastNameTextbox.Text).ToUpper();
                else
                    Namelabel.Text = (FirstNameTextbox.Text + " " + MiddleNameTextbox.Text + " " + LastNameTextbox.Text).ToUpper();
                
            }
            sqldatareader.Close();
        }

        private void RetrieveAccountInformation()
        {
            cryptography = new Cryptography();
            string RetrieveQuery = "SELECT USERNAME, PASSWORD, [ACCOUNT TYPE] FROM [Tbl.Users] WHERE [USER ID] = '" + UserID + "'";
            sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                UserNameTextbox.Text = cryptography.Decrypt(sqldatareader.GetString(0));
                PasswordTextbox.Text = cryptography.Decrypt(sqldatareader.GetString(1));
                ConfirmPasswordTextbox.Text = cryptography.Decrypt(sqldatareader.GetString(1));
                AccessLevellabel.Text = sqldatareader.GetString(2).ToUpper();
            }
            sqldatareader.Close();
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
                    AccountpictureBox.Image = Image.FromStream(new MemoryStream(ImageArray));
                }   
            }

            catch (Exception)
            {
                //DON'T DISPLAY ANYTHING SHIT !
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

        private void RetrieveAssignedSections()
        {
            string RetrieveQuery = "SELECT * FROM [Tbl.AssignedSections] WHERE [TEACHER ID] = '" + TeacherID + "'";
            sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();
            
            while (sqldatareader.Read())
            {
                int index = 2;
                for (int iterator = 0; iterator < 10; iterator++)
                {
                    SectionsDropdown.AddItem(sqldatareader.GetString(index));
                    index++;
                }
            }
            sqldatareader.Close();
            Sections_Old_Data();
            
            try
            {
                SectionsDropdown.selectedIndex = 0;
                SectionsGridView.Rows[0].Cells[1].Value = SectionsDropdown.selectedValue.ToString();

                SectionsDropdown.selectedIndex = 1;
                SectionsGridView.Rows[1].Cells[1].Value = SectionsDropdown.selectedValue.ToString();

                SectionsDropdown.selectedIndex = 2;
                SectionsGridView.Rows[2].Cells[1].Value = SectionsDropdown.selectedValue.ToString();

                SectionsDropdown.selectedIndex = 3;
                SectionsGridView.Rows[3].Cells[1].Value = SectionsDropdown.selectedValue.ToString();

                SectionsDropdown.selectedIndex = 4;
                SectionsGridView.Rows[4].Cells[1].Value = SectionsDropdown.selectedValue.ToString();

                SectionsDropdown.selectedIndex = 5;
                SectionsGridView.Rows[5].Cells[1].Value = SectionsDropdown.selectedValue.ToString();

                SectionsDropdown.selectedIndex = 6;
                SectionsGridView.Rows[6].Cells[1].Value = SectionsDropdown.selectedValue.ToString();

                SectionsDropdown.selectedIndex = 7;
                SectionsGridView.Rows[7].Cells[1].Value = SectionsDropdown.selectedValue.ToString();

                SectionsDropdown.selectedIndex = 8;
                SectionsGridView.Rows[8].Cells[1].Value = SectionsDropdown.selectedValue.ToString();

                SectionsDropdown.selectedIndex = 9;
                SectionsGridView.Rows[9].Cells[1].Value = SectionsDropdown.selectedValue.ToString();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        private void Sections_Old_Data()
        {
            for (int iterator = 0; iterator < 10; iterator++)
            {
                SectionsDropdown.RemoveItem("");
            }
        }

        private void Where_to_Check_Checkboxes()
        {
            try
            {
                int row = 0;
                for (int Iterator = 0; Iterator < 8; Iterator++)
                {
                    if (SubjectsGridView.Rows[row].Cells[1].Value.ToString() == "ENGLISH")
                        English_CheckBox.Checked = true;
                    else if (SubjectsGridView.Rows[row].Cells[1].Value.ToString() == "SCIENCE")
                        Science_CheckBox.Checked = true;
                    else if (SubjectsGridView.Rows[row].Cells[1].Value.ToString() == "MATHEMATICS")
                        Math_CheckBox.Checked = true;
                    else if (SubjectsGridView.Rows[row].Cells[1].Value.ToString() == "FILIPINO")
                        Filipino_CheckBox.Checked = true;
                    else if (SubjectsGridView.Rows[row].Cells[1].Value.ToString() == "ARALING PANLIPUNAN")
                        AP_CheckBox.Checked = true;
                    else if (SubjectsGridView.Rows[row].Cells[1].Value.ToString() == "MAPEH")
                        Mapeh_CheckBox.Checked = true;
                    else if (SubjectsGridView.Rows[row].Cells[1].Value.ToString() == "TECHNOLOGY LIVELIHOOD EDUCATION")
                        TLE_CheckBox.Checked = true;
                    else if (SubjectsGridView.Rows[row].Cells[1].Value.ToString() == "EDUKASYON SA PAGPAPAKATAO")
                        ESP_CheckBox.Checked = true;

                    row++;
                }
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        private void RetrieveHandledSubjects()
        {
            string RetrieveQuery = "SELECT * FROM [Tbl.HandledSubjects] WHERE [TEACHER ID] = '" + TeacherID + "'";
            sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                int index = 2;
                for (int iterator = 0; iterator < 8; iterator++)
                {
                    SubjectsDropdown.AddItem(sqldatareader.GetString(index).ToUpper());
                    index++;
                }
            }
            sqldatareader.Close();
            Subjects_Old_Data();

            SubjectsDropdown.selectedIndex = 0;
            if (SubjectsDropdown.selectedValue.ToString() != "NOT APPLICABLE")
            {
                try
                {
                    SubjectsDropdown.selectedIndex = 0;
                    SubjectsGridView.Rows[0].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 1;
                    SubjectsGridView.Rows[1].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 2;
                    SubjectsGridView.Rows[2].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 3;
                    SubjectsGridView.Rows[3].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 4;
                    SubjectsGridView.Rows[4].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 5;
                    SubjectsGridView.Rows[5].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 6;
                    SubjectsGridView.Rows[6].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 7;
                    SubjectsGridView.Rows[7].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();
                }

                catch (Exception)
                {
                    //DON'T DO ANYTHING BITCH !
                }
            }

            else
            {
                try
                {
                    SubjectsDropdown.selectedIndex = 0;
                    SubjectsGridView.Rows[0].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 1;
                    SubjectsGridView.Rows[1].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 2;
                    SubjectsGridView.Rows[2].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 3;
                    SubjectsGridView.Rows[3].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 4;
                    SubjectsGridView.Rows[4].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 5;
                    SubjectsGridView.Rows[5].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 6;
                    SubjectsGridView.Rows[6].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();

                    SubjectsDropdown.selectedIndex = 7;
                    SubjectsGridView.Rows[7].Cells[1].Value = SubjectsDropdown.selectedValue.ToString();
                }

                catch (Exception)
                {
                    //DON'T DO ANYTHING BITCH !
                }
            }
        }
        
        private void Subjects_Old_Data()
        {
            for (int iterator = 0; iterator < 8; iterator++)
            {
                SubjectsDropdown.RemoveItem("");
            }
        }

        private void Init_1()
        {
            int iteratethisvalue = 1;
            for (int iterator = 0; iterator < 8; iterator++)
            {
                SubjectsGridView.Rows.Add();
                SubjectsGridView.Rows[iterator].Cells[0].Value = iteratethisvalue + ".";
                iteratethisvalue++;
            }
        }

        private void Init_2()
        {
            int iteratethisvalue = 1;
            for (int iterator = 0; iterator < 10; iterator++)
            {
                SectionsGridView.Rows.Add();
                SectionsGridView.Rows[iterator].Cells[0].Value = iteratethisvalue + ".";
                iteratethisvalue++;
            }
        }

        private void EnableControls()
        {
            FirstNameTextbox.Enabled = true;
            MiddleNameTextbox.Enabled = true;
            LastNameTextbox.Enabled = true;
            BirthDateTextbox.Enabled = true;
            GenderTextbox.Enabled = true;
            BloodTypeTextbox.Enabled = true;
            PresentAddressTextbox.Enabled = true;
            ReligionTextbox.Enabled = true;
            EmailAddressTextbox.Enabled = true;
            MobileNumberTextbox.Enabled = true;
        }

        private void DisableControls()
        {
            FirstNameTextbox.Enabled = false;
            MiddleNameTextbox.Enabled = false;
            LastNameTextbox.Enabled = false;
            BirthDateTextbox.Enabled = false;
            GenderTextbox.Enabled = false;
            BloodTypeTextbox.Enabled = false;
            PresentAddressTextbox.Enabled = false;
            ReligionTextbox.Enabled = false;
            EmailAddressTextbox.Enabled = false;
            MobileNumberTextbox.Enabled = false;
        }

        private void ResetTextBoxes()
        {
            FirstNameTextbox.ResetText();
            MiddleNameTextbox.ResetText();
            LastNameTextbox.ResetText();
            BirthDateTextbox.ResetText();
            GenderTextbox.ResetText();
            BloodTypeTextbox.ResetText();
            PresentAddressTextbox.ResetText();
            ReligionTextbox.ResetText();
            EmailAddressTextbox.ResetText();
            MobileNumberTextbox.ResetText();
        }

        private void Enable_DisAble_Update_Buttons()
        {
            try
            {
                string RetrieveQuery = "SELECT VALUE FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG105'";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    indicator = sqldatareader.GetString(0);

                    if (indicator.Equals("1"))
                    {
                        UpdateAssignedSectionsButton.Enabled = true; UpdateHandledSubjectButton.Enabled = true;
                        UpdateAssignedSectionsButton.Cursor = Cursors.Default; UpdateHandledSubjectButton.Cursor = Cursors.Default;
                    }
                        
                    else if (indicator.Equals("0"))
                    {
                        UpdateAssignedSectionsButton.Enabled = false; UpdateHandledSubjectButton.Enabled = false;
                        UpdateAssignedSectionsButton.Cursor = Cursors.No; UpdateHandledSubjectButton.Cursor = Cursors.No;
                    }

                    else
                    {
                        UpdateAssignedSectionsButton.Enabled = false; UpdateHandledSubjectButton.Enabled = false;
                        UpdateAssignedSectionsButton.Cursor = Cursors.No; UpdateHandledSubjectButton.Cursor = Cursors.No;
                    }
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !    
            }
        }

        private bool isNumber(string param)
        {
            try
            {
                long.Parse(param);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (UpdateButton.Text == "UPDATE INFORMATION")
            {
                UpdateButton.Text = "SAVE ALL";
                UpdateButton.Size = new Size(95, 30);
                UpdateButton.Location = new Point(901, 445);
                ResetButton.Visible = true;

                EnableControls();
                FirstNameTextbox.Focus();
            }

            else if (UpdateButton.Text == "SAVE ALL")
            {
                //EXCEPTION 2
                try
                {
                    opacityform = new OpacityForm();
                    cryptography = new Cryptography();
                    darkeropacityform = new DarkerOpacityForm();
                    notificationwindow = new NotificationWindow();

                    if (FirstNameTextbox.Text.Trim().Length < 1 || MiddleNameTextbox.Text.Trim().Length < 1 || LastNameTextbox.Text.Trim().Length < 1 ||
                        BirthDateTextbox.Text.Trim().Length < 1 || GenderTextbox.Text.Length < 1 || BloodTypeTextbox.Text.Trim().Length < 1 ||
                        PresentAddressTextbox.Text.Trim().Length < 1 || ReligionTextbox.Text.Trim().Length < 1 || EmailAddressTextbox.Text.Trim().Length < 1
                        || MobileNumberTextbox.Text.Trim().Length < 1)
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

                    else if (isNumber(MobileNumberTextbox.Text.Trim()) == false)
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "PHONE NUMBER CONTAIN AN INVALID\nCHARACTERS !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();
                    }
                    
                    else
                    {
                        //INNER EXCEPTION 2
                        try
                        {
                            string alterquery = "UPDATE [Tbl.Teachers] SET [FIRST NAME] = @fname, [MIDDLE NAME] = @mname, [LAST NAME] = @lname," +
                                "GENDER = @gender, [BIRTH DATE] = @bdate, [PRESENT ADDRESS] = @paddress, RELIGION = @religion, [BLOOD TYPE] = @btype," +
                                "[EMAIL ADDRESS] = @eaddress, [MOBILE NUMBER] = @mnumber WHERE [USER ID] = '" + UserID + "'";
                            sqlcommand = new SqlCommand(alterquery, sqlconnection);

                            sqlcommand.Parameters.AddWithValue("@fname", FirstNameTextbox.Text.Trim());
                            sqlcommand.Parameters.AddWithValue("@mname", MiddleNameTextbox.Text.Trim());
                            sqlcommand.Parameters.AddWithValue("@lname", LastNameTextbox.Text.Trim());
                            sqlcommand.Parameters.AddWithValue("@gender", GenderTextbox.Text.Trim());

                            sqlcommand.Parameters.AddWithValue("@bdate", BirthDateTextbox.Text.Trim());
                            sqlcommand.Parameters.AddWithValue("@paddress", PresentAddressTextbox.Text.Trim());
                            sqlcommand.Parameters.AddWithValue("@religion", ReligionTextbox.Text.Trim());

                            sqlcommand.Parameters.AddWithValue("@btype", BloodTypeTextbox.Text.Trim());
                            sqlcommand.Parameters.AddWithValue("@eaddress", EmailAddressTextbox.Text.Trim());
                            sqlcommand.Parameters.AddWithValue("@mnumber", MobileNumberTextbox.Text.Trim());
                            sqlcommand.ExecuteNonQuery();

                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.check;
                            notificationwindow.MessageText = "SUCCESSFULLY UPDATED !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();

                            UpdateButton.Text = "UPDATE INFORMATION";
                            UpdateButton.Size = new Size(170, 30);
                            UpdateButton.Location = new Point(826, 445);

                            ResetButton.Visible = false;
                            DisableControls();
                        }
                        
                        catch (Exception exception)
                        {
                            opacityform.Show();
                            MessageBox.Show(exception.Message.ToString(), "Account Information Form Inner Exception 2",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);

                            opacityform.Hide();
                        }
                    }
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "Account Information Form Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            LoadAccountImage();
            RetrievePersonalInformation();
            RetrieveAccountInformation();
        }

        private void CloseButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        private void AccountInformationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void bunifuSeparator1_KeyDown(object sender, KeyEventArgs e)
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

        private void ShowPasswordImg_Click(object sender, EventArgs e)
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

        private void ShowPasswordImg_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg1.Size = new Size(22, 22);
        }

        private void ShowPasswordImg_MouseLeave(object sender, EventArgs e)
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

        private void AccountpictureBox_Click(object sender, EventArgs e)
        {
            try
            {
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
                    AccountpictureBox.Image = bitmap;

                    FileStream filestream = new FileStream(@ImageFilename, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[filestream.Length];

                    filestream.Read(imgByteArr, 0, Convert.ToInt32(filestream.Length));
                    filestream.Close();

                    string TempQuery = "UPDATE [Tbl.Photos] SET [FILE NAME] = @filename, PICTURE = @picture WHERE [USER ID] = '" + UserID + "'";
                    sqlcommand = new SqlCommand(TempQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@filename", ImageFilename.ToString());
                    sqlcommand.Parameters.AddWithValue("@picture", imgByteArr);
                    sqlcommand.ExecuteNonQuery();
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void AccountpictureBox_MouseHover(object sender, EventArgs e)
        {
            AccountpictureBox.Size = new Size(115, 115);
        }

        private void AccountpictureBox_MouseLeave(object sender, EventArgs e)
        {
            AccountpictureBox.Size = new Size(110, 110);
        }

        private void bunifuDropdown9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }

        private void ESP_CheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            //BULLSHIT !
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enable_DisAble_Update_Buttons();
        }

        private void UpdateAssignedSectionsButton_Click(object sender, EventArgs e)
        {
            try
            {

            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !    
            }
        }
        
        private void UpdateHandledSubjectButton_Click(object sender, EventArgs e)
        {
            try
            {

            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !    
            }
        }

        private void ShowPasswordImg2_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg2.Size = new Size(20, 20);
        }
    }
}
