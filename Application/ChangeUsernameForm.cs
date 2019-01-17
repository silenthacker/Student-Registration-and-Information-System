using System;
using System.Data;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
using System.Diagnostics.CodeAnalysis;
namespace Application
{
    public partial class ChangeUsernameForm : Form
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
        string sqlquery1, sqlquery2, sqlquery3;
        private string currentuserid;

        public ChangeUsernameForm()
        {
            InitializeComponent();
        }

        private void ChangeUsernameForm_Load(object sender, EventArgs e)
        {
            NewUsernameTextbox.ResetText();
            ConfirmUsernameTextbox.ResetText();

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
                    sqlquery1 = "SELECT USERNAME FROM [Tbl.Users] WHERE [USER ID] = '" + currentuserid + "'";
                    sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                    SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                    while (sqldatareader.Read())
                    {
                        OldUsernameTextbox.Text = cryptography.Decrypt(sqldatareader.GetString(0));
                    }
                    sqldatareader.Close();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Change Username Form Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Change Username Form Exception 1",
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

                if (NewUsernameTextbox.Text.Trim().Length == 0 || ConfirmUsernameTextbox.Text.Trim().Length == 0)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE THE REQUIRED\nINFORMATIONS BEING ASK !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (NewUsernameTextbox.Text.Trim().Equals(OldUsernameTextbox.Text.Trim()) ||
                    OldUsernameTextbox.Text.Trim().Equals(NewUsernameTextbox.Text.Trim()))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "YOUR NEW USERNAME AND OLD ARE\nJUST THE SAME !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (!NewUsernameTextbox.Text.Trim().Equals(ConfirmUsernameTextbox.Text.Trim()) || 
                    !ConfirmUsernameTextbox.Text.Trim().Equals(NewUsernameTextbox.Text.Trim()))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE CONFIRM YOUR NEW USERNAME !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (NewUsernameTextbox.Text.Trim().Length != 0 && ConfirmUsernameTextbox.Text.Trim().Length != 0)
                {
                    //INNER EXCEPTION 2
                    try
                    {
                        //CHECK IF THE NEW USERNAME IS ALREADY TAKEN BY ANOTHER USER
                        sqlquery2 = "SELECT COUNT(*) FROM [Tbl.Users] WHERE USERNAME = '" + cryptography.Encrypt(ConfirmUsernameTextbox.Text.Trim()) + "'";
                        sqldataadapter = new SqlDataAdapter(sqlquery2, sqlconnection);
                        DataTable datatable = new DataTable();
                        sqldataadapter.Fill(datatable);

                        //OPPS, USERNAME IS ALREADY TAKEN
                        if (datatable.Rows[0][0].ToString() == "1")
                        {
                            notificationwindow.CaptionText = "UPDATE WAS ABORTED !";
                            notificationwindow.MsgImage.Image = Properties.Resources.error;
                            notificationwindow.MessageText = "OPPS, USERNAME IS ALREADY TAKEN,\nTRY A DIFFERENT ONE !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }

                        //FUCK YEAH, USERNAME IS NOT YET TAKEN !!
                        else if (datatable.Rows[0][0].ToString() == "0")
                        {
                            //ERROR EXIST HERE.
                            sqlquery3 = "UPDATE [Tbl.Users] SET USERNAME = @username WHERE [USER ID] = '" + currentuserid + "'";
                            sqlcommand = new SqlCommand(sqlquery3, sqlconnection);

                            sqlcommand.Parameters.AddWithValue("@username", cryptography.Encrypt(ConfirmUsernameTextbox.Text.Trim()));
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
                    }

                    catch (Exception exception)
                    {
                        opacityform.Show();
                        MessageBox.Show(exception.Message.ToString(), "@Change Username Form Inner Exception 2",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Change Username Form Exception 2",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void NewUsernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }

            else if (e.KeyData == Keys.Enter)
            {
                if (NewUsernameTextbox.Text.Trim().Length <= 0 &&
                    ConfirmUsernameTextbox.Text.Trim().Length <= 0)
                {
                    SubmitButton_Click(sender, e);
                }

                else if (NewUsernameTextbox.Text.Trim().Length > 0 &&
                    ConfirmUsernameTextbox.Text.Trim().Length <= 0)
                {
                    ConfirmUsernameTextbox.Focus();
                }

                else if (NewUsernameTextbox.Text.Trim().Length <= 0 &&
                    ConfirmUsernameTextbox.Text.Trim().Length > 0)
                {
                    SubmitButton_Click(sender, e);
                }

                else if (NewUsernameTextbox.Text.Trim().Length > 0 &&
                    ConfirmUsernameTextbox.Text.Trim().Length > 0)
                {
                    SubmitButton_Click(sender, e);
                }
            }
        }

        private void ConfirmUsernameTextbox_KeyDown(object sender, KeyEventArgs e)
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

        private void ChangeUsernameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlconnection.Close();
            e.Cancel = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        private void OldUsernamelTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
