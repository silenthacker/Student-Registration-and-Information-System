using System;
using System.Data;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class AddSchoolYearForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;

        SQLConnectionConfig sqlconnectionconfig;
        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;
        GetSpecifiedPrefix getspecifiedprefix;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;
        
        private int NewEntryID;
        string sqlquery1, sqlquery2, Prefix_ID;

        public AddSchoolYearForm()
        {
            InitializeComponent();
        }

        private void AddSchoolYearForm_Load(object sender, EventArgs e)
        {
            InsertButton.Select();

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
                    Init_NewEntryID();
                    RetrieveSchoolYearData();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Add School Year Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Add School Year Form Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        private void Init_NewEntryID()
        {
            getspecifiedprefix = new GetSpecifiedPrefix();
            Prefix_ID = getspecifiedprefix.GetSchoolYearPrefix();

            string VerifyQuery = "SELECT COUNT(*) FROM [Tbl.SchoolYear]";
            sqldataadapter = new SqlDataAdapter(VerifyQuery, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST SCHOOL YEAR ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                sqlquery1 = "SELECT [ENTRY ID] FROM [Tbl.SchoolYear]";
                sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    string str1 = sqldatareader.GetString(0);
                    string str2 = str1.Remove(0, Prefix_ID.Length);
                    NewEntryID = int.Parse(str2) + 1;
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW SCHOOL YEAR ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                sqlquery2 = "SELECT SUFFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'SCHOOL YEAR ID'";
                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    string str2 = sqldatareader2.GetString(0);
                    NewEntryID = int.Parse(str2);
                }
                sqldatareader2.Close();
            }
        }

        private void RetrieveSchoolYearData()
        {
            string sqlquery0 = "SELECT * FROM [Tbl.SchoolYear]";
            sqldataadapter = new SqlDataAdapter(sqlquery0, sqlconnection);
            DataTable datatable = new DataTable();

            sqldataadapter.Fill(datatable);
            SchoolYearGridView.AutoGenerateColumns = false;
            SchoolYearGridView.DataSource = datatable;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 2
            try
            {
                opacityform = new OpacityForm();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                if (SchoolYearTextbox.Text.Trim().Length < 1)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE A SCHOOL YEAR !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
            
                else if (!SchoolYearTextbox.Text.Trim().ToUpper().Contains("S.Y."))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE FOLLOW AND PROVIDE\nTHE SPECIFIED SCHOOL YEAR FORMAT !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else
                {
                    //INNER EXCEPTION 2
                    try
                    {
                        string TempQuery = "SELECT COUNT(*) FROM [Tbl.SchoolYear] WHERE [SCHOOL YEAR] = '" + 
                            SchoolYearTextbox.Text.Trim().ToUpper() + "'";
                        sqldataadapter = new SqlDataAdapter(TempQuery, sqlconnection);
                        DataTable datatable0 = new DataTable();
                        sqldataadapter.Fill(datatable0);


                        if (datatable0.Rows[0][0].ToString() == "1")
                        {
                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.warning;
                            notificationwindow.MessageText = "THAT SCHOOL YEAR ALREADY EXIST !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }

                        else if (datatable0.Rows[0][0].ToString() == "0")
                        {
                            string InsertQuery = "INSERT INTO [Tbl.SchoolYear]([ENTRY ID], [SCHOOL YEAR], [WAS SET]) VALUES(@EntryID, @schoolyear, @ws)";
                            sqlcommand = new SqlCommand(InsertQuery, sqlconnection);
                            sqlcommand.Parameters.AddWithValue("@EntryID", Prefix_ID + NewEntryID.ToString());
                            sqlcommand.Parameters.AddWithValue("@schoolyear", SchoolYearTextbox.Text.Trim().ToUpper());
                            sqlcommand.Parameters.AddWithValue("@ws", "0");
                            sqlcommand.ExecuteNonQuery();
                            
                            RetrieveSchoolYearData();
                            SchoolYearTextbox.ResetText();
                            InsertButton.Select();
                            Init_NewEntryID();
                        }
                    }

                    catch (Exception exception)
                    {
                        opacityform.Show();
                        MessageBox.Show(exception.StackTrace.ToString(), "@Add School Year Form Inner Exception 2",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.StackTrace.ToString(), "@Add School Year Form Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        private void AddSchoolYearForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlconnection.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void SchoolYearTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }

            else if (e.KeyCode == Keys.Enter)
            {
                InsertButton_Click(sender, e);
            }
        }
    }
}
