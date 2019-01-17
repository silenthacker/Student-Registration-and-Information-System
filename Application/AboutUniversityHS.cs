using System;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.CSharp.RuntimeBinder;
using System.Deployment.Internal.CodeSigning;
namespace Application
{
    public partial class AboutUniversityHS : Form
    {
        public AboutUniversityHS()
        {
            InitializeComponent();
        }

        private void AboutUniversityHS_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 20);
        }

        private void AboutUniversityHS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
