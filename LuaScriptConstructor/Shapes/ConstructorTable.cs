using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using Crainiate.Diagramming;

namespace LuaScriptConstructor.Shapes
{
    /// <summary>
    /// Constructor table.
    /// </summary>
    class ConstructorTable : Table, Saves.IConstructorSerializable
    {
        private System.Drawing.Image _icon;
        private bool _allowRenew = false;
        public Types.Function _function;

        /// <summary>
        /// Represents exceptions when using a <see cref="ConstructorTable"/> with an unsuitable type.
        /// </summary>
        class InappropriateTableTypeException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the System.Exception class.
            /// </summary>
            public InappropriateTableTypeException() : base() { }

            /// <summary>
            /// Initializes a new instance of the System.Exception class with message.
            /// </summary>
            /// <param name="message">A message describing the error</param>
            public InappropriateTableTypeException(string message) : base(message) { }

            /// <summary>
            /// Initializes a new instance of the System.Exception class with message.
            /// </summary>
            /// <param name="message">An error message indicating the reason for the exception being thrown</param>
            /// <param name="innerException">The exception that threw the current exception, or a null reference (Nothing in VisualBasic) if no inner exception is set</param>
            public InappropriateTableTypeException(string message, Exception innerException) : base(message, innerException) { }


            /// <summary>
            /// Initializes a new instance of the System.Exception class with serialized data.
            /// </summary>
            /// <param name="info">The System.Runtime.Serialization.SerializationInfo object containing the serialized object data about the thrown exception</param>
            /// <param name="context"></param>
            protected InappropriateTableTypeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        }

        /// <summary>
        /// Constructor table types.
        /// </summary>
        public enum ConstructorTableTypes
        {
            Function,
            Variable,
            Constant
        }

        /// <summary>
        /// Table type.
        /// </summary>
        public ConstructorTableTypes Type { get; set; }

        public class TableEventArgs : EventArgs
        {
            /// <summary>
            /// Table.
            /// </summary>
            public ConstructorTable Table { get; protected set; }

            public TableEventArgs(ConstructorTable table)
            {
                Table = table;
            }
        }

        public delegate void TableEvents(object sender, TableEventArgs e);

        public event TableEvents BeforeSzieChanged;

        public event TableEvents SizeChanged;

        public event TableEvents BeforeLocationChanged;

        public event TableEvents LocationChanged;

        /// <summary>
        /// Sets or returns permission to renew a table.
        /// </summary>
        public bool AllowRenew
        {
            get
            {
                return _allowRenew;
            }
            set
            {
                _allowRenew = value;
            }
        }

        /// <summary>
        /// Table function.
        /// </summary>
        public Types.Function Function
        {
            get
            {
                return _function;
            }
            set
            {
                if (_function != null)
                {
                    if (_function.Diagram != null)
                    {
                        try
                        {
                            _function.Diagram.SelectedChanged -= RenewTable;
                        }
                        catch { }
                    }
                }

                _function = value;

                if (_function != null)
                {
                    if (_function.Diagram != null)
                    {
                        try
                        {
                            _function.Diagram.SelectedChanged += RenewTable;
                        }
                        catch { }
                    }
                }
            }
        }

        /// <summary>
        /// Table variable.
        /// </summary>
        public Types.Variable Variable { get; set; }

        /// <summary>
        /// Table constant.
        /// </summary>
        public Types.Constant Constant { get; set; }

        /// <summary>
        /// Table owner.
        /// </summary>
        public Types.Constant Owner
        {
            get
            {
                if (Type == ConstructorTableTypes.Variable)
                {
                    return Variable;
                }
                else if (Type == ConstructorTableTypes.Function)
                {
                    return Function;
                }
                else
                {
                    return Constant;
                }
            }
        }

        /// <summary>
        /// Values of connected inputs;
        /// </summary>
        public Dictionary<string, string> ArgumentsValues { get; set; }

        /// <summary>
        /// Values of connected return;
        /// </summary>
        public Dictionary<string, string> RetrurnsValues { get; set; }

