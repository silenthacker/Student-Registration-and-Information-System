using System;
using System.Windows.Forms;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class NotificationWindow : Form
    {
        string captionstr;
        public string CaptionText
        {
            get {
                return captionstr;
            }

            set {
                captionstr = value;
            }
        }
        
        string msgstr;
        public string MessageText
        {
            get {
                return msgstr;
            }

            set {
                msgstr = value;
            }
        }
        public NotificationWindow()
        {
            InitializeComponent();
        }

        private void NotificationWindow_Load(object sender, EventArgs e)
        {
            this.Text = CaptionText;
            MessageString.Text = MessageText;
        }
        
        private void NotificationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotificationWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void bunifuSeparator1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CloseButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
