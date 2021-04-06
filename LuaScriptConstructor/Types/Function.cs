using System;
using System.Collections.Generic;

namespace LuaScriptConstructor.Types
{
    /// <summary>
    /// Lua function.
    /// </summary>
    class Function : Variable
    {
        /// <summary>
        /// Represents a class containing data for a <see cref="CompileComplite"/> and <see cref="CompileError"/> event.
        /// </summary>
        public class FunctionCompileEventArgs : EventArgs
        {
            /// <summary>
            /// Compile warnings.
            /// </summary>
            public List<string> Warnings { get; protected set; }

            /// <summary>
            /// Compile error.
            /// </summary>
            public Exception Error { get; protected set; }

            /// <summary>
            /// Represents a class containing data for a <see cref="CompileComplite"/> and <see cref="CompileError"/> event.
            /// </summary>
            /// <param name="error">Compile error</param>
            public FunctionCompileEventArgs(Exception error) { Error = error; Warnings = new List<string>(); }

            /// <summary>
            /// Represents a class containing data for a <see cref="CompileComplite"/> and <see cref="CompileError"/> event.
            /// </summary>
            /// <param name="warnings">Compile warnings</param>
            public FunctionCompileEventArgs(List<string> warnings) { Warnings = warnings; Error = null; }

            /// <summary>
            /// Represents a class containing data for a <see cref="CompileComplite"/> and <see cref="CompileError"/> event.
            /// </summary>
            /// <param name="error">Compile error</param>
            /// <param name="warnings">Compile warnings</param>
            public FunctionCompileEventArgs(Exception error, List<string> warnings) { Error = error; Warnings = warnings; }

        }

        /// <summary>
        /// Represents a method that handles <see cref="CompileComplite"/> and <see cref="CompileError"/> events.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public delegate void FunctionCompileEvents(object sender, FunctionCompileEventArgs e);

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
        /// Function argument list.
        /// </summary>
        public List<string> Arguments { get; protected set; }

        /// <summary>
        /// Function return list.
        /// </summary>
        public List<string> Returns { get; protected set; }

        /// <summary>
        /// Funtion table.
        /// </summary>
        new public virtual Shapes.ConstructorTable Table { get; protected set; }

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
        /// Occurs when the assembly of the function is complete.
        /// </summary>
        public FunctionCompileEvents CompileComplite;

        /// <summary>
        /// Occurs when the assembly of a function fails.
        /// </summary>
        public FunctionCompileEvents CompileError;

        /// <summary>
        /// Lua function.
        /// </summary>
        protected Function() { }

        /// <summary>
        /// Lua function.
        /// </summary>
        /// <param name="name">Function name.</param>
        public Function(string name) : this(name, FuntionTypes.Regular) { }

        /// <summary>
        /// Lua function.
        /// </summary>
        /// <param name="name">Function name</param>
        /// <param name="type">Function type</param>
        public Function(string name, FuntionTypes type)
        {
            Name = name;
            Type = type;
            CompileComplite += (s, e) => { };
            CompileError += (s, e) => { };
        }

        public void Compile(Forms.ConstructorDiagram diagram)
        {
            List<string> warnings = new List<string>();

            try
            {
                Table = BuildTable(diagram, ref warnings);
            }
            catch (Exception e)
            {
                CompileError(this, new FunctionCompileEventArgs(e, warnings));
            }

            CompileComplite(this, new FunctionCompileEventArgs(warnings));
        }

        /// <summary>
        /// Build function table.
        /// </summary>
        /// <param name="diagram">Function diagramm</param>
        /// <param name="warnings">Warnings list</param>
        /// <returns></returns>
        private Shapes.ConstructorTable BuildTable(Forms.ConstructorDiagram diagram, ref List<string> warnings)
        {
          
            Shapes.ConstructorTable table = new Shapes.ConstructorTable();
            table.Type = Shapes.ConstructorTable.ConstructionTableTypes.Function;
            table.Function = this;
            table.SetKey(Prefix + "_" + Name + DateTime.Now.GetHashCode());

            if ((AccessType == VariableAccessTypes.Input) || (AccessType == VariableAccessTypes.InputOutput))
            {
                var input = new Crainiate.Diagramming.Port();
                input.SetKey("input_" + Prefix + "_" + Name + DateTime.Now.GetHashCode());
                input.Direction = Crainiate.Diagramming.Direction.In;
                input.Orientation = Crainiate.Diagramming.PortOrientation.Top;
                input.Style = Crainiate.Diagramming.PortStyle.Simple;
                input.AllowMove = false;
                table.Ports.Add(input);
            }

            if ((AccessType == VariableAccessTypes.Output) || (AccessType == VariableAccessTypes.InputOutput))
            {
                var output = new Crainiate.Diagramming.Port();
                output.SetKey("output_" + Prefix + "_" + Name + DateTime.Now.GetHashCode());
                output.Direction = Crainiate.Diagramming.Direction.Out;
                output.Orientation = Crainiate.Diagramming.PortOrientation.Bottom;
                output.Style = Crainiate.Diagramming.PortStyle.Simple;
                output.AllowMove = false;
                table.Ports.Add(output);
            }

            foreach (Shapes.ConstructorConnector connector in diagram.Connectors.Values)
            {
                if (connector.StartPort.Key.Contains("functionargument"))
                {
                    Arguments.Add("argument_" + (Arguments.Count + 1).ToString());
                }

                if (connector.EndPort.Key.Contains("functionreturn"))
                {
                    Returns.Add("return_" + (Returns.Count + 1).ToString());
                }
            }

            Crainiate.Diagramming.TableGroup arguments = new Crainiate.Diagramming.TableGroup("Arguments");

            foreach (var argument in Arguments)
            {
                Crainiate.Diagramming.TableRow row = new Crainiate.Diagramming.TableRow(argument.Replace("a", "A").Replace("_", " "));
                Crainiate.Diagramming.TablePort port = new Crainiate.Diagramming.TablePort(row);
                port.AllowMove = false;
                port.Orientation = Crainiate.Diagramming.PortOrientation.Left;
                port.Direction = Crainiate.Diagramming.Direction.In;
                port.Style = Crainiate.Diagramming.PortStyle.Input;
                arguments.Rows.Add(row);
                table.Ports.Add(port);
            }
            table.Groups.Add(arguments);

            Crainiate.Diagramming.TableGroup returns = new Crainiate.Diagramming.TableGroup("Returns");

            foreach (var @return in Returns)
            {
                Crainiate.Diagramming.TableRow row = new Crainiate.Diagramming.TableRow(@return.Replace("r", "R").Replace("_", " "));
                Crainiate.Diagramming.TablePort port = new Crainiate.Diagramming.TablePort(row);
                port.AllowMove = false;
                port.Orientation = Crainiate.Diagramming.PortOrientation.Right;
                port.Direction = Crainiate.Diagramming.Direction.Out;
                port.Style = Crainiate.Diagramming.PortStyle.Output;
                returns.Rows.Add(row);
                table.Ports.Add(port);
            }
            table.Groups.Add(returns);

            return table;
        }
    }
}
