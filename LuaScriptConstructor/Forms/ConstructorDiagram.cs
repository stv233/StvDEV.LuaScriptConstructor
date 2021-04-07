using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Crainiate.Diagramming.Forms;

namespace LuaScriptConstructor.Forms
{
    /// <summary>
    /// Constructor diagram.
    /// </summary>
    class ConstructorDiagram : Diagram
    {
        private struct Mouse
        {
            public int X;
            public int Y;
        }

        private Mouse mouse;

        /// <summary>
        /// Types of constructor diagrams.
        /// </summary>
        public enum ConstructorDiagramTypes
        {
            Regular,
            Main,
            None
        }

        /// <summary>
        /// Occurs when the type is changed.
        /// </summary>
        public EventHandler DiagramTypeChanged;

        private ConstructorDiagramTypes type = ConstructorDiagramTypes.None;

        /// <summary>
        /// Diagram type.
        /// </summary>
        public ConstructorDiagramTypes Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != type)
                {
                    this.Clear();
                    Connectors.Clear();
                    Tables.Clear();
                    type = value;

                    if (type == ConstructorDiagramTypes.Main)
                    {
                        var mainTable = new Shapes.ConstructorTable(Components.ScriptСomponents.Functions[0].Table);
                        Model.Shapes.Add(mainTable);
                        Tables[mainTable.Key].Location = new PointF(200, 10);

                        var initTable = new Shapes.ConstructorTable(Components.ScriptСomponents.Functions[1].Table);
                        Model.Shapes.Add(initTable);
                        Tables[initTable.Key].Location = new PointF(50, 10);
                    }
                    else if (type == ConstructorDiagramTypes.Regular)
                    {
                        var functionStartTable = new Shapes.ConstructorTable(Components.ScriptСomponents.Functions[2].Table);
                        Model.Shapes.Add(functionStartTable);
                        Tables[functionStartTable.Key].Location = new PointF(200, 10);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of connectors in the diagram.
        /// </summary>
        public Dictionary<string, Shapes.ConstructorConnector> Connectors { get; protected set; }

        /// <summary>
        /// Returns a list of tables in the diaram.
        /// </summary>
        public Dictionary<string, Shapes.ConstructorTable> Tables { get; protected set; }

        /// <summary>
        /// Constructor diagram.
        /// </summary>
        public ConstructorDiagram() : base()
        {
            #region /// Initialization

            #region /// Properties

            Connectors = new Dictionary<string, Shapes.ConstructorConnector>();
            Tables = new Dictionary<string, Shapes.ConstructorTable>();

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

            #region /// Events

            DiagramTypeChanged += (s, e) => { };

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

                            if (element is Shapes.ConstructorConnector)
                            {
                                try
                                {
                                    Connectors.Remove(element.Key);
                                    this.Model.Lines.Remove(element.Key);
                                }
                                catch { }
                            }
                            else if (element is Shapes.ConstructorTable)
                            {
                                try
                                {
                                    Tables.Remove(element.Key);
                                    this.Model.Shapes.Remove(element.Key);
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

        /// <summary>
        /// Constructor diagram.
        /// </summary>
        /// <param name="type">Diagram type</param>
        public ConstructorDiagram(ConstructorDiagramTypes type) : this()
        {
            Type = type;
        }

        protected override void OnElementInserted(Crainiate.Diagramming.Element element)
        {
            if (element is Shapes.ConstructorTable)
            {
                Tables.Add(element.Key, (Shapes.ConstructorTable)element);
            }
            base.OnElementInserted(element);
        }
    }
}
