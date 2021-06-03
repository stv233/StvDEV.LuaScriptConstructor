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
        public static Dictionary<string, Types.Constant> Constants 
        {
            get
            {
                var constants = new Dictionary<string, Types.Constant>();

                var constant = new Types.Constant
                {
                    Value = "Constant"
                };
                constants.Add("constant", constant);

                return constants;
            }
        }

        /// <summary>
        /// Variables.
        /// </summary>
        public static Dictionary<string, Types.Variable> Variables
        {
            get
            {
                var variables = new Dictionary<string, Types.Variable>();

                var get = new Types.Variable
                {
                    Name = "Get",
                    Prefix = "getvariable",
                    AccessType = Types.Variable.VariableAccessTypes.None,
                    InteractionType = Types.Variable.ValueInteractionTypes.Get
                };
                get.TableRebuilding += (s, e) =>
                {
                    e.Table.Heading = "SomeVariable";
                    e.Table.SubHeading = "Variable";
                    e.Table.Label = new Crainiate.Diagramming.Label("Get");
                };
                variables.Add(get.Name, get);

                return variables;
            }
        }

        /// <summary>
        /// Functions.
        /// </summary>
        public static Dictionary<string, Types.Function> Functions
        {
            get
            {
                var functions = new Dictionary<string, Types.Function>();

                var set = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Set",
                    Prefix = "setvariable",
                    Description = "Sets the value of a variable",
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
                    e.Table.Heading = "SomeVariable";
                    e.Table.SubHeading = set.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(200, 50);
                    e.Table.Size = e.Table.MinimumSize;

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

                functions.Add(set.Name, set);

                return functions;
            }
        }
    }
}
