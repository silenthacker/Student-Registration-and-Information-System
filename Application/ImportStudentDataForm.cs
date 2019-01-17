using System;
using System.Data;
using System.Drawing;
using Microsoft.Win32;

using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Application
{
    public partial class ImportStudentDataForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;

        SQLConnectionConfig sqlconnectionconfig;
        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;

        SqlConnection sqlconnection;
        SqlCommand sqlcommand;
        SqlDataAdapter sqldataadapter;
        DataTable datatable;

        private string CurrentSchoolYear;
        private bool isGeneratedid = false, isGeneratedup = false,
            isSuccessfull = false, Import_Student_Data_Begin = false;

        private string str1, str2, str3, str4;
        private int NewStudentID, VirtualStudentID, NewUserID, EntryCount;
        private string ReferSectionName, ReferGradeLevelName, Maximum_Students, Enrolled_Students;

        public ImportStudentDataForm()
        {
            InitializeComponent();
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 26);

            SaveButton.Enabled = false; GenerateidButton.Enabled = false; GenerateupButton.Enabled = false;
            SaveButton.Cursor = Cursors.No; GenerateidButton.Cursor = Cursors.No; GenerateupButton.Cursor = Cursors.No;

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
                    GetCurrentSchoolYear();
                    Populate_Section_Gridview();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Import Form Inner Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Import Form Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void GetCurrentSchoolYear()
        {
            try
            {
                string TempQuery = "SELECT [CURRENT SCHOOL YEAR] FROM [Tbl.CurrentSchoolYear]";
                sqlcommand = new SqlCommand(TempQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    CurrentSchoolYear = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DO NOTHING SHIT !
            }
        }

        private void Populate_Section_Gridview()
        {
            try
            {
                string sqlquery1 = "SELECT TOP 10 [SECTION ID], [SECTION NAME], [MAXIMUM STUDENTS]," +
                    " [ENROLLED], [SCHOOL YEAR] FROM [Tbl.Sections] WHERE [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
                DataTable datatable = new DataTable();

                sqldataadapter.Fill(datatable);
                ListofSectionsGridview.AutoGenerateColumns = false;
                ListofSectionsGridview.DataSource = datatable;
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        private void BrowseRaisedButton_Click(object sender, EventArgs e)
        {
            //EXCEPTION 2
            try
            {
                //START WORKING STATE
                BrowseButton.Cursor = Cursors.AppStarting;

                OpenFileDialog OFD = new OpenFileDialog();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                OFD.Multiselect = false;
                OFD.RestoreDirectory = true;
                OFD.Title = "Choose your excel file";
                OFD.InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\Documents";
                OFD.Filter = "Excel Workbook (*.xlsx;*.xls;)|*.xlsx;*.xls;";

                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    string WorkBookName = "Students";
                    string connectionstring = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + OFD.FileName.ToString() +
                    ";Extended Properties = 'Excel 12.0 XML; HDR = YES;';";
                    
                    OleDbConnection connection = new OleDbConnection(connectionstring);
                    OleDbCommand command = new OleDbCommand("SELECT * FROM [" + WorkBookName + "$]", connection);
                    connection.Open();

                    OleDbDataAdapter dataadapter = new OleDbDataAdapter(command);
                    datatable = new DataTable();
                    dataadapter.Fill(datatable);

                    GridView.DataSource = datatable;
                    GridView.AutoGenerateColumns = false;
                    connection.Close();

                    isGeneratedid = false; isGeneratedup = false;
                    GenerateidButton.Enabled = true; GenerateupButton.Enabled = true; SaveButton.Enabled = false;
                    GenerateidButton.Cursor = Cursors.Default; GenerateupButton.Cursor = Cursors.Default; SaveButton.Cursor = Cursors.No;
                }

                //STOP WORKING STATE
                BrowseButton.Cursor = Cursors.Default;
            }

            catch (Exception exception)
            {
                notificationwindow.CaptionText = "MESSAGE CONTENT";
                notificationwindow.MsgImage.Image = Properties.Resources.error;
                notificationwindow.MessageText = "AN ERROR OCCURED DURING IMPORT !\nTHE FOLLOWING MESSAGE MIGHT HELP.";

                darkeropacityform.Show();
                notificationwindow.ShowDialog();
                darkeropacityform.Hide();

                MessageBox.Show(exception.Message.ToString(), "@Import Form Exception 2",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Get_Latest_Studentid()
        {
            string sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Students]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST STUDENT ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                string sqlquery2 = "SELECT [STUDENT ID] FROM [Tbl.Students]";
                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    str1 = sqldatareader.GetString(0);
                    NewStudentID = int.Parse(str1) + 1;
                    VirtualStudentID = int.Parse(str1) + 1;
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW STUDENT ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                string sqlquery3 = "SELECT VALUE FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'STUDENT ID'";
                sqlcommand = new SqlCommand(sqlquery3, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    str2 = sqldatareader2.GetString(0);
                    NewStudentID = int.Parse(str2);
                }
                sqldatareader2.Close();
            }
        }

        private void Get_Latest_Userid()
        {
            string sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Users]";
            sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            //INCREMENT THE LAST USER ID
            if (int.Parse(datatable.Rows[0][0].ToString()) > 0)
            {
                string sqlquery2 = "SELECT [USER ID] FROM [Tbl.Users]";
                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    str3 = sqldatareader.GetString(0);
                    NewUserID = int.Parse(str3) + 1;
                }
                sqldatareader.Close();
            }

            //ASSIGN NEW USER ID
            else if (datatable.Rows[0][0].ToString() == "0")
            {
                string sqlquery3 = "SELECT VALUE FROM [Tbl.Defaults] WHERE [ENTRY NAME] = 'USER ID'";
                sqlcommand = new SqlCommand(sqlquery3, sqlconnection);
                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                while (sqldatareader2.Read())
                {
                    str4 = sqldatareader2.GetString(0);
                    NewUserID = int.Parse(str4);
                }
                sqldatareader2.Close();
            }
        }

        //GENERATE USER && STUDENT ID'S
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //START WORKING STATE
                GenerateidButton.Cursor = Cursors.AppStarting;
                Get_Latest_Userid();
                Get_Latest_Studentid();

                int outer_row = 0;
                foreach (DataRow row in datatable.Rows)
                {
                    if (GridView.Rows[outer_row].Cells[0].Value.ToString().Trim() == "" ||
                    GridView.Rows[outer_row].Cells[1].Value.ToString().Trim() == "")
                    {
                        int virtual_row = 0;
                        foreach (DataRow virtualrow in datatable.Rows)
                        {
                            GridView.Rows[virtual_row].Cells[0].Value = DBNull.Value;
                            GridView.Rows[virtual_row].Cells[1].Value = DBNull.Value;
                            virtual_row++;
                        }
                        
                        int _row = 0;
                        foreach (DataRow rows in datatable.Rows)
                        {
                            GridView.Rows[_row].Cells[0].Value = NewStudentID.ToString();
                            GridView.Rows[_row].Cells[1].Value = NewUserID.ToString();
                            _row++; NewStudentID++; NewUserID++;
                        }
                        isGeneratedid = true;
                    }
                    outer_row++;
                }
                
                //STOP WORKING STATE
                GenerateidButton.Cursor = Cursors.Default;
                if (isGeneratedid == true && isGeneratedup == true)
                {
                    SaveButton.Enabled = true;
                    SaveButton.Cursor = Cursors.Default;
                }
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }
        
        //GENERATE UNAME'S && PWORD'S
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //START WORKING STATE
                GenerateupButton.Cursor = Cursors.AppStarting;
                Get_Latest_Userid();
                Get_Latest_Studentid();

                int outer_row = 0;
                foreach (DataRow row in datatable.Rows)
                {
                    if (GridView.Rows[outer_row].Cells[13].Value.ToString().Trim() == "" ||
                        GridView.Rows[outer_row].Cells[14].Value.ToString().Trim() == "")
                    {
                        int virtual_row = 0;
                        foreach (DataRow virtualrow in datatable.Rows)
                        {
                            GridView.Rows[virtual_row].Cells[13].Value = DBNull.Value;
                            GridView.Rows[virtual_row].Cells[14].Value = DBNull.Value;
                            virtual_row++;
                        }
                        
                        int _row = 0;
                        foreach (DataRow rows in datatable.Rows)
                        {
                            GridView.Rows[_row].Cells[13].Value = VirtualStudentID.ToString();
                            GridView.Rows[_row].Cells[14].Value = "12345678";
                            _row++; VirtualStudentID++;
                        }
                        isGeneratedup = true;
                    }
                    outer_row++;
                }
                
                //STOP WORKING STATE
                GenerateupButton.Cursor = Cursors.Default;
                if (isGeneratedid == true && isGeneratedup == true)
                {
                    SaveButton.Enabled = true;
                    SaveButton.Cursor = Cursors.Default;
                }
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        private int Get_Entry_Count(int count)
        {
            try
            {
                count = 0;
                foreach (DataRow rows in datatable.Rows)
                {
                    count++;
                }

                return count;
            }

            catch (Exception)
            {
                return count;
            }
        }

        private void Set_Refers()
        {
            try
            {
                ReferSectionName = GridView.Rows[0].Cells[11].Value.ToString().ToUpper().Trim();
                ReferGradeLevelName = GridView.Rows[0].Cells[12].Value.ToString().ToUpper().Trim();
                EntryCount = Get_Entry_Count(0);

                string OuterQuery = "SELECT [MAXIMUM STUDENTS], [ENROLLED] FROM [Tbl.Sections] WHERE [SECTION NAME] = '" +
                    ReferSectionName + "' AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";
                sqlcommand = new SqlCommand(OuterQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    Maximum_Students = sqldatareader.GetString(0);
                    Enrolled_Students = sqldatareader.GetString(1);
                }
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !
            }
        }

        //SAVE DATA
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //START WORKING STATE
                SaveButton.Cursor = Cursors.AppStarting;

                variables = new Variables();
                cryptography = new Cryptography();

                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();
                
                int _row = 0; Set_Refers();
                foreach (DataRow row in datatable.Rows)
                {
                    //VERIFY SECTION EXISTENSE
                    string VerifyQuery1 = "SELECT COUNT(*) FROM [Tbl.Sections] WHERE [SECTION NAME] = '" +
                        GridView.Rows[_row].Cells[11].Value.ToString().Trim().ToUpper() + "'";

                    sqldataadapter = new SqlDataAdapter(VerifyQuery1, sqlconnection);
                    DataTable VirtualTable1 = new DataTable();
                    sqldataadapter.Fill(VirtualTable1);

                    //VERIFY STUDENT REGISTRATION
                    string VerifyQuery2 = "SELECT COUNT(*) FROM [Tbl.Students] WHERE [FIRST NAME] = '" +
                        GridView.Rows[_row].Cells[3].Value.ToString().Trim() + "' AND [MIDDLE NAME] = '" + GridView.Rows[_row].Cells[4].Value.ToString().Trim() +
                        "' AND [LAST NAME] = '" + GridView.Rows[_row].Cells[5].Value.ToString().Trim() + "'";

                    sqldataadapter = new SqlDataAdapter(VerifyQuery2, sqlconnection);
                    DataTable VirtualTable2 = new DataTable();
                    sqldataadapter.Fill(VirtualTable2);

                    if (GridView.Rows[_row].Cells[0].Value.ToString().Trim() == "" || GridView.Rows[_row].Cells[1].Value.ToString().Trim() == "" ||
                        GridView.Rows[_row].Cells[2].Value.ToString().Trim() == "" || GridView.Rows[_row].Cells[3].Value.ToString().Trim() == "" ||
                        GridView.Rows[_row].Cells[4].Value.ToString().Trim() == "" || GridView.Rows[_row].Cells[5].Value.ToString().Trim() == "" ||
                        GridView.Rows[_row].Cells[6].Value.ToString().Trim() == "" || GridView.Rows[_row].Cells[7].Value.ToString().Trim() == "" ||
                        GridView.Rows[_row].Cells[8].Value.ToString().Trim() == "" || GridView.Rows[_row].Cells[9].Value.ToString().Trim() == "" ||
                        GridView.Rows[_row].Cells[10].Value.ToString().Trim() == "" || GridView.Rows[_row].Cells[11].Value.ToString().Trim() == "" ||
                        GridView.Rows[_row].Cells[12].Value.ToString().Trim() == "" || GridView.Rows[_row].Cells[13].Value.ToString().Trim() == "" ||
                        GridView.Rows[_row].Cells[14].Value.ToString().Trim() == "")
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "SOME CELL CONTAINS A NULL CHARACTER !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (VirtualTable1.Rows[0][0].ToString() == "0")
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "THERE IS UNKNOWN SECTION NAME !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (int.Parse(VirtualTable2.Rows[0][0].ToString()) > 0)
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "THERE ARE STUDENT ENTRY THAT IS\nALREADY REGISTERED !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (!GridView.Rows[_row].Cells[6].Value.ToString().ToUpper().Trim().Equals("MALE") &&
                        !GridView.Rows[_row].Cells[6].Value.ToString().ToUpper().Trim().Equals("FEMALE"))
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "THERE IS UNKNOWN GENDER TYPE !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (GridView.Rows[_row].Cells[9].Value.ToString().Trim().Length < 11 ||
                        GridView.Rows[_row].Cells[9].Value.ToString().Trim().Length > 11)
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "THERE IS INVALID MOBILE NUMBER !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (isNumber(GridView.Rows[_row].Cells[9].Value.ToString().Trim()) == false)
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "THERE IS MOBILE NUMBER THAT\nCONTAINS AN INVALID CHARACTER !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (!GridView.Rows[_row].Cells[10].Value.ToString().Trim().Contains("@") ||
                        !GridView.Rows[_row].Cells[10].Value.ToString().Trim().Contains(".com"))
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "THERE IS INVALID EMAIL ADDRESS !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (!GridView.Rows[_row].Cells[11].Value.ToString().ToUpper().Trim().Equals(ReferSectionName))
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.error;
                        notificationwindow.MessageText = "SYSTEM CANNOT IMPORT MULTIPLE\nDIFFERENT SECTIONS AT ONE TIME !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (!GridView.Rows[_row].Cells[12].Value.ToString().ToUpper().Trim().Equals(ReferGradeLevelName))
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.error;
                        notificationwindow.MessageText = "SYSTEM CANNOT IMPORT MULTIPLE\nDIFFERENT GRADE LEVEL AT ONE TIME !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (!GridView.Rows[_row].Cells[12].Value.ToString().ToUpper().Trim().Equals("GRADE 7") && !GridView.Rows[_row].Cells[12].Value.ToString().ToUpper().Trim().Equals("GRADE 8") &&
                        !GridView.Rows[_row].Cells[12].Value.ToString().ToUpper().Trim().Equals("GRADE 9") && !GridView.Rows[_row].Cells[12].Value.ToString().ToUpper().Trim().Equals("GRADE 10"))
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.warning;
                        notificationwindow.MessageText = "THERE IS UNKNOWN GRADE LEVEL !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else if (EntryCount > int.Parse(Maximum_Students))
                    {
                        notificationwindow.CaptionText = "MESSAGE CONTENT";
                        notificationwindow.MsgImage.Image = Properties.Resources.error;
                        notificationwindow.MessageText = "STUDENT DATA EXCEEDS THE\nSECTION'S REGISTRATION LIMIT !";

                        darkeropacityform.Show();
                        notificationwindow.ShowDialog();
                        darkeropacityform.Hide();

                        Import_Student_Data_Begin = false;
                        break;
                    }

                    else
                    {
                        Import_Student_Data_Begin = true;
                    }

                    _row++;
                }

                //SHOW MESSAGE AFTER SUCCESSFULL IMPORT
                if (Import_Student_Data_Begin == true)
                {
                    int row = 0; Set_Refers();
                    foreach (DataRow rows in datatable.Rows)
                    {
                        string query2, query3, query4, query5, query6, query7, query8, query9, query10;
                        string FullName = GridView.Rows[row].Cells[5].Value.ToString().Trim() + ", " + GridView.Rows[row].Cells[3].Value.ToString().Trim() + " "
                            + GridView.Rows[row].Cells[4].Value.ToString().Trim().Remove(1, GridView.Rows[row].Cells[4].Value.ToString().Trim().Length - 1) + ".";

                        //INSERT INTO STUDENTS TABLE
                        query2 = "INSERT INTO [Tbl.Students]([STUDENT ID], [USER ID], LRN, [FIRST NAME], [MIDDLE NAME], [LAST NAME], [GRADE LEVEL]," +
                            "SECTION, GENDER, [BIRTH DATE], [PRESENT ADDRESS], [PLACE OF BIRTH], [BLOOD TYPE], RELIGION, [INDIGINOUS GROUP]," +
                            "[EMAIL ADDRESS], [MOBILE NUMBER]) VALUES(@studentid, @userid, @lrn, @firstname, @middlename, @lastname, @gradelevel," +
                            "@section, @gender, @birthdate, @presentaddress, @placeofbirth, @bloodtype, @religion, @indiginousgroup, @emailaddress," +
                            "@mobilenumber)";
                        sqlcommand = new SqlCommand(query2, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@studentid", GridView.Rows[row].Cells[0].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@userid", GridView.Rows[row].Cells[1].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@lrn", GridView.Rows[row].Cells[2].Value.ToString().Trim());

                        sqlcommand.Parameters.AddWithValue("@firstname", GridView.Rows[row].Cells[3].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@middlename", GridView.Rows[row].Cells[4].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@lastname", GridView.Rows[row].Cells[5].Value.ToString().Trim());

                        sqlcommand.Parameters.AddWithValue("@gradelevel", GridView.Rows[row].Cells[12].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@section", GridView.Rows[row].Cells[11].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@gender", GridView.Rows[row].Cells[6].Value.ToString().Trim());

                        sqlcommand.Parameters.AddWithValue("@birthdate", GridView.Rows[row].Cells[7].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@presentaddress", GridView.Rows[row].Cells[8].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@placeofbirth", "");

                        sqlcommand.Parameters.AddWithValue("@bloodtype", "");
                        sqlcommand.Parameters.AddWithValue("@religion", "");
                        sqlcommand.Parameters.AddWithValue("@indiginousgroup", "");

                        sqlcommand.Parameters.AddWithValue("@emailaddress", GridView.Rows[row].Cells[10].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@mobilenumber", GridView.Rows[row].Cells[9].Value.ToString().Trim());
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO FAMILY BACKGROUND TABLE
                        query3 = "INSERT INTO [Tbl.FamilyBackgrounds]([STUDENT ID], [FATHERS NAME], [FATHERS OCCUPATION], [FATHERS CONTACT NUMBER]," +
                            "[FATHERS ADDRESS], [MOTHERS NAME], [MOTHERS OCCUPATION], [MOTHERS CONTACT NUMBER], [MOTHERS ADDRESS]) VALUES(@studentid," +
                            "@fathersname, @fatheroccupation, @fathersnumber, @fathersaddress, @mothername, @motheroccupation, @mothernumber, @motheraddress)";
                        sqlcommand = new SqlCommand(query3, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@studentid", GridView.Rows[row].Cells[0].Value.ToString().Trim());

                        sqlcommand.Parameters.AddWithValue("@fathersname", "");
                        sqlcommand.Parameters.AddWithValue("@fatheroccupation", "");
                        sqlcommand.Parameters.AddWithValue("@fathersnumber", "");
                        sqlcommand.Parameters.AddWithValue("@fathersaddress", "");

                        sqlcommand.Parameters.AddWithValue("@mothername", "");
                        sqlcommand.Parameters.AddWithValue("@motheroccupation", "");
                        sqlcommand.Parameters.AddWithValue("@mothernumber", "");
                        sqlcommand.Parameters.AddWithValue("@motheraddress", "");
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO USERS TABLE
                        query4 = "INSERT INTO [Tbl.Users]([USER ID], USERNAME, PASSWORD, [ACCOUNT STATUS], [ACCOUNT TYPE], [LAST LOGIN]," +
                            "[IS PWD CHANGED], [SITUATION STATUS]) VALUES(@userid, @username, @password, @accountstatus, @account_type, @last_login, @ispwdchanged, @stat)";
                        sqlcommand = new SqlCommand(query4, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@userid", GridView.Rows[row].Cells[1].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@username", cryptography.Encrypt(GridView.Rows[row].Cells[13].Value.ToString().Trim()));
                        sqlcommand.Parameters.AddWithValue("@password", cryptography.Encrypt(GridView.Rows[row].Cells[14].Value.ToString().Trim()));
                        sqlcommand.Parameters.AddWithValue("@accountstatus", "Active");

                        sqlcommand.Parameters.AddWithValue("@account_type", "Student");
                        sqlcommand.Parameters.AddWithValue("@last_login", "NO LOGIN HISTORY");
                        sqlcommand.Parameters.AddWithValue("@ispwdchanged", "False");
                        sqlcommand.Parameters.AddWithValue("@stat", "0");
                        sqlcommand.ExecuteNonQuery();

                        //UPDATE SECTIONS TABLE --> ENROLLED
                        query5 = "UPDATE [Tbl.Sections] SET ENROLLED = @enrolled WHERE [SECTION NAME] = @section_nane" + 
                            " AND [SCHOOL YEAR] = '" + CurrentSchoolYear + "'";

                        sqlcommand = new SqlCommand(query5, sqlconnection);
                        sqlcommand.Parameters.AddWithValue("@enrolled", (long.Parse(Enrolled_Students) + 1).ToString());
                        sqlcommand.Parameters.AddWithValue("@section_nane", GridView.Rows[row].Cells[11].Value.ToString().Trim());
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO STUDENT LOAD TABLE --> 1st Grading
                        query6 = "INSERT INTO [Tbl.FirstGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                            "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid1g, @studentname1g," +
                            "@gender1g, @gradelevel1g, @section1g, @sb11g, @sb21g, @sb31g, @sb41g, @sb51g, @sb61g, @sb71g, @sb81g, @schoolyear1g)";
                        sqlcommand = new SqlCommand(query6, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@studentid1g", GridView.Rows[row].Cells[0].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@studentname1g", FullName);
                        sqlcommand.Parameters.AddWithValue("@gender1g", GridView.Rows[row].Cells[6].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@gradelevel1g", GridView.Rows[row].Cells[12].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@section1g", GridView.Rows[row].Cells[11].Value.ToString().Trim());

                        sqlcommand.Parameters.AddWithValue("@sb11g", "");
                        sqlcommand.Parameters.AddWithValue("@sb21g", "");
                        sqlcommand.Parameters.AddWithValue("@sb31g", "");
                        sqlcommand.Parameters.AddWithValue("@sb41g", "");
                        sqlcommand.Parameters.AddWithValue("@sb51g", "");
                        sqlcommand.Parameters.AddWithValue("@sb61g", "");
                        sqlcommand.Parameters.AddWithValue("@sb71g", "");
                        sqlcommand.Parameters.AddWithValue("@sb81g", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear1g", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO STUDENT LOAD TABLE --> 2nd Grading
                        query7 = "INSERT INTO [Tbl.SecondGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                            "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid2g, @studentname2g," +
                            "@gender2g, @gradelevel2g, @section2g, @sb12g, @sb22g, @sb32g, @sb42g, @sb52g, @sb62g, @sb72g, @sb82g, @schoolyear2g)";
                        sqlcommand = new SqlCommand(query7, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@studentid2g", GridView.Rows[row].Cells[0].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@studentname2g", FullName);
                        sqlcommand.Parameters.AddWithValue("@gender2g", GridView.Rows[row].Cells[6].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@gradelevel2g", GridView.Rows[row].Cells[12].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@section2g", GridView.Rows[row].Cells[11].Value.ToString().Trim());

                        sqlcommand.Parameters.AddWithValue("@sb12g", "");
                        sqlcommand.Parameters.AddWithValue("@sb22g", "");
                        sqlcommand.Parameters.AddWithValue("@sb32g", "");
                        sqlcommand.Parameters.AddWithValue("@sb42g", "");
                        sqlcommand.Parameters.AddWithValue("@sb52g", "");
                        sqlcommand.Parameters.AddWithValue("@sb62g", "");
                        sqlcommand.Parameters.AddWithValue("@sb72g", "");
                        sqlcommand.Parameters.AddWithValue("@sb82g", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear2g", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO STUDENT LOAD TABLE --> 3rd Grading
                        query8 = "INSERT INTO [Tbl.ThirdGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                            "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid3g, @studentname3g," +
                            "@gender3g, @gradelevel3g, @section3g, @sb13g, @sb23g, @sb33g, @sb43g, @sb53g, @sb63g, @sb73g, @sb83g, @schoolyear3g)";
                        sqlcommand = new SqlCommand(query8, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@studentid3g", GridView.Rows[row].Cells[0].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@studentname3g", FullName);
                        sqlcommand.Parameters.AddWithValue("@gender3g", GridView.Rows[row].Cells[6].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@gradelevel3g", GridView.Rows[row].Cells[12].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@section3g", GridView.Rows[row].Cells[11].Value.ToString().Trim());

                        sqlcommand.Parameters.AddWithValue("@sb13g", "");
                        sqlcommand.Parameters.AddWithValue("@sb23g", "");
                        sqlcommand.Parameters.AddWithValue("@sb33g", "");
                        sqlcommand.Parameters.AddWithValue("@sb43g", "");
                        sqlcommand.Parameters.AddWithValue("@sb53g", "");
                        sqlcommand.Parameters.AddWithValue("@sb63g", "");
                        sqlcommand.Parameters.AddWithValue("@sb73g", "");
                        sqlcommand.Parameters.AddWithValue("@sb83g", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear3g", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO STUDENT LOAD TABLE --> 4rth Grading
                        query9 = "INSERT INTO [Tbl.FourthGradingStudentLoad]([STUDENT ID], [STUDENT NAME], GENDER, [GRADE LEVEL], SECTION," +
                            "FILIPINO, ENGLISH, MATHEMATICS, SCIENCE, AP, TLE, MAPEH, ESP, [SCHOOL YEAR]) VALUES(@studentid4g, @studentname4g," +
                            "@gender4g, @gradelevel4g, @section4g, @sb14g, @sb24g, @sb34g, @sb44g, @sb54g, @sb64g, @sb74g, @sb84g, @schoolyear4g)";
                        sqlcommand = new SqlCommand(query9, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@studentid4g", GridView.Rows[row].Cells[0].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@studentname4g", FullName);
                        sqlcommand.Parameters.AddWithValue("@gender4g", GridView.Rows[row].Cells[6].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@gradelevel4g", GridView.Rows[row].Cells[12].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@section4g", GridView.Rows[row].Cells[11].Value.ToString().Trim());

                        sqlcommand.Parameters.AddWithValue("@sb14g", "");
                        sqlcommand.Parameters.AddWithValue("@sb24g", "");
                        sqlcommand.Parameters.AddWithValue("@sb34g", "");
                        sqlcommand.Parameters.AddWithValue("@sb44g", "");
                        sqlcommand.Parameters.AddWithValue("@sb54g", "");
                        sqlcommand.Parameters.AddWithValue("@sb64g", "");
                        sqlcommand.Parameters.AddWithValue("@sb74g", "");
                        sqlcommand.Parameters.AddWithValue("@sb84g", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear4g", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        //INSERT INTO [Tbl.StudentAverages]
                        query10 = "INSERT INTO [Tbl.StudentAverages]([STUDENT ID], [STUDENT NAME], LRN, [GRADE LEVEL], SECTION, " +
                            "[FIRST GRADING], [SECOND GRADING], [THIRD GRADING], [FOURTH GRADING], GPA, [SCHOOL YEAR]) " +
                            "VALUES(@sid, @studname, @lrn, @glevel, @section, @fga, @sga, @tga, @ffga, @gpa, @schoolyear)";
                        sqlcommand = new SqlCommand(query10, sqlconnection);

                        sqlcommand.Parameters.AddWithValue("@sid", GridView.Rows[row].Cells[0].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@studname", FullName);
                        sqlcommand.Parameters.AddWithValue("@lrn", GridView.Rows[row].Cells[2].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@glevel", GridView.Rows[row].Cells[12].Value.ToString().Trim());
                        sqlcommand.Parameters.AddWithValue("@section", GridView.Rows[row].Cells[11].Value.ToString().Trim());

                        sqlcommand.Parameters.AddWithValue("@fga", "");
                        sqlcommand.Parameters.AddWithValue("@sga", "");
                        sqlcommand.Parameters.AddWithValue("@tga", "");
                        sqlcommand.Parameters.AddWithValue("@ffga", "");
                        sqlcommand.Parameters.AddWithValue("@gpa", "");
                        sqlcommand.Parameters.AddWithValue("@schoolyear", CurrentSchoolYear);
                        sqlcommand.ExecuteNonQuery();

                        isSuccessfull = true;
                        row++;
                    }
                }

                if (isSuccessfull == true)
                {
                    notificationwindow.CaptionText = "REGISTRATION SUCCESS !";
                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                    notificationwindow.MessageText = "ALL DATA WAS SAVED SUCCESSFULLY !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();

                    DialogResult = DialogResult.OK;
                }

                //STOP WORKING STATE
                SaveButton.Cursor = Cursors.Default;
            }

            catch (Exception)
            {
                //DON'T DO ANYTHING BITCH !   
            }
        }

        private bool isNumber(string data)
        {
            try
            {
                long.Parse(data);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ImportStudentDataForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }
    }
}
