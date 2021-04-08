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
                        Tables[mainTable.Key].Width = Tables[mainTable.Key].Width + 6;

                        var initTable = new Shapes.ConstructorTable(Components.ScriptСomponents.Functions[1].Table);
                        Model.Shapes.Add(initTable);
                        Tables[initTable.Key].Location = new PointF(50, 10);
                    }
                    else if (type == ConstructorDiagramTypes.Regular)
                    {
                        var functionStartTable = new Shapes.ConstructorTable(Components.ScriptСomponents.Functions[2].Table);
                        functionStartTable.Heading = this.Parent.Text;
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
            var tsmiEdit = new ToolStripMenuItem("Edit")
            {
                ShortcutKeyDisplayString = "F2",
                ShortcutKeys = Keys.F2,
                Visible = false
            };
            tsmiEdit.Click += (se, ev) =>
            {
                if (Model.SelectedShapes().Count == 1)
                {
                    foreach (var shape in Model.SelectedShapes().Values)
                    {
                        if (shape is Shapes.ConstructorTable)
                        {
                            var table = shape as Shapes.ConstructorTable;

                            if (table.CanEditHeading)
                            {
                                BeginEditHeading(table);
                                return;
                            }
                        }
                    }
                }
            };
            cmsMenu.Items.Add(tsmiEdit);
            var tsmiBuild = new ToolStripMenuItem { Text = "Build" };
            tsmiBuild.Click += (s, e) => { Build(); };
            cmsMenu.Items.Add(tsmiBuild);
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
                                    var table = (Shapes.ConstructorTable)element;

                                    // If the table is a function.
                                    if (table.Type == Shapes.ConstructorTable.ConstructionTableTypes.Function)
                                    {
                                        // If the table is a table of one of the Script component functions, then it cannot be deleted.
                                        foreach (Types.Function function in Components.ScriptСomponents.Functions)
                                        {
                                            if (table.Function.Prefix == function.Prefix)
                                            {
                                                return;
                                            }
                                        }
                                    }

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

            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    
                    if (Model.SelectedShapes().Count == 1)
                    {
                        
                        foreach (var shape in Model.SelectedShapes().Values)
                        {
                            if (shape is Shapes.ConstructorTable)
                            {
                                var table = shape as Shapes.ConstructorTable;

                                if ((table.CanEditHeading))
                                {
                                    tsmiEdit.Visible = true;
                                    return;
                                }
                            }
                        }
                    }
                }

                tsmiEdit.Visible = false;
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
                var table = (Shapes.ConstructorTable)element;
                Tables.Add(element.Key, table);
                
                if (table.Type == Shapes.ConstructorTable.ConstructionTableTypes.Function)
                {
                    table.BackColor = ((Types.Function)table.Owner).Table.BackColor;
                    table.GradientColor = ((Types.Function)table.Owner).Table.GradientColor;
                }
                else if (table.Type == Shapes.ConstructorTable.ConstructionTableTypes.Variable)
                {
                    table.BackColor = ((Types.Variable)table.Owner).Table.BackColor;
                    table.GradientColor = ((Types.Variable)table.Owner).Table.GradientColor;
                }
                else
                {
                    table.BackColor = table.Owner.Table.BackColor;
                    table.GradientColor = table.Owner.Table.GradientColor;
                }
            }
            base.OnElementInserted(element);
        }

        /// <summary>
        /// Begin edit table heding, if table allow it.
        /// </summary>
        /// <param name="table"></param>
        public void BeginEditHeading(Shapes.ConstructorTable table)
        {
            if (!table.CanEditHeading)
            {
                return;
            }

            var texbox = new System.Windows.Forms.TextBox
            {
                Text = table.Heading,
                Left = -100,
                Tag = table.FontName,
                Parent = this.Parent

            };

            table.FontName = "Consolas";
            this.Refresh();

            texbox.TextChanged += (s, e) =>
            {
                table.Heading = texbox.Text;

                // If this is a function start table, then rename the title along with it.
                if (table.Type == Shapes.ConstructorTable.ConstructionTableTypes.Function)
                {
                    if (table.Function.Prefix == Components.ScriptСomponents.Functions[2].Prefix)
                    {
                        this.Parent.Text = table.Heading;
                    }
                }

                this.Refresh();
            };
            texbox.LostFocus += (s, e) =>
            {
                table.FontName = texbox.Tag.ToString();
                this.Refresh();
                texbox.Dispose();
                texbox = null;
            };

            texbox.Focus();
            texbox.SelectionStart = texbox.Text.Length;
            texbox.SelectionLength = 0;
        }
        
        /// <summary>
        /// Build function.
        /// </summary>
        protected virtual void Build()
        {
            var function = new Types.Function(this.Parent.Text.Replace(" ","_"));
            function.AccessType = Types.Variable.VariableAccessTypes.InputOutput;
            function.Build(this);
            var form = (frMain)frMain.ActiveForm;
            form.ProjectFunctions[this.Parent.Text.Replace(" ", "_")] = function;
        }
    }
}
