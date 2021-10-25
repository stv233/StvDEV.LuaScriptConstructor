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
                BackColor = UserSettings.ColorScheme.SecondaryColor,
                ForeColor = UserSettings.ColorScheme.SecondaryColor,
                GridColor = UserSettings.ColorScheme.GridColor,
                Dock = DockStyle.Fill,
                Heading = name,
                Parent = this
            };

            var paging = new Crainiate.Diagramming.Forms.Paging
            {
                Enabled = false,
            };
            _diagram.Paging = paging;

            _diagram.Suspend();
            _diagram.Dock = DockStyle.None;
            _diagram.MaximumSize = new Size(UserSettings.DiagramSize, UserSettings.DiagramSize);
            _diagram.Size = new Size(UserSettings.DiagramSize, UserSettings.DiagramSize);
            _diagram.Model.SetSize(new Size(UserSettings.DiagramSize, UserSettings.DiagramSize));
            _diagram.Resume();

            _diagram.HeadingChanged += (s, e) =>
            {
                this.Text = _diagram.Heading;
                
            };
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

        /// <summary>
        /// Diagram tab page.
        /// </summary>
        protected override Point ScrollToControl(Control activeControl)
        {
            return DisplayRectangle.Location;
        }

    }
}
