using System;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Application
{
    public partial class ChangeSecurityCodeForm : Form
    {
        Variables variables;
        Cryptography cryptography;

        NotificationWindow notificationwindow;
        DarkerOpacityForm darkeropacityform;

        public ChangeSecurityCodeForm()
        {
            InitializeComponent();
        }

        private void ChangeSecurityCodeForm_Load(object sender, EventArgs e)
        {
            try
            {
                variables = new Variables();
                cryptography = new Cryptography();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string VirtualData = registrykey.GetValue("Security Code").ToString();

                CurrentSecurityCodeTextbox.Text = cryptography.Decrypt(VirtualData);
                CurrentSecurityCodeTextbox.Enabled = false;
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                cryptography = new Cryptography();
                darkeropacityform = new DarkerOpacityForm();
                notificationwindow = new NotificationWindow();

                if (NewSecurityCodeTextbox.Text.Trim().Length == 0)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE NEW SECURITY CODE !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (ConfirmSecurityCodeTextbox.Text.Trim().Length == 0)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE CONFIRM YOUR NEW\nSECURITY CODE !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (!ConfirmSecurityCodeTextbox.Text.Trim().Equals(NewSecurityCodeTextbox.Text.Trim()) ||
                    !NewSecurityCodeTextbox.Text.Trim().Equals(ConfirmSecurityCodeTextbox.Text.Trim()))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "SECURITY CODES DOES NOT MATCH !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else
                {
                    RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                    updateregistrykey.SetValue("Security Code", cryptography.Encrypt(ConfirmSecurityCodeTextbox.Text.Trim()));

                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.check;
                    notificationwindow.MessageText = "SUCCESSFULLY UPDATED !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();

                    DialogResult = DialogResult.OK;
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private void CurrentSecurityCodeTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (CurrentSecurityCodeTextbox.Text.Length >= 1)
            {
                ShowPasswordImg1.Visible = true;
            }

            else if (CurrentSecurityCodeTextbox.Text.Length < 1)
            {
                ShowPasswordImg1.Visible = false;
            }
        }

        private void NewSecurityCodeTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (NewSecurityCodeTextbox.Text.Length >= 1)
            {
                ShowPasswordImg2.Visible = true;
            }

            else if (NewSecurityCodeTextbox.Text.Length < 1)
            {
                ShowPasswordImg2.Visible = false;
            }
        }

        private void ConfirmSecurityCodeTextbox_OnValueChanged(object sender, EventArgs e)
        {
            if (ConfirmSecurityCodeTextbox.Text.Length >= 1)
            {
                ShowPasswordImg3.Visible = true;
            }

            else if (ConfirmSecurityCodeTextbox.Text.Length < 1)
            {
                ShowPasswordImg3.Visible = false;
            }
        }

        private void ShowPasswordImg1_Click(object sender, EventArgs e)
        {
            //SHOW
            if (CurrentSecurityCodeTextbox.isPassword == true)
            {
                CurrentSecurityCodeTextbox.isPassword = false;
                ShowPasswordImg1.Image = Properties.Resources.Hide;
            }

            //HIDE
            else if (CurrentSecurityCodeTextbox.isPassword == false)
            {
                CurrentSecurityCodeTextbox.isPassword = true;
                ShowPasswordImg1.Image = Properties.Resources.Show;
            }
        }

        private void ShowPasswordImg1_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg1.Size = new Size(25, 25);
        }

        private void ShowPasswordImg1_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg1.Size = new Size(23, 23);
        }

        private void ShowPasswordImg2_Click(object sender, EventArgs e)
        {
            //SHOW
            if (NewSecurityCodeTextbox.isPassword == true)
            {
                NewSecurityCodeTextbox.isPassword = false;
                ShowPasswordImg2.Image = Properties.Resources.Hide;
            }

            //HIDE
            else if (NewSecurityCodeTextbox.isPassword == false)
            {
                NewSecurityCodeTextbox.isPassword = true;
                ShowPasswordImg2.Image = Properties.Resources.Show;
            }
        }

        private void ShowPasswordImg2_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg2.Size = new Size(25, 25);
        }

        private void ShowPasswordImg2_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg2.Size = new Size(23, 23);
        }

        private void ShowPasswordImg3_Click(object sender, EventArgs e)
        {
            //SHOW
            if (ConfirmSecurityCodeTextbox.isPassword == true)
            {
                ConfirmSecurityCodeTextbox.isPassword = false;
                ShowPasswordImg3.Image = Properties.Resources.Hide;
            }

            //HIDE
            else if (ConfirmSecurityCodeTextbox.isPassword == false)
            {
                ConfirmSecurityCodeTextbox.isPassword = true;
                ShowPasswordImg3.Image = Properties.Resources.Show;
            }
        }

        private void ShowPasswordImg3_MouseHover(object sender, EventArgs e)
        {
            ShowPasswordImg3.Size = new Size(25, 25);
        }

        private void ShowPasswordImg3_MouseLeave(object sender, EventArgs e)
        {
            ShowPasswordImg3.Size = new Size(23, 23);
        }
        
        private void ChangeSecurityCodeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.OK;
        }
    }
}
