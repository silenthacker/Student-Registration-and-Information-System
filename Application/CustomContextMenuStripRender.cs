using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Application
{
    class CustomContextMenuStripRender : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get
            {
                return Color.Teal;
            }
        }
    }
}
