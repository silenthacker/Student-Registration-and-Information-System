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
    public partial class ManageTeachersForm : Form
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

        private string indicator, UpdateQuery;

        public ManageTeachersForm()
        {
            InitializeComponent();
        }

        private void ManageTeachersForm_Load(object sender, EventArgs e)
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
                    MessageBox.Show(exception.Message.ToString(), "@Manage Teacher Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Manage Teacher Form Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void Where_To_Check_CheckBoxes()
        {
            try
            {
                string Query1 = "SELECT [VALUE] FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG105'";
                sqlcommand = new SqlCommand(Query1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    indicator = sqldatareader.GetString(0);

                    if (indicator.Equals("1"))
                        AllowRadioButton.Checked = true;

                    else if (indicator.Equals("0"))
                        DisAllowRadioButton.Checked = true;

                    else
                        NotSureRadioButton.Checked = true;
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }
        
        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();
                
                if (AllowRadioButton.Checked == true)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG105'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "1");
                    sqlcommand.ExecuteNonQuery();
                }

                else if (DisAllowRadioButton.Checked == true)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG105'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "0");
                    sqlcommand.ExecuteNonQuery();
                }

                else if (NotSureRadioButton.Checked == true)
                {
                    UpdateQuery = "UPDATE [Tbl.SystemSettings] SET [VALUE] = @value WHERE [SETTINGS ID] = 'SEG105'";
                    sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@value", "NS");
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

        private void ManageTeachersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }
    }
}
