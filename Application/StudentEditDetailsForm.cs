using System;
using System.IO;
using System.Data;
using System.Drawing;

using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Diagnostics.CodeAnalysis;
using System.Deployment.Internal.CodeSigning;
using System.Globalization;
namespace Application
{
    public partial class StudentEditDetailsForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;

        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;
        ResetControlState reseter;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;

        string ImageFilename;
        private string StudentID, UserID;
        public string Gender, BirthDate;

        public StudentEditDetailsForm()
        {
            InitializeComponent();
        }

        private void StudentEditDetailsForm_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 26);
            
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
                    //LOAD ACCOUNT PICTURE
                    Load_Account_Picture();

                    //LOAD PERSONAL INFO AS PLACEHOLDER
                    Load_Personal_Info_AsPlaceholder();

                    //LOAD FAMILY BACKGROUND AS PLACEHOLDER
                    Load_Family_Background_AsPlaceholder();

                    //LOAD ACCOUNT INFORMATION
                    Load_Account_Information();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Student Edit Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Student Edit Form Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void Load_Account_Picture()
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
                    byte[] ImageArray = (byte[]) row[1];
                    AccountPicture.Image = Image.FromStream(new MemoryStream(ImageArray));
                }
            }

            catch (Exception)
            {
                //DON'T DISPLAY ANYTHING SHIT !
            }
        }

        private void Load_Personal_Info_AsPlaceholder()
        {
            try
            {
                string RetrieveQuery = "SELECT * FROM [Tbl.Students] WHERE [STUDENT ID] = '" + StudentID + "'";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    StudentIDTextbox.Text = sqldatareader.GetString(0);
                    UserIDTextbox.Text = sqldatareader.GetString(1);
                    LRNTextbox.Text = sqldatareader.GetString(2);

                    FirstNameTextbox.Text = sqldatareader.GetString(3);
                    MiddleNameTextbox.Text = sqldatareader.GetString(4);
                    LastNameTextbox.Text = sqldatareader.GetString(5);

                    GradeLevelDropdown.Clear();
                    GradeLevelDropdown.AddItem(sqldatareader.GetString(6));
                    GradeLevelDropdown.selectedIndex = 0;

                    SectionDropdown.Clear();
                    SectionDropdown.AddItem(sqldatareader.GetString(7));
                    SectionDropdown.selectedIndex = 0;

                    Gender = sqldatareader.GetString(8);
                    if (Gender.Equals("Male")) {
                        GenderDropdown.selectedIndex = 0;
                    }

                    else {
                        GenderDropdown.selectedIndex = 1;
                    }

                    BirthDate = string.Format("{0:d}", sqldatareader.GetString(9));
                    BirthDatepicker.Value = DateTime.Parse(BirthDate);

                    PresentAddressTextbox.Text = sqldatareader.GetString(10);
                    PlaceOfBirthTextbox.Text = sqldatareader.GetString(11);
                    BloodTypeTextbox.Text = sqldatareader.GetString(12);
                    
                    ReligionTextbox.Text = sqldatareader.GetString(13);
                    IndiginousGroupTextbox.Text = sqldatareader.GetString(14);
                    EmailAddressTextbox.Text = sqldatareader.GetString(15);
                    MobileNumberTextbox.Text = sqldatareader.GetString(16);
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING SHIT !
            }
        }

        private void Load_Family_Background_AsPlaceholder()
        {
            try
            {
                string RetrieveQuery = "SELECT * FROM [Tbl.FamilyBackgrounds] WHERE [STUDENT ID] = '" + StudentID + "'";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();
                
                while (sqldatareader.Read())
                {
                    FathersNameTextbox.Text =  sqldatareader.GetString(1);
                    FathersOccupationTextbox.Text =  sqldatareader.GetString(2);
                    FathersContactNumberTextbox.Text =  sqldatareader.GetString(3);
                    FathersAddressTextbox.Text =  sqldatareader.GetString(4);

                    MothersNameTextbox.Text =  sqldatareader.GetString(5);
                    MothersOccupationTextbox.Text =  sqldatareader.GetString(6);
                    MothersContactNumberTextbox.Text =  sqldatareader.GetString(7);
                    MothersAddressTextbox.Text = sqldatareader.GetString(8);
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING SHIT !
            }
        }

        private void Load_Account_Information()
        {
            try
            {
                cryptography = new Cryptography();
                string RetrieveQuery = "SELECT * FROM [Tbl.Users] WHERE [USER ID] = '" + UserID + "'";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    UsernameTextbox.Text = cryptography.Decrypt(sqldatareader.GetString(1));
                    PasswordTextbox.Text = cryptography.Decrypt(sqldatareader.GetString(2));
                    ConfirmPasswordTextbox.Text = cryptography.Decrypt(sqldatareader.GetString(2));
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
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
                    //TODO:
                    ImageFilename = OFD.FileName;
                    Bitmap bitmap = new Bitmap(ImageFilename);
                    AccountPicture.Image = bitmap;
                }
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING SHIT !
            }
        }

        private void ResetFlatButton_Click(object sender, EventArgs e)
        {
            reseter = new ResetControlState();
            reseter.Update_Student_Details_Reset_Controls(this);

            Load_Account_Picture();
            Load_Account_Information();

            Load_Personal_Info_AsPlaceholder();
            Load_Family_Background_AsPlaceholder();
        }

        private void UpdateFlatButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 2
            try
            {
                string j = @"""";
                opacityform = new OpacityForm();
                cryptography = new Cryptography();

                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                //INNER EXCEPTION 2
                try
                {
                    if (LRNTextbox.Text.Trim().Length < 1 || FirstNameTextbox.Text.Trim().Length < 1 || MiddleNameTextbox.Text.Trim().Length < 1 ||
                    LastNameTextbox.Text.Trim().Length < 1 || PresentAddressTextbox.Text.Trim().Length < 1 || PlaceOfBirthTextbox.Text.Trim().Length < 1 ||
                    BloodTypeTextbox.Text.Trim().Length < 1 || ReligionTextbox.Text.Trim().Length < 1 || EmailAddressTextbox.Text.Trim().Length < 1 ||
                    MobileNumberTextbox.Text.Trim().Length < 1 || FathersNameTextbox.Text.Trim().Length < 1 || FathersOccupationTextbox.Text.Trim().Length < 1 ||
                    FathersContactNumberTextbox.Text.Trim().Length < 1 || FathersAddressTextbox.Text.Trim().Length < 1 || MothersNameTextbox.Text.Trim().Length < 1 ||
                    MothersOccupationTextbox.Text.Trim().Length < 1 || MothersContactNumberTextbox.Text.Trim().Length < 1 ||
                    MothersAddressTextbox.Text.Trim().Length < 1 || PasswordTextbox.Text.Trim().Length < 1 || ConfirmPasswordTextbox.Text.Trim().Length < 1)
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

                    else if (MobileNumberTextbox.Text.Trim().ToUpper().Contains("A") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("B") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("C") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("D") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("E") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("F") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("G") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("H") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("I") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("J") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("K") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("L") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("M") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("N") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("O") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("P") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("Q") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("R") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("S") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("T") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("W") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("X") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("Y") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("Z") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("`") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("~") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("!") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("@") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("#") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("$") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("%") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("^") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("&") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("*") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("(") || MobileNumberTextbox.Text.Trim().ToUpper().Contains(")") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("_") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("-") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("+") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("=") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("{") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("[") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("}") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("]") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains(";") || MobileNumberTextbox.Text.Trim().ToUpper().Contains(":") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("'") || MobileNumberTextbox.Text.Trim().ToUpper().Contains(j) ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("\\") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("|") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains(",") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("<") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains(".") || MobileNumberTextbox.Text.Trim().ToUpper().Contains(">") ||
                    MobileNumberTextbox.Text.Trim().ToUpper().Contains("/") || MobileNumberTextbox.Text.Trim().ToUpper().Contains("?"))
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "PHONE NUMBER CONTAINS AN INVALID\nCHARACTER !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();
                    }

                    else if (FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("A") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("B") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("C") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("D") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("E") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("F") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("G") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("H") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("I") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("J") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("K") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("L") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("M") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("N") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("O") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("P") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("Q") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("R") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("S") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("T") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("W") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("X") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("Y") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("Z") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("`") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("~") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("!") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("@") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("#") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("$") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("%") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("^") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("&") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("*") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("(") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains(")") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("_") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("-") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("+") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("=") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("{") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("[") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("}") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("]") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains(";") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains(":") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("'") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains(j) ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("\\") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("|") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains(",") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("<") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains(".") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains(">") ||
                    FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("/") || FathersContactNumberTextbox.Text.Trim().ToUpper().Contains("?"))
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "YOUR FATHERS PHONE NUMBER CONTAINS\nAN INVALID CHARACTER !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();
                    }

                    else if (MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("A") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("B") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("C") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("D") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("E") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("F") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("G") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("H") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("I") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("J") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("K") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("L") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("M") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("N") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("O") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("P") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("Q") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("R") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("S") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("T") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("W") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("X") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("Y") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("Z") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("`") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("~") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("!") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("@") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("#") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("$") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("%") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("^") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("&") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("*") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("(") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains(")") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("_") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("-") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("+") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("=") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("{") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("[") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("}") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("]") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains(";") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains(":") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("'") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains(j) ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("\\") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("|") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains(",") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("<") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains(".") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains(">") ||
                    MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("/") || MothersContactNumberTextbox.Text.Trim().ToUpper().Contains("?"))
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
                        if (ImageFilename != null) {

                            //UPDATE [Tbl.Photos] IF IMAGE CHANGED
                            FileStream filestream = new FileStream(ImageFilename, FileMode.Open, FileAccess.Read);
                            byte[] imgByteArr = new byte[filestream.Length];
                            filestream.Read(imgByteArr, 0, Convert.ToInt32(filestream.Length));
                            filestream.Close();

                            string UpdateQuery0 = "UPDATE [Tbl.Photos] SET [FILE NAME] = @filename, PICTURE = @picture WHERE [USER ID] = '" + UserID + "'";
                            sqlcommand = new SqlCommand(UpdateQuery0, sqlconnection);
                            sqlcommand.Parameters.AddWithValue("@filename", ImageFilename.ToString());
                            sqlcommand.Parameters.AddWithValue("@picture", imgByteArr);
                            sqlcommand.ExecuteNonQuery();
                        }

                        //UPDATE [Tbl.Students]
                        string UpdateQuery1 = "UPDATE [Tbl.Students] SET [FIRST NAME] = @1, [MIDDLE NAME] = @2, [LAST NAME] = @3, [GENDER] = @4, [BIRTH DATE] = @5, " +
                            "[PRESENT ADDRESS] = @6, [PLACE OF BIRTH] = @7, [BLOOD TYPE] = @8, [RELIGION] = @9, [INDIGINOUS GROUP] = @10, [EMAIL ADDRESS] = @11, " + 
                            "[MOBILE NUMBER] = @12 WHERE [STUDENT ID] = '" + StudentID + "'";
                        sqlcommand = new SqlCommand(UpdateQuery1, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@1", FirstNameTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@2", MiddleNameTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@3", LastNameTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@4", GenderDropdown.selectedValue.ToString());

                        sqlcommand.Parameters.AddWithValue("@5", BirthDatepicker.Value.ToLongDateString().ToString());
                        sqlcommand.Parameters.AddWithValue("@6", PresentAddressTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@7", PlaceOfBirthTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@8", BloodTypeTextbox.Text.Trim());

                        sqlcommand.Parameters.AddWithValue("@9", ReligionTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@10", IndiginousGroupTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@11", EmailAddressTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@12", MobileNumberTextbox.Text.Trim());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.FamilyBackgrounds]
                        string UpdateQuery2 = "UPDATE [Tbl.FamilyBackgrounds] SET [FATHERS NAME] = @1, [FATHERS OCCUPATION] = @2, [FATHERS CONTACT NUMBER] = @3, [FATHERS ADDRESS] = @4, " +
                            "[MOTHERS NAME] = @5, [MOTHERS OCCUPATION] = @6, [MOTHERS CONTACT NUMBER] = @7, [MOTHERS ADDRESS] = @8 WHERE [STUDENT ID] = '" + StudentID + "'";
                        sqlcommand = new SqlCommand(UpdateQuery2, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@1", FathersNameTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@2", FathersOccupationTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@3", FathersContactNumberTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@4", FathersAddressTextbox.Text.Trim());

                        sqlcommand.Parameters.AddWithValue("@5", MothersNameTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@6", MothersOccupationTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@7", MothersContactNumberTextbox.Text.Trim());
                        sqlcommand.Parameters.AddWithValue("@8", MothersAddressTextbox.Text.Trim());
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE [Tbl.Users]
                        string UpdateQuery3 = "UPDATE [Tbl.Users] SET [USERNAME] = @1, [PASSWORD] = @2 WHERE [USER ID] = '" + UserID + "'";
                        sqlcommand = new SqlCommand(UpdateQuery3, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@1", cryptography.Encrypt(UsernameTextbox.Text));
                        sqlcommand.Parameters.AddWithValue("@2", cryptography.Encrypt(PasswordTextbox.Text));
                        sqlcommand.ExecuteNonQuery();

                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.check;
                        notificationwindow.MessageText = "SUCCESSFULY UPDATED !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        //CLOSE THE CURRENT FORM
                        sqlconnection.Close();
                        DialogResult = DialogResult.OK;
                    }
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Student Edit Form Inner Exception 2",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Student Edit Form Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void CloseFlatButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void StudentEditDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void PasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text.Length >= 1)
            {
                ShowPasswordImg1.Visible = true;
            }

            else if (PasswordTextbox.Text.Length < 1)
            {
                ShowPasswordImg1.Visible = false;
            }
        }

        private void ConfirmPasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (ConfirmPasswordTextbox.Text.Length >= 1)
            {
                ShowPasswordImg2.Visible = true;
            }

            else if (ConfirmPasswordTextbox.Text.Length < 1)
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
            ShowPasswordImg1.Size = new Size(27, 27);
        }

        private void ShowPasswordImg1_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg1.Size = new Size(25, 25);
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

        private void StudentEditDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
        
        private void ShowPasswordImg2_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg2.Size = new Size(27, 27);
        }

        private void ShowPasswordImg2_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg2.Size = new Size(25, 25);
        }
    }
}
