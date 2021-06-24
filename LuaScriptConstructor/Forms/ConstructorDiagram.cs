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
        string _heading;
        private ConstructorDiagramTypes _type = ConstructorDiagramTypes.None;
        private Mouse mouse;
        private Stack<Snapshot> snapshots = new Stack<Snapshot>();

        /// <summary>
        /// Represents a snapshot record.
        /// </summary>
        public class Snapshot
        {
            /// <summary>
            /// Record name.
            /// </summary>
            public string Name { get; protected set; }

            /// <summary>
            /// Recorded state.
            /// </summary>
            public string State { get; protected set; }

            /// <summary>
            /// Represents a snapshot record.
            /// </summary>
            /// <param name="name">Record name.</param>
            /// <param name="state">Recorded state.</param>
            public Snapshot(string name, string state)
            {
                Name = name;
                State = state;
            }
        }

        /// <summary>
        /// Represents a dialog form for selecting a snapshot.
        /// </summary>
        public class SnapshotsDialog : Form
        {
            /// <summary>
            /// Selected snapshot.
            /// </summary>
            public Snapshot SelectedSnapshot { get; protected set; }

            /// <summary>
            /// Snapshot collection.
            /// </summary>
            public Stack<Snapshot> Snapshots { get; protected set; }

            /// <summary>
            /// Represents a dialog form for selecting a snapshot.
            /// </summary>
            /// <param name="snapshots"></param>
            public SnapshotsDialog(ref Stack<Snapshot> snapshots)
            {
                #region /// Initialization

                Snapshots = snapshots;

                this.Size = new Size(300, 200);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.Icon = Icon.FromHandle(Properties.Resources.ViewSnapshots_16x.GetHicon());

                var btOk = new Button
                {
                    Text = "Restore",
                    FlatStyle = FlatStyle.Popup,
                    Dock = DockStyle.Bottom,
                    Enabled = false,
                    Parent = this,
                    //DialogResult = DialogResult.OK,
                };

                var btCancel = new Button
                {
                    Text = "Cancel",
                    FlatStyle = FlatStyle.Popup,
                    Dock = DockStyle.Bottom,
                    Parent = this,
                    DialogResult = DialogResult.Cancel,
                };

                var lbSnapshots = new ListBox
                {
                    SelectionMode = SelectionMode.One,
                    DrawMode = DrawMode.Normal,
                    BackColor = UserSettings.ColorScheme.SecondaryColor,
                    ForeColor = UserSettings.ColorScheme.ForeColor,
                    Dock = DockStyle.Top,
                    BorderStyle = BorderStyle.None,
                    Height = this.Height - btOk.Height - btCancel.Height,
                    Parent = this
                };
                foreach (Snapshot ss in Snapshots)
                {
                    lbSnapshots.Items.Add(ss.Name);
                }

                #endregion

                #region /// Events

                lbSnapshots.DoubleClick += (s, e) =>
                {
                    if (lbSnapshots.SelectedItem != null)
                    {
                        btOk.PerformClick();
                    }
                };

                lbSnapshots.SelectedIndexChanged += (s, e) =>
                {
                    btOk.Enabled = (lbSnapshots.SelectedItem != null);
                };

                btOk.Click += (s, e) =>
                {
                    foreach (Snapshot ss in Snapshots)
                    {
                        if (ss.Name == (lbSnapshots.SelectedItem as string))
                        {
                            SelectedSnapshot = ss;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                };

                #endregion
            }
        }

        /// <summary>
        /// Storage structure of mouse parameters.
        /// </summary>
        private struct Mouse
        {
            public int X;
            public int Y;
        }

        /// <summary>
        /// Represents a class containing data for a <see cref="ConstructorDiagram"/> events.
        /// </summary>
        public class DiagramEventArgs : EventArgs
        {
            /// <summary>
            /// Diagram.
            /// </summary>
            public ConstructorDiagram Diagram { get; protected set; }

            public DiagramEventArgs(ConstructorDiagram diagram)
            {
                Diagram = diagram;
            }
        }

        /// <summary>
        /// Represents a method that handles <see cref="DiagramTypeChanged"/>, <see cref="OnTakeSnapshot"/> and <see cref="OnSnapshotRestored"/> events.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public delegate void ConstructorDiagramEvent(object sender, DiagramEventArgs e);

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
        /// Occurs when heading changed. 
        /// </summary>
        public event ConstructorDiagramEvent HeadingChanged;

        /// <summary>
        /// Occurs when a snapshot is loaded.
        /// </summary>
        public event ConstructorDiagramEvent OnTakeSnapshot;

        /// <summary>
        /// Occurs when redo is executed.
        /// </summary>
        public event ConstructorDiagramEvent OnSnapshotRestored;

        /// <summary>
        /// Occurs when the type is changed.
        /// </summary>
        public event ConstructorDiagramEvent DiagramTypeChanged;

        /// <summary>
        /// Diagram type.
        /// </summary>
        public ConstructorDiagramTypes Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value != _type)
                {

                    this.Clear();
                    Connectors.Clear();
                    Tables.Clear();
                    _type = value;

                    if (_type == ConstructorDiagramTypes.Main)
                    {
                        var mainTable = new Shapes.ConstructorTable(Components.ScriptСomponents.Functions["Main"].Table);
                        Model.Shapes.Add(mainTable);
                        Tables[mainTable.Key].Location = new PointF(200, 10);
                        Tables[mainTable.Key].Width = Tables[mainTable.Key].Width + 6;

                        var initTable = new Shapes.ConstructorTable(Components.ScriptСomponents.Functions["Init"].Table);
                        Model.Shapes.Add(initTable);
                        Tables[initTable.Key].Location = new PointF(50, 10);
                    }
                    else if (_type == ConstructorDiagramTypes.Regular)
                    {
                        var functionStartTable = new Shapes.ConstructorTable(Components.ScriptСomponents.Functions["Function start"].Table);
                        functionStartTable.Heading = this.Heading;
                        Model.Shapes.Add(functionStartTable);
                        Tables[functionStartTable.Key].Location = new PointF(200, 10);
                    }

                    if (DiagramTypeChanged != null)
                    {
                        DiagramTypeChanged(this, new DiagramEventArgs(this));
                    }
                }
            }
        }

        /// <summary>
        /// Diagram heading.
        /// </summary>
        public string Heading
        {
            get
            {
                return _heading;
            }
            set
            {
                _heading = value;
                if (HeadingChanged != null)
                {
                    HeadingChanged(this, new DiagramEventArgs(this));
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

            var cmsMenu = new ContextMenuStrip() { BackColor = UserSettings.ColorScheme.MainColor, ForeColor = UserSettings.ColorScheme.MainColor, Renderer = new Forms.Rendering.ConstructorMenuStripRender()};
            var tsmiConnector = new ToolStripMenuItem
            {
                Text = "Add connector",
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Image = Properties.Resources.Connector_16x
            };
            tsmiConnector.Click += (s, e) =>
            {
                Shapes.ConstructorConnector connector = new Shapes.ConstructorConnector();
                connector.Start.Location = new PointF(mouse.X - 25, mouse.Y - 25);
                connector.End.Location = new PointF(mouse.X + 25, mouse.Y + 25); //300,140
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
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
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
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                ShortcutKeyDisplayString = "Shift+F6",
                ShortcutKeys = Keys.Shift | Keys.F6
            };
            tsmiBuild.Click += (s, e) => { Build(); };
            cmsMenu.Items.Add(tsmiBuild);

            var tsmiDelete = new ToolStripMenuItem
            {
                Text = "Delete",
                Image = Properties.Resources.DeleteTable_16x,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Visible = false,
                ShortcutKeyDisplayString = "Delete",
                ShortcutKeys = Keys.Delete
            };
            tsmiDelete.Click += (s, e) =>
            {
                DeleteElements();   
            };
            cmsMenu.Items.Add(tsmiDelete);

            if (Program.DeveloperMode)
            {
                var tsmiSave = new ToolStripMenuItem
                {
                    Text = "[Developer mode] Save graph...",
                    Image = Properties.Resources.Save_16x,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    ForeColor = UserSettings.ColorScheme.ForeColor,
                };
                tsmiSave.Click += (s, e) =>
                {
                    using (var sfd = new SaveFileDialog())
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            System.IO.File.WriteAllText(sfd.FileName, this.SerializeToString());
                        }
                    }
                };
                cmsMenu.Items.Add(tsmiSave);
            }

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
                    DeleteElements();
                }

            };

            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    bool edit = false;
                    bool delete = false;

                    if (Model.SelectedShapes().Count == 1)
                    {
                        
                        foreach (var shape in Model.SelectedShapes().Values)
                        {
                            if (shape is Shapes.ConstructorTable)
                            {
                                var table = shape as Shapes.ConstructorTable;

                                if ((table.CanEditHeading))
                                {
                                    edit = true;
                                }

                            }
                        }
                    }

                    if (Model.SelectedElements().Count > 0)
                    {
                        delete = true;
                        if ((Model.SelectedElements().Count == 1) && (Model.SelectedShapes().Count == 1))
                        {
                            foreach(var shape in Model.SelectedShapes().Values)
                            {
                                foreach (var scriptComponent in Components.ScriptСomponents.Functions.Values)
                                {
                                    try
                                    {
                                        if ((shape as Shapes.ConstructorTable).Function.Prefix == scriptComponent.Prefix)
                                        {
                                            delete = false;
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        
                    }

                    tsmiEdit.Visible = edit;
                    tsmiDelete.Visible = delete;
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

            var textBox = new System.Windows.Forms.TextBox
            {
                Text = table.Heading,
                Left = (int)(table.X - (this.Parent as DiagramTabPage).HorizontalScroll.Value + 4),
                Top = (int)(table.Y - (this.Parent as DiagramTabPage).VerticalScroll.Value + 6),
                Width = (int)table.Width - 8,
                BackColor = table.BackColor,
                ForeColor = table.Forecolor,
                BorderStyle = BorderStyle.None,
                Font = new Font("Consolas", 17,FontStyle.Regular),
                Parent = this.Parent

            };
            textBox.BringToFront();

            //this.Refresh();

            textBox.TextChanged += (s, e) =>
            {
                table.Heading = textBox.Text;

                // If this is a function start table, then rename the title along with it.
                if (table.Type == Shapes.ConstructorTable.ConstructorTableTypes.Function)
                {
                    if (table.Function.Prefix == Components.ScriptСomponents.Functions["Function start"].Prefix)
                    {
                        Heading = table.Heading;
                    }
                }

                //this.Refresh();
            };
            textBox.LostFocus += (s, e) =>
            {
                this.Refresh();
                textBox.Dispose();
                textBox = null;
            };

            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
            textBox.SelectionLength = 0;
        }

        /// <summary>
        /// Build function.
        /// </summary>
        public virtual void Build()
        {
            var function = new Types.Function(this.Parent.Text.Replace(" ","_"), ((this.Type == ConstructorDiagramTypes.Regular) ? Types.Function.FuntionTypes.Regular 
                : ((this.Type == ConstructorDiagramTypes.Main) ? Types.Function.FuntionTypes.Main : Types.Function.FuntionTypes.Regular)));
            function.AccessType = Types.Variable.VariableAccessTypes.InputOutput;
            function.Description = "User function";
            function.Build(this);
            //var form = (frMain)this.ParentForm;
            //form.ProjectFunctions[this.Parent.Text.Replace(" ", "_")] = function;
            //form.RefreshProjectFunction();
        }

        /// <summary>
        /// Takes a snapshot of the current state of the diagram.
        /// </summary>
        public virtual void TakeSnapshot()
        {
            snapshots.Push(new Snapshot(DateTime.Now.ToString(), SerializeToString()));
            if (OnTakeSnapshot != null)
            {
                OnTakeSnapshot(this, new DiagramEventArgs(this));
            }
        }

        /// <summary>
        /// Restores state to the last recorded snapshot.
        /// </summary>
        public virtual void RestoreLastSnapshot()
        {
           if (snapshots.Count > 0)
            {
                Snapshot snapshot = snapshots.Pop();
                snapshots.Push(snapshot);
                DeserializeFromString(snapshot.State);
                if (OnSnapshotRestored != null)
                {
                    OnSnapshotRestored(this, new DiagramEventArgs(this));
                }
            }
        }

        /// <summary>
        /// Calls a dialog with a list of snapshots and then restores the state of the selected.
        /// </summary>
        public virtual void RestoreSnapshot()
        {
            using (SnapshotsDialog snapshotsDialog = new SnapshotsDialog(ref snapshots) 
                { Text = "Restore snapshot", BackColor = UserSettings.ColorScheme.MainColor, ForeColor = UserSettings.ColorScheme.ForeColor})
            {
                if (snapshotsDialog.ShowDialog() == DialogResult.OK)
                {
                    DeserializeFromString(snapshotsDialog.SelectedSnapshot.State);
                    if (OnSnapshotRestored != null)
                    {
                        OnSnapshotRestored(this, new DiagramEventArgs(this));
                    }
                }
            }
        }

        /// <summary>
        /// Removes the elements selected in the diagram.
        /// </summary>
        private void DeleteElements()
        {

            if (this.Model.SelectedElements() != null)
            {
                foreach (var element in this.Model.SelectedElements().Values)
                {

                    if (element is Shapes.ConstructorConnector)
                    {
                        try
                        {
                            foreach (string key in this.Model.Lines.Keys)
                            {
                                if (this.Model.Lines[key] == element)
                                {
                                    this.Model.Lines.Remove(key);
                                    break;
                                }
                            }

                            foreach (string key in this.Connectors.Keys)
                            {
                                if (this.Connectors[key] == element)
                                {
                                    this.Connectors.Remove(key);
                                    break;
                                }
                            }
                        }
                        catch { }
                    }
                    else if (element is Shapes.ConstructorTable)
                    {
                        bool script = false;
                        foreach (var scriptComponent in Components.ScriptСomponents.Functions.Values)
                        {
                            try
                            {
                                if ((element as Shapes.ConstructorTable).Function.Prefix == scriptComponent.Prefix)
                                {
                                    script = true;
                                    break;
                                }
                            }
                            catch { }
                        }
                        if (script) { continue; };

                        try
                        {

                            foreach (string key in this.Model.Shapes.Keys)
                            {
                                if (this.Model.Shapes[key] == element)
                                {
                                    this.Model.Shapes.Remove(key);
                                    break;
                                }
                            }

                            foreach (string key in this.Tables.Keys)
                            {
                                if (this.Tables[key] == element)
                                {
                                    this.Tables.Remove(key);
                                    break;
                                }
                            }

                        }
                        catch { }
                    }

                }
                this.Refresh();
            }
        }

        /// <summary>
        /// On insert new element.
        /// </summary>
        /// <param name="element">Element</param>
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
                        var ownerTable = ((Types.Function)table.Owner).Table;
                        table.BackColor = ownerTable.BackColor;
                        table.GradientColor = ownerTable.GradientColor;
                        table.MinimumSize = ownerTable.MinimumSize;
                        table.Size = ownerTable.Size;
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
                        table.Forecolor = ((Types.Variable)table.Owner).Table.Forecolor;
                        table.BorderColor = table.Forecolor;
                    }
                    catch
                    {
                        table.BackColor = new Types.Variable().Table.BackColor;
                        table.GradientColor = new Types.Variable().Table.GradientColor;
                        table.Forecolor = new Types.Variable().Table.Forecolor;
                        table.BorderColor = table.Forecolor;
                    }
                }
                else
                {
                    try
                    {
                        table.BackColor = table.Owner.Table.BackColor;
                        table.GradientColor = table.Owner.Table.GradientColor;
                        table.Forecolor = table.Owner.Table.Forecolor;
                        table.BorderColor = table.Forecolor;
                    }
                    catch
                    {
                        table.BackColor = new Types.Constant().Table.BackColor;
                        table.GradientColor = new Types.Constant().Table.GradientColor;
                        table.Forecolor = new Types.Constant().Table.Forecolor;
                        table.BorderColor = table.Forecolor;
                    }
                }
                var elementList = new Crainiate.Diagramming.ElementList(true);
                elementList.Add(element);
                AlignElementLocations(elementList);
            }
            base.OnElementInserted(element);
        }

        /// <summary>
        /// Serialize constructor diagram to string.
        /// </summary>
        /// <returns>Serialized string</returns>
        public string SerializeToString()
        {
            string result = "{";
            result += "Heading=∴Heading=>" + Heading + "<=Heading∴;";
            result += "Type=" + Type + ";";
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
            this.Tables.Clear();
            this.Connectors.Clear();
            this.Model.Clear();

            serializedDiagram = serializedDiagram.Substring(1, serializedDiagram.Length - 2);
            while (serializedDiagram.Length > 0)
            {
                int propertySign = serializedDiagram.IndexOf('=');
                string propertyName = serializedDiagram.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedDiagram, propertySign);
                switch (propertyName)
                {
                    case "Heading":
                        this.Heading = (serializedDiagram.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴Heading=>", "").Replace("<=Heading∴", ""));
                        serializedDiagram = serializedDiagram.Substring(delimiter + 1);
                        break;
                    case "Type":
                        string typeString = (serializedDiagram.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        switch (typeString)
                        {
                            case "Main":
                                _type = ConstructorDiagramTypes.Main;
                                break;
                            case "None":
                                _type = ConstructorDiagramTypes.None;
                                break;
                            case "Regular":
                                _type = ConstructorDiagramTypes.Regular;
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

                            foreach (var table in Tables.Values)
                            {
                                foreach (Crainiate.Diagramming.Port port in table.Ports.Values)
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
                            Connectors.Add(connector.Key, connector);
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
