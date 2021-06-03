using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represent logical components
    /// </summary>
    static class LogicalComponents
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
                Dictionary<string, Types.Function> functions = new Dictionary<string, Types.Function>();

                #region /// And

                var and = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "And",
                    Description = "Returns the truth of the expression \"value1 and value2\"",
                    Prefix = "and",
                    Type = Types.Function.FuntionTypes.Regular,
                    Identifier = new Properties.Settings().LibraryName + ".And",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                and.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                and.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.TrueFalse_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(and.Name);
                    e.Table.Function = and;
                    e.Table.Heading = and.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = and.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(260, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    foreach (Crainiate.Diagramming.TableGroup group in e.Table.Groups)
                    {
                        group.Text = group.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        foreach (Crainiate.Diagramming.TableRow row in group.Rows)
                        {
                            row.Text = row.Text.Replace("Argument", "Value").Replace("Return", "Truth");
                        }
                    }
                };

                functions.Add(and.Name, and);

                #endregion

                #region /// Or

                var or = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Or",
                    Prefix = "or",
                    Description = "Returns the truth of the expression \"value1 or value2\"",
                    Identifier = new Properties.Settings().LibraryName + ".Or",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };

                or.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                or.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.TrueFalse_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(or.Name);
                    e.Table.Function = or;
                    e.Table.Heading = or.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = or.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(260, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    foreach (Crainiate.Diagramming.TableGroup group in e.Table.Groups)
                    {
                        group.Text = group.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        foreach (Crainiate.Diagramming.TableRow row in group.Rows)
                        {
                            row.Text = row.Text.Replace("Argument", "Value").Replace("Return", "Truth");
                        }
                    }
                };

                functions.Add(or.Name, or);


                #endregion

                #region /// Not

                var not = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Not",
                    Prefix = "not",
                    Description = "Returns the inverted value of value1",
                    Identifier = new Properties.Settings().LibraryName + ".Not",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                not.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                not.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.TrueFalse_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(not.Name);
                    e.Table.Function = not;
                    e.Table.Heading = not.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = not.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 130);
                    e.Table.Size = e.Table.MinimumSize;

                    foreach (Crainiate.Diagramming.TableGroup group in e.Table.Groups)
                    {
                        group.Text = group.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        foreach (Crainiate.Diagramming.TableRow row in group.Rows)
                        {
                            row.Text = row.Text.Replace("Argument", "Value").Replace("Return", "Truth");
                        }
                    }
                };

                functions.Add(not.Name, not);


                #endregion

                return functions;
            }
        }
    }
}
