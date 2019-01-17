using System;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Application
{
    public partial class OtherSettingsForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;

        SQLConnectionConfig sqlconnectionconfig;
        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;
        GetCurrentSchoolYear getcurrentschoolyear;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;
        private string EntryID, IsCheck, currentschoolyear;

        public OtherSettingsForm()
        {
            InitializeComponent();
        }

        private void SystemDefaultsForm_Load(object sender, EventArgs e)
        {
            SaveButton.Select();
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 10);

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
                    //DON'T MIND THIS !
                    Where_To_Check_Radio_Buttons();

                    //DISPLAY CURRENT SCHOOL YEAR
                    Init_Current_SchoolYear();

                    //INITIALIZE SCHOOL YEAR DROPDOWN AND ID
                    Retrieve_School_Year_List_And_ID();

                    //CHECK VALIDITY OF SECTIONS
                    Enable_Or_Disable_2ndSaveButton();

                    //INITIALIZE SECTION ID DROPDOWN
                    Retrieve_SectionID_List();

                    //POPULATE DATAGRIDVIES
                    Load_Section_Records();
                    Load_School_Year_Records();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.ToString(), "@Other Settings Form Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Other Settings Form Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }
        
        private void Init_Current_SchoolYear()
        {
            string sqlquery0 = "SELECT [CURRENT SCHOOL YEAR] FROM [Tbl.CurrentSchoolYear]";
            sqlcommand = new SqlCommand(sqlquery0, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                CurrentSchoolYearLabel.Text = "* CURRENT SCHOOL YEAR: " + sqldatareader.GetString(0);
            }
            sqldatareader.Close();
        }

        private void Where_To_Check_Radio_Buttons()
        {
            string TempQuery = "SELECT VALUE FROM [Tbl.SystemSettings] WHERE [SETTINGS ID] = 'SEG100'";
            sqlcommand = new SqlCommand(TempQuery, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read()) {
                IsCheck = sqldatareader.GetString(0);
            }
            sqldatareader.Close();

            if (IsCheck.Equals("0")) {
                DisableAllRadioButton.Checked = true;
            }

            else if (IsCheck.Equals("1FG")) {
                FirstGradingRadioButton.Checked = true;   
            }

            else if (IsCheck.Equals("2SG")) {
                SecondGradingRadioButton.Checked = true;
            }

            else if (IsCheck.Equals("3TG")) {
                ThirdGradingRadioButton.Checked = true;
            }

            else if (IsCheck.Equals("4FG")) {
                FourthGradingRadioButton.Checked = true;
            }
        }

        private void Enable_Or_Disable_2ndSaveButton()
        {
            string sqlquery0 = "SELECT COUNT(*) FROM [Tbl.Sections]";
            sqldataadapter = new SqlDataAdapter(sqlquery0, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                SaveButton2.Enabled = true;
                DeleteFlatButton1.Enabled = true;

                SaveButton2.Cursor = Cursors.Default;
                DeleteFlatButton1.Cursor = Cursors.Default;
            }

            else if (datatable.Rows[0][0].ToString() == "0")
            {
                SaveButton2.Enabled = false;
                DeleteFlatButton1.Enabled = false;

                SaveButton2.Cursor = Cursors.No;
                DeleteFlatButton1.Cursor = Cursors.No;
            }
        }

        private void Retrieve_School_Year_List_And_ID()
        {
            try
            {
                string sqlquery1 = "SELECT [ENTRY ID], [SCHOOL YEAR] FROM [Tbl.SchoolYear]";
                sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    SchoolYearIDDropdown.AddItem(sqldatareader.GetString(0));
                    SchoolYearDropdown.AddItem(sqldatareader.GetString(1));
                    CurrentSchoolYearDropdown.AddItem(sqldatareader.GetString(1));
                }
                sqldatareader.Close();

                SchoolYearIDDropdown.selectedIndex = 0;
                SchoolYearDropdown.selectedIndex = 0;
                CurrentSchoolYearDropdown.selectedIndex = 0;
            }

            catch (Exception) {
                //DO NOTHING SHIT !
            }
        }

        private void Retrieve_SectionID_List()
        {
            try
            {
                string sqlquery2 = "SELECT [SECTION ID] FROM [Tbl.Sections]";
                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    SectionIDDropdown.AddItem(sqldatareader.GetString(0));
                }
                sqldatareader.Close();
                SectionIDDropdown.selectedIndex = 0;
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }
        
        private void Load_Section_Records()
        {
            string sqlquery3 = "SELECT * FROM [Tbl.Sections]";
            sqldataadapter = new SqlDataAdapter(sqlquery3, sqlconnection);
            DataTable datatable = new DataTable();

            sqldataadapter.Fill(datatable);
            SectionsGridView.AutoGenerateColumns = false;
            SectionsGridView.DataSource = datatable;
        }

        private void Load_School_Year_Records()
        {
            string sqlquery4 = "SELECT * FROM [Tbl.SchoolYear]";
            sqldataadapter = new SqlDataAdapter(sqlquery4, sqlconnection);
            DataTable datatable = new DataTable();

            sqldataadapter.Fill(datatable);
            SchoolYarGridView.AutoGenerateColumns = false;
            SchoolYarGridView.DataSource = datatable;
        }

        //SAVE CURRENT SCHOOL YEAR
        private void SaveButton_Click(object sender, EventArgs e)
        {
            variables = new Variables();
            opacityform = new OpacityForm();
            
            //EXCEPTION 2
            try
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                string GetID = "SELECT [ENTRY ID] FROM [Tbl.SchoolYear] WHERE [SCHOOL YEAR] = '" + 
                    CurrentSchoolYearDropdown.selectedValue.ToString() + "'";
                sqlcommand = new SqlCommand(GetID, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    EntryID = sqldatareader.GetString(0);
                }
                sqldatareader.Close();

                string TempQuery = "SELECT COUNT(*) FROM [Tbl.CurrentSchoolYear]";
                sqldataadapter = new SqlDataAdapter(TempQuery, sqlconnection);
                DataTable datatable = new DataTable();
                sqldataadapter.Fill(datatable);
                
                if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
                {
                    string UpdateQuery0 = "UPDATE [Tbl.CurrentSchoolYear] SET [CURRENT SCHOOL YEAR] = @currentschoolyear, [SCHOOL YEAR ID] = @slyid";
                    sqlcommand = new SqlCommand(UpdateQuery0, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@currentschoolyear", CurrentSchoolYearDropdown.selectedValue.ToString());
                    sqlcommand.Parameters.AddWithValue("@slyid", EntryID);
                    sqlcommand.ExecuteNonQuery();

                    string UpdateQuery1 = "UPDATE [Tbl.SchoolYear] SET [WAS SET] = @ws WHERE [ENTRY ID] = '" + EntryID + "'";
                    sqlcommand = new SqlCommand(UpdateQuery1, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@ws", "1");
                    sqlcommand.ExecuteNonQuery();

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                    notificationwindow.MessageText = "CURRENT SCHOOL YEAR WAS\nSET TO " + CurrentSchoolYearDropdown.selectedValue.ToString();

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();

                    //SYNC NEW CURRENT SECTION LABEL
                    CurrentSchoolYearLabel.Text = "* CURRENT SCHOOL YEAR: " + CurrentSchoolYearDropdown.selectedValue.ToString();

                    //RESET CONTROL STATE
                    CurrentSchoolYearDropdown.selectedIndex = 0;
                }

                else if (datatable.Rows[0][0].ToString() == "0")
                {
                    string UpdateQuery0_0 = "INSERT INTO [Tbl.CurrentSchoolYear]([CURRENT SCHOOL YEAR], [SCHOOL YEAR ID]) VALUES(@currentschoolyear, @slyid)";
                    sqlcommand = new SqlCommand(UpdateQuery0_0, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@currentschoolyear", CurrentSchoolYearDropdown.selectedValue.ToString());
                    sqlcommand.Parameters.AddWithValue("@slyid", EntryID);
                    sqlcommand.ExecuteNonQuery();

                    string UpdateQuery1 = "UPDATE [Tbl.SchoolYear] SET [WAS SET] = @ws WHERE [ENTRY ID] = '" + EntryID + "'";
                    sqlcommand = new SqlCommand(UpdateQuery1, sqlconnection);
                    sqlcommand.Parameters.AddWithValue("@ws", "1");
                    sqlcommand.ExecuteNonQuery();

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                    notificationwindow.MessageText = "CURRENT SCHOOL YEAR WAS\nSET TO " + CurrentSchoolYearDropdown.selectedValue.ToString();

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();

                    //SYNC NEW CURRENT SECTION LABEL
                    CurrentSchoolYearLabel.Text = "* CURRENT SCHOOL YEAR: " + CurrentSchoolYearDropdown.selectedValue.ToString();

                    //RESET CONTROL STATE
                    CurrentSchoolYearDropdown.selectedIndex = 0;
                }

                //UPDATE REGISTRY VALUES
                RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                updateregistrykey.SetValue("NofMaxSections", "0");
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Other Settings Form Exception 2",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        //DELETE SECTIONS
        private void DeleteFlatButton1_Click(object sender, EventArgs e)
        {
            variables = new Variables();
            opacityform = new OpacityForm();
            
            //DELETE SECTION EXCEPTION
            try
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                string TempQuery = "SELECT COUNT(*) FROM [Tbl.Sections]" +
                        " WHERE [SECTION ID] = '" + SectionIDDropdown.selectedValue.ToString() + "' AND [ENROLLED] = '0'";
                sqldataadapter = new SqlDataAdapter(TempQuery, sqlconnection);
                DataTable datatable = new DataTable();
                sqldataadapter.Fill(datatable);

                if (datatable.Rows[0][0].ToString() == "1")
                {
                    RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                    string CurrentSectionCount = registrykey.GetValue("NofMaxSections").ToString();
                    
                    string DeleteQuery = "DELETE FROM [Tbl.Sections] WHERE [SECTION ID] = '" + SectionIDDropdown.selectedValue.ToString() + "'";
                    sqlcommand = new SqlCommand(DeleteQuery , sqlconnection);
                    sqlcommand.ExecuteNonQuery();

                    //UPDATE SECTION COUNT
                    RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                    updateregistrykey.SetValue("NofMaxSections", (int.Parse(CurrentSectionCount) - 1).ToString());

                    //REFRESH SECTIONS GRIDVIEW
                    Load_Section_Records();

                    //REMOVE DELETED ID
                    SectionIDDropdown.Clear();

                    //RETRIEVE NEW VALUES
                    Retrieve_SectionID_List();
                }

                else if (datatable.Rows[0][0].ToString() == "0")
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                    notificationwindow.MessageText = "THIS SECTION CAN'T BE DELETED,\nSOME STUDENTS ARE ENROLLED HERE !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Delete Section Exception",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        //UPDATE SECTION ERRORS
        private void SaveButton2_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            getcurrentschoolyear = new GetCurrentSchoolYear();
            currentschoolyear = getcurrentschoolyear.GetCurrentSchoolYearData();

            //EXCEPTION 3
            try
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                if (AlterSectionValueTextbox.Text.Trim().Length < 1 || AlterMaximumStudentValueTextbox.Text.Trim().Length < 1)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE NEW SECTION NAME\n&& MAXIMUM STUDENTS !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (isnumber(AlterMaximumStudentValueTextbox.Text.Trim()) == false)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "INVALID VALUE ON MAXIMUM STUDENTS !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else
                {
                    string TempQuery = "SELECT COUNT(*) FROM [Tbl.Sections]" +
                        " WHERE [SECTION ID] = '" + SectionIDDropdown.selectedValue.ToString() + "' AND [ENROLLED] = '0'";
                    sqldataadapter = new SqlDataAdapter(TempQuery, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    if (datatable.Rows[0][0].ToString() == "1")
                    {
                        //TODO:
                        string VerifyQuery = "SELECT COUNT(*) FROM [Tbl.Sections] WHERE [SECTION NAME] = '" +
                            AlterSectionValueTextbox.Text.Trim().ToUpper() + "' AND [SCHOOL YEAR] = '" + currentschoolyear + "'";
                        sqldataadapter = new SqlDataAdapter(VerifyQuery, sqlconnection);
                        DataTable virtualtable = new DataTable();
                        sqldataadapter.Fill(virtualtable);

                        if (virtualtable.Rows[0][0].ToString() == "1")
                        {
                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.warning;
                            notificationwindow.MessageText = "THAT SECTION ALREADY EXIST FOR \nSCHOOL YEAR " +
                                CurrentSchoolYearDropdown.selectedValue.ToString();

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }

                        else if (virtualtable.Rows[0][0].ToString() == "0")
                        {
                            string UpdateQuery1 = "UPDATE [Tbl.Sections] SET [SECTION NAME] = @secname, [MAXIMUM STUDENTS] = @maxstud," + 
                                "[SCHOOL YEAR] = @scholyear WHERE [SECTION ID] = '" + SectionIDDropdown.selectedValue.ToString() + "'";

                            sqlcommand = new SqlCommand(UpdateQuery1, sqlconnection);
                            sqlcommand.Parameters.AddWithValue("@secname", AlterSectionValueTextbox.Text.Trim().ToUpper());
                            sqlcommand.Parameters.AddWithValue("@maxstud", AlterMaximumStudentValueTextbox.Text.Trim());
                            sqlcommand.Parameters.AddWithValue("@scholyear", SchoolYearDropdown.selectedValue.ToString());
                            sqlcommand.ExecuteNonQuery();

                            //REFRESH SECTIONS GRIDVIEW
                            Load_Section_Records();

                            //RESET CONTROL STATE
                            SchoolYearDropdown.selectedIndex = 0;
                            AlterSectionValueTextbox.ResetText();
                            AlterMaximumStudentValueTextbox.ResetText();
                        }
                    }

                    else if (datatable.Rows[0][0].ToString() == "0")
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.error;
                        notificationwindow.MessageText = "YOU CAN'T ALTER THIS SECTION,\nSOME STUDENTS ARE ENROLLED HERE !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Other Settings Form Exception 3",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        //DELETE SCHOOL YEAR
        private void DeleteFlatButton2_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            
            //DELETE SCHOOL YEAR EXCEPTION
            try
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                string TempString = "SELECT COUNT(*) FROM [Tbl.SchoolYear] WHERE [ENTRY ID] = '" + SchoolYearIDDropdown.selectedValue.ToString() 
                    + "' AND [WAS SET] = '0'";
                sqldataadapter = new SqlDataAdapter(TempString, sqlconnection);
                DataTable datatable = new DataTable();
                sqldataadapter.Fill(datatable);

                if (datatable.Rows[0][0].ToString() == "1")
                {
                    string DeleteQuery = "DELETE FROM [Tbl.SchoolYear] WHERE [ENTRY ID] = '" + SchoolYearIDDropdown.selectedValue.ToString() + "'";
                    sqlcommand = new SqlCommand(DeleteQuery, sqlconnection);
                    sqlcommand.ExecuteNonQuery();

                    //REFRESH SCHOOL YEAR GRIDVIEW
                    Load_School_Year_Records();

                    //REMOVE DELETED VALUES
                    CurrentSchoolYearDropdown.Clear();
                    SectionIDDropdown.Clear();
                    SchoolYearDropdown.Clear();
                    SchoolYearIDDropdown.Clear();

                    //RETRIEVE NEW VALUES
                    Retrieve_School_Year_List_And_ID();
                    Retrieve_SectionID_List();
                }

                else if (datatable.Rows[0][0].ToString() == "0")
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.error;
                    notificationwindow.MessageText = "THIS SCHOOL YEAR CAN'T BE DELETED,\nSOME STUDENTS ARE ENROLLED HERE !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Delete School Year Exception",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        //UPDATE SCHOOL YEAR ERRORS
        private void SaveButton3_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();

            //EXCEPTION 4
            try
            {
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                if (AlterSchoolYearValueTextbox.Text.Trim().Length < 1)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE A SCHOOL YEAR !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (!AlterSchoolYearValueTextbox.Text.Trim().ToUpper().Contains("S.Y."))
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
                    string TempQuery = "SELECT COUNT(*) FROM [Tbl.CurrentSchoolYear] WHERE [SCHOOL YEAR ID] = '" + 
                        SchoolYearIDDropdown.selectedValue.ToString() + "'";
                    sqldataadapter = new SqlDataAdapter(TempQuery, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);
                    
                    if (datatable.Rows[0][0].ToString() == "1")
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.error;
                        notificationwindow.MessageText = "YOU CAN'T ALTER THE CURRENT\nSCHOOL YEAR !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();
                    }

                    else if (datatable.Rows[0][0].ToString() == "0")
                    {
                        string TempQuery1 = "SELECT COUNT(*) FROM [Tbl.SchoolYear] WHERE [ENTRY ID] = '" + 
                            SchoolYearIDDropdown.selectedValue.ToString() + "' AND [WAS SET] = '0'";

                        sqldataadapter = new SqlDataAdapter(TempQuery1, sqlconnection);
                        DataTable datatable1 = new DataTable();
                        sqldataadapter.Fill(datatable1);

                        if (datatable1.Rows[0][0].ToString() == "1")
                        {
                            string UpdateQuery2 = "UPDATE [Tbl.SchoolYear] SET [SCHOOL YEAR] = @schoolyear WHERE [ENTRY ID] = '" +
                            SchoolYearIDDropdown.selectedValue.ToString() + "'";

                            sqlcommand = new SqlCommand(UpdateQuery2, sqlconnection);
                            sqlcommand.Parameters.AddWithValue("@schoolyear", AlterSchoolYearValueTextbox.Text.Trim().ToUpper());
                            sqlcommand.ExecuteNonQuery();

                            //REFRESH SCHOOL YEAR GRIDVIEW
                            Load_School_Year_Records();

                            //RESET CONTROL STATE
                            SchoolYearIDDropdown.selectedIndex = 0;
                            AlterSchoolYearValueTextbox.ResetText();
                            bunifuCards1.Select();

                            //REMOVE OLD VALUES
                            SchoolYearDropdown.Clear();
                            SchoolYearIDDropdown.Clear();
                            CurrentSchoolYearDropdown.Clear();

                            //SYNC NEW VALUE TO SCHOOL YEAR DROPDOWNS
                            Retrieve_School_Year_List_And_ID();
                        }

                        else if (datatable1.Rows[0][0].ToString() == "0")
                        {
                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.error;
                            notificationwindow.MessageText = "THIS SCHOOL YEAR CAN'T BE ALTERED !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Other Settings Form Exception 4",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }
        
        private void OtherSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlconnection.Close();
        }

        //1FG
        private void FirstGradingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();

            //EXCEPTION 5
            try
            {
                string UpdateQuery4 = "UPDATE [Tbl.SystemSettings] SET VALUE = '1FG' WHERE [SETTINGS ID] = 'SEG100'";
                sqlcommand = new SqlCommand(UpdateQuery4, sqlconnection);
                sqlcommand.ExecuteNonQuery();
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Other Settings Form Exception 5",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        //2SG
        private void SecondGradingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();

            //EXCEPTION 6
            try
            {
                string UpdateQuery4 = "UPDATE [Tbl.SystemSettings] SET VALUE = '2SG' WHERE [SETTINGS ID] = 'SEG100'";
                sqlcommand = new SqlCommand(UpdateQuery4, sqlconnection);
                sqlcommand.ExecuteNonQuery();
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Other Settings Form Exception 6",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        //3TG
        private void ThirdGradingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();

            //EXCEPTION 7
            try
            {
                string UpdateQuery4 = "UPDATE [Tbl.SystemSettings] SET VALUE = '3TG' WHERE [SETTINGS ID] = 'SEG100'";
                sqlcommand = new SqlCommand(UpdateQuery4, sqlconnection);
                sqlcommand.ExecuteNonQuery();
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Other Settings Form Exception 7",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        //4FG
        private void FourthGradingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();

            //EXCEPTION 8
            try
            {
                string UpdateQuery4 = "UPDATE [Tbl.SystemSettings] SET VALUE = '4FG' WHERE [SETTINGS ID] = 'SEG100'";
                sqlcommand = new SqlCommand(UpdateQuery4, sqlconnection);
                sqlcommand.ExecuteNonQuery();
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Other Settings Form Exception 8",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        //0
        private void DisableAllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();

            //EXCEPTION 9
            try
            {
                string UpdateQuery4 = "UPDATE [Tbl.SystemSettings] SET VALUE = '0' WHERE [SETTINGS ID] = 'SEG100'";
                sqlcommand = new SqlCommand(UpdateQuery4, sqlconnection);
                sqlcommand.ExecuteNonQuery();
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Other Settings Form Exception 9",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        private void CurrentSchoolYearDropdown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool isnumber(string N)
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