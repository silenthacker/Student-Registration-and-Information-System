using System;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
namespace Application
{
    public partial class DisableStudentForm : Form
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
        private string isActive;

        public DisableStudentForm()
        {
            InitializeComponent();
        }

        private void DisableStudentForm_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 10);
            bunifuCards1.Select();

            //EXCEPTION 1
            try
            {
                opacityform = new OpacityForm();
                variables = new Variables();
                cryptography = new Cryptography();
                sqlconnectionconfig = new SQLConnectionConfig();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string tempdata = registrykey.GetValue("SQLServerConnectionString").ToString();
                
                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                DisplayUsersListInHumanReadableFormat();
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "Disable Student Form Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void DisplayUsersListInHumanReadableFormat()
        {
            try
            {
                string sqlquery1 = "SELECT * FROM [Tbl.Users] WHERE [ACCOUNT TYPE] = 'Student'";
                sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
                DataTable datatable = new DataTable();

                sqldataadapter.Fill(datatable);
                UsersListGridView.AutoGenerateColumns = false;
                UsersListGridView.DataSource = datatable;
            }

            catch (Exception)
            {
                //DONT DISPLAY ANYTHING SHIT !
            }
        }

        private void RefreshPicture_Click(object sender, EventArgs e)
        {
            UserIDTextbox.ResetText();
            bunifuCards1.Select();
            DisplayUsersListInHumanReadableFormat();
        }

        private void RefreshPicture_MouseHover(object sender, EventArgs e)
        {
            RefreshPicture.Size = new Size(41, 41);
        }

        private void RefreshPicture_MouseLeave(object sender, EventArgs e)
        {
            RefreshPicture.Size = new Size(39, 39);
        }

        private void UserIDTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                DialogResult = DialogResult.OK;
            }

            else if (e.KeyCode == Keys.Enter)
            {
                //EXCEPTION 2
                try
                {
                    opacityform = new OpacityForm();
                    darkeropacityform = new DarkerOpacityForm();
                    notificationwindow = new NotificationWindow();

                    if (UserIDTextbox.Text.Trim().Length < 1)
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "NO USER ID ENTERED !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();
                    }

                    else if (IsNumber(UserIDTextbox.Text.Trim()) == false)
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "INVALID USER ID - " + UserIDTextbox.Text.Trim() + " !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();
                    }

                    else
                    {
                        string sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Users] WHERE [USER ID] = '" + UserIDTextbox.Text.Trim() +
                            "' AND [ACCOUNT TYPE] = 'Student'";
                        sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
                        DataTable datatable = new DataTable();
                        sqldataadapter.Fill(datatable);

                        //USER ID IS VALID - UPDATE USER STATUS
                        if (datatable.Rows[0][0].ToString() == "1")
                        {
                            string query1 = "SELECT [ACCOUNT STATUS] FROM [Tbl.Users] WHERE [USER ID] = '" + UserIDTextbox.Text.Trim() + "'";
                            sqlcommand = new SqlCommand(query1, sqlconnection);
                            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                            while (sqldatareader.Read()) {
                                isActive = sqldatareader.GetString(0);
                            }
                            sqldatareader.Close();

                            if (isActive.Equals("Active"))
                            {
                                opacityform.Show();
                                var PlsDontContinue = MessageBox.Show("ARE YOU SURE TO DISABLE THIS ACCOUNT ?, THIS USER CANNOT LOGIN ANYMORE" +
                                    " UNLESS YOU ENABLE IT BACK !\n\nDO YOU WANT TO PROCEED ANYWAY ?", "ARE YOU SURE ?",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                                if (PlsDontContinue == DialogResult.No || PlsDontContinue == DialogResult.Cancel)
                                {
                                    opacityform.Hide();
                                }

                                else if (PlsDontContinue == DialogResult.Yes)
                                {
                                    opacityform.Hide();
                                    string alterquery1 = "UPDATE [Tbl.Users] SET [ACCOUNT STATUS] = @accountstatus WHERE [USER ID] = '" +
                                    UserIDTextbox.Text.Trim() + "'";

                                    sqlcommand = new SqlCommand(alterquery1, sqlconnection);
                                    sqlcommand.Parameters.AddWithValue("@accountstatus", "Disabled");
                                    sqlcommand.ExecuteNonQuery();

                                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                                    notificationwindow.MessageText = "USER ACCOUNT IS NOW DISABLED !";

                                    darkeropacityform.Show();
                                    notificationwindow.ShowDialog();
                                    darkeropacityform.Hide();

                                    RefreshPicture_Click(sender, e);
                                }
                            }

                            else if (isActive.Equals("Disabled"))
                            {
                                notificationwindow.CaptionText = "MESSAGE CONTENT";
                                notificationwindow.MsgImage.Image = Properties.Resources.check;
                                notificationwindow.MessageText = "THIS STUDENT ACCOUNT IS\nALREADY DISABLED !";

                                darkeropacityform.Show();
                                notificationwindow.ShowDialog();
                                darkeropacityform.Hide();
                            }
                        }

                        //FUCK YEAH, USER ID IS NOT VALID
                        else if (datatable.Rows[0][0].ToString() == "0")
                        {
                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.warning;
                            notificationwindow.MessageText = "NO RECORDS FOUND FOR\nUSER ID - " + UserIDTextbox.Text.Trim() + " !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }
                    }
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "Disable Student Form Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }
        }

        private bool IsNumber(string N)
        {
            try
            {
                int.Parse(N);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        private void DisableStudentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
