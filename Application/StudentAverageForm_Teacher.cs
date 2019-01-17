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
    public partial class StudentAverageForm_Teacher : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;
        
        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        //SqlDataAdapter sqldataadapter;

        private string TeacherID, CurrentSchoolYear;

        public StudentAverageForm_Teacher()
        {
            InitializeComponent();
        }

        private void StudentAverageForm_Teacher_Load(object sender, EventArgs e)
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
                TeacherID = registrykey.GetValue("Teacher ID").ToString();

                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                //INNER EXCEPTION 1
                try
                {
                    GetCurrentSchoolYear(); Retrieve_Section_List();
                    Retrieve_SchoolYear_List(); Populate_DataGridView();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Student Average Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Student Average Form Exception 1",
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

        private void Populate_DataGridView()
        {
            try
            {
                string RetrieveQuery = "SELECT * FROM [Tbl.StudentAverages] WHERE [GRADE LEVEL] = '" + GradeLevelDropdown.selectedValue.ToString() +
                    "' AND [SECTION] = '" + SectionDropdown.selectedValue.ToString() + "' AND [SCHOOL YEAR] = '" +
                    SchoolYearDropdown.selectedValue.ToString() + "' ORDER BY [STUDENT ID]";

                SqlDataAdapter sqldataadapter = new SqlDataAdapter(RetrieveQuery, sqlconnection);
                DataTable datatable = new DataTable();
                sqldataadapter.Fill(datatable);

                StudentAverageGridview.DataSource = datatable;
                StudentAverageGridview.AutoGenerateColumns = false;
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Retrieve_Section_List()
        {
            try
            {
                string localvariablestring = "SELECT * FROM [Tbl.AssignedSections] WHERE [TEACHER ID] = '" + TeacherID + "'";
                sqlcommand = new SqlCommand(localvariablestring, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                SectionDropdown.Clear();
                while (sqldatareader.Read())
                {
                    int index = 2;
                    for (int iterator = 0; iterator < 10; iterator++)
                    {
                        SectionDropdown.AddItem(sqldatareader.GetString(index));
                        index++;
                    }
                }

                SectionDropdown.selectedIndex = 0;
                sqldatareader.Close();
                
                try
                {
                    RemoveSpaceInSections();
                }

                catch (Exception)
                {
                    //DO NOTHING BITCH !
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void RemoveSpaceInSections()
        {
            int index = 2;
            for (int iterator = 0; iterator < 10; iterator++)
            {
                SectionDropdown.RemoveItem("");
                index++;
            }
        }

        private void Retrieve_SchoolYear_List()
        {
            try
            {
                string RetrieveQuery = "SELECT [SCHOOL YEAR] FROM [Tbl.SchoolYear]";
                sqlcommand = new SqlCommand(RetrieveQuery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    SchoolYearDropdown.AddItem(sqldatareader.GetString(0));
                }
                SchoolYearDropdown.selectedIndex = 0;
                sqldatareader.Close();
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void GradeLevelDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (GradeLevelDropdown.selectedIndex == 0)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 7'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }

                else if (GradeLevelDropdown.selectedIndex == 1)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 8'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }

                else if (GradeLevelDropdown.selectedIndex == 2)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 9'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }

                else if (GradeLevelDropdown.selectedIndex == 3)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 10'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }
            }

            catch (Exception)
            {
                //NOTHING
            }
        }

        private void SectionDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (GradeLevelDropdown.selectedIndex == 0)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 7'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }

                else if (GradeLevelDropdown.selectedIndex == 1)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 8'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }

                else if (GradeLevelDropdown.selectedIndex == 2)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 9'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }

                else if (GradeLevelDropdown.selectedIndex == 3)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 10'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }
            }

            catch (Exception)
            {
                //NOTHING
            }
        }

        private void SchoolYearDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (GradeLevelDropdown.selectedIndex == 0)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 7'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }

                else if (GradeLevelDropdown.selectedIndex == 1)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 8'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }

                else if (GradeLevelDropdown.selectedIndex == 2)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 9'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }

                else if (GradeLevelDropdown.selectedIndex == 3)
                {
                    string Query = "SELECT * FROM [Tbl.StudentAverages] WHERE [SECTION] = '" + SectionDropdown.selectedValue.ToString() +
                        "' AND [SCHOOL YEAR] = '" + SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 10'";

                    SqlDataAdapter sqldataadapter = new SqlDataAdapter(Query, sqlconnection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);

                    StudentAverageGridview.DataSource = datatable;
                    StudentAverageGridview.AutoGenerateColumns = false;
                }
            }

            catch (Exception)
            {
                //NOTHING
            }
        }

        private void StudentAverageForm_Teacher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }
    }
}
