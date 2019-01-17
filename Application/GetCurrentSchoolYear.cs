using System;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
namespace Application
{
    class GetCurrentSchoolYear
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        string sqlquery1, SchoolYear;

        public string GetCurrentSchoolYearData()
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
                sqlquery1 = "SELECT [CURRENT SCHOOL YEAR] FROM [Tbl.CurrentSchoolYear]";
                sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    SchoolYear = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
                return SchoolYear;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "@GetCurrentSchoolYear Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                return SchoolYear;
            }
        }
    }
}
