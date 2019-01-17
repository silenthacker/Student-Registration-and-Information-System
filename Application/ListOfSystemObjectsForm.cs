using System;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
namespace Application
{
    public partial class ListOfSystemObjectsForm : Form
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
        private string UserID, isActive;

        public ListOfSystemObjectsForm()
        {
            InitializeComponent();
        }

        private void ListOfSystemObjectsForm_Load(object sender, EventArgs e)
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
                UserID = registrykey.GetValue("User ID").ToString();

                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                DisplayStudentsListInHumanReadableFormat();
                DisplayTeachersListInHumanReadableFormat();
                DisplayUsersListInHumanReadableFormat();
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@List Of System Objects Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }


        DataTable datatable1;
        private void DisplayStudentsListInHumanReadableFormat()
        {
            try
            {
                string sqlquery1 = "SELECT * FROM [Tbl.Students]";
                sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
                datatable1 = new DataTable();

                sqldataadapter.Fill(datatable1);
                StudentsListGridView.AutoGenerateColumns = false;
                StudentsListGridView.DataSource = datatable1;
            }

            catch (Exception) {
                //DONT DISPLAY ANYTHING SHIT !
            }
        }

        DataTable datatable2;
        private void DisplayTeachersListInHumanReadableFormat()
        {
            try
            {
                string sqlquery2 = "SELECT * FROM [Tbl.Teachers]";
                sqldataadapter = new SqlDataAdapter(sqlquery2, sqlconnection);
                datatable2 = new DataTable();

                sqldataadapter.Fill(datatable2);
                TeachersListGridView.AutoGenerateColumns = false;
                TeachersListGridView.DataSource = datatable2;
            }

            catch (Exception) {
                //DONT DISPLAY ANYTHING SHIT !
            }
        }

        DataTable datatable3;
        private void DisplayUsersListInHumanReadableFormat()
        {
            try
            {
                string sqlquery3 = "SELECT * FROM [Tbl.Users]";
                sqldataadapter = new SqlDataAdapter(sqlquery3, sqlconnection);
                datatable3 = new DataTable();

                sqldataadapter.Fill(datatable3);
                UsersListGridView.AutoGenerateColumns = false;
                UsersListGridView.DataSource = datatable3;
            }

            catch (Exception) {
                //DONT DISPLAY ANYTHING SHIT !
            }
        }

        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dataview = datatable1.DefaultView;
                dataview.RowFilter = string.Format("[STUDENT ID] like '%{0}%'", SearchTextBox.Text.Trim());
                StudentsListGridView.DataSource = dataview.ToTable();
            }
        }

        private void SearchTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dataview = datatable2.DefaultView;
                dataview.RowFilter = string.Format("[TEACHER ID] like '%{0}%'", SearchTextbox2.Text.Trim());
                TeachersListGridView.DataSource = dataview.ToTable();
            }
        }

        private void SearchTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dataview = datatable3.DefaultView;
                dataview.RowFilter = string.Format("[USER ID] like '%{0}%'", SearchTextbox3.Text.Trim());
                UsersListGridView.DataSource = dataview.ToTable();
            }
        }

        private void RefreshPicture1_Click(object sender, EventArgs e)
        {
            SearchTextBox.ResetText();
            bunifuCards1.Select();
            DisplayStudentsListInHumanReadableFormat();
        }

        private void RefreshPicture1_MouseHover(object sender, EventArgs e)
        {
            RefreshPicture1.Size = new Size(40, 40);
        }

        private void RefreshPicture1_MouseLeave(object sender, EventArgs e)
        {
            RefreshPicture1.Size = new Size(38, 38);
        }

        private void RefreshPicture2_Click(object sender, EventArgs e)
        {
            SearchTextbox2.ResetText();
            bunifuCards1.Select();
            DisplayTeachersListInHumanReadableFormat();
        }

        private void RefreshPicture2_MouseHover(object sender, EventArgs e)
        {
            RefreshPicture2.Size = new Size(40, 40);
        }

        private void RefreshPicture2_MouseLeave(object sender, EventArgs e)
        {
            RefreshPicture2.Size = new Size(38, 38);
        }

        private void RefreshPicture3_Click(object sender, EventArgs e)
        {
            SearchTextbox3.ResetText();
            UserIDTextbox.ResetText();
            bunifuCards1.Select();
            DisplayUsersListInHumanReadableFormat();
        }

        private void RefreshPicture3_MouseHover(object sender, EventArgs e)
        {
            RefreshPicture3.Size = new Size(40, 40);
        }

        private void RefreshPicture3_MouseLeave(object sender, EventArgs e)
        {
            RefreshPicture3.Size = new Size(38, 38);
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

                    else if (UserID.Equals(UserIDTextbox.Text.Trim()) || UserIDTextbox.Text.Trim().Equals(UserID))
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.error;
                        notificationwindow.MessageText = "THIS OPERATION CANNOT BE DONE\nBECAUSE YOU CANNOT ALTER\nYOUR OWN ACCOUNT !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();
                    }

                    else
                    {
                        string sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Users] WHERE [USER ID] = '" + UserIDTextbox.Text.Trim() + "'";
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

                                if (PlsDontContinue == DialogResult.No || PlsDontContinue == DialogResult.Cancel) {
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

                                    RefreshPicture3_Click(sender, e);
                                }
                            }

                            else if (isActive.Equals("Disabled"))
                            {
                                string alterquery2 = "UPDATE [Tbl.Users] SET [ACCOUNT STATUS] = @accountstatus WHERE [USER ID] = '" +
                                     UserIDTextbox.Text.Trim() + "'";

                                sqlcommand = new SqlCommand(alterquery2, sqlconnection);
                                sqlcommand.Parameters.AddWithValue("@accountstatus", "Active");
                                sqlcommand.ExecuteNonQuery();

                                notificationwindow.CaptionText = "MESSAGE CONTENT";
                                notificationwindow.MsgImage.Image = Properties.Resources.check;
                                notificationwindow.MessageText = "USER ACCOUNT IS NOW ENABLED !";

                                darkeropacityform.Show();
                                notificationwindow.ShowDialog();
                                darkeropacityform.Hide();

                                RefreshPicture3_Click(sender, e);
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
                    MessageBox.Show(exception.Message.ToString(), "@List Of System Objects Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void SearchTextbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void SearchTextbox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void TabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
            {
                DisplayStudentsListInHumanReadableFormat();
            }

            else if (TabControl.SelectedIndex == 1)
            {
                DisplayTeachersListInHumanReadableFormat();
            }

            else if (TabControl.SelectedIndex == 2)
            {
                DisplayUsersListInHumanReadableFormat();
            }
        }

        private bool IsNumber(string N)
        {
            try {
                int.Parse(N);
                return true;
            }

            catch (Exception) {
                return false;
            }
        }
    }
}
