using System;
using System.Collections.Generic;

namespace LuaScriptConstructor.Types
{
    /// <summary>
    /// Represents a constant type class for a script constructor.
    /// </summary>
    class Function : Variable, Saves.IConstructorSerializable
    {
        private int unicBuildCounter = 10;

        /// <summary>
        /// Structure of writing connectors when building a function code
        /// </summary>
        private struct codeConnector
        {
            public string StartShape;
            public string StartPort;
            public string EndShape;
            public string EndPort;
        }

        /// <summary>
        /// Function table code filling types.
        /// </summary>
        private enum fillTableTypes
        {
            Function,
            Return,
            SetVariable,
            IfWhile
        }

        /// <summary>
        /// Represents a class containing data for a <see cref="BuildSuccess"/> and <see cref="BuildError"/> event.
        /// </summary>
        public class FunctionBuildEventArgs : EventArgs
        {
            /// <summary>
            /// Build warnings.
            /// </summary>
            public List<string> Warnings { get; protected set; }

            /// <summary>
            /// Build error.
            /// </summary>
            public Exception Error { get; protected set; }

            /// <summary>
            /// Represents a class containing data for a <see cref="BuildSuccess"/> and <see cref="BuildError"/> event.
            /// </summary>
            /// <param name="error">Build error</param>
            public FunctionBuildEventArgs(Exception error) { Error = error; Warnings = new List<string>(); }

            /// <summary>
            /// Represents a class containing data for a <see cref="BuildSuccess"/> and <see cref="BuildError"/> event.
            /// </summary>
            /// <param name="warnings">Build warnings</param>
            public FunctionBuildEventArgs(List<string> warnings) { Warnings = warnings; Error = null; }

            /// <summary>
            /// Represents a class containing data for a <see cref="BuildSuccess"/> and <see cref="BuildError"/> event.
            /// </summary>
            /// <param name="error">Build error</param>
            /// <param name="warnings">Build warnings</param>
            public FunctionBuildEventArgs(Exception error, List<string> warnings) { Error = error; Warnings = warnings; }

        }

        /// <summary>
        /// Represents a method that handles <see cref="BuildSuccess"/> and <see cref="BuildError"/> events.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public delegate void FunctionBuildEvents(object sender, FunctionBuildEventArgs e);

        /// <summary>
        /// Fires during table rebuild.
        /// </summary>
        public override event RebuildTableEvents TableRebuilding;

        /// <summary>
        /// Lua function types.
        /// </summary>
        public enum FuntionTypes
        {
            Main,
            Init,
            Regular
        }
        
        /// <summary>
        /// Funtion type.
        /// </summary>
        public FuntionTypes Type { get; protected set; }

        /// <summary>
        /// Function description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Function argument list.
        /// </summary>
        public List<string> Arguments { get; protected set; }

        /// <summary>
        /// Function return list.
        /// </summary>
        public List<string> Returns { get; protected set; }

        /// <summary>
        /// Function diagram.
        /// </summary>
        public virtual Forms.ConstructorDiagram Diagram { get; set; }

        /// <summary>
        /// Funtion table.
        /// </summary>
        new public virtual Shapes.ConstructorTable Table
        {
            get
            {
                if (this is ProgrammaticallyDefinedFunction)
                {
                    return (this as ProgrammaticallyDefinedFunction).Table;
                }
                
                List<string> warnings = new List<string>();
                Shapes.ConstructorTable table = BuildTable(Diagram, ref warnings);
                try
                {
                    TableRebuilding(this, new RebuildEventArgs(ref table));
                }
                catch (NullReferenceException) { }
                return table;
            }
        }

        /// <summary>
        /// Function code.
        /// </summary>
        public virtual string Code { get; protected set; }

        /// <summary>
        /// Function value.
        /// </summary>
        public override string Value
        {
            get
            {
                return Name;
            }
        }

        /// <summary>
        /// Function value interaction type.
        /// </summary>
        public override ValueInteractionTypes InteractionType
        {
            get
            {
                return ValueInteractionTypes.GetSet;
            }
        }

