using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components.TriggerComponents
{
    /// <summary>
    /// Represent player trigger components
    /// </summary>
    static class Player
    {
        /// <summary>
        /// Constants.
        /// </summary>
        public static Dictionary<string, Types.Constant> Constants { get { return new Dictionary<string, Types.Constant>(); } }

        /// <summary>
        /// Variables.
        /// </summary>
        public static Dictionary<string, Types.Variable> Variables { get { return new Dictionary<string, Types.Variable>(); } }

        /// <summary>
        /// Functions.
        /// </summary>
        public static Dictionary<string, Types.Function> Functions
        {
            get
            {
                var functions = new Dictionary<string, Types.Function>();

                #region // Player inside the trigger

                var playerInsideTheTrigger = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Player inside the trigger",
                    Prefix = "if",
                    Description = "Player inside the trigger",
                    Identifier = "if (g_Entity[e]['plrinzone'] == 1)",
                    IdentifierWithArguments = true,
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                playerInsideTheTrigger.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                playerInsideTheTrigger.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.If_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.BackColor = System.Drawing.Color.DarkMagenta;
                    e.Table.GradientColor = System.Drawing.Color.DarkMagenta;
                    e.Table.CanEditHeading = true;
                    e.Table.Function = playerInsideTheTrigger;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 30, 70);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Clear();

                    var argumentRow = new Crainiate.Diagramming.TableRow("Condition") { Forecolor = e.Table.Forecolor };
                    e.Table.Rows.Add(argumentRow);

                    foreach (string key in e.Table.Ports.Keys)
                    {
                        if (e.Table.Ports[key].Key.Contains("argument"))
                        {
                            (e.Table.Ports[key] as Crainiate.Diagramming.TablePort).TableItem = argumentRow;
                            e.Table.Ports[key].BackColor = e.Table.BackColor;
                            e.Table.Ports[key].GradientColor = e.Table.BackColor;
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
                        BorderColor = e.Table.BorderColor,
                        Orientation = Crainiate.Diagramming.PortOrientation.Bottom,
                        Direction = Crainiate.Diagramming.Direction.Out,
                        //Style = Crainiate.Diagramming.PortStyle.Input
                    };
                    truePort.SetKey("trueOutput_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                    e.Table.Ports.Add(truePort);
                    truePort.X += -25;

                };

                functions.Add(playerInsideTheTrigger.Name, playerInsideTheTrigger);

                #endregion

                #region // Player inside the trigge

                var playerOutOfTrigger = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Player out of trigger",
                    Prefix = "if",
                    Description = "Player out of trigger",
                    Identifier = "if (g_Entity[e]['plrinzone'] == 0)",
                    IdentifierWithArguments = true,
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                playerOutOfTrigger.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                playerOutOfTrigger.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.If_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.BackColor = System.Drawing.Color.DarkMagenta;
                    e.Table.GradientColor = System.Drawing.Color.DarkMagenta;
                    e.Table.CanEditHeading = true;
                    e.Table.Function = playerOutOfTrigger;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 30, 70);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Clear();

                    var argumentRow = new Crainiate.Diagramming.TableRow("Condition") { Forecolor = e.Table.Forecolor };
                    e.Table.Rows.Add(argumentRow);

                    foreach (string key in e.Table.Ports.Keys)
                    {
                        if (e.Table.Ports[key].Key.Contains("argument"))
                        {
                            (e.Table.Ports[key] as Crainiate.Diagramming.TablePort).TableItem = argumentRow;
                            e.Table.Ports[key].BackColor = e.Table.BackColor;
                            e.Table.Ports[key].GradientColor = e.Table.BackColor;
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
                        BorderColor = e.Table.BorderColor,
                        Orientation = Crainiate.Diagramming.PortOrientation.Bottom,
                        Direction = Crainiate.Diagramming.Direction.Out,
                        //Style = Crainiate.Diagramming.PortStyle.Input
                    };
                    truePort.SetKey("trueOutput_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                    e.Table.Ports.Add(truePort);
                    truePort.X += -25;

                };

                functions.Add(playerOutOfTrigger.Name, playerOutOfTrigger);

                #endregion

                return functions;
            }
        }
    }
}
