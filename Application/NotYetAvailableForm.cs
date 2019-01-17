using System;
using System.Windows.Forms;

using Microsoft.CSharp.RuntimeBinder;
namespace Application
{
    public partial class NotYetAvailableForm : Form
    {
        public NotYetAvailableForm()
        {
            InitializeComponent();
        }
        
        private void NotYetAvailableForm_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void NotYetAvailableForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
