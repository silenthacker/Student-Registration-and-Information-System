using System;
using System.Drawing;
using System.Windows.Forms;

namespace Application
{
    public partial class SystemLogForm : Form
    {
        public SystemLogForm()
        {
            InitializeComponent();
        }

        private void SystemLogForm_Load(object sender, EventArgs e)
        {
            int BoundsWidth = Screen.PrimaryScreen.Bounds.Width;
            int BoundsHeight = Screen.PrimaryScreen.Bounds.Height;
            int X_Coordinate = BoundsWidth - this.Width;
            int Y_Coordinate = BoundsHeight - this.Height;
            this.Location = new Point(X_Coordinate / 2, (Y_Coordinate / 2) + 26);
        }
    }
}
