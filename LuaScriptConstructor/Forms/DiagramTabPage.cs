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
            Name = name;

            this.AutoScroll = true;

            diagram = new ConstructorDiagram
            {
                //AutoScroll = true,
                Dock = DockStyle.Fill,
                Parent = this
            };

            var margin = new Crainiate.Diagramming.Forms.Margin
            {
                Bottom = 0F,
                Left = 0F,
                Right = 0F,
                Top = 0F
            };

            var paging = new Crainiate.Diagramming.Forms.Paging
            {
                Enabled = false,
                Margin = margin,
                Padding = new System.Drawing.SizeF(0, 0),
                Page = 1,
                WorkspaceColor = System.Drawing.SystemColors.AppWorkspace
            };
            diagram.Paging = paging;

            diagram.Suspend();
            diagram.Dock = DockStyle.None;
            diagram.Width = 2000;
            diagram.Height = 2000;
            diagram.Resume();
        }
    }
}
