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
    /// Constructor tool trip render.
    /// </summary>
    class ConstructorToolStripRender : ToolStripProfessionalRenderer
    {
        public ConstructorToolStripRender() : base (new ConstructorColor()) { }

        protected class ConstructorColor : ProfessionalColorTable
        {
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }
    }
}