        /// <summary>
        /// Can edit table Heading.
        /// </summary>
        public bool CanEditHeading { get; set; }

        /// <summary>
        /// Table icon.
        /// </summary>
        public System.Drawing.Image Icon
        {
            get
            {
                try
                {
                    return new System.Drawing.Bitmap(_icon);
                }
                catch
                {
                    return new System.Drawing.Bitmap(Properties.Resources.UserFunction_16x);
                }
            }
            set
            {
                _icon = value;
            }
        }

        public override PointF Location
        {
            get
            {
                return base.Location;
            }
            set
            {
                if (BeforeLocationChanged != null)
                {
                    BeforeLocationChanged(this, new TableEventArgs(this));
                }
                base.Location = value;
                if (LocationChanged != null)
                {
                    LocationChanged(this, new TableEventArgs(this));
                }
            }
        }

        /// <summary>
        /// Table size.
        /// </summary>
        public override SizeF Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                var width = value.Width;
                var height = value.Height;

                if (width < MinimumSize.Width)
                {
                    width = MinimumSize.Width;
                }

                if (height < MinimumSize.Height)
                {
                    height = MinimumSize.Height;
                }

                if (BeforeSzieChanged != null)
                {
                    BeforeSzieChanged(this, new TableEventArgs(this));
                }

                base.Size = new SizeF(width, height);

