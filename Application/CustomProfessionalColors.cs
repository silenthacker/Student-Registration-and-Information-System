using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Application
{
    class CustomProfessionalColors : ProfessionalColorTable
    {
        Color BackGroundColor = Color.FromArgb(39, 44, 51);
        Color HoverColor = Color.FromArgb(58, 66, 77);
        
        public override Color MenuBorder
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return Color.Teal;
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return BackGroundColor;
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color ButtonCheckedHighlightBorder
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color ButtonPressedBorder
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color ButtonPressedHighlightBorder
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color ButtonSelectedBorder
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color ButtonSelectedHighlightBorder
        {
            get
            {
                return HoverColor;
            }
        }

        public override Color ToolStripBorder
        {
            get
            {
                return HoverColor;
            }
        }
    }
}
