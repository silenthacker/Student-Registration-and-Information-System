using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Win32;
using System.Windows.Forms;

using Microsoft.CSharp.RuntimeBinder;
namespace Application
{
    public partial class FeedbackForm : Form
    {
        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;

        DarkerOpacityForm darkeropacityform;
        NotificationWindow notificationwindow;

        internal string AFK, JFK;
        private string FeedbackType = "Comments", UserFeeling = "Happy";
        
        public FeedbackForm()
        {
            InitializeComponent();
        }

        private void FeedbackForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomContextMenuStripRender());
        }

        private void FeedbackForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            variables = new Variables();
            opacityform = new OpacityForm();
            cryptography = new Cryptography();

            darkeropacityform = new DarkerOpacityForm();
            notificationwindow = new NotificationWindow();

            //EXCEPTION 1
            try
            {
                SmtpClient smtpclient = new SmtpClient("smtp.gmail.com");
                MailMessage email = new MailMessage();

                AFK = "Josepamasilenthacker@gmail.com";
                JFK = cryptography.Decrypt(variables._64BaseStringHash);

                if (FeedbackTextbox.Text.Trim().Length < 1 || NameTextbox.Text.Trim().Length < 1 || EmailTextbox.Text.Trim().Length < 1)
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE THE REQUIRED\nINFORMATIONS BEING ASK !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }

                else if (!EmailTextbox.Text.Trim().Contains("@") || !EmailTextbox.Text.Trim().Contains(".com"))
                {
                    notificationwindow.CaptionText = "MESSAGE CONTENT";
                    notificationwindow.MsgImage.Image = Properties.Resources.warning;
                    notificationwindow.MessageText = "PLEASE PROVIDE A VALID EMAIL ADDRESS !";

                    darkeropacityform.Show();
                    notificationwindow.ShowDialog();
                    darkeropacityform.Hide();
                }
                
                else
                {
                    //INNER EXCEPTION 1
                    try
                    {
                        email.To.Add("PTLESolutions@gmail.com");
                        email.From = new MailAddress(EmailTextbox.Text.Trim(), NameTextbox.Text.Trim());
                        email.Subject = NameTextbox.Text + " added a " + FeedbackType + "! From " + 
                            NameTextbox.Text + " - " + EmailTextbox.Text;

                        email.Body = "Hello, Good day ! I am " + NameTextbox.Text + " and I feel " +
                            UserFeeling + " whenever I use your system. and I am suggesting for " + SuggestionTextbox.Text +
                            "My Feedback is " + FeedbackTextbox.Text + ", Keep it up! and have a nice day.";
                        
                        smtpclient.EnableSsl = true;
                        smtpclient.Port = 587;
                        smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpclient.Credentials = new NetworkCredential(AFK, JFK);
                        smtpclient.Timeout = 15;

                        try {
                            smtpclient.Send(email);
                            notificationwindow.CaptionText = "MESSAGE SENT !";
                            notificationwindow.MsgImage.Image = Properties.Resources.check;
                            notificationwindow.MessageText = "YOUR FEEDBACK HAS BEEN SENT !, KEEP\nSENDING YOUR FEEDBACKS TO IMPROVE\nOUR SYSTEM !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }

                        catch (SmtpException) {

                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.error;
                            notificationwindow.MessageText = "FEEDBACK NOT SENT, PLEASE CHECK\nYOUR INTERNET CONNECTION !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();
                        }
                    }

                    catch (Exception exception)
                    {
                        opacityform.Show();
                        MessageBox.Show(exception.Message.ToString(), "@Feedback Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        opacityform.Hide();
                    }
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Feedback Form Exception 1",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        private void sHOWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FeedbackForm_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.ShowBalloonTip(2000, "PTLE Solutions", 
                    "Click here To help improve our system by sending your feedback.", 
                    ToolTipIcon.Info);
            }

            else if (this.WindowState == FormWindowState.Normal)
            {
                //DO NOTHING SHIT !
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void YesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //EXCEPTION 1
            try
            {
                variables = new Variables();
                opacityform = new OpacityForm();

                RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                updateregistrykey.SetValue("Show Feedback Form", "False");
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Feedback Form Exception 1",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }

        private void CommentsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FeedbackType = "Comments";
        }

        private void QuestionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FeedbackType = "Question";
        }

        private void BugReportRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FeedbackType = "Bug Report";
        }

        private void FeatureRequestRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FeedbackType = "Feature Request";
        }

        private void HappyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserFeeling = "Happy";
        }

        private void AngryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserFeeling = "Angry";
        }

        private void CryingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserFeeling = "Crying";
        }

        private void QuiteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserFeeling = "Quite";
        }

        private void KissingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserFeeling = "Kissing";
        }

        private void FeedbackTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }

            else if (e.KeyData == Keys.Enter)
            {
                SendButton_Click(sender, e);
            }
        }

        private void FeedbackForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void SuspiciousRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserFeeling = "Suspicious";
        }

        private void NoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //EXCEPTION 2
            try
            {
                variables = new Variables();
                opacityform = new OpacityForm();

                RegistryKey updateregistrykey = Registry.CurrentUser.CreateSubKey(@variables.pathname);
                updateregistrykey.SetValue("Show Feedback Form", "True");
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@Feedback Form Exception 2",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }
        }
    }
}
