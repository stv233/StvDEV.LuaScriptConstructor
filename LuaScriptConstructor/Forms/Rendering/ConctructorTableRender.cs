using Crainiate.Diagramming;
using Crainiate.Diagramming.Forms.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Forms.Rendering
{
    class ConctructorTableRender : Crainiate.Diagramming.Forms.Rendering.TableRender
    {

        public override void RenderElement(IRenderable element, Graphics graphics, Render render)
        {
            base.RenderElement(element, graphics, render);

            var table = element as Crainiate.Diagramming.Table;

            if (table.Label != null)
            {
                LabelRender renderer = render.GetRenderer(table.Label) as LabelRender;
                if (table.Label.Wrap)
                {
                    renderer.RenderElement(table.Label, graphics, render, table.InternalRectangle);
                }
                else
                {
                    renderer.RenderElement(table.Label, graphics, render);
                }
            }

        }
        
    }
}
