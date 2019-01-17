using System;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class AboutUniversity : Form
    {
        OpacityForm opacityform;

        public AboutUniversity()
        {
            InitializeComponent();
        }

        private void AboutUniversity_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 20);
        }
        
        private void BukSULinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //EXCEPTION 1
            try
            {
                opacityform = new OpacityForm();
                System.Diagnostics.Process.Start("http://buksu.edu.ph/");
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.Message.ToString(), "@About University Form Exception 1",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                opacityform.Hide();
            }    
        }

        private void AboutUniversity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