                if (SizeChanged != null)
                {
                    SizeChanged(this, new TableEventArgs(this));
                }
            }
        }

        /// <summary>
        /// Constructor table.
        /// </summary>
        public ConstructorTable() : base() {}

        /// <summary>
        /// Creates a constructor table based on the prototype.
        /// </summary>
        /// <param name="prototype">Prototype</param>
        public ConstructorTable(ConstructorTable prototype) : base(prototype)
        {
            Type = prototype.Type;
            Function = prototype.Function;
            Variable = prototype.Variable;
            Constant = prototype.Constant;
            ArgumentsValues = prototype.ArgumentsValues;
            RetrurnsValues = prototype.RetrurnsValues;
            CanEditHeading = prototype.CanEditHeading;
            Size = prototype.Size;

            Ports.Clear();
            foreach (Port port in prototype.Ports.Values)
            {
                if (port is TablePort)
                {
                    var tablePort = (TablePort)port;
                    TablePort clone = new TablePort(tablePort.TableItem);
                    clone.Direction = tablePort.Direction;
                    clone.Orientation = tablePort.Orientation;
                    clone.Alignment = tablePort.Alignment;
                    clone.Style = tablePort.Style;
                    Ports.Add(port.Key, clone);
                    clone.Location = tablePort.Location;
                }
                else
                {
                    Port clone = (Port)port.Clone();
                    Ports.Add(port.Key, clone);
                }
            }
        }

        /// <summary>
        /// Renew the table according to its function table
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void RenewTable(object sender, EventArgs e)
        {
            if (this.Type != ConstructorTableTypes.Function)
            {
                throw new InappropriateTableTypeException("Renew is only available for function tables.");
            }

            if (!AllowRenew) { return; };

            if (Function.Diagram != null)
            {
                Function.Diagram.Suspend();
            }

            Dictionary<Port, string> portsItem = new Dictionary<Port, string>();
            foreach (Port port in this.Ports.Values)
            {
                if (port is TablePort)
                {
                    portsItem.Add(port, (port as TablePort).TableItem.Text);
                } 
            }

            var prototype = this.Function.Table;
            this.Heading = prototype.Heading;
            this.SubHeading = prototype.SubHeading;
            this.Groups = new TableGroups();
            Table.CopyGroups(prototype.Groups, this.Groups);
            this.Rows = new TableRows();
            Table.CopyRows(prototype.Rows, this.Rows);

            List<string> portsToRemove = new List<string>();

            foreach (string portKey in this.Ports.Keys)
            {
                Port port = this.Ports[portKey];

                if (port is TablePort)
                {
                    if (FindTableItemWithText(portsItem[port], this) != null)
                    {
                        (port as TablePort).TableItem = FindTableItemWithText(portsItem[port], this);
                        ///Fixes a strange error, with a change in the orientation of the port, I do not know where it comes from///
                        port.Orientation = PortOrientation.Left;
                        ///////
                    }
                    else
                    {
                        portsToRemove.Add(portKey);
                    }
                }
            }

            foreach(string portKey in portsToRemove)
            {
                var port = this.Ports[portKey];
                port.Label = new Label("[Port_Removed]");
                this.Ports.Remove(portKey);

            }

            foreach(Port port in prototype.Ports.Values)
            {
                if (port is TablePort)
                {
                    if (!portsItem.ContainsValue((port as TablePort).TableItem.Text))
                    {
                        if (FindTableItemWithText((port as TablePort).TableItem.Text, this) != null)
                        {
                            var newPort = new TablePort(FindTableItemWithText((port as TablePort).TableItem.Text, this));
                            newPort.SetKey(port.Key.Substring(0, port.Key.LastIndexOf('_')) + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                            newPort.Orientation = port.Orientation;
                            newPort.Direction = port.Direction;
                            newPort.Style = port.Style;
                            this.Ports.Add(newPort);
                        }
                    }
                }
            }

            foreach(Port port in this.Ports.Values)
            {
                if (port is TablePort)
                {
                    LocatePort(port);
                }
            }

            if (Function.Diagram != null)
            {
                Function.Diagram.Resume();
            }

        }

        /// <summary>
        /// Serializes a table to a string.
        /// </summary>
        /// <returns>Serialized table</returns>
        public string SerializeToString()
        {
            string result = "{";
            result += "Key=" + Key + ";";
            result += "Heading=∴Heading=>" + Heading + "<=Heading∴;";
            result += "SubHeading=∴SubHeading=>" + SubHeading + "<=SubHeading∴;";
            result += "Type=" + Type + ";";
            result += "CanEditHeading= " + CanEditHeading.ToString() + ";";
            if (Function != null)
            {
                result += "Function=" + Function.Name + ";";
            }
            result += "Size=" + Width + "-" + Height + ";";
            result += "Location=" + Location.X + "-" + Location.Y + ";";
            result += "Groups=" + SerializeGroups(Groups) + ";";
            result += "Rows=" + SerializeRows(Rows) + ";";
            result += "Ports=" + SerializePorts(Ports) + ";";
            result += "}";

            return result;
        }

        /// <summary>
        /// Serializes table groups to string.
        /// </summary>
        /// <param name="groups">TableGroups</param>
        /// <returns>Serialized table groups</returns>
        private string SerializeGroups(TableGroups groups)
        {
            string result = "{";
            foreach(TableGroup group in groups)
            {
                result += "group={";
                result += "Text=∴Text=>" + group.Text + "<=Text∴;";
                result += "Groups=" + SerializeGroups(group.Groups) + ";";
                result += "Rows=" + SerializeRows(group.Rows) + ";";
                result += "};";
            }
            result += "}";

            return result;
        }

        /// <summary>
        /// Serializes table rows to string.
        /// </summary>
        /// <param name="rows">TableRows</param>
        /// <returns>Serialized table rows</returns>
        private string SerializeRows(TableRows rows)
        {
            string result = "{";
            foreach(TableRow row in rows)
            {
                result += "row={";
                result += "Text=∴Text=>" + row.Text + "<=Text∴;";
                result += "};";
            }
            result += "}";

            return result;
        }

        /// <summary>
        /// Serializes ports to string.
        /// </summary>
        /// <param name="ports">Ports</param>
        /// <returns>Serialized ports</returns>
        private string SerializePorts(Ports ports)
        {
            string result = "{";
            foreach(Port port in Ports.Values)
            {
                result += "port={";
                result += "Key=" + port.Key + ";";
                result += "Direction=" + port.Direction + ";";
                result += "Orientation=" + port.Orientation + ";";
                result += "Style=" + port.Style + ";";
                result += "Location=" + port.Location.X + "-" + port.Location.Y + ";";
                if (port is TablePort)
                {
                    var tablePort = port as TablePort;
                    result += "TableItem=" + tablePort.TableItem.Text + ";";
                }
                result += "};";
            }
            result += "}";

            return result;
        }

        /// <summary>
        /// Deserializes a table from a string.
        /// </summary>
        /// <param name="serializedTable">Serialized table</param>
        public void DeserializeFromString(string serializedTable)
        {
            serializedTable = serializedTable.Substring(1, serializedTable.Length - 2);
            while (serializedTable.Length > 0)
            {
                int propertySign = serializedTable.IndexOf('=');
                string propertyName = serializedTable.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedTable, propertySign);
                switch (propertyName)
                {
                    case "Key":
                        this.SetKey(serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "Heading":
                        this.Heading = (serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴Heading=>","").Replace("<=Heading∴",""));
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "SubHeading":
                        this.SubHeading = (serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴SubHeading=>","").Replace("<=SubHeading∴",""));
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "Type":
                        string type = (serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        switch (type)
                        {
                            
                            case "Constant":
                                this.Type = ConstructorTableTypes.Constant;
                                break;
                            case "Function":
                                this.Type = ConstructorTableTypes.Function;
                                break;
                            case "Variable":
                                this.Type = ConstructorTableTypes.Variable;
                                break;
                        }
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "CanEditHeading":
                        this.CanEditHeading = Convert.ToBoolean(serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "Function":
                        this.Function =  new Types.Function(serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "Size":
                        string[] size = (serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)).Split('-'));
                        this.Size = new System.Drawing.SizeF((float)Convert.ToDouble(size[0]), (float)Convert.ToDouble(size[1]));
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "Location":
                        string[] location = (serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)).Split('-'));
                        this.Location = new System.Drawing.PointF((float)Convert.ToDouble(location[0]), (float)Convert.ToDouble(location[1]));
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "Groups":
                        this.Groups = DeserializeGroups(serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "Rows":
                        this.Rows = DeserializeRows(serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;
                    case "Ports":
                        DeserializePorts(serializedTable.Substring(propertySign + 1, delimiter - (propertySign + 1)), this);
                        serializedTable = serializedTable.Substring(delimiter + 1);
                        break;

                }
            }
        }

        /// <summary>
        /// Deserializes table groups from string.
        /// </summary>
        /// <param name="serializedGroups">Serialized groups</param>
        /// <returns>TableGroups</returns>
        private TableGroups DeserializeGroups(string serializedGroups)
        {
            serializedGroups = serializedGroups.Substring(1, serializedGroups.Length - 2);
            TableGroups tableGroups = new TableGroups();

            while (serializedGroups.Length > 0)
            {
                int propertySign = serializedGroups.IndexOf('=');
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedGroups,propertySign);
                tableGroups.Add(DeserializeGroup(serializedGroups.Substring(propertySign + 1, delimiter - (propertySign + 1))));
                serializedGroups = serializedGroups.Substring(delimiter + 1);
            }

            return tableGroups;
        }

        /// <summary>
        /// Deserializes table group from string.
        /// </summary>
        /// <param name="serializedGroup">Serialized group</param>
        /// <returns>TableGroup</returns>
        private TableGroup DeserializeGroup(string serializedGroup)
        {
            serializedGroup = serializedGroup.Substring(1, serializedGroup.Length - 2);
            TableGroup group = new TableGroup();

            while (serializedGroup.Length > 0)
            {
                int propertySign = serializedGroup.IndexOf('=');
                string propertyName = serializedGroup.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedGroup, propertySign);
                switch(propertyName)
                {
                    case "Text":
                        group.Text = (serializedGroup.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴Text=>","").Replace("<=Text∴",""));
                        serializedGroup = serializedGroup.Substring(delimiter + 1);
                        break;
                    case "Groups":
                        group.Groups = DeserializeGroups(serializedGroup.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedGroup = serializedGroup.Substring(delimiter + 1);
                        break;
                    case "Rows":
                        group.Rows = DeserializeRows(serializedGroup.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedGroup = serializedGroup.Substring(delimiter + 1);
                        break;
                }
            }

            return group;
        }

        /// <summary>
        /// Deserializes table rows from string.
        /// </summary>
        /// <param name="serializedRows">Serialized rows</param>
        /// <returns>TableRows</returns>
        private TableRows DeserializeRows(string serializedRows)
        {
            serializedRows = serializedRows.Substring(1, serializedRows.Length - 2);
            TableRows tableRows = new TableRows();

            while (serializedRows.Length > 0)
            {
                int propertySign = serializedRows.IndexOf('=');
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedRows, propertySign);
                tableRows.Add(DeserializeRow(serializedRows.Substring(propertySign + 1, delimiter - (propertySign + 1))));
                serializedRows = serializedRows.Substring(delimiter + 1);
            }

            return tableRows;
        }

        /// <summary>
        /// Deserializes table row from string.
        /// </summary>
        /// <param name="serializedRow">Serialized row</param>
        /// <returns>TableRow</returns>
        private TableRow DeserializeRow(string serializedRow)
        {
            serializedRow = serializedRow.Substring(1, serializedRow.Length - 2);
            TableRow row = new TableRow();

            while (serializedRow.Length > 0)
            {
                int propertySign = serializedRow.IndexOf('=');
                string propertyName = serializedRow.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedRow, propertySign);
                switch (propertyName)
                {
                    case "Text":
                        row.Text = (serializedRow.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴Text=>","").Replace("<=Text∴",""));
                        serializedRow = serializedRow.Substring(delimiter + 1);
                        break;
                }
            }

            return row;
        }

        /// <summary>
        /// Deserializes ports from string.
        /// </summary>
        /// <param name="serializedPorts">Serialized ports</param>
        /// <param name="table">Ports table</param>
        /// <returns>Ports</returns>
        private Ports DeserializePorts(string serializedPorts, ConstructorTable table)
        {
            serializedPorts = serializedPorts.Substring(1, serializedPorts.Length - 2);
            Ports ports = new Ports(table.Model);

            while (serializedPorts.Length > 0)
            {
                int propertySign = serializedPorts.IndexOf('=');
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedPorts, propertySign);
                ports.Add(DeserializePort(serializedPorts.Substring(propertySign + 1, delimiter - (propertySign + 1)), table));
                serializedPorts = serializedPorts.Substring(delimiter + 1);
            }

            table.Ports = ports;
            return ports;
        }

        /// <summary>
        /// Deserializes port from string.
        /// </summary>
        /// <param name="serializedPort">Serialized port</param>
        /// <param name="table">Port table</param>
        /// <returns>Port</returns>
        private Port DeserializePort(string serializedPort, ConstructorTable table)
        {
            serializedPort = serializedPort.Substring(1, serializedPort.Length - 2);
            TablePort port = new TablePort(new TableRow());
            bool isTablePort = false;

            while (serializedPort.Length > 0)
            {
                int propertySign = serializedPort.IndexOf('=');
                string propertyName = serializedPort.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedPort, propertySign);
                switch (propertyName)
                {
                    case "Key":
                        port.SetKey(serializedPort.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedPort = serializedPort.Substring(delimiter + 1);
                        break;
                    case "Direction":
                        string direction = (serializedPort.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        switch (direction)
                        {
                            case "Both":
                                port.Direction = Direction.Both;
                                break;
                            case "In":
                                port.Direction = Direction.In;
                                break;
                            case "None":
                                port.Direction = Direction.None;
                                break;
                            case "Out":
                                port.Direction = Direction.Out;
                                break;
                        }
                        serializedPort = serializedPort.Substring(delimiter + 1);
                        break;
                    case "Orientation":
                        string orientation = (serializedPort.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        switch (orientation)
                        {
                            case "None":
                                port.Orientation = PortOrientation.None;
                                break;
                            case "Right":
                                port.Orientation = PortOrientation.Right;
                                break;
                            case "Top":
                                port.Orientation = PortOrientation.Top;
                                break;
                            case "Bottom":
                                port.Orientation = PortOrientation.Bottom;
                                break;
                            case "Left":
                                port.Orientation = PortOrientation.Left;
                                break;
                        }
                        serializedPort = serializedPort.Substring(delimiter + 1);
                        break;
                    case "Style":
                        string style = (serializedPort.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        switch (style)
                        {
                            case "Default":
                                port.Style = PortStyle.Default;
                                break;
                            case "Input":
                                port.Style = PortStyle.Input;
                                break;
                            case "Output":
                                port.Style = PortStyle.Output;
                                break;
                            case "Simple":
                                port.Style = PortStyle.Simple;
                                break;
                        }
                        serializedPort = serializedPort.Substring(delimiter + 1);
                        break;
                    case "Location":
                        table.Ports.Add(port);
                        string[] location = (serializedPort.Substring(propertySign + 1, delimiter - (propertySign + 1)).Split('-'));
                        port.Location = new System.Drawing.PointF((float)Convert.ToDouble(location[0]), (float)Convert.ToDouble(location[1]));
                        serializedPort = serializedPort.Substring(delimiter + 1);
                        break;
                    case "TableItem":
                        isTablePort = true;
                        string tableItemText = (serializedPort.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        port.TableItem = FindTableItemWithText(tableItemText, table);
                        serializedPort = serializedPort.Substring(delimiter + 1);
                        break;
                }
            }

            if (isTablePort)
            {
                return port;
            }
            else
            {
                Port simplePort = new Port();
                simplePort.SetKey(port.Key);
                simplePort.Direction = port.Direction;
                simplePort.Orientation = port.Orientation;
                simplePort.Style = port.Style;
                table.Ports.Add(simplePort);
                simplePort.Location = port.Location;
                foreach (string key in table.Ports.Keys)
                {
                    if (table.Ports[key] == port)
                    {
                        table.Ports.Remove(key);
                        break;
                    }
                }
                return simplePort;
            }
        }

        /// <summary>
        /// Searches the table for an item with the given text.
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>TableItem or null</returns>
        public TableItem FindTableItemWithText(string text)
        {
            return FindTableItemWithText(text, this);
        }

        /// <summary>
        /// Searches the table for an item with the given text.
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="table">Table</param>
        /// <returns>TableItem or null</returns>
        private static TableItem FindTableItemWithText(string text,Table table)
        {
            TableItem tableItem = null;
            if (table.Groups != null)
            {
                 tableItem = FindTableItemWithText(text, table.Groups);
            }
            if (tableItem == null)
            {
                if (table.Rows != null)
                {
                    foreach (TableRow row in table.Rows)
                    {
                        if (row.Text == text)
                        {
                            return row;
                        }
                    }
                }
            }
            return tableItem;
        }

        /// <summary>
        /// Searches the table groups for an item with the given text.
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="groups">Groups</param>
        /// <returns>TableItem or null</returns>
        private static TableItem FindTableItemWithText(string text, TableGroups groups)
        {
            foreach (TableGroup group in groups)
            {
                if (group.Text == text)
                {
                    return group;
                }

                if (group.Groups != null)
                {
                    TableItem groupsReturn = FindTableItemWithText(text, group.Groups);
                    if (groupsReturn != null)
                    {
                        return groupsReturn;
                    }
                }

                if (group.Rows != null)
                {
                    foreach (TableRow row in group.Rows)
                    {
                        if (row.Text == text)
                        {
                            return row;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Searches the table for a port with a given name, ignoring the unique indicators.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Port</returns>
        public Port FindPortWithName(string name)
        {
            return FindPortWithName(name, this);
        }

        /// <summary>
        /// Searches the table for a port with a given name, ignoring the unique indicators.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="table">Port</param>
        /// <returns>Return</returns>
        private static Port FindPortWithName(string name, Table table)
        {
            foreach(Port port in table.Ports.Values)
            {
                if (name == port.Key.Substring(0, port.Key.LastIndexOf("_"))) { return port; }
            }
            return null;
        }
    }
}
