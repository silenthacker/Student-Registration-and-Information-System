using System;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.CSharp.RuntimeBinder;
namespace Application
{
    class GetSpecifiedPrefix
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        
        string sqlquery0, sqlquery1, sqlquery2, sqlquery3, sqlquery4;
        string schoolyearid_prefix, sectionid_prefix, pictureid_prefix, assignedid_prefix, handledid_prefix, permissionid_prefix;

        //SCHOOL YEAR ID
        public string GetSchoolYearPrefix()
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
            sqlquery0 = "SELECT PREFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = '" + "SCHOOL YEAR ID" + "'";
            sqlcommand = new SqlCommand(sqlquery0, sqlconnection);
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            while (sqldatareader.Read())
            {
                schoolyearid_prefix = sqldatareader.GetString(0);
            }
            sqldatareader.Close();
            return schoolyearid_prefix;
        }


        //SECTION ID
        public string GetSectionIDPrefix()
        {
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
                sqlquery1 = "SELECT PREFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = '" + "SECTION ID" + "'";
                sqlcommand = new SqlCommand(sqlquery1, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    sectionid_prefix = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
                return sectionid_prefix;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "@GetSpecifiedPrefix Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                return sectionid_prefix;
            }
        }

        //PICTURE ID
        public string GetPictureIDPrefix()
        {
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
                sqlquery2 = "SELECT PREFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = '" + "PICTURE ID" + "'";
                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    pictureid_prefix = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
                return pictureid_prefix;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "@GetSpecifiedPrefix Exception 2",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pictureid_prefix;
            }
        }

        //ASSIGN ID
        public string GetAssignedIDPrefix()
        {
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
                sqlquery3 = "SELECT PREFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = '" + "ASSIGN ID" + "'";
                sqlcommand = new SqlCommand(sqlquery3, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    assignedid_prefix = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
                return assignedid_prefix;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "@GetSpecifiedPrefix Exception 3",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                return assignedid_prefix;
            }
        }

        //HANDLE ID
        public string GetHandledIDPrefix()
        {
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
                sqlquery4 = "SELECT PREFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = '" + "HANDLE ID" + "'";
                sqlcommand = new SqlCommand(sqlquery4, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    handledid_prefix = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
                return handledid_prefix;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "@GetSpecifiedPrefix Exception 4",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                return handledid_prefix;
            }
        }

        //PERMISSION ID
        public string GetPermissionIDPrefix()
        {
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
                sqlquery4 = "SELECT PREFIX FROM [Tbl.Defaults] WHERE [ENTRY NAME] = '" + "PERMISSION ID" + "'";
                sqlcommand = new SqlCommand(sqlquery4, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    permissionid_prefix = sqldatareader.GetString(0);
                }
                sqldatareader.Close();
                return permissionid_prefix;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "@GetSpecifiedPrefix Exception 5",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                return handledid_prefix;
            }
        }
    }
}
