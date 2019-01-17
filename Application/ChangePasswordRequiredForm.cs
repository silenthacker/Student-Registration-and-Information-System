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
    public partial class ChangePasswordRequiredForm : Form
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

        bool isClosed = false;
        string sqlquery1, sqlquery2;
        
        public ChangePasswordRequiredForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordRequiredForm_Load(object sender, EventArgs e)
        {
            isClosed = false;
        }
        
        private void ChangePasswordRequiredForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            opacityform = new OpacityForm();
            opacityform.Show();

            if (isClosed == false)
            {
                MessageBox.Show("CLOSING THIS FORM IS NOT ALLOWED !", "NOT ALLOWED !",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

                opacityform.Hide();
                e.Cancel = true;
            }

            else if (isClosed == true)
            {
                opacityform.Hide();
                e.Cancel = false;
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 1
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
                    //INNER EXCEPTION 1
                    try
                    {
                        variables = new Variables();
                        cryptography = new Cryptography();
                        sqlconnectionconfig = new SQLConnectionConfig();

                        RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                        string tempdata = registrykey.GetValue("SQLServerConnectionString").ToString();
                        string currentuserid = registrykey.GetValue("User ID").ToString();

                        //USER SQLSERVER CONNECTION SETTINGS
                        sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                        sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                        sqlconnection.Open();

                        //CHECK IF THE NEW USERNAME IS ALREADY TAKEN BY ANOTHER USER
                        sqlquery1 = "SELECT COUNT(PASSWORD) FROM [Tbl.Users] WHERE [USER ID] = '" + currentuserid + "' AND PASSWORD = '" 
                            + cryptography.Encrypt(NewPasswordTextbox.Text.Trim()) +"'";
                        DataTable datatable = new DataTable();
                        sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
                        sqldataadapter.Fill(datatable);

                        //OPPS, PASSWORD IS THE SAME WITH THE OLD ONE !
                        if (datatable.Rows[0][0].ToString() == "1")
                        {
                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.warning;
                            notificationwindow.MessageText = "YOUR NEW PASSWORD AND OLD ARE\nJUST THE SAME !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }

                        //FUCK YAH,! IT'S NOT THE SAME !
                        else if (datatable.Rows[0][0].ToString() == "0")
                        {
                            //ERROR EXIST HERE.
                            sqlquery2 = "UPDATE [Tbl.Users] SET PASSWORD = @password, [IS PWD CHANGED] = @ispwdchanged WHERE [USER ID] = '" +
                                currentuserid + "'";
                            sqlcommand = new SqlCommand(sqlquery2, sqlconnection);

                            sqlcommand.Parameters.AddWithValue("@password", cryptography.Encrypt(ConfirmPasswordTextbox.Text.Trim()));
                            sqlcommand.Parameters.AddWithValue("@ispwdchanged", "True");
                            sqlcommand.ExecuteNonQuery();

                            notificationwindow.CaptionText = "SUCCESS !";
                            notificationwindow.MsgImage.Image = Properties.Resources.check;
                            notificationwindow.MessageText = "SUCCESSFULLY UPDATED !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();

                            sqlconnection.Close();
                            isClosed = true;
                            DialogResult = DialogResult.OK;
                        }
                    }

                    catch (Exception exception)
                    {
                        opacityform.Show();
                        MessageBox.Show(exception.Message.ToString(), "@Change Password Required Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Change Password Required Form Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void ShowPasswordImg1_Click(object sender, EventArgs e)
        {
            //SHOW
            if (NewPasswordTextbox.isPassword == true)
            {
                ShowPasswordImg1.Image = Properties.Resources.Hide;
                NewPasswordTextbox.isPassword = false;
            }

            //HIDE
            else if (NewPasswordTextbox.isPassword == false)
            {
                ShowPasswordImg1.Image = Properties.Resources.Show;
                NewPasswordTextbox.isPassword = true;
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

        private void NewPasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (NewPasswordTextbox.Text.Trim().Length >= 1)
            {
                ShowPasswordImg1.Visible = true;
            }

            else if (NewPasswordTextbox.Text.Trim().Length < 1)
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

        private void NewPasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }

            else if (e.KeyData == Keys.Enter)
            {
                if (NewPasswordTextbox.Text.Trim().Length <= 0 && 
                    ConfirmPasswordTextbox.Text.Trim().Length <= 0)
                {
                    ChangeButton_Click(sender, e);
                }

                else if (NewPasswordTextbox.Text.Trim().Length > 0 && 
                    ConfirmPasswordTextbox.Text.Trim().Length <= 0)
                {
                    ConfirmPasswordTextbox.Focus();
                }

                else if (NewPasswordTextbox.Text.Trim().Length <= 0 && 
                    ConfirmPasswordTextbox.Text.Trim().Length > 0)
                {
                    ChangeButton_Click(sender, e);
                }

                else if (NewPasswordTextbox.Text.Trim().Length > 0 && 
                    ConfirmPasswordTextbox.Text.Trim().Length > 0)
                {
                    ChangeButton_Click(sender, e);
                }
            }
        }

        private void ConfirmPasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }

            else if (e.KeyData == Keys.Enter)
            {
                ChangeButton_Click(sender, e);
            }
        }

        private void ChangePasswordRequiredForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
