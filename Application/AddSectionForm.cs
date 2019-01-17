using System;
using System.Data;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class AddSectionForm : Form
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

        internal string Prefix, CurrentSectionCount;
        int NewSectionID; string str1, str2, str3;
        private string sqlquery1, sqlquery2, sqlquery3, sqlquery4, sqlquery5;
        
        public AddSectionForm()
        {
            InitializeComponent();
        }
        
        private void AddSectionForm_Load(object sender, EventArgs e)
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
                    Init_NewSectionID();
                    RetriveSectionData();
                    RetrieveSchoolYearList();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.ToString(), "@Add Section Form Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Add Section Form Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }
        
        private void Init_NewSectionID()
        {
            getspecifiedprefix = new GetSpecifiedPrefix();
            Prefix = getspecifiedprefix.GetSectionIDPrefix();

            sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Sections]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST SECTION ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                sqlquery2 = "SELECT [SECTION ID] FROM [Tbl.Sections]";
                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    str1 = sqldatareader.GetString(0);
                    str3 = str1.Remove(0, Prefix.Length);
                    NewSectionID = int.Parse(str3) + 1;
                }
                sqldatareader.Close();
            }

            //AUTO ASSIGN NEW SECTION ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                sqlquery3 = "SELECT SUFFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = '" + "SECTION ID" + "'";
                sqlcommand = new SqlCommand(sqlquery3, sqlconnection);
                SqlDataReader sqldatareader1 = sqlcommand.ExecuteReader();

                while (sqldatareader1.Read())
                {
                    str2 = sqldatareader1.GetString(0);
                    NewSectionID = int.Parse(str2);
                }
                sqldatareader1.Close();
            }
        }

        private void RetrieveSchoolYearList()
        {
            try
            {
                string localvariablestring = "SELECT [CURRENT SCHOOL YEAR] FROM [Tbl.CurrentSchoolYear]";
                sqlcommand = new SqlCommand(localvariablestring, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    CurrentSchoolYearDropdown.AddItem(sqldatareader.GetString(0));
                }
                CurrentSchoolYearDropdown.selectedIndex = 0;
                sqldatareader.Close();
            }

            catch (Exception) {
                //DONT DISPLAY ANYTHING SHIT !
            }
        }

        private void SectionNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                InsertButton_Click(sender, e);
            }
        }

        private void MaxStudentTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                InsertButton_Click(sender, e);
            }
        }

        private void RetriveSectionData()
        {
            //EXCEPTION 2
            try
            {
                sqlquery4 = "SELECT * FROM [Tbl.Sections]";
                sqldataadapter = new SqlDataAdapter(sqlquery4, sqlconnection);
                DataTable datatable = new DataTable();

                sqldataadapter.Fill(datatable);
                ListofSectionsGridview.AutoGenerateColumns = false;
                ListofSectionsGridview.DataSource = datatable;
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Add Section Form Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }
        
        private void InsertButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 3
            try
            {
                variables = new Variables();
                opacityform = new OpacityForm();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                if (SectionNameTextbox.Text.Trim().Length < 1 || MaxStudentTextbox.Text.Trim().Length < 1)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE SECTION NAME,\nMAXIMUM STUDENTS AND SCHOOL YEAR !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (isNumber(MaxStudentTextbox.Text.Trim()) == false)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "INVALID DATA ON MAXIMUM STUDENTS !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
                
                else
                {
                    //INNER EXCEPTION 3
                    try
                    {
                        string TempQuery = "SELECT COUNT(*) FROM [Tbl.Sections] WHERE [SECTION NAME] = '" + 
                            SectionNameTextbox.Text.Trim().ToUpper()  + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYearDropdown.selectedValue.ToString() + "'";

                        sqldataadapter = new SqlDataAdapter(TempQuery, sqlconnection);
                        DataTable datatable = new DataTable();
                        sqldataadapter.Fill(datatable);
                        
                        if (datatable.Rows[0][0].ToString() == "1")
                        {
                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.warning;
                            notificationwindow.MessageText = "THAT SECTION ALREADY EXIST FOR \nSCHOOL YEAR " + CurrentSchoolYearDropdown.selectedValue.ToString();

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }

                        else if (datatable.Rows[0][0].ToString() == "0")
                        {
                            RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                            CurrentSectionCount = registrykey.GetValue("NofMaxSections").ToString();

                            if (int.Parse(CurrentSectionCount) < 10)
                            {
                                sqlquery5 = "INSERT INTO [Tbl.Sections]([SECTION ID], [SECTION NAME], [MAXIMUM STUDENTS], ENROLLED, [SCHOOL YEAR])" +
                                    " VALUES(@sectionid, @section_name, @maximumstudents, @enrolled, @schoolyear)";
                                sqlcommand = new SqlCommand(sqlquery5, sqlconnection);
                                sqlcommand.Parameters.AddWithValue("@sectionid", Prefix + NewSectionID.ToString());
                                sqlcommand.Parameters.AddWithValue("@section_name", SectionNameTextbox.Text.Trim().ToUpper());
                                sqlcommand.Parameters.AddWithValue("@maximumstudents", MaxStudentTextbox.Text.Trim());
                                sqlcommand.Parameters.AddWithValue("@enrolled", "0");
                                sqlcommand.Parameters.AddWithValue("@schoolyear", CurrentSchoolYearDropdown.selectedValue.ToString().ToUpper());
                                sqlcommand.ExecuteNonQuery();

                                //UPDATE SECTION COUNT
                                RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                                updateregistrykey.SetValue("NofMaxSections", (int.Parse(CurrentSectionCount) + 1).ToString());

                                Init_NewSectionID();
                                RetriveSectionData();

                                SectionNameTextbox.ResetText();
                                MaxStudentTextbox.ResetText();

                                CurrentSchoolYearDropdown.selectedIndex = 0;
                                InsertButton.Select();
                            }

                            else if (int.Parse(CurrentSectionCount) == 10)
                            {
                                notificationwindow.CaptionText = "MESSAGE CONTENT";
                                notificationwindow.MsgImage.Image = Properties.Resources.error;
                                notificationwindow.MessageText = "YOU CAN ONLY CREATE 10 SECTIONS\nEVERY SCHOOL YEAR !";

                                darkeropacityform.Show();
                                notificationwindow.ShowDialog();
                                darkeropacityform.Hide();
                            }
                        }
                    }

                    catch (Exception exception)
                    {
                        opacityform.Show();
                        MessageBox.Show(exception.Message.ToString(), "@Add Section Form Inner Exception 3",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Add Section Form Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        private void AddSectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlconnection.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void AddSectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool isNumber(string N)
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
