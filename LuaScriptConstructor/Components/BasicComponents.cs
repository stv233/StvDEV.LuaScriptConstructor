using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represents components for working with conditions.
    /// </summary>
    static class BasicComponents
    {
        /// <summary>
        /// Constants.
        /// </summary>
        public static List<Types.Constant> Constants { get { return new List<Types.Constant>(); } }

        /// <summary>
        /// Variables.
        /// </summary>
        public static List<Types.Variable> Variables { get { return new List<Types.Variable>(); } }

        /// <summary>
        /// Functions.
        /// </summary>
        public static List<Types.Function> Functions
        {
            get
            {
                var functions = new List<Types.Function>();

                #region // If

                var @if = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "If",
                    Prefix = "if",
                    Description = "Truth condition",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                @if.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                @if.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.If_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.BackColor = System.Drawing.Color.DarkMagenta;
                    e.Table.GradientColor = System.Drawing.Color.DarkMagenta;
                    e.Table.CanEditHeading = true;
                    e.Table.Function = @if;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 30, 70);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Clear();

                    var argumentRow = new Crainiate.Diagramming.TableRow("Condition");
                    e.Table.Rows.Add(argumentRow);

                    foreach (string key in e.Table.Ports.Keys)
                    {
                        if (e.Table.Ports[key].Key.Contains("argument"))
                        {
                            (e.Table.Ports[key] as Crainiate.Diagramming.TablePort).TableItem = argumentRow;
                            e.Table.LocatePort(e.Table.Ports[key]);
                            break;
                        }

                        if (e.Table.Ports[key].Key.Contains("output"))
                        {
                            e.Table.Ports[key].BackColor = System.Drawing.Color.Red;
                            e.Table.Ports[key].GradientColor = System.Drawing.Color.Red;
                            e.Table.Ports[key].Orientation = Crainiate.Diagramming.PortOrientation.Bottom;
                            e.Table.Ports[key].X += 25;
                        }
                    }

                    var truePort = new Crainiate.Diagramming.Port()
                    {
                        BackColor = System.Drawing.Color.Green,
                        GradientColor = System.Drawing.Color.Green,
                        Orientation = Crainiate.Diagramming.PortOrientation.Bottom,
                        Direction = Crainiate.Diagramming.Direction.Out,
                        //Style = Crainiate.Diagramming.PortStyle.Input
                    };
                    truePort.SetKey("trueOutput_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                    e.Table.Ports.Add(truePort);
                    truePort.X += -25;

                };

                functions.Add(@if);

                #endregion

                var @while = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "While",
                    Prefix = "while",
                    Description = "Loop with a precondition",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                @while.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                @while.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.While_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.BackColor = System.Drawing.Color.MediumVioletRed;
                    e.Table.GradientColor = System.Drawing.Color.MediumVioletRed;
                    e.Table.CanEditHeading = true;
                    e.Table.Function = @while;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 30, 70);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Clear();

                    var argumentRow = new Crainiate.Diagramming.TableRow("Condition");
                    e.Table.Rows.Add(argumentRow);

                    foreach (string key in e.Table.Ports.Keys)
                    {
                        if (e.Table.Ports[key].Key.Contains("argument"))
                        {
                            (e.Table.Ports[key] as Crainiate.Diagramming.TablePort).TableItem = argumentRow;
                            e.Table.LocatePort(e.Table.Ports[key]);
                            break;
                        }

                        if (e.Table.Ports[key].Key.Contains("output"))
                        {
                            e.Table.Ports[key].BackColor = System.Drawing.Color.Red;
                            e.Table.Ports[key].GradientColor = System.Drawing.Color.Red;
                            e.Table.Ports[key].Orientation = Crainiate.Diagramming.PortOrientation.Bottom;
                            e.Table.Ports[key].X += 25;
                        }
                    }

                    var truePort = new Crainiate.Diagramming.Port()
                    {
                        BackColor = System.Drawing.Color.Green,
                        GradientColor = System.Drawing.Color.Green,
                        Orientation = Crainiate.Diagramming.PortOrientation.Bottom,
                        Direction = Crainiate.Diagramming.Direction.Out,
                        //Style = Crainiate.Diagramming.PortStyle.Input
                    };
                    truePort.SetKey("trueOutput_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                    e.Table.Ports.Add(truePort);
                    truePort.X += -25;

                };

                functions.Add(@while);

                return functions;
            }
        }
    }
}
