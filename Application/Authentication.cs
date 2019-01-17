using System;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Windows.Forms;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
using System.Security.Authentication;
namespace Application
{
    class Authentication
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;

        SQLConnectionConfig sqlconfig;
        ServerManualConnectionForm sqlmanualconn;
        
        private string sqlquery1, sqlquery2;
        bool Administrator, Teacher, Student;
        string Useridvirtualdata, TeacheridVirtualdata, StudentidVirtualdata;
        public bool IsVerified = false, IsAdmin = false, IsTeacher = false, IsStudent = false;
        SqlConnection sqlconnection;

        public void VerifyLoginCredentials(LoginForm Controls)
        {
            Controls.LoginErrorMessage.Text = "";
            Controls.LoginErrorMessage.Visible = false;
            
            if (Controls.UsernameTextbox.Text.Length == 0)
            {
                System.Threading.Thread.Sleep(100);
                Controls.LoginErrorMessage.Text = "USERNAME REQUIRED !";
                Controls.LoginErrorMessage.Location = new Point(141, 134);
                Controls.LoginErrorMessage.Visible = true;
                Controls.UsernameTextbox.Focus();
            }

            else if (Controls.PasswordTextbox.Text.Length == 0)
            {
                System.Threading.Thread.Sleep(100);
                Controls.LoginErrorMessage.Text = "PASSWORD REQUIRED !";
                Controls.LoginErrorMessage.Location = new Point(141, 134);
                Controls.LoginErrorMessage.Visible = true;
                Controls.PasswordTextbox.Focus();
            }

            else if (Controls.PasswordTextbox.Text.Length != 0 && Controls.PasswordTextbox.Text.Length != 0)
            {
                if (Controls.UsernameTextbox.Text.EndsWith(" ") || Controls.PasswordTextbox.Text.EndsWith(" "))
                {
                    System.Threading.Thread.Sleep(100);
                    Controls.LoginErrorMessage.Text = "SORRY, THAT DIDN'T WORK !";
                    Controls.LoginErrorMessage.Location = new Point(126, 134);
                    Controls.LoginErrorMessage.Visible = true;
                    IsVerified = false;
                }

                else
                {
                    variables = new Variables();
                    opacityform = new OpacityForm();
                    cryptography = new Cryptography();

                    sqlconfig = new SQLConnectionConfig();
                    sqlmanualconn = new ServerManualConnectionForm();
                    
                    DataTable datatable = new DataTable();
                    SqlDataAdapter sqldataadapter;
                    SqlCommand sqlcommand;
                    
                    //EXCEPTION 1
                    try
                    {
                        RegistryKey getregistrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                        string tempdata = getregistrykey.GetValue("SQLServerConnectionString").ToString();
                        getregistrykey.Close();

                        //USER SQLSERVER CONNECTION SETTINGS
                        sqlconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                        sqlconnection = new SqlConnection(sqlconfig.SqlConnectionString);
                        sqlconnection.Open();

                        //CHECK ACCOUNT VALIDITY
                        sqlquery1 = "SELECT COUNT(*) FROM [Tbl.Users] WHERE USERNAME = '" + cryptography.Encrypt(Controls.UsernameTextbox.Text) +
                            "' AND PASSWORD = '" + cryptography.Encrypt(Controls.PasswordTextbox.Text) + "' AND [ACCOUNT STATUS] = 'Active' AND [SITUATION STATUS] = '0'";
                          
                        sqldataadapter = new SqlDataAdapter(sqlquery1, sqlconnection);
                        sqldataadapter.Fill(datatable);

                        //ACCOUNT EXIST
                        if (datatable.Rows[0][0].ToString() == "1")
                        {
                            if (isAdministrator(Controls.UsernameTextbox.Text) == true)
                            {
                                //UPDATE USER LOGIN HISTORY
                                string LongDate, ShortTime;
                                LongDate = DateTime.Now.ToLongDateString();
                                ShortTime = DateTime.Now.ToShortTimeString();

                                sqlquery2 = "UPDATE [Tbl.Users] SET [LAST LOGIN] = @lastlogin, [SITUATION STATUS] = @sitstat WHERE USERNAME = @username";
                                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);

                                sqlcommand.Parameters.AddWithValue("@username", cryptography.Encrypt(Controls.UsernameTextbox.Text.Trim()));
                                sqlcommand.Parameters.AddWithValue("@lastlogin", LongDate + " - " + ShortTime);
                                sqlcommand.Parameters.AddWithValue("@sitstat", "1");
                                sqlcommand.ExecuteNonQuery();

                                //SET REGISTRY SETTINGS
                                string wildcardquery = "SELECT [USER ID] FROM [Tbl.Users] WHERE USERNAME = '" +
                                    cryptography.Encrypt(Controls.UsernameTextbox.Text.Trim()) + "'";

                                sqlcommand = new SqlCommand(wildcardquery, sqlconnection);
                                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                                while (sqldatareader.Read()) {
                                    Useridvirtualdata = sqldatareader.GetString(0);
                                }
                                sqldatareader.Close();

                                //SET REGISTRY SETTINGS
                                string newwildcardquery = "SELECT [TEACHER ID] FROM [Tbl.Teachers] WHERE [USER ID] = '" +
                                    Useridvirtualdata + "'";

                                sqlcommand = new SqlCommand(newwildcardquery, sqlconnection);
                                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                                while (sqldatareader2.Read()) {
                                    TeacheridVirtualdata = sqldatareader2.GetString(0);
                                }
                                sqldatareader2.Close();

                                RegistryKey newregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                                newregistrykey.SetValue("User ID", Useridvirtualdata);
                                newregistrykey.SetValue("Teacher ID", TeacheridVirtualdata);

                                IsVerified = true;
                                IsAdmin = true;
                                sqlconnection.Close();
                            }

                            else if (isTeacher(Controls.UsernameTextbox.Text) == true)
                            {
                                //UPDATE USER LOGIN HISTORY
                                string LongDate, ShortTime;
                                LongDate = DateTime.Now.ToLongDateString();
                                ShortTime = DateTime.Now.ToShortTimeString();

                                sqlquery2 = "UPDATE [Tbl.Users] SET [LAST LOGIN] = @lastlogin, [SITUATION STATUS] = @sitstat WHERE USERNAME = @username";
                                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);

                                sqlcommand.Parameters.AddWithValue("@username", cryptography.Encrypt(Controls.UsernameTextbox.Text.Trim()));
                                sqlcommand.Parameters.AddWithValue("@lastlogin", LongDate + " - " + ShortTime);
                                sqlcommand.Parameters.AddWithValue("@sitstat", "1");
                                sqlcommand.ExecuteNonQuery();

                                //SET REGISTRY SETTINGS
                                string wildcardquery = "SELECT [USER ID] FROM [Tbl.Users] WHERE USERNAME = '" +
                                    cryptography.Encrypt(Controls.UsernameTextbox.Text.Trim()) + "'";

                                sqlcommand = new SqlCommand(wildcardquery, sqlconnection);
                                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                                while (sqldatareader.Read()) {
                                    Useridvirtualdata = sqldatareader.GetString(0);
                                }
                                sqldatareader.Close();

                                //SET REGISTRY SETTINGS
                                string newwildcardquery = "SELECT [TEACHER ID] FROM [Tbl.Teachers] WHERE [USER ID] = '" +
                                    Useridvirtualdata + "'";

                                sqlcommand = new SqlCommand(newwildcardquery, sqlconnection);
                                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                                while (sqldatareader2.Read()) {
                                    TeacheridVirtualdata = sqldatareader2.GetString(0);
                                }
                                sqldatareader2.Close();

                                RegistryKey newregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                                newregistrykey.SetValue("User ID", Useridvirtualdata);
                                newregistrykey.SetValue("Teacher ID", TeacheridVirtualdata);

                                IsVerified = true;
                                IsTeacher = true;
                                sqlconnection.Close();
                            }

                            else if (isStudent(Controls.UsernameTextbox.Text) == true)
                            {
                                //UPDATE USER LOGIN HISTORY
                                string LongDate, ShortTime;
                                LongDate = DateTime.Now.ToLongDateString();
                                ShortTime = DateTime.Now.ToShortTimeString();

                                sqlquery2 = "UPDATE [Tbl.Users] SET [LAST LOGIN] = @lastlogin, [SITUATION STATUS] = @sitstat WHERE USERNAME = @username";
                                sqlcommand = new SqlCommand(sqlquery2, sqlconnection);

                                sqlcommand.Parameters.AddWithValue("@username", cryptography.Encrypt(Controls.UsernameTextbox.Text.Trim()));
                                sqlcommand.Parameters.AddWithValue("@lastlogin", LongDate + " - " + ShortTime);
                                sqlcommand.Parameters.AddWithValue("@sitstat", "1");
                                sqlcommand.ExecuteNonQuery();

                                //SET REGISTRY SETTINGS
                                string wildcardquery = "SELECT [USER ID] FROM [Tbl.Users] WHERE USERNAME = '" +
                                    cryptography.Encrypt(Controls.UsernameTextbox.Text.Trim()) + "'";

                                sqlcommand = new SqlCommand(wildcardquery, sqlconnection);
                                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                                while (sqldatareader.Read())
                                {
                                    Useridvirtualdata = sqldatareader.GetString(0);
                                }
                                sqldatareader.Close();

                                //SET REGISTRY SETTINGS
                                string newwildcardquery = "SELECT [STUDENT ID] FROM [Tbl.Students] WHERE [USER ID] = '" +
                                    Useridvirtualdata + "'";

                                sqlcommand = new SqlCommand(newwildcardquery, sqlconnection);
                                SqlDataReader sqldatareader2 = sqlcommand.ExecuteReader();

                                while (sqldatareader2.Read())
                                {
                                    StudentidVirtualdata = sqldatareader2.GetString(0);
                                }
                                sqldatareader2.Close();

                                RegistryKey newregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                                newregistrykey.SetValue("User ID", Useridvirtualdata);
                                newregistrykey.SetValue("Student ID", StudentidVirtualdata);

                                IsVerified = true;
                                IsStudent = true;
                                sqlconnection.Close();
                            }
                        }

                        //ACCOUNT NOT FOUND
                        else if (datatable.Rows[0][0].ToString() == "0")
                        {
                            IsVerified = false;
                            sqlconnection.Close();

                            Controls.LoginErrorMessage.Text = "SORRY, THAT DIDN'T WORK !";
                            Controls.LoginErrorMessage.Location = new Point(126, 134);
                            Controls.LoginErrorMessage.Visible = true;
                        }
                    }

                    catch (Exception exception)
                    {
                        opacityform = new OpacityForm();
                        opacityform.Show();

                        MessageBox.Show(exception.Message.ToString(), "@Authentication Exception 1",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        opacityform.Hide();
                    }
                }
            }
        }

        private bool isAdministrator(string username)
        {
            //DETERMIN WHETHER THE AUTHENTICATED USER IS ADMINISTRATOR OR NON-ADMIN.
            string VerifyQuery1 = "SELECT COUNT(*) FROM [Tbl.Users] WHERE [ACCOUNT TYPE] = '" + "Administrator" +
            "' AND USERNAME = '" + cryptography.Encrypt(username) + "'";

            SqlDataAdapter sqldataadapter = new SqlDataAdapter(VerifyQuery1, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            if (datatable.Rows[0][0].ToString() == "1") {
                Administrator = true;
            }

            else if (datatable.Rows[0][0].ToString() == "0") {
                Administrator = false;
            }

            return Administrator;
        }

        private bool isTeacher(string username)
        {
            //DETERMIN WHETHER THE AUTHENTICATED USER IS A TEACHER
            string VerifyQuery2 = "SELECT COUNT(*) FROM [Tbl.Users] WHERE [ACCOUNT TYPE] = '" + "School Teacher" +
                "' AND USERNAME = '" + cryptography.Encrypt(username) + "'";

            SqlDataAdapter sqldataadapter = new SqlDataAdapter(VerifyQuery2, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            if (datatable.Rows[0][0].ToString() == "1") {
                Teacher = true;
            }

            else if (datatable.Rows[0][0].ToString() == "0") {
                Teacher = false;
            }

            return Teacher;
        }

        private bool isStudent(string username)
        {
            //DETERMIN WHETHER THE AUTHENTICATED USER IS A STUDENT
            string VerifyQuery3 = "SELECT COUNT(*) FROM [Tbl.Users] WHERE [ACCOUNT TYPE] = '" + "Student" +
                "' AND USERNAME = '" + cryptography.Encrypt(username) + "'";

            SqlDataAdapter sqldataadapter = new SqlDataAdapter(VerifyQuery3, sqlconnection);
            DataTable datatable = new DataTable();
            sqldataadapter.Fill(datatable);

            if (datatable.Rows[0][0].ToString() == "1") {
                Student = true;
            }

            else if (datatable.Rows[0][0].ToString() == "0") {
                Student = false;
            }

            return Student;
        }
    }
}
