using System;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Application
{
    public partial class SecurityCodeForm : Form
    {
        LoginForm loginform;
        Variables variables;
        Cryptography cryptography;

        public SecurityCodeForm()
        {
            InitializeComponent();
        }

        private void SecurityCodeForm_Load(object sender, EventArgs e)
        {
            try
            {
                string Username = Environment.UserName.ToUpper();
                UsernameLabel.Text = "PC USER: " + Username;
            }

            catch (Exception)
            {
                //DONT DO ANYTHING BITCH !
            }
        }

        private void AuthenticateButton_Click(object sender, EventArgs e)
        {
            try
            {
                AuthenticateButton.Cursor = Cursors.AppStarting;

                //HACKABLE CODE //TYPE LENS !
                loginform = new LoginForm();
                variables = new Variables();
                cryptography = new Cryptography();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string security_passphrase = registrykey.GetValue("Security Code").ToString();

                if (!cryptography.Encrypt(SecurityCodeTextbox.Text.Trim()).Equals(security_passphrase))
                {
                    ErrorLabel.Visible = true;
                    SecurityCodeTextbox.LineFocusedColor = Color.Red;
                    SecurityCodeTextbox.LineIdleColor = Color.Red;
                    SecurityCodeTextbox.LineMouseHoverColor = Color.Red;
                    AuthenticateButton.Cursor = Cursors.Default;
                }

                else if (cryptography.Encrypt(SecurityCodeTextbox.Text.Trim()).Equals(security_passphrase))
                {
                    AuthenticateButton.Cursor = Cursors.Default;
                    this.Hide();
                    loginform.Show();
                }

                //RESTORE SECURITY STATE
                SecurityCodeForm_Load(sender, e);
            }

            catch (Exception)
            {
                //DONT DO ANYTHING BITCH !
            }
        }

        private void SecurityCodeTextbox_OnValueChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            SecurityCodeTextbox.LineFocusedColor = Color.Blue;
            SecurityCodeTextbox.LineIdleColor = Color.Gray;
            SecurityCodeTextbox.LineMouseHoverColor = Color.Blue;

            if (SecurityCodeTextbox.Text.Length > 0)
                SecurityCodeTextbox.isPassword = true;

            else if (SecurityCodeTextbox.Text.Length < 1)
                SecurityCodeTextbox.isPassword = false;
        }
        
        private void DontCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                variables = new Variables();
                RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);

                if (DontCheckBox.Checked == false)
                    updateregistrykey.SetValue("Show Security Form", "True");

                else if (DontCheckBox.Checked == true)
                    updateregistrykey.SetValue("Show Security Form", "False");

                updateregistrykey.Close();
            }

            catch (Exception)
            {
                //DONT DO ANYTHING BITCH !
            }
        }

        private void SecurityCodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void SecurityCodeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }

        private void SecurityCodeTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                AuthenticateButton_Click(sender, e);
        }
    }
}
