using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Application
{
    class MyCustomRenderer : ToolStripProfessionalRenderer
    {
        public MyCustomRenderer(ProfessionalColorTable professionalColorTable) : base(professionalColorTable)
        {
            //DO NOTHING SHIT !
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //DO NOTHING SHIT !
        }
    }
}
