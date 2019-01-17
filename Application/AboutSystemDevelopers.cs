using System;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class AboutSystemDevelopers : Form
    {
        public AboutSystemDevelopers()
        {
            InitializeComponent();
        }

        private void AboutSystemDevelopers_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            this.Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 20);
        }
         
        private void AboutSystemDevelopers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void bunifuSeparator1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void bunifuSeparator2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
