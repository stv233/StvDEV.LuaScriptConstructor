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
    class ConstructorDiagram : Diagram, Saves.IConstructorSerializable
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
                Text = "Add connector",
                Image = Properties.Resources.Connector_16x
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
                Visible = false,
                Image = Properties.Resources.EditLabel_16x
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
            var tsmiBuild = new ToolStripMenuItem 
            { 
                Text = "Build function", 
                Image = Properties.Resources.BuildSelection_16x,
                ShortcutKeyDisplayString = "Shift+F6",
                ShortcutKeys = Keys.Shift | Keys.F6
            };
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
                                    if (table.Type == Shapes.ConstructorTable.ConstructorTableTypes.Function)
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
                var table = element as Shapes.ConstructorTable;
                Tables.Add(element.Key, table);
                
                if (table.Type == Shapes.ConstructorTable.ConstructorTableTypes.Function)
                {
                    try
                    {
                        table.BackColor = ((Types.Function)table.Owner).Table.BackColor;
                        table.GradientColor = ((Types.Function)table.Owner).Table.GradientColor;
                    }
                    catch 
                    {
                        table.BackColor = Color.White;
                        table.GradientColor = Color.White;
                    }
                    table.AllowRenew = true;
                }
                else if (table.Type == Shapes.ConstructorTable.ConstructorTableTypes.Variable)
                {
                    try
                    {
                        table.BackColor = ((Types.Variable)table.Owner).Table.BackColor;
                        table.GradientColor = ((Types.Variable)table.Owner).Table.GradientColor;
                    }
                    catch 
                    {
                        table.BackColor = new Types.Variable().Table.BackColor;
                        table.GradientColor = new Types.Variable().Table.GradientColor;
                    }
                }
                else
                {
                    try
                    {
                        table.BackColor = table.Owner.Table.BackColor;
                        table.GradientColor = table.Owner.Table.GradientColor;
                    }
                    catch 
                    {
                        table.BackColor = new Types.Constant().Table.BackColor;
                        table.GradientColor = new Types.Constant().Table.GradientColor;
                    }
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
                if (table.Type == Shapes.ConstructorTable.ConstructorTableTypes.Function)
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
        public virtual void Build()
        {
            var function = new Types.Function(this.Parent.Text.Replace(" ","_"));
            function.AccessType = Types.Variable.VariableAccessTypes.InputOutput;
            function.Description = "User function";
            function.Build(this);
            //var form = (frMain)this.ParentForm;
            //form.ProjectFunctions[this.Parent.Text.Replace(" ", "_")] = function;
            //form.RefreshProjectFunction();
        }
        
        /// <summary>
        /// Serialize constructor diagram to string.
        /// </summary>
        /// <returns>Serialized string</returns>
        public string SerializeToString()
        {
            string result = "{";
            result += "Type=" + type + ";";
            result += "Tables=" + SerializeTables(Tables.Values) + ";";
            result += "Connectors=" + SerializeConnectors(Connectors.Values) + ";";
            result += "}";
            return result;
        }

        /// <summary>
        /// Serialize diagram connectors to string.
        /// </summary>
        /// <param name="connectors">Diagram conectors</param>
        /// <returns>Serialized connectors</returns>
        private string SerializeConnectors(Dictionary<string, Shapes.ConstructorConnector>.ValueCollection connectors)
        {
            string result = "{";
            foreach(Shapes.ConstructorConnector connector in connectors)
            {
                result += "Connector=" + connector.SerializeToString() + ";";
            }
            result += "}";
            return result;
        }

        /// <summary>
        /// Serialize diagram tabkes to string.
        /// </summary>
        /// <param name="tables">Diagram tables</param>
        /// <returns>Serialized diagram</returns>
        private string SerializeTables(Dictionary<string, Shapes.ConstructorTable>.ValueCollection tables)
        {
            string result = "{";
            foreach (Shapes.ConstructorTable table in tables)
            {
                result += "Table=" + table.SerializeToString() + ";";
            }
            result += "}";
            return result;
        }

        /// <summary>
        /// Deserialize constuctor diagram from string.
        /// </summary>
        /// <param name="serializedDiagram">Serialized diagram</param>
        public void DeserializeFromString(string serializedDiagram)
        {
            serializedDiagram = serializedDiagram.Substring(1, serializedDiagram.Length - 2);
            while (serializedDiagram.Length > 0)
            {
                int propertySign = serializedDiagram.IndexOf('=');
                string propertyName = serializedDiagram.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedDiagram, propertySign);
                switch (propertyName)
                {
                    case "Type":
                        string typeString = (serializedDiagram.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        switch (typeString)
                        {
                            case "Main":
                                type = ConstructorDiagramTypes.Main;
                                break;
                            case "None":
                                type = ConstructorDiagramTypes.None;
                                break;
                            case "Regular":
                                type = ConstructorDiagramTypes.Regular;
                                break;
                        }
                        serializedDiagram = serializedDiagram.Substring(delimiter + 1);
                        break;
                    case "Tables":
                        string tables = (serializedDiagram.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        foreach (Shapes.ConstructorTable table in DeserializeTables(tables).Values)
                        {
                            this.Model.Shapes.Add(table);
                        }
                        serializedDiagram = serializedDiagram.Substring(delimiter + 1);
                        break;
                    case "Connectors":
                        string connectors = (serializedDiagram.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        Dictionary<string, Shapes.ConstructorConnector>.ValueCollection connectorsValues = DeserializeConnectors(connectors).Values;
                        foreach (Shapes.ConstructorConnector connector in connectorsValues)
                        {
                            
                            foreach(var table in Tables.Values)
                            {
                                foreach(Crainiate.Diagramming.Port port in table.Ports.Values)
                                {
                                    if ((connector.StartPort != null) && (connector.StartPort.Key == port.Key))
                                    {
                                        connector.Start.Port = port;
                                    }
                                    if ((connector.EndPort != null) && (connector.EndPort.Key == port.Key))
                                    {
                                        connector.End.Port = port;
                                    }
                                }
                            }
                            Connectors.Add(connector.Key,connector);
                            this.Model.Lines.Add(connector);
                        }
                        serializedDiagram = serializedDiagram.Substring(delimiter + 1);
                        break;
                }
            }
        }

        /// <summary>
        /// Deserialize constructor diagram connectors from string.
        /// </summary>
        /// <param name="serializedConnestors">Serialized connector</param>
        /// <returns>Diagram connectors</returns>
        private Dictionary<string, Shapes.ConstructorConnector> DeserializeConnectors(string serializedConnestors)
        {
            serializedConnestors = serializedConnestors.Substring(1, serializedConnestors.Length - 2);
            Dictionary<string, Shapes.ConstructorConnector> result = new Dictionary<string, Shapes.ConstructorConnector>();
            while (serializedConnestors.Length > 0)
            {
                int propertySign = serializedConnestors.IndexOf('=');
                string propertyName = serializedConnestors.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedConnestors, propertySign);
                switch (propertyName)
                {
                    case "Connector":
                        Shapes.ConstructorConnector connector = new Shapes.ConstructorConnector();
                        connector.End.Marker = new Crainiate.Diagramming.Arrow();
                        connector.Start.Marker = new Crainiate.Diagramming.Marker(Crainiate.Diagramming.MarkerStyle.Ellipse);
                        connector.DeserializeFromString(serializedConnestors.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        result[connector.Key] = connector;
                        serializedConnestors = serializedConnestors.Substring(delimiter + 1);
                        break;
                }
            }
            return result;
        }

        /// <summary>
        /// Deserialize constructor diagram tables from string.
        /// </summary>
        /// <param name="serializedTables">Serialized tables</param>
        /// <returns>Diagram tables</returns>
        private Dictionary<string, Shapes.ConstructorTable> DeserializeTables(string serializedTables)
        {
            serializedTables = serializedTables.Substring(1, serializedTables.Length - 2);
            Dictionary<string, Shapes.ConstructorTable> result = new Dictionary<string, Shapes.ConstructorTable>();
            while (serializedTables.Length > 0)
            {
                int propertySign = serializedTables.IndexOf('=');
                string propertyName = serializedTables.Substring(0, propertySign);
                int delimiter = Saves.Saves. FindPropertyDelemiter(serializedTables, propertySign);
                switch (propertyName)
                {
                    case "Table":
                        Shapes.ConstructorTable table = new Shapes.ConstructorTable();
                        table.DeserializeFromString(serializedTables.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        result[table.Key] = table;
                        serializedTables = serializedTables.Substring(delimiter + 1);
                        break;
                }
            }
            return result;
        }

       
    }
}
