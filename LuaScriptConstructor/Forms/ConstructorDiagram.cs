using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Crainiate.Diagramming.Forms;

namespace LuaScriptConstructor.Forms
{
    /// <summary>
    /// Constructor diagram
    /// </summary>
    class ConstructorDiagram : Diagram
    {
        private struct Mouse
        {
            public int X;
            public int Y;
        }

        private Mouse mouse;

        public Dictionary<string, Crainiate.Diagramming.Connector> Connectors { get; set; }

        public ConstructorDiagram() : base()
        {
            #region /// Initialization

            #region /// Properties

            Connectors = new Dictionary<string, Crainiate.Diagramming.Connector>();

            #endregion

            #region /// Menu

            var cmsMenu = new ContextMenuStrip();
            var tsmiConnector = new ToolStripMenuItem
            {
                Text = "Add connector"
            };
            tsmiConnector.Click += (s, e) =>
            {
                Shapes.ConstructorConnector connector = new Shapes.ConstructorConnector();
                connector.Start.Location = new PointF(mouse.X - 50, mouse.Y - 50);
                connector.End.Location = new PointF(mouse.X + 50, mouse.Y + 50); //300,140
                connector.Avoid = true;
                connector.End.Marker = new Crainiate.Diagramming.Arrow();
                connector.Start.Marker = new Crainiate.Diagramming.Marker(Crainiate.Diagramming.MarkerStyle.Ellipse);

                this.Model.Lines.Add(connector);
                this.Connectors.Add(connector.Key, connector);
                connector.Selected = true;
                this.Refresh();
            };
            cmsMenu.Items.Add(tsmiConnector);
            this.ContextMenuStrip = cmsMenu;

            #endregion

            #region /// Render

            Render.AddRenderer(typeof(Shapes.ConstructorConnector), new Crainiate.Diagramming.Forms.Rendering.ConnectorRender());
            Render.AddRenderer(typeof(Shapes.ConstructorTable), new Crainiate.Diagramming.Forms.Rendering.TableRender());

            #endregion

            #endregion

            #region /// Events

            this.MouseMove += (s, e) =>
            {
                mouse.X = e.X;
                mouse.Y = e.Y;
            };

            this.PreviewKeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (this.Model.SelectedElements() != null)
                    {
                        foreach (var element in this.Model.SelectedElements().Values)
                        {

                            if (element is Crainiate.Diagramming.Line)
                            {
                                try
                                {

                                    if (element is Crainiate.Diagramming.Connector)
                                    {
                                        Connectors.Remove(element.Key);
                                    }

                                    this.Model.Lines.Remove(element.Key);
                                }
                                catch { }
                            }
                            
                            
                        }
                        this.Refresh();
                    }
                }
            };


            #endregion
        }
    }
}
