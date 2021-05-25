using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LuaScriptConstructor.Forms.Rendering
{
    /// <summary>
    /// Constructor menu strip render.
    /// </summary>
    class ConstructorMenuStripRender : ToolStripProfessionalRenderer
    {
       public ConstructorMenuStripRender() : base(new ConstructorColor()) { }

        protected class ConstructorColor : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return UserSettings.ColorScheme.SecondaryColor; }
            }
            public override Color MenuItemBorder
            {
                get { return UserSettings.ColorScheme.SecondaryColor; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return UserSettings.ColorScheme.MainColor; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return UserSettings.ColorScheme.MainColor; }
            }

            public override Color ToolStripDropDownBackground
            {
                get { return UserSettings.ColorScheme.MainColor; }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get { return UserSettings.ColorScheme.SecondaryColor; }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get { return UserSettings.ColorScheme.SecondaryColor; }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return UserSettings.ColorScheme.MainColor; }
            }

            public override Color ImageMarginGradientEnd
            {
                get { return UserSettings.ColorScheme.MainColor; }
            }

            public override Color ImageMarginGradientMiddle
            {
                get { return UserSettings.ColorScheme.MainColor; }
            }

        }
    }
}
