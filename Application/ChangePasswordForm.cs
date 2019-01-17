using System;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class ChangePasswordForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;

        SQLConnectionConfig sqlconnectionconfig;
        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        string sqlquery1, sqlquery2;
        private string currentuserid;

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            OldPasswordTextbox.ResetText();
            ConfirmPasswordTextbox.ResetText();
            NewPasswordTextbox.Focus();

            //EXCEPTION 1
            try
            {
                variables = new Variables();
                opacityform = new OpacityForm();
                cryptography = new Cryptography();
                sqlconnectionconfig = new SQLConnectionConfig();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string tempdata = registrykey.GetValue("SQLServerConnectionString").ToString();
                currentuserid = registrykey.GetValue("User ID").ToString();

                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                //INNER EXCEPTION 1
                try
                {
                    sqlquery1 = "SELECT PASSWORD FROM [Tbl.Users] WHERE [USER ID] = '" + currentuserid + "'";
                    sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                    SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                    while (sqldatareader.Read())
                    {
                        OldPasswordTextbox.Text = cryptography.Decrypt(sqldatareader.GetString(0));
                    }
                    sqldatareader.Close();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Change Password Form Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Change Password Form Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 2
            try
            {
                opacityform = new OpacityForm();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                if (NewPasswordTextbox.Text.Trim().Length == 0 || ConfirmPasswordTextbox.Text.Trim().Length == 0)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE THE REQUIRED\nINFORMATIONS BEING ASK !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (OldPasswordTextbox.Text.Trim().Equals(NewPasswordTextbox.Text.Trim()) ||
                    NewPasswordTextbox.Text.Trim().Equals(OldPasswordTextbox.Text.Trim()))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "YOUR NEW PASSWORD AND OLD ARE\nJUST THE SAME !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (!NewPasswordTextbox.Text.Trim().Equals(ConfirmPasswordTextbox.Text.Trim()) || 
                    !ConfirmPasswordTextbox.Text.Trim().Equals(NewPasswordTextbox.Text.Trim()))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE CONFIRM YOUR NEW PASSWORD !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (NewPasswordTextbox.Text.Trim().Length < 8 || ConfirmPasswordTextbox.Text.Trim().Length < 8)
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
                    //INNER EXCEPTION 2
                    try
                    {
                        //ERROR EXIST HERE.
                        sqlquery2 = "UPDATE [Tbl.Users] SET PASSWORD = @password WHERE [USER ID] = '" + currentuserid + "'";
                        sqlcommand = new SqlCommand(sqlquery2, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@password", cryptography.Encrypt(ConfirmPasswordTextbox.Text.Trim()));
                        sqlcommand.ExecuteNonQuery();

                        notificationwindow.CaptionText = "SUCCESS !";
                        notificationwindow.MsgImage.Image = Properties.Resources.check;
                        notificationwindow.MessageText = "SUCCESSFULLY UPDATED !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        sqlconnection.Close();
                        DialogResult = DialogResult.OK;
                    }

                    catch (Exception exception)
                    {
                        opacityform.Show();
                        MessageBox.Show(exception.Message.ToString(), "@Change Password Form Exception 2",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Change Password Form Exception 2",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ShowPasswordImg1_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg1.Size = new Size(22, 22);
        }

        private void ShowPasswordImg1_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg1.Size = new Size(20, 20);
        }

        private void ShowPasswordImg2_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg2.Size = new Size(22, 22);
        }

        private void ShowPasswordImg2_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg2.Size = new Size(20, 20);
        }

        private void ShowPasswordImg3_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg3.Size = new Size(22, 22);
        }

        private void ShowPasswordImg3_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg3.Size = new Size(20, 20);
        }

        private void ShowPasswordImg1_Click(object sender, EventArgs e)
        {
            //SHOW
            if (OldPasswordTextbox.isPassword == true)
            {
                OldPasswordTextbox.isPassword = false;
                ShowPasswordImg1.Image = Properties.Resources.Hide;
            }

            //HIDE
            else if (OldPasswordTextbox.isPassword == false)
            {
                OldPasswordTextbox.isPassword = true;
                ShowPasswordImg1.Image = Properties.Resources.Show;
            }
        }

        private void ShowPasswordImg2_Click(object sender, EventArgs e)
        {
            //SHOW
            if (NewPasswordTextbox.isPassword == true)
            {
                NewPasswordTextbox.isPassword = false;
                ShowPasswordImg2.Image = Properties.Resources.Hide;
            }

            //HIDE
            else if (NewPasswordTextbox.isPassword == false)
            {
                NewPasswordTextbox.isPassword = true;
                ShowPasswordImg2.Image = Properties.Resources.Show;
            }
        }

        private void ShowPasswordImg3_Click(object sender, EventArgs e)
        {
            //SHOW
            if (ConfirmPasswordTextbox.isPassword == true)
            {
                ConfirmPasswordTextbox.isPassword = false;
                ShowPasswordImg3.Image = Properties.Resources.Hide;
            }

            //HIDE
            else if (ConfirmPasswordTextbox.isPassword == false)
            {
                ConfirmPasswordTextbox.isPassword = true;
                ShowPasswordImg3.Image = Properties.Resources.Show;
            }
        }

        private void OldPasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (OldPasswordTextbox.Text.Length >= 1)
            {
                ShowPasswordImg1.Visible = true;
            }

            else if (OldPasswordTextbox.Text.Length < 1)
            {
                ShowPasswordImg1.Visible = false;
            }
        }

        private void NewPasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (NewPasswordTextbox.Text.Length >= 1)
            {
                ShowPasswordImg2.Visible = true;
            }

            else if (NewPasswordTextbox.Text.Length < 1)
            {
                ShowPasswordImg2.Visible = false;
            }
        }

        private void ConfirmPasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (ConfirmPasswordTextbox.Text.Length >= 1)
            {
                ShowPasswordImg3.Visible = true;
            }

            else if (ConfirmPasswordTextbox.Text.Length < 1)
            {
                ShowPasswordImg3.Visible = false;
            }
        }

        private void NewPasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }

            else if (e.KeyData == Keys.Enter)
            {
                if (NewPasswordTextbox.Text.Trim().Length <= 0 &&
                    ConfirmPasswordTextbox.Text.Trim().Length <= 0)
                {
                    SubmitButton_Click(sender, e);
                }

                else if (NewPasswordTextbox.Text.Trim().Length > 0 &&
                    ConfirmPasswordTextbox.Text.Trim().Length <= 0)
                {
                    ConfirmPasswordTextbox.Focus();
                }

                else if (NewPasswordTextbox.Text.Trim().Length <= 0 &&
                    ConfirmPasswordTextbox.Text.Trim().Length > 0)
                {
                    SubmitButton_Click(sender, e);
                }

                else if (NewPasswordTextbox.Text.Trim().Length > 0 &&
                    ConfirmPasswordTextbox.Text.Trim().Length > 0)
                {
                    SubmitButton_Click(sender, e);
                }
            }
        }

        private void ConfirmPasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }

            else if (e.KeyData == Keys.Enter)
            {
                SubmitButton_Click(sender, e);
            }
        }

        private void ChangePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlconnection.Close();
            e.Cancel = false;
        }

        private void OldPasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
