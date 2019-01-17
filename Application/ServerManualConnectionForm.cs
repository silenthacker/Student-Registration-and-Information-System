using System;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Windows.Forms;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class ServerManualConnectionForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconfig;
        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;

        //INIT: NEW SQL CONNECTION
        SqlConnection sqlconnection;
        string tempconnectionstring;

        public ServerManualConnectionForm()
        {
            InitializeComponent();
        }

        private void ServerManualConnectionForm_Load(object sender, EventArgs e)
        {
            ServerNameTextbox.ResetText();
            DatabaseNameTextbox.ResetText();
            SqlServerUsernameTextbox.ResetText();
            SqlServerPasswordTextbox.ResetText();

            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 15);
        }
        
        private void Show_Hide_Visual_Representation_Labels()
        {
            if (ServerNameTextbox.Text.Length == 0) {
                Asterisk1.Visible = true;
            }
            else
                Asterisk1.Visible = false;

            if (DatabaseNameTextbox.Text.Length == 0) {
                Asterisk2.Visible = true;
            }
            else
                Asterisk2.Visible = false;

            if (SqlServerUsernameTextbox.Text.Length == 0) {
                Asterisk3.Visible = true;
            }
            else
                Asterisk3.Visible = false;

            if (SqlServerPasswordTextbox.Text.Length == 0) {
                Asterisk4.Visible = true;
            }
            else
                Asterisk4.Visible = false;
        }

        private void TestConnectionButton_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            darkeropacityform = new DarkerOpacityForm();
            notificationwindow = new NotificationWindow();

            //EXCEPTION 1
            try
            {
                //SHOW VISUAL REPRESENTATION FOR EMPTY TEXTBOXES
                Show_Hide_Visual_Representation_Labels();

                if (ServerNameTextbox.Text.Length == 0 || DatabaseNameTextbox.Text.Length == 0 || 
                    SqlServerUsernameTextbox.Text.Length == 0 || SqlServerPasswordTextbox.Text.Length == 0)
                {
                    notificationwindow.CaptionText = "CONNECTION REFUSED";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE THE REQUIRED\nINFORMATIONS BEING ASK !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (ServerNameTextbox.Text.EndsWith(" ") || DatabaseNameTextbox.Text.EndsWith(" ")
                    || SqlServerUsernameTextbox.Text.EndsWith(" ") || SqlServerPasswordTextbox.Text.EndsWith(" "))
                {
                    notificationwindow.CaptionText = "CONNECTION REFUSED";
                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                    notificationwindow.MessageText = "LOGIN FAILED !\nPLEASE REVIEW YOUR INFORMATION.";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (ServerNameTextbox.Text.Length != 0 && DatabaseNameTextbox.Text.Length != 0
                    && SqlServerUsernameTextbox.Text.Length != 0 && SqlServerPasswordTextbox.Text.Length != 0)
                {
                    //INNER EXCEPTION 1
                    try
                    {
                        variables = new Variables();
                        sqlconfig = new SQLConnectionConfig();

                        tempconnectionstring = "Data Source=" + ServerNameTextbox.Text + ";" + "Initial Catalog=" + DatabaseNameTextbox.Text + ";" 
                            + "Persist Security Info=True;" + "User ID=" + SqlServerUsernameTextbox.Text + ";" + "Password=" + SqlServerPasswordTextbox.Text + "";

                        sqlconfig.SqlConnectionString = tempconnectionstring;
                        sqlconnection = new SqlConnection(sqlconfig.SqlConnectionString);

                        do
                        {
                            Cursor = Cursors.AppStarting;
                            sqlconnection.Open();

                            if (sqlconnection.State == ConnectionState.Open)
                            {
                                notificationwindow.CaptionText = "CONNECTION TESTING";
                                notificationwindow.MsgImage.Image = Properties.Resources.check;
                                notificationwindow.MessageText = "TEST CONNECTION SUCCEEDED !";

                                darkeropacityform.Show();
                                notificationwindow.ShowDialog();
                                darkeropacityform.Hide();

                                Cursor = Cursors.Default;
                                break;
                            }
                        }

                        while (sqlconnection.State == ConnectionState.Closed);
                        sqlconnection.Close();
                    }

                    catch (Exception exception)
                    {
                        Cursor = Cursors.Default;
                        opacityform.Show();
                        MessageBox.Show(exception.Message.ToString(), "@Server Connection Inner Exception 1",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Server Connection Exception 1",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            darkeropacityform = new DarkerOpacityForm();
            notificationwindow = new NotificationWindow();

            //EXCEPTION 2
            try
            {
                //SHOW VISUAL REPRESENTATION FOR EMPTY TEXTBOXES
                Show_Hide_Visual_Representation_Labels();

                if (ServerNameTextbox.Text.Length == 0 || DatabaseNameTextbox.Text.Length == 0 ||
                    SqlServerUsernameTextbox.Text.Length == 0 || SqlServerPasswordTextbox.Text.Length == 0)
                {
                    notificationwindow.CaptionText = "CONNECTION REFUSED";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE THE REQUIRED\nINFORMATIONS BEING ASK !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (ServerNameTextbox.Text.EndsWith(" ") || DatabaseNameTextbox.Text.EndsWith(" ")
                    || SqlServerUsernameTextbox.Text.EndsWith(" ") || SqlServerPasswordTextbox.Text.EndsWith(" "))
                {
                    notificationwindow.CaptionText = "CONNECTION REFUSED";
                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                    notificationwindow.MessageText = "LOGIN FAILED !\nPLEASE REVIEW YOUR INFORMATION.";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (ServerNameTextbox.Text.Length != 0 && DatabaseNameTextbox.Text.Length != 0
                && SqlServerUsernameTextbox.Text.Length != 0 && SqlServerPasswordTextbox.Text.Length != 0)
                {
                    //INNER EXCEPTION 2
                    try
                    {
                        variables = new Variables();
                        cryptography = new Cryptography();
                        sqlconfig = new SQLConnectionConfig();

                        tempconnectionstring = "Data Source=" + ServerNameTextbox.Text + ";" + "Initial Catalog=" + DatabaseNameTextbox.Text + ";"
                            + "Persist Security Info=True;" + "User ID=" + SqlServerUsernameTextbox.Text + ";" + "Password=" + SqlServerPasswordTextbox.Text + "";

                        sqlconfig.SqlConnectionString = tempconnectionstring;
                        sqlconnection = new SqlConnection(sqlconfig.SqlConnectionString);

                        do
                        {
                            Cursor = Cursors.AppStarting;
                            sqlconnection.Open();

                            if (sqlconnection.State == ConnectionState.Open)
                            {
                                //PLEASE CHANGE THIS CODE !
                                if (DatabaseNameTextbox.Text.Trim().Equals("BUKSU.SLS_DB"))
                                {
                                    notificationwindow.CaptionText = "CONNECTION RESULTS";
                                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                                    notificationwindow.MessageText = "YOU'RE ALL SET ! CONNECTION\nWAS SUCCESSFULY ESTABLISHED.";

                                    darkeropacityform.Show();
                                    notificationwindow.ShowDialog();
                                    darkeropacityform.Hide();

                                    variables.UserSqlConnectionString = tempconnectionstring;

                                    //INNER EXCEPTION 3
                                    try
                                    {
                                        RegistryKey registrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                                        registrykey.SetValue("SQLServerConnectionString", cryptography.Encrypt(tempconnectionstring));
                                    }

                                    catch (Exception exception)
                                    {
                                        opacityform.Show();
                                        MessageBox.Show(exception.Message.ToString(), "@Server Connection Inner Exception 3",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        opacityform.Hide();
                                    }

                                    Cursor = Cursors.Default;
                                    DialogResult = DialogResult.OK;
                                    break;
                                }

                                else
                                {
                                    notificationwindow.CaptionText = "CONNECTION RESULTS";
                                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                                    notificationwindow.MessageText = "INVALID DATABASE - " + DatabaseNameTextbox.Text.Trim() +
                                        "\nDATABASE DOES NOT CONTAIN ALL\nTHE TABLES NEEDED TO RUN THE SYSTEM !";

                                    darkeropacityform.Show();
                                    notificationwindow.ShowDialog();
                                    darkeropacityform.Hide();

                                    Cursor = Cursors.Default;
                                    break;
                                }
                            }
                        }

                        while (sqlconnection.State == ConnectionState.Closed);
                        sqlconnection.Close();
                    }

                    catch (Exception exception)
                    {
                        Cursor = Cursors.Default;
                        opacityform.Show();

                        MessageBox.Show(exception.Message.ToString(), "@Server Connection Inner Exception 2",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Server Connection Exception 2",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void ServerNameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) 
            {
                DialogResult = DialogResult.OK;
            }

            else if (e.KeyData == Keys.Enter)
            {
                OKButton_Click(sender, e);
            }
        }

        private bool Validate_Database(string databasename)
        {
            try
            {
                
            }

            catch (Exception)
            {

            }

            return true;
        }

        private void ServerNameTextbox_OnValueChanged(object sender, EventArgs e)
        {
            Show_Hide_Visual_Representation_Labels();
        }

        private void DatabaseNameTextbox_OnValueChanged(object sender, EventArgs e)
        {
            Show_Hide_Visual_Representation_Labels();
        }

        private void SqlServerUsernameTextbox_OnValueChanged(object sender, EventArgs e)
        {
            Show_Hide_Visual_Representation_Labels();
        }

        private void SqlServerPasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            Show_Hide_Visual_Representation_Labels();
        }
    }
}
