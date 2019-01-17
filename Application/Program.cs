using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Application
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                //CREATE REGISTRY SETTINGS
                string pathname = "PTLE Solutions\\CLAYGO\\Current User Settings";
                RegistryKey getregistrykey = Registry.CurrentUser.OpenSubKey(@pathname);
                Cryptography cryptography = new Cryptography();

                //CREATE
                if (getregistrykey == null)
                {
                    RegistryKey createregistrykey = Registry.CurrentUser.CreateSubKey(@pathname);
                    createregistrykey.SetValue("User ID", "");
                    createregistrykey.SetValue("Teacher ID", "");
                    createregistrykey.SetValue("Student ID", "");

                    createregistrykey.SetValue("NofMaxSections", "0");
                    createregistrykey.SetValue("Show Feedback Form", "True");
                    createregistrykey.SetValue("Show Security Form", "True");
                    createregistrykey.SetValue("SQLServerConnectionString", "");
                    createregistrykey.SetValue("Security Code", cryptography.Encrypt("CLAYGO@PTLE"));
                }

                //CONCATE
                else if (getregistrykey != null)
                {
                    RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@pathname);
                    string tempdata5 = getregistrykey.GetValue("Security Code").ToString();
                    string tempdata4 = getregistrykey.GetValue("Show Security Form").ToString();
                    string tempdata3 = getregistrykey.GetValue("NofMaxSections").ToString();
                    string tempdata2 = getregistrykey.GetValue("Show Feedback Form").ToString();
                    string tempdata = getregistrykey.GetValue("SQLServerConnectionString").ToString();

                    updateregistrykey.SetValue("User ID", "");
                    updateregistrykey.SetValue("Teacher ID", "");
                    updateregistrykey.SetValue("Student ID", "");

                    updateregistrykey.SetValue("Security Code", tempdata5);
                    updateregistrykey.SetValue("Show Security Form", tempdata4);
                    updateregistrykey.SetValue("NofMaxSections", tempdata3);
                    updateregistrykey.SetValue("Show Feedback Form", tempdata2);
                    updateregistrykey.SetValue("SQLServerConnectionString", tempdata);
                }
                
                RegistryKey GetRegistryValue = Registry.CurrentUser.OpenSubKey(@pathname);
                string VirtualString = GetRegistryValue.GetValue("Show Security Form").ToString();
                
                //SUB
                if (VirtualString.Equals("True"))
                {   
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    System.Windows.Forms.Application.Run(new SecurityCodeForm());
                }

                else if (VirtualString.Equals("False"))
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    System.Windows.Forms.Application.Run(new LoginForm());
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message+exception.StackTrace+"\nClosing ...", "Main entry point exception", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
