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
        private ConstructorDiagram _diagram;

        /// <summary>
        /// Tab diagram.
        /// </summary>
        public ConstructorDiagram Diagram
        {
            get
            {
                return _diagram;
            }
            set
            {
                _diagram = value;
            }
        }

        /// <summary>
        /// Diagram tab page.
        /// </summary>
        public DiagramTabPage() : this("") { }

        public DiagramTabPage(string name) : base(name)
        {
            #region /// Initialization

            Name = name;
            this.AutoScroll = true;

            _diagram = new ConstructorDiagram
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
            _diagram.Paging = paging;

            _diagram.Suspend();
            _diagram.Dock = DockStyle.None;
            _diagram.Width = 2000;
            _diagram.Height = 2000;
            _diagram.Resume();

            #endregion

            #region /// Events


            int scrollX = -1;
            int scrollY = -1;
            bool scroll = false;
            Point autoScrollPosition = new Point();

            this.Diagram.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Middle)
                {
                    if (!scroll)
                    {
                        scrollX = e.X;
                        scrollY = e.Y;
                        autoScrollPosition = this.AutoScrollPosition;
                        scroll = true;
                        Diagram.Suspend();
                    }
                }
            };

            this.Diagram.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Middle)
                {
                    if (scroll)
                    {
                        scroll = false;
                        Diagram.Resume();
                    }
                }
            };

            bool tick = false;
            this.Diagram.MouseMove += (s, e) => 
            {
                tick = !tick;
                if (scroll && tick)
                {
                    this.AutoScrollPosition = new Point(autoScrollPosition.X + (scrollX - e.X), autoScrollPosition.Y + (scrollY - e.Y));
                }
            };

            #endregion


        }


    }
}
