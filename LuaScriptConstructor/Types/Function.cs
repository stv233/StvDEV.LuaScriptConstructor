using System;
using System.Collections.Generic;

namespace LuaScriptConstructor.Types
{
    class Function : Variable
    {
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
        public override Shapes.ConstructorTable Table { get; protected set; }

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
        public EventHandler CompileComplite;

        /// <summary>
        /// Occurs when the assembly of a function fails.
        /// </summary>
        public EventHandler CompileError;

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
        }

        public void Compile(Forms.ConstructorDiagram diagram)
        {
            try
            {
                Table = BuildTable(diagram);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Function compile error!\n" + e.Message,
                    "Function compile error!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private Shapes.ConstructorTable BuildTable(Forms.ConstructorDiagram diagram)
        {
            Shapes.ConstructorTable table = new Shapes.ConstructorTable();
            table.Type = Shapes.ConstructorTable.ConstructionTableTypes.Function;
            table.Function = this;

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
