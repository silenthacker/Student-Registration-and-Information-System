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
    public partial class EnrollmentReportForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;
        
        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        //SqlDataAdapter sqldataadapter;

        public EnrollmentReportForm()
        {
            InitializeComponent();
        }

        private void EnrollmentReportForm_Load(object sender, EventArgs e)
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
                    GetSchoolYearList();
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.Message.ToString(), "@Enrollment Report Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Enrollment Report Form Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void SchoolYearDropdown_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                Show_Count_Labels();
                Display_EnrollmentChart();
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void GetSchoolYearList()
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
                sqldatareader.Close();
                SchoolYearDropdown.selectedIndex = 0;
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Show_Count_Labels()
        {
            try
            {
                //MALE
                string RetrieveQuery1 = "SELECT COUNT(GENDER) FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                    SchoolYearDropdown.selectedValue.ToString() + "' AND GENDER = 'Male'";

                SqlDataAdapter sqldataadapter = new SqlDataAdapter(RetrieveQuery1, sqlconnection);
                DataTable datatable = new DataTable();
                sqldataadapter.Fill(datatable);
                MaleCountLabel.Text = datatable.Rows[0][0].ToString();
                
                if (MaleCountLabel.Text.Length == 1) {
                    MaleCountLabel.Location = new Point(44, 29);
                    MaleCountLabel.Text = datatable.Rows[0][0].ToString();
                }

                else if (MaleCountLabel.Text.Length == 2) {
                    MaleCountLabel.Location = new Point(38, 29);
                    MaleCountLabel.Text = datatable.Rows[0][0].ToString();
                }

                else if (MaleCountLabel.Text.Length == 3) {
                    MaleCountLabel.Location = new Point(33, 29);
                    MaleCountLabel.Text = datatable.Rows[0][0].ToString();
                }
                
                else if (MaleCountLabel.Text.Length == 4) {
                    MaleCountLabel.Location = new Point(27, 29);
                    MaleCountLabel.Text = datatable.Rows[0][0].ToString();
                }

                else if (MaleCountLabel.Text.Length == 5) {
                    MaleCountLabel.Location = new Point(22, 29);
                    MaleCountLabel.Text = datatable.Rows[0][0].ToString();
                }

                //FEMALE
                string RetrieveQuery2 = "SELECT COUNT(GENDER) FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                SchoolYearDropdown.selectedValue.ToString() + "' AND GENDER = 'Female'";

                SqlDataAdapter sqldataadapter2 = new SqlDataAdapter(RetrieveQuery2, sqlconnection);
                DataTable datatable2 = new DataTable();
                sqldataadapter2.Fill(datatable2);
                FemaleCountLabel.Text = datatable2.Rows[0][0].ToString();

                if (FemaleCountLabel.Text.Length == 1) {
                    FemaleCountLabel.Location = new Point(44, 29);
                    FemaleCountLabel.Text = datatable2.Rows[0][0].ToString();
                }

                else if (FemaleCountLabel.Text.Length == 2) {
                    FemaleCountLabel.Location = new Point(38, 29);
                    FemaleCountLabel.Text = datatable2.Rows[0][0].ToString();
                }

                else if (FemaleCountLabel.Text.Length == 3) {
                    FemaleCountLabel.Location = new Point(33, 29);
                    FemaleCountLabel.Text = datatable2.Rows[0][0].ToString();
                }

                else if (FemaleCountLabel.Text.Length == 4) {
                    FemaleCountLabel.Location = new Point(27, 29);
                    FemaleCountLabel.Text = datatable2.Rows[0][0].ToString();
                }

                else if (FemaleCountLabel.Text.Length == 5) {
                    FemaleCountLabel.Location = new Point(22, 29);
                    FemaleCountLabel.Text = datatable2.Rows[0][0].ToString();
                }

                string GrandTotal = (int.Parse(MaleCountLabel.Text) + int.Parse(FemaleCountLabel.Text)).ToString();
                if (GrandTotal.Length == 1) {
                    GrandTotalCountLabel.Location = new Point(101, 29);
                    GrandTotalCountLabel.Text = GrandTotal;
                }

                else if (GrandTotal.Length == 2) {
                    GrandTotalCountLabel.Location = new Point(95, 29);
                    GrandTotalCountLabel.Text = GrandTotal;
                }

                else if (GrandTotal.Length == 3) {
                    GrandTotalCountLabel.Location = new Point(90, 29);
                    GrandTotalCountLabel.Text = GrandTotal;
                }

                else if (GrandTotal.Length == 4) {
                    GrandTotalCountLabel.Location = new Point(84, 29);
                    GrandTotalCountLabel.Text = GrandTotal;
                }

                else if (GrandTotal.Length == 5) {
                    GrandTotalCountLabel.Location = new Point(79, 29);
                    GrandTotalCountLabel.Text = GrandTotal;
                }

                //GRADE 7
                string RetrieveQuery3 = "SELECT COUNT([GRADE LEVEL]) FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                    SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 7'";

                SqlDataAdapter sqldataadapter3 = new SqlDataAdapter(RetrieveQuery3, sqlconnection);
                DataTable datatable3 = new DataTable();
                sqldataadapter3.Fill(datatable3);
                G7CountLabel.Text = datatable3.Rows[0][0].ToString();

                if (G7CountLabel.Text.Length == 1) {
                    G7CountLabel.Location = new Point(44, 29);
                    G7CountLabel.Text = datatable3.Rows[0][0].ToString();
                }

                else if (G7CountLabel.Text.Length == 2) {
                    G7CountLabel.Location = new Point(38, 29);
                    G7CountLabel.Text = datatable3.Rows[0][0].ToString();
                }

                else if (G7CountLabel.Text.Length == 3) {
                    G7CountLabel.Location = new Point(33, 29);
                    G7CountLabel.Text = datatable3.Rows[0][0].ToString();
                }

                else if (G7CountLabel.Text.Length == 4) {
                    G7CountLabel.Location = new Point(27, 29);
                    G7CountLabel.Text = datatable3.Rows[0][0].ToString();
                }

                else if (G7CountLabel.Text.Length == 5) {
                    G7CountLabel.Location = new Point(22, 29);
                    G7CountLabel.Text = datatable3.Rows[0][0].ToString();
                }

                //GRADE 8
                string RetrieveQuery4 = "SELECT COUNT([GRADE LEVEL]) FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                    SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 8'";

                SqlDataAdapter sqldataadapter4 = new SqlDataAdapter(RetrieveQuery4, sqlconnection);
                DataTable datatable4 = new DataTable();
                sqldataadapter4.Fill(datatable4);
                G8CountLabel.Text = datatable4.Rows[0][0].ToString();

                if (G8CountLabel.Text.Length == 1) {
                    G8CountLabel.Location = new Point(44, 29);
                    G8CountLabel.Text = datatable4.Rows[0][0].ToString();
                }

                else if (G8CountLabel.Text.Length == 2) {
                    G8CountLabel.Location = new Point(38, 29);
                    G8CountLabel.Text = datatable4.Rows[0][0].ToString();
                }

                else if (G8CountLabel.Text.Length == 3) {
                    G8CountLabel.Location = new Point(33, 29);
                    G8CountLabel.Text = datatable4.Rows[0][0].ToString();
                }

                else if (G8CountLabel.Text.Length == 4) {
                    G8CountLabel.Location = new Point(27, 29);
                    G8CountLabel.Text = datatable4.Rows[0][0].ToString();
                }

                else if (G8CountLabel.Text.Length == 5) {
                    G8CountLabel.Location = new Point(22, 29);
                    G8CountLabel.Text = datatable4.Rows[0][0].ToString();
                }

                //GRADE 9
                string RetrieveQuery5 = "SELECT COUNT([GRADE LEVEL]) FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                    SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 9'";

                SqlDataAdapter sqldataadapter5 = new SqlDataAdapter(RetrieveQuery5, sqlconnection);
                DataTable datatable5 = new DataTable();
                sqldataadapter5.Fill(datatable5);
                G9CountLabel.Text = datatable5.Rows[0][0].ToString();

                if (G9CountLabel.Text.Length == 1) {
                    G9CountLabel.Location = new Point(44, 29);
                    G9CountLabel.Text = datatable5.Rows[0][0].ToString();
                }

                else if (G9CountLabel.Text.Length == 2) {
                    G9CountLabel.Location = new Point(38, 29);
                    G9CountLabel.Text = datatable5.Rows[0][0].ToString();
                }

                else if (G9CountLabel.Text.Length == 3) {
                    G9CountLabel.Location = new Point(33, 29);
                    G9CountLabel.Text = datatable5.Rows[0][0].ToString();
                }

                else if (G9CountLabel.Text.Length == 4) {
                    G9CountLabel.Location = new Point(27, 29);
                    G9CountLabel.Text = datatable5.Rows[0][0].ToString();
                }

                else if (G9CountLabel.Text.Length == 5) {
                    G9CountLabel.Location = new Point(22, 29);
                    G9CountLabel.Text = datatable5.Rows[0][0].ToString();
                }

                //GRADE 10
                string RetrieveQuery6 = "SELECT COUNT([GRADE LEVEL]) FROM [Tbl.FirstGradingStudentLoad] WHERE [SCHOOL YEAR] = '" +
                    SchoolYearDropdown.selectedValue.ToString() + "' AND [GRADE LEVEL] = 'Grade 10'";

                SqlDataAdapter sqldataadapter6 = new SqlDataAdapter(RetrieveQuery6, sqlconnection);
                DataTable datatable6 = new DataTable();
                sqldataadapter6.Fill(datatable6);
                G10CountLabel.Text = datatable6.Rows[0][0].ToString();

                if (G10CountLabel.Text.Length == 1) {
                    G10CountLabel.Location = new Point(44, 29);
                    G10CountLabel.Text = datatable6.Rows[0][0].ToString();
                }

                else if (G10CountLabel.Text.Length == 2) {
                    G10CountLabel.Location = new Point(38, 29);
                    G10CountLabel.Text = datatable6.Rows[0][0].ToString();
                }

                else if (G10CountLabel.Text.Length == 3) {
                    G10CountLabel.Location = new Point(33, 29);
                    G10CountLabel.Text = datatable6.Rows[0][0].ToString();
                }

                else if (G10CountLabel.Text.Length == 4) {
                    G10CountLabel.Location = new Point(27, 29);
                    G10CountLabel.Text = datatable6.Rows[0][0].ToString();
                }

                else if (G10CountLabel.Text.Length == 5) {
                    G10CountLabel.Location = new Point(22, 29);
                    G10CountLabel.Text = datatable6.Rows[0][0].ToString();
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void Display_EnrollmentChart()
        {
            try
            {
                foreach (var series in EnrollmentChart.Series)
                {
                    series.Points.Clear();
                }
                
                EnrollmentChart.Series["Enrolled"].Points.AddXY("GRADE 7", G7CountLabel.Text);
                EnrollmentChart.Series["Enrolled"].Points.AddXY("GRADE 8", G8CountLabel.Text);
                EnrollmentChart.Series["Enrolled"].Points.AddXY("GARDE 9", G9CountLabel.Text);
                EnrollmentChart.Series["Enrolled"].Points.AddXY("GRADE 10", G10CountLabel.Text);
            }

            catch (Exception)
            {
                throw;
                //DO NOTHING BITCH !
            }
        }
        private void EnrollmentReportForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }
    }
}
