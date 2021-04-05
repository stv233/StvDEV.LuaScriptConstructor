using System;
using System.Drawing;
using System.Windows.Forms;

namespace LuaScriptConstructor.Forms
{
    /// <summary>
    /// Diagram tab page.
    /// </summary>
    class DiagramTabPage : TabPage
    {
       

        private ConstructorDiagram diagram;
        public ConstructorDiagram Diagram
        {
            get
            {
                return diagram;
            }
            set
            {
                diagram = value;
            }
        }


        public DiagramTabPage() : this("") { }

        public DiagramTabPage(string name) : base(name)
        {
            diagram = new ConstructorDiagram
            {
                Width = this.ClientSize.Width,
                Height = this.ClientSize.Height,
                Parent = this
            };

            this.Resize += (s, e) =>
            {
                diagram.Width = this.ClientSize.Width;
                diagram.Height = this.ClientSize.Height;
            };
        }
    }
}
