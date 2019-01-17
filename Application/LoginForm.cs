using System;
using MaterialSkin;
using System.Drawing;

using Microsoft.Win32;
using System.Windows.Forms;
using MaterialSkin.Controls;

using Microsoft.CSharp.RuntimeBinder;
using Microsoft.SqlServer.Server;
namespace Application
{
    public partial class LoginForm : MaterialForm
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        Authentication authentication;

        DarkerOpacityForm darkeropacityform;
        NotificationWindow notificationwindow;
        
        TeacherWorkspace teacherworkspace;
        StudentWorkspace studentworkspace;

        AdministratorWorkspace administratorworkspace;
        ServerManualConnectionForm servermanualconnection;

        public LoginForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal900, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ResetLoginFormState();
            PrepareOrElseRetriveUserSettings();
        }
        
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void SqlServerSettingsButton_Click(object sender, EventArgs e)
        {
            opacityform = new OpacityForm();
            servermanualconnection = new ServerManualConnectionForm();
            
            opacityform.Show();
            servermanualconnection.ShowDialog();
            
            opacityform.Hide();
        }

        private void UsernameTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (UsernameTextbox.Text.Length > 0)
            {
                LoginErrorMessage.Visible = false;
            }
        }

        private void PasswordTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text.Length > 0)
            {
                LoginErrorMessage.Visible = false;
            }
        }

        private void UsernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (UsernameTextbox.Text.Length <= 0 && PasswordTextbox.Text.Length <= 0)
                {
                    LoginButton_Click(sender, e);
                }

                else if (UsernameTextbox.Text.Length > 0 && PasswordTextbox.Text.Length <= 0)
                {
                    PasswordTextbox.Focus();
                }

                else if (UsernameTextbox.Text.Length <= 0 && PasswordTextbox.Text.Length > 0)
                {
                    LoginButton_Click(sender, e);
                }

                else if (UsernameTextbox.Text.Length > 0 && PasswordTextbox.Text.Length > 0)
                {
                    LoginButton_Click(sender, e);
                }
            }

            else if (e.KeyData == Keys.F12)
            {
                SqlServerSettingsButton_Click(sender, e);
            }

            else if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void PasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                LoginButton_Click(sender, e);
            }

            else if (e.KeyData == Keys.F12)
            {
                SqlServerSettingsButton_Click(sender, e);
            }

            else if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Show_BusyCursor_State()
        {
            LoginButton.Cursor = Cursors.AppStarting;
        }

        private void Show_DefaultCursor_State()
        {
            LoginButton.Cursor = Cursors.Default;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Show_BusyCursor_State();
            opacityform = new OpacityForm();
            darkeropacityform = new DarkerOpacityForm();
            notificationwindow = new NotificationWindow();

            //EXCEPTION 2
            try
            {
                variables = new Variables();
                RegistryKey getregistrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string tempdata = getregistrykey.GetValue("SQLServerConnectionString").ToString();
                getregistrykey.Close();

                if (UsernameTextbox.Text.Length == 0 || PasswordTextbox.Text.Length == 0)
                {
                    authentication = new Authentication();
                    authentication.VerifyLoginCredentials(this);

                    Show_DefaultCursor_State();
                }

                else if (tempdata == string.Empty)
                {
                    notificationwindow.CaptionText = "SERVER NOT FOUND";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "WE CAN'T ESTABLISHED A CONNECTION\nTO THE SERVER, " + 
                        "PLEASE SETUP THE\nFOLLOWING CONFIGURATIONS.";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();

                    SqlServerSettingsButton_Click(sender, e);
                    Show_DefaultCursor_State();
                }

                else
                {
                    //INNER EXCEPTION 2
                    try
                    {
                        authentication = new Authentication();
                        authentication.VerifyLoginCredentials(this);

                        //AUTHENTICATED & ADMINISTRATOR
                        if (authentication.IsVerified == true && authentication.IsAdmin == true)
                        {
                            administratorworkspace = new AdministratorWorkspace();
                            
                            this.Hide();
                            administratorworkspace.Show();
                            Show_DefaultCursor_State();
                        }

                        //AUTHENTICATED & TEACHER
                        else if (authentication.IsVerified == true && authentication.IsTeacher == true)
                        {
                            teacherworkspace = new TeacherWorkspace();
                            
                            this.Hide();
                            teacherworkspace.Show();
                            Show_DefaultCursor_State();
                        }

                        //AUTHENTICATED & STUDENT
                        else if (authentication.IsVerified == true && authentication.IsStudent == true)
                        {
                            studentworkspace = new StudentWorkspace();

                            this.Hide();
                            studentworkspace.Show();
                            Show_DefaultCursor_State();
                        }
                    }

                    catch (Exception exception)
                    {
                        opacityform.Show();
                        MessageBox.Show(exception.Message.ToString(), "@LoginForm Inner Exception 2",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        opacityform.Hide();
                    }

                    Show_DefaultCursor_State();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@LoginForm Exception 2",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }
        
        private void ResetLoginFormState()
        {
            UsernameTextbox.Focus();
            UsernameTextbox.ResetText();
            PasswordTextbox.ResetText();

            LoginErrorMessage.Visible = false;
            LoginErrorMessage.Location = new Point(141, 134);
        }

        private void PrepareOrElseRetriveUserSettings()
        {
            opacityform = new OpacityForm();
            cryptography = new Cryptography();

            //EXCEPTION 1
            try
            {
                //OPEN REGISTRY SETTING
                variables = new Variables();
                RegistryKey getregistrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);

                //CREATE
                if (getregistrykey == null)
                {
                    RegistryKey createregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
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
                    RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
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

                getregistrykey.Close();
            }

            catch (Exception) {
                //DON'T DISPLAY ANYTHING SHIT !
            }
        }

        private void CloseTopButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void CloseTopButton_MouseHover(object sender, EventArgs e)
        {
            CloseTopButton.BackColor = Color.FromArgb(39, 44, 51);
            CloseTopButton.Image = Properties.Resources.Close_Button_Hover;
        }

        private void CloseTopButton_MouseLeave(object sender, EventArgs e)
        {
            CloseTopButton.Image = Properties.Resources.Close_Button;
        }

        private void MinimizeTopButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeTopButton_MouseHover(object sender, EventArgs e)
        {
            MinimizeTopButton.BackColor = Color.FromArgb(39, 44, 51);
            MinimizeTopButton.Image = Properties.Resources.Minimized_Button_Hover;
        }

        private void MinimizeTopButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeTopButton.Image = Properties.Resources.Minimized_Button;
        }

        private void MaximizeTopButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void MaximizeTopButton_MouseHover(object sender, EventArgs e)
        {
            MaximizeTopButton.BackColor = Color.FromArgb(39, 44, 51);
            MaximizeTopButton.Image = Properties.Resources.Miximized_Button_Hover;
        }

        private void MaximizeTopButton_MouseLeave(object sender, EventArgs e)
        {
            MaximizeTopButton.Image = Properties.Resources.Miximized_Button;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                SqlServerSettingsButton_Click(sender, e);
            }
        }
    }
}