        /// <summary>
        /// Occurs when the assembly of the function is complete.
        /// </summary>
        public FunctionBuildEvents BuildSuccess;

        /// <summary>
        /// Occurs when the assembly of a function fails.
        /// </summary>
        public FunctionBuildEvents BuildError;

        /// <summary>
        /// Represents a constant type class for a script constructor.
        /// </summary>
        protected Function()
        {
        }

        /// <summary>
        /// Represents a constant type class for a script constructor.
        /// </summary>
        /// <param name="name">Function name</param>
        public Function(string name) : this(name, FuntionTypes.Regular) { }

        /// <summary>
        /// Represents a constant type class for a script constructor.
        /// </summary>
        /// <param name="name">Function name</param>
        /// <param name="type">Function type</param>
        public Function(string name, FuntionTypes type)
        {
            Name = name;
            Type = type;
            Arguments = new List<string>();
            Returns = new List<string>();       
            BuildSuccess += (object s, FunctionBuildEventArgs e) => 
            {
               foreach (string warning in e.Warnings)
                {
                    frMain.ConsoleWarning(warning);
                }
                frMain.ConsoleMessage("Build successful: ", System.Drawing.Color.LimeGreen);
                frMain.ConsoleMessage("0 errors ", System.Drawing.Color.Red, false);
                frMain.ConsoleMessage(e.Warnings.Count.ToString() + " warnings", System.Drawing.Color.Gold, false);
                frMain.ConsoleMessage("\n", System.Drawing.Color.Black, false);
            };
            BuildError += (object s, FunctionBuildEventArgs e) =>
            {
                foreach (string warning in e.Warnings)
                {
                    frMain.ConsoleWarning(warning);
                }
                frMain.ConsoleError(e.Error.Message);
                frMain.ConsoleMessage("Build failed: ", System.Drawing.Color.DarkRed);
                frMain.ConsoleMessage("1 error ", System.Drawing.Color.Red, false);
                frMain.ConsoleMessage(e.Warnings.Count.ToString() + " warnings", System.Drawing.Color.Gold, false);
                frMain.ConsoleMessage("\n", System.Drawing.Color.Black, false);
            };
            TableRebuilding += (s, e) => { };
        }

        /// <summary>
        /// Build function.
        /// </summary>
        /// <param name="diagram">Function</param>
        /// <returns><Build success/returns>
        public bool Build(Forms.ConstructorDiagram diagram)
        {
            frMain.ConsoleMessage("Building \"", System.Drawing.Color.LimeGreen);
            frMain.ConsoleMessage(this.Name, System.Drawing.Color.Green, false);
            frMain.ConsoleMessage("\" function...\n", System.Drawing.Color.LimeGreen, false);

            List<string> warnings = new List<string>();

            try
            {
                if (this.Type == FuntionTypes.Regular)
                {
                    BuildTable(diagram, ref warnings);
                    this.Code = BuildCode(diagram, ref warnings);
                }
                else
                {
                    string init = BuildCode(diagram, ref warnings, FuntionTypes.Init);
                    this.Code = init + "\n\n\n" + BuildCode(diagram, ref warnings, FuntionTypes.Main);
                }
            }
            catch (Exception e)
            {
                BuildError(this, new FunctionBuildEventArgs(e, warnings));
                foreach (Shapes.ConstructorTable table in diagram.Tables.Values)
                {
                    table.ArgumentsValues = null;
                    table.RetrurnsValues = null;
                }
                return false;
            }

            BuildSuccess(this, new FunctionBuildEventArgs(warnings));
            return true;
        }

