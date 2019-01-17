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
    public partial class StudentFullDetailsForm : Form
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

        private string studentid, userid, currlogin;
        private bool restricted;

        public bool Restricted
        {
            get {
                return restricted;
            }

            set {
                restricted = value;
            }
        }

        public string StudentID
        {
            get {
                return studentid;
            }

            set {
                studentid = value;
            }
        }

        public string UserID
        {
            get {
                return userid;
            }

            set {
                userid = value;
            }
        }

        public StudentFullDetailsForm()
        {
            InitializeComponent();
        }

        private void StudentFullDetailsForm_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 26);
            ImageGridView.Select();

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
                    //RETRIEVE ACCOUNT PICTURE
                    Retrieve_Account_Picture();

                    //RETRIEVE PERSONAL INFORMATION
                    Retrieve_Student_Personal_Info();

                    //RETRIEVE FAMILY BACKGROUND INFORMATION
                    Retrieve_Family_Background_Info();

                    //RETRIEVE ACCOUNT INFORMATION
                    Retrieve_Account_Info();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Student Details Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Student Details Form Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
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
                    byte[] ImageArray = (byte[]) row[1];
                    AccountPicture.Image = Image.FromStream(new MemoryStream(ImageArray));
                }
            }

            catch (Exception)
            {
                //DON'T DISPLAY ANYTHING SHIT !
            }
        }

        private void Retrieve_Student_Personal_Info()
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

                    GradeLevelTextbox.Text = sqldatareader.GetString(6);
                    SectionTextbox.Text = sqldatareader.GetString(7);
                    GenderTextbox.Text = sqldatareader.GetString(8);
                    BirthDateTextbox.Text = sqldatareader.GetString(9);

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
                //DO NOTHING SHIT !
            }
        }

        private void Retrieve_Family_Background_Info()
        {
            try
            {
                string RetrieveQuery = "SELECT * FROM [Tbl.FamilyBackgrounds] WHERE [STUDENT ID] = '" + StudentID + "'";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    FathersNameTextbox.Text = sqldatareader.GetString(1);
                    FathersOccupationTextbox.Text = sqldatareader.GetString(2);
                    FathersNumberTextbox.Text = sqldatareader.GetString(3);
                    FathersAddressTextbox.Text = sqldatareader.GetString(4);

                    MothersNameTextbox.Text = sqldatareader.GetString(5);
                    MothersOccupationTextbox.Text = sqldatareader.GetString(6);
                    MothersNumberTextbox.Text = sqldatareader.GetString(7);
                    MothersAddressTextbox.Text = sqldatareader.GetString(8);
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }
        
        private void Retrieve_Account_Info()
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
                    LastLoginTextbox.Text = sqldatareader.GetString(5);

                    currlogin = sqldatareader.GetString(7);
                    if (currlogin.Equals("1")) {
                        YesRadioButton.Checked = true;
                    }

                    else if (currlogin.Equals("0")) {
                        NoRadioButton.Checked = true;
                    }
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }

        private void ShowUsernamePictureButton_Click(object sender, EventArgs e)
        {
            if (Restricted == false)
            {
                //SHOW
                if (UsernameTextbox.isPassword == true)
                {
                    UsernameTextbox.isPassword = false;
                    ShowUsernamePictureButton.Image = Properties.Resources.Hide;
                }

                //HIDE
                else if (UsernameTextbox.isPassword == false)
                {
                    UsernameTextbox.isPassword = true;
                    ShowUsernamePictureButton.Image = Properties.Resources.Show;
                }
            }

            else if (Restricted == true)
            {
                notificationwindow = new NotificationWindow();
                darkeropacityform = new DarkerOpacityForm();

                notificationwindow.CaptionText = "STUDENT REGISTRATION & INFORMATION SYSTEM";
                notificationwindow.MsgImage.Image = Properties.Resources.error;
                notificationwindow.MessageText = "SHOWING THIS USERNAME IS NOT\nALLOWED, LETS RESPECT EACH PRIVACY !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }
        }

        private void ShowUsernamePictureButton_MouseHover(object sender, EventArgs e)
        {
            ShowUsernamePictureButton.Size = new Size(27, 27);
        }

        private void ShowUsernamePictureButton_MouseLeave(object sender, EventArgs e)
        {
            ShowUsernamePictureButton.Size = new Size(25, 25);
        }

        private void ShowPasswordPictureButton_Click(object sender, EventArgs e)
        {
            if (Restricted == false)
            {
                //SHOW
                if (PasswordTextbox.isPassword == true)
                {
                    PasswordTextbox.isPassword = false;
                    ShowPasswordPictureButton.Image = Properties.Resources.Hide;
                }

                //HIDE
                else if (PasswordTextbox.isPassword == false)
                {
                    PasswordTextbox.isPassword = true;
                    ShowPasswordPictureButton.Image = Properties.Resources.Show;
                }
            }

            else if (Restricted == true)
            {
                notificationwindow = new NotificationWindow();
                darkeropacityform = new DarkerOpacityForm();

                notificationwindow.CaptionText = "STUDENT REGISTRATION & INFORMATION SYSTEM";
                notificationwindow.MsgImage.Image = Properties.Resources.error;
                notificationwindow.MessageText = "SHOWING THIS PASSWORD IS NOT\nALLOWED, LETS RESPECT EACH PRIVACY !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();
            }
        }

        private void ShowPasswordPictureButton_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordPictureButton.Size = new Size(27, 27);
        }

        private void ShowPasswordPictureButton_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordPictureButton.Size = new Size(25, 25);
        }

        private void RefreshPictureButton_Click(object sender, EventArgs e)
        {
            Retrieve_Account_Info();
        }

        private void RefreshPictureButton_MouseHover(object sender, EventArgs e)
        {
            RefreshPictureButton.Size = new Size(29, 29);
        }

        private void RefreshPictureButton_MouseLeave(object sender, EventArgs e)
        {
            RefreshPictureButton.Size = new Size(27, 27);
        }
        
        private void StudentFullDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
        
        private void StudentIDTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
