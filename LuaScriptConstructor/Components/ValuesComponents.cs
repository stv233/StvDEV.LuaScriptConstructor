using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represents components for working with values.
    /// </summary>
    class ValuesComponents
    {
        /// <summary>
        /// Constants.
        /// </summary>
        public static List<Types.Constant> Constants 
        {
            get
            {
                var constants = new List<Types.Constant>();

                var constant = new Types.Constant
                {
                    Value = "Constant"
                };
                constants.Add(constant);

                return constants;
            }
        }

        /// <summary>
        /// Variables.
        /// </summary>
        public static List<Types.Variable> Variables
        {
            get
            {
                var variables = new List<Types.Variable>();

                var get = new Types.Variable
                {
                    Name = "Get",
                    Prefix = "getvariable",
                    AccessType = Types.Variable.VariableAccessTypes.None,
                    InteractionType = Types.Variable.ValueInteractionTypes.Get
                };
                variables.Add(get);

                return variables;
            }
        }

        /// <summary>
        /// Functions.
        /// </summary>
        public static List<Types.Function> Functions
        {
            get
            {
                var functions = new List<Types.Function>();

                var set = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Set",
                    Prefix = "setvariable",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                set.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                set.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.LocalVariable_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label("Set");
                    e.Table.BackColor = new Types.Variable().Table.BackColor;
                    e.Table.GradientColor = new Types.Variable().Table.BackColor;
                    e.Table.CanEditHeading = true;
                    e.Table.Function = set;
                    e.Table.Heading = "Set";
                    e.Table.SubHeading = "Sets the value of a variable";

                    e.Table.Groups.Clear();

                    foreach(string key in e.Table.Ports.Keys)
                    {
                        if (e.Table.Ports[key].Key.Contains("argument"))
                        {
                            e.Table.Ports.Remove(key);
                            break;
                        }
                    }

                    var setPort = new Crainiate.Diagramming.Port()
                    {
                        Orientation = Crainiate.Diagramming.PortOrientation.Left,
                        Direction = Crainiate.Diagramming.Direction.In,
                        Style = Crainiate.Diagramming.PortStyle.Input
                    };
                    setPort.SetKey("argument-" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                    e.Table.Ports.Add(setPort);

                };

                functions.Add(set);

                return functions;
            }
        }
    }
}