        /// <summary>
        /// Build function table.
        /// </summary>
        /// <param name="diagram">Function diagramm</param>
        /// <param name="warnings">Warnings list</param>
        /// <returns>Function table</returns>
        protected Shapes.ConstructorTable BuildTable(Forms.ConstructorDiagram diagram, ref List<string> warnings)
        {
            Arguments = new List<string>();
            Returns = new List<string>();
            List<string> IgnoreList = new List<string>();

            Shapes.ConstructorTable table = new Shapes.ConstructorTable
            {
                Heading = Name,
                SubHeading = Description,
                BackColor = UserSettings.ColorScheme.MainColor,
                GradientColor = UserSettings.ColorScheme.MainColor,
                Forecolor = UserSettings.ColorScheme.ForeColor,
                BorderColor = UserSettings.ColorScheme.ForeColor,
                Label = new Crainiate.Diagramming.Label(Name.Replace("_", " ")),
                Type = Shapes.ConstructorTable.ConstructorTableTypes.Function,
                Size = new System.Drawing.SizeF(100f, 100f),
                Icon = Properties.Resources.UserFunction_16x,
                Function = this
            };
            table.SetKey(Prefix + "_" + Name + "_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());

            if ((AccessType == VariableAccessTypes.Input) || (AccessType == VariableAccessTypes.InputOutput))
            {
                var input = new Crainiate.Diagramming.Port
                {
                    Direction = Crainiate.Diagramming.Direction.In,
                    Orientation = Crainiate.Diagramming.PortOrientation.Top,
                    Style = Crainiate.Diagramming.PortStyle.Default,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                    AllowMove = false,
                };
                input.SetKey("input_" + Prefix + "_" + Name + "_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                table.Ports.Add(input);
            }

            if ((AccessType == VariableAccessTypes.Output) || (AccessType == VariableAccessTypes.InputOutput))
            {
                var output = new Crainiate.Diagramming.Port
                {
                    Direction = Crainiate.Diagramming.Direction.Out,
                    Orientation = Crainiate.Diagramming.PortOrientation.Bottom,
                    Style = Crainiate.Diagramming.PortStyle.Default,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                    AllowMove = false,
                };
                output.SetKey("output_" + Prefix + "_" + Name + "_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                table.Ports.Add(output);
            }

            foreach (Shapes.ConstructorConnector connector in diagram.Connectors.Values)
            {
                try
                {
                    if (connector.StartPort.Key.Contains("functionargument"))
                    {
                        if (!IgnoreList.Contains(connector.StartPort.Key))
                        {
                            if (connector.Start.DockedElement is Shapes.ConstructorTable)
                            {
                                Arguments.Add("argument-"
                                    + ((Shapes.ConstructorTable)connector.Start.DockedElement).Heading
                                    + "_" + (Arguments.Count + 1).ToString());
                                IgnoreList.Add(connector.StartPort.Key);
                            }
                        }

                    }
                }
                catch (System.NullReferenceException)
                {
                    warnings.Add("Connector start is not connected to port!");
                }

                try
                {
                    if (connector.EndPort.Key.Contains("functionreturn"))
                    {
                            if (connector.End.DockedElement is Shapes.ConstructorTable)
                            {
                                Returns.Add("return-"
                                    + ((Shapes.ConstructorTable)connector.End.DockedElement).Heading
                                    + "_ " + (Returns.Count + 1).ToString());
                            }

                    }
                }
                catch (System.NullReferenceException)
                {
                    warnings.Add("Connector end is not connected to port!");
                }
            }

            Crainiate.Diagramming.TableGroup arguments = new Crainiate.Diagramming.TableGroup("Arguments") { Forecolor = UserSettings.ColorScheme.ForeColor};

            foreach (var argument in Arguments)
            {
                Crainiate.Diagramming.TableRow row = new Crainiate.Diagramming.TableRow(argument.Replace("argument-", "").Replace("_", " ")) 
                    { Backcolor = table.BackColor, Forecolor = UserSettings.ColorScheme.ForeColor };
                Crainiate.Diagramming.TablePort port = new Crainiate.Diagramming.TablePort(row)
                {
                    Orientation = Crainiate.Diagramming.PortOrientation.Left,
                    Direction = Crainiate.Diagramming.Direction.In,
                    Style = Crainiate.Diagramming.PortStyle.Input,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                };
                port.SetKey(argument + "_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                arguments.Rows.Add(row);
                table.Ports.Add(port);
            }
            table.Groups.Add(arguments);

            Crainiate.Diagramming.TableGroup returns = new Crainiate.Diagramming.TableGroup("Returns") { Forecolor = UserSettings.ColorScheme.ForeColor };

            foreach (var @return in Returns)
            {
                Crainiate.Diagramming.TableRow row = new Crainiate.Diagramming.TableRow(@return.Replace("return-", "").Replace("_", " ")) 
                    { Backcolor = table.BackColor, Forecolor = UserSettings.ColorScheme.ForeColor };
                Crainiate.Diagramming.TablePort port = new Crainiate.Diagramming.TablePort(row)
                {
                    Orientation = Crainiate.Diagramming.PortOrientation.Left,
                    Direction = Crainiate.Diagramming.Direction.Out,
                    Style = Crainiate.Diagramming.PortStyle.Output,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                };
                port.SetKey(@return + "_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                returns.Rows.Add(row);
                table.Ports.Add(port);
            }
            table.Groups.Add(returns);

            return table;
        }

        /// <summary>
        /// Build function code
        /// </summary>
        /// <param name="diagram">Function diagram</param>
        /// <param name="warnings">Warrnings list</param>
        /// <param name="type">Function type</param>
        /// <returns>Function code</returns>
        protected string BuildCode(Forms.ConstructorDiagram diagram, ref List<string> warnings, FuntionTypes type = FuntionTypes.Regular)
        {

            string code = "";

            // Function header
            if (type == FuntionTypes.Regular)
            {
                code += "function " + Name + "(e,";

                foreach (string arg in Arguments)
                {
                    code += arg.Replace("argument-", "").Substring(0, arg.Replace("argument-", "").LastIndexOf("_")) + ",";
                }

                if (Arguments.Count > 0)
                {
                    code = code.Substring(0, code.Length - 1);
                }

                code += ")\n";
            }
            else if (type == FuntionTypes.Init)
            {
                code += "function " + Name.ToLower() + "_init_name(e, name)\n";
            }
            else if (type == FuntionTypes.Main)
            {
                code += "function " + Name.ToLower() + "_main(e)\n";
            }

            List<codeConnector> codeConnectors = new List<codeConnector>();

            // Fill connectors list
            foreach (Shapes.ConstructorConnector connector in diagram.Connectors.Values)
            {
                var codeConnector = new codeConnector();
                if (connector.StartPort != null)
                {
                    codeConnector.StartPort = connector.StartPort.ToString();
                    codeConnector.StartShape = (connector.StartPort.Parent as Crainiate.Diagramming.Shape).ToString(); ;
                }
                
                if (connector.EndPort != null)
                {
                    codeConnector.EndPort = connector.EndPort.ToString();
                    codeConnector.EndShape = (connector.EndPort.Parent as Crainiate.Diagramming.Shape).ToString();
                }

                codeConnectors.Add(codeConnector);
            }

            // Search start function
            Shapes.ConstructorTable currentTable = null;
            foreach(codeConnector codeConnector in codeConnectors)
            {
                if (codeConnector.StartPort != null)
                {
                    string startPort = "startoutput_";

                    if (type == FuntionTypes.Main)
                    {
                        startPort = "mainoutput_";
                    }
                    else if (type == FuntionTypes.Init)
                    {
                        startPort = "initoutput_";
                    }
                    if (codeConnector.StartPort.Contains(startPort))
                    {
                        currentTable = diagram.Tables[codeConnector.EndShape];
                        break;
                    }
                }
            }
            if (currentTable == null)
            {
                if (type != FuntionTypes.Init)
                {
                    throw new Exception("Failed to locate the beginning of the function. Possibly the function table is not connected to the connector.");
                }
                else
                {
                    code += "end\n";
                    return code;
                }
            }

            // Iterate function sequence
            while (currentTable != null)
            {
                if ((currentTable.ArgumentsValues != null) && (currentTable.RetrurnsValues != null))
                {
                    throw new Exception("Incorrect function call order detected.");
                }
                FillTable(diagram, ref warnings, ref currentTable, ref code, codeConnectors, GetFillType(currentTable.Function.Prefix));


                bool found = false;
                foreach (Crainiate.Diagramming.Port port in currentTable.Ports.Values)
                {
                    if (port.Key.Contains("output_"))
                    {
                        foreach (codeConnector codeConnector in codeConnectors)
                        {
                            if (codeConnector.StartPort == port.ToString())
                            {
                                
                                try
                                {
                                    found = true;
                                    currentTable = diagram.Tables[codeConnector.EndShape];
                                    break;
                                }
                                catch
                                {
                                    found = false;
                                    currentTable = null;
                                }
                            }
                        }
                    }
                }

                if (!found)
                {
                    break;
                }
                
            }

            // Print function returns
            code += "return ";
            bool comma = false;
            foreach (codeConnector codeConnector in codeConnectors)
            {
                if (codeConnector.EndPort.Contains("functionreturn"))
                {
                    Shapes.ConstructorTable returnTable = diagram.Tables[codeConnector.EndShape];
                    if (comma) { code += ","; }
                    FillTable(diagram, ref warnings, ref returnTable, ref code, codeConnectors, fillTableTypes.Return);
                    comma = true;
                }
            }

            code += "\nend\n";

            foreach(Shapes.ConstructorTable table in diagram.Tables.Values)
            {
                table.ArgumentsValues = null;
                table.RetrurnsValues = null;
            }

            return code;

        }

        /// <summary>
        /// Fill table code.
        /// </summary>
        /// <param name="diagram">Function diagram</param>
        /// <param name="warnings">Warnings list</param>
        /// <param name="table">Table</param>
        /// <param name="code">Code</param>
        /// <param name="codeConnectors">Diagramm connectors list</param>
        /// <param name="fillType">Fill type</param>
        private void FillTable(Forms.ConstructorDiagram diagram, ref List<string> warnings, ref Shapes.ConstructorTable table, ref string code, List<codeConnector> codeConnectors, fillTableTypes fillType = fillTableTypes.Function)
        {
            table.ArgumentsValues = new Dictionary<string, string>();
            table.RetrurnsValues = new Dictionary<string, string>();

            // Iterate ports
            foreach (Crainiate.Diagramming.Port port in table.Ports.Values)
            {
                // Arguments ports
                if (port.Key.Contains("argument"))
                {
                    Shapes.ConstructorTable argumentTable = null;
                    string returnConnector = "";

                    // Search connected to argument table
                    foreach(codeConnector codeConnector in codeConnectors)
                    {
                        if (codeConnector.EndPort == port.ToString())
                        {
                            if (!diagram.Tables.ContainsKey(codeConnector.StartShape))
                            {
                                throw new Exception("A connector that does not lead to a value is connected to the argument of the " + table.Heading + " function.");
                            }
                            argumentTable = diagram.Tables[codeConnector.StartShape];
                            returnConnector = codeConnector.StartPort;
                            break;
                        }
                    }
                    if (argumentTable == null)
                    {
                        continue;
                    }

                    // If argument connected to function
                    if (argumentTable.Type == Shapes.ConstructorTable.ConstructorTableTypes.Function)
                    {
                        // If connectet to argument table not filled, fill it.
                        if (argumentTable.RetrurnsValues == null)
                        {
                            FillTable(diagram, ref warnings, ref argumentTable, ref code, codeConnectors);
                        }

                        table.ArgumentsValues[port.Key] = argumentTable.RetrurnsValues[returnConnector];
                    }
                    else
                    {
                        table.ArgumentsValues[port.Key] = argumentTable.Heading;
                    }
                }

                // Return ports
                if (port.Key.Contains("return"))
                {
                    foreach(codeConnector codeConnector in codeConnectors)
                    {
                        // If port has connected connector, create return variable.
                        if (codeConnector.StartPort == port.ToString())
                        {
                            table.RetrurnsValues[port.ToString()] = table.Function.Identifier.Replace(".","") + "_return_" + Math.Abs(DateTime.Now.GetHashCode()).ToString() + unicBuildCounter.ToString("X4");
                            unicBuildCounter++;
                        }
                    }
                }
            }

            // Print code as "return = function(arguments)"
            if (fillType == fillTableTypes.Function)
            {
                if (table.RetrurnsValues.Count > 0)
                {
                    code += "local ";
                    bool сomma = false;
                    foreach(Crainiate.Diagramming.Port port in table.Ports.Values)
                    {
                        if (port.Key.Contains("return"))
                        {
                            if (сomma) { code += ","; }
                            if (table.RetrurnsValues.ContainsKey(port.ToString()))
                            {
                                code += table.RetrurnsValues[port.ToString()];
                            }
                            else
                            {
                                code += "_";
                            }
                            сomma = true;
                        }
                    }
                    //foreach (string @return in table.RetrurnsValues.Values)
                    //{
                    //    if (сomma) { code += ","; }
                    //    code += @return;
                    //    сomma = true;
                    //}
                    code += " = ";
                }

                code += table.Function.Identifier + "(e";

                if (table.ArgumentsValues.Count > 0)
                {
                    foreach (string argument in table.ArgumentsValues.Values)
                    {
                        code += ","; 
                        code += argument;
                    }
                }

                code += ")\n";
            }
            // Print code as "arguments"
            else if (fillType == fillTableTypes.Return)
            {
                if (table.ArgumentsValues.Count > 0)
                {
                    bool сomma = false;
                    foreach (string argument in table.ArgumentsValues.Values)
                    {
                        if (сomma) { code += ","; }
                        code += argument;
                        сomma = true;
                    }
                }

            }
            // Print code as "function = arguments" 
            else if (fillType == fillTableTypes.SetVariable)
            {
                if (table.ArgumentsValues.Count > 0)
                {
                    bool comma = false;
                    code += table.Heading + " = ";
                    foreach (string argument in table.ArgumentsValues.Values)
                    {
                        if (comma) { code += ","; }
                        code += argument;
                        comma = true;
                    }
                    code += "\n";
                }
            }
            // Print code as "if (argument) then functions end"
            else if (fillType == fillTableTypes.IfWhile)
            {
                if ((table.Function as ProgrammaticallyDefinedFunction).IdentifierWithArguments)
                {
                    code += table.Function.Identifier;
                }
                else
                {
                    if (table.Function.Prefix == "if")
                    {
                        code += "if(";
                    }
                    else
                    {
                        code += "while (";
                    }

                    if (table.ArgumentsValues.Count > 0)
                    {
                        bool comma = false;
                        foreach (string argument in table.ArgumentsValues.Values)
                        {
                            if (comma) { code += ","; }
                            code += argument;
                            comma = true;
                        }
                    }
                    else
                    {
                        code += "true";
                    }

                    code += ") ";
                }

                if (table.Function.Prefix == "if")
                {
                    code += "then\n";
                }
                else
                {
                    code += "do\n";
                }

                Shapes.ConstructorTable currentIfTable = null;

                foreach (codeConnector codeConnector in codeConnectors)
                {
                    if (codeConnector.StartPort != null)
                    {
                        if (codeConnector.StartShape == table.ToString())
                        {
                            if (codeConnector.StartPort.Contains("trueOutput"))
                            {
                                currentIfTable = diagram.Tables[codeConnector.EndShape];
                                break;
                            }
                        }
                    }
                }

                while (currentIfTable != null)
                {
                    if ((currentIfTable.ArgumentsValues != null) && (currentIfTable.RetrurnsValues != null))
                    {
                        throw new Exception("Incorrect function call order detected.");
                    }
                    FillTable(diagram, ref warnings, ref currentIfTable, ref code, codeConnectors, GetFillType(currentIfTable.Function.Prefix));


                    bool found = false;
                    foreach (Crainiate.Diagramming.Port port in currentIfTable.Ports.Values)
                    {
                        if (port.Key.Contains("output_"))
                        {
                            foreach (codeConnector codeConnector in codeConnectors)
                            {
                                if (codeConnector.StartPort == port.ToString())
                                {

                                    try
                                    {
                                        found = true;
                                        currentIfTable = diagram.Tables[codeConnector.EndShape];
                                        break;
                                    }
                                    catch
                                    {
                                        found = false;
                                        currentIfTable = null;
                                    }
                                }
                            }
                        }
                    }

                    if (!found)
                    {
                        break;
                    }
                }

                code += "end\n";
            }


        }

        /// <summary>
        /// Return fill type by prefix.
        /// </summary>
        /// <param name="prefix">Prefix</param>
        /// <returns></returns>
        private fillTableTypes GetFillType(string prefix)
        {
            return ((prefix == "setvariable") ? fillTableTypes.SetVariable : (((prefix == "if") || prefix == "while") ? fillTableTypes.IfWhile : fillTableTypes.Function));
        }

        /// <summary>
        /// Serialize function to string.
        /// </summary>
        /// <returns>Serialized function</returns>
        public string SerializeToString()
        {
            string result = "{";
            result += "Name=∴Name=>" + Name + "<=Name∴;";
            result += "Prefix=∴Prefix=>" + Prefix + "<=Prefix∴;";
            result += "Type=" + Type + ";";
            result += "Identifier=∴Identifier=>" + Identifier + "<=Identifier∴;";
            result += "Description=∴Description=>" + Description + "<=Description∴;";
            result += "Value=∴Value=>" + Value + "<=Value∴;";
            result += "Diagram=" + Diagram.SerializeToString() + ";";
            result += "Code=∴Code=>" + Code + "<=Code∴;";
            result += "}";
            return result;
        }

        /// <summary>
        /// Deserialize function from string.
        /// </summary>
        /// <param name="serializedFunction">Serialized function</param>
        public void DeserializeFromString(string serializedFunction)
        {
            serializedFunction = serializedFunction.Substring(1, serializedFunction.Length - 2);
            while (serializedFunction.Length > 0)
            {
                int propertySign = serializedFunction.IndexOf('=');
                string propertyName = serializedFunction.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedFunction, propertySign);
                switch (propertyName)
                {
                    case "Name":
                        this.Name = (serializedFunction.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴Name=>","").Replace("<=Name∴",""));
                        serializedFunction = serializedFunction.Substring(delimiter + 1);
                        break;
                    case "Prefix":
                        this.Prefix = (serializedFunction.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴Prefix=>","").Replace("<=Prefix∴",""));
                        serializedFunction = serializedFunction.Substring(delimiter + 1);
                        break;
                    case "Type":
                        string type = (serializedFunction.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        switch (type)
                        {

                            case "Init":
                                this.Type = FuntionTypes.Init;
                                break;
                            case "Main":
                                this.Type = FuntionTypes.Main;
                                break;
                            case "Regular":
                                this.Type = FuntionTypes.Regular;
                                break;
                        }
                        serializedFunction = serializedFunction.Substring(delimiter + 1);
                        break;
                    case "Identifier":
                        this.Identifier = (serializedFunction.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴Identifier=>", "").Replace("<=Identifier∴", ""));
                        serializedFunction = serializedFunction.Substring(delimiter + 1);
                        break;
                    case "Description":
                        this.Description = (serializedFunction.Substring(propertySign + 1, delimiter - (propertySign + 1))).Replace("∴Description=>", "").Replace("<=Description∴", "");
                        serializedFunction = serializedFunction.Substring(delimiter + 1);
                        break;
                    case "Value":
                        this.Value = (serializedFunction.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴Value=>","").Replace("<=Value∴",""));
                        serializedFunction = serializedFunction.Substring(delimiter + 1);
                        break;
                    case "Diagram":
                        this.Diagram = new Forms.ConstructorDiagram();
                        this.Diagram.DeserializeFromString(serializedFunction.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedFunction = serializedFunction.Substring(delimiter + 1);
                        break;
                    case "Code":
                        this.Code = (serializedFunction.Substring(propertySign + 1, delimiter - (propertySign + 1))).Replace("∴Code=>", "").Replace("<=Code∴", "");
                        serializedFunction = serializedFunction.Substring(delimiter + 1);
                        break;

                }
            }
        }
    }
}
