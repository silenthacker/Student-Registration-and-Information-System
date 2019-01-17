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
    public partial class ManageStudentsForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;

        DarkerOpacityForm darkeropacityform;
        NotificationWindow notificationwindow;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        //SqlDataAdapter sqldataadapter;

        private string G7, G8, G9, G10, UpdateQuery;

        public ManageStudentsForm()
        {
            InitializeComponent();
        }

        private void DisAllowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (G7CheckBox.Checked == true || G8CheckBox.Checked == true
                || G9CheckBox.Checked == true || G10CheckBox.Checked == true)
            {
                DisAllowRadioButton.Checked = false;
            }
        }

        private void G7CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (G7CheckBox.Checked == true || G8CheckBox.Checked == true
                || G9CheckBox.Checked == true || G10CheckBox.Checked == true)
            {
                DisAllowRadioButton.Checked = false;
            }

            else
            {
                DisAllowRadioButton.Checked = true;
            }
        }

        private void ManageStudentsForm_Load(object sender, EventArgs e)
        {
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
                    Where_To_Check_CheckBoxes();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Manage Student Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Manage Student Form Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void Where_To_Check_CheckBoxes()
        {
            try
            {
                string Query1 = "SELECT [VALUE] FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG101'";
                sqlcommand = new SqlCommand(Query1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    G7 = sqldatareader.GetString(0);
                    if (G7.Equals("1"))
                        G7CheckBox.Checked = true;
                }
                sqldatareader.Close();

                string Query2 = "SELECT [VALUE] FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG102'";
                sqlcommand = new SqlCommand(Query2, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    G8 = sqldatareader2.GetString(0);
                    if (G8.Equals("1"))
                        G8CheckBox.Checked = true;
                }
                sqldatareader2.Close();

                string Query3 = "SELECT [VALUE] FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG103'";
                sqlcommand = new SqlCommand(Query3, sqlconnection);
                SqlDataReader sqldatareader3 = sqlcommand.ExecuteReader();

                while (sqldatareader3.Read())
                {
                    G9 = sqldatareader3.GetString(0);
                    if (G9.Equals("1"))
                        G9CheckBox.Checked = true;
                }
                sqldatareader3.Close();

                string Query4 = "SELECT [VALUE] FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG104'";
                sqlcommand = new SqlCommand(Query4, sqlconnection);
                SqlDataReader sqldatareader4 = sqlcommand.ExecuteReader();

                while (sqldatareader4.Read())
                {
                    G10 = sqldatareader4.GetString(0);
                    if (G10.Equals("1"))
                        G10CheckBox.Checked = true;
                }
                sqldatareader4.Close();
                
                if (G7.Equals("0") && G8.Equals("0") && G9.Equals("0") && G10.Equals("0"))
                    DisAllowRadioButton.Checked = true;
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                //GRADE 7 - SEG101
                if (G7CheckBox.CheckState == CheckState.Checked)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG101'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "1");
                    sqlcommand.ExecuteNonQuery();
                }
                
                else if (G7CheckBox.CheckState == CheckState.Unchecked)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG101'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "0");
                    sqlcommand.ExecuteNonQuery();
                }

                //GRADE 8 - SEG102
                if (G8CheckBox.CheckState == CheckState.Checked)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG102'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "1");
                    sqlcommand.ExecuteNonQuery();
                }

                else if (G8CheckBox.CheckState == CheckState.Unchecked)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG102'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "0");
                    sqlcommand.ExecuteNonQuery();
                }

                //GRADE 9 - SEG103
                if (G9CheckBox.CheckState == CheckState.Checked)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG103'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "1");
                    sqlcommand.ExecuteNonQuery();
                }

                else if (G9CheckBox.CheckState == CheckState.Unchecked)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG103'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "0");
                    sqlcommand.ExecuteNonQuery();
                }

                //GRADE 10 - SEG104
                if (G10CheckBox.CheckState == CheckState.Checked)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG104'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "1");
                    sqlcommand.ExecuteNonQuery();
                }

                else if (G10CheckBox.CheckState == CheckState.Unchecked)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG104'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "0");
                    sqlcommand.ExecuteNonQuery();
                }


                //DISALLOW ALL
                if (DisAllowRadioButton.Checked == true)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG101'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "0");
                    sqlcommand.ExecuteNonQuery();

                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG102'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "0");
                    sqlcommand.ExecuteNonQuery();

                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG103'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "0");
                    sqlcommand.ExecuteNonQuery();

                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG104'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "0");
                    sqlcommand.ExecuteNonQuery();
                }

                notificationwindow.CaptionText = "STUDENT REGISTRATION & INFORMATION SYSTEM";
                notificationwindow.MsgImage.Image = Properties.Resources.check;
                notificationwindow.MessageText = "SUCCESSFULLY SAVED !";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();

                DialogResult = DialogResult.OK;
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void G7CheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }
    }
}
