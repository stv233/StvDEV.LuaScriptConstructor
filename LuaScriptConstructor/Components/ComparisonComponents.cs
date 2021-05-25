using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    class ComparisonComponents
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
                List<Types.Function> functions = new List<Types.Function>();

                #region /// Addition

                var greater = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Greater (>)",
                    Description = "Returns the truth of the expression \"value1 > value2\"",
                    Prefix = "greater",
                    Type = Types.Function.FuntionTypes.Regular,
                    Identifier = new Properties.Settings().LibraryName + ".Greater",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                greater.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                greater.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GreaterLessEqua_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(greater.Name);
                    e.Table.Function = greater;
                    e.Table.Heading = greater.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = greater.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
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

                functions.Add(greater);

                #endregion

                #region /// Less

                var less = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Less (<)",
                    Prefix = "less",
                    Description = "Returns the truth of the expression \"value1 < value2\"",
                    Identifier = new Properties.Settings().LibraryName + ".Less",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };

                less.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                less.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GreaterLessEqua_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(less.Name);
                    e.Table.Function = less;
                    e.Table.Heading = less.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = less.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
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

                functions.Add(less);


                #endregion

                #region /// GreaterOrEqual

                var greaterOrEqual = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GreaterOrEqual (>=)",
                    Prefix = "greaterOrEqual",
                    Description = "Returns the truth of the expression \"value1 >= value2\"",
                    Identifier = new Properties.Settings().LibraryName + ".GreaterOrEqual",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                greaterOrEqual.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                greaterOrEqual.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GreaterLessEqua_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(greaterOrEqual.Name);
                    e.Table.Function = greaterOrEqual;
                    e.Table.Heading = greaterOrEqual.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = greaterOrEqual.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
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

                functions.Add(greaterOrEqual);


                #endregion

                #region /// LessOrEqual

                var lessOrEqual = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "LessOrEqual (<=)",
                    Prefix = "lessOrEqual",
                    Description = "Returns the truth of the expression \"value1 <= value2\"",
                    Identifier = new Properties.Settings().LibraryName + ".LessOrEqual",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                lessOrEqual.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                lessOrEqual.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GreaterLessEqua_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(lessOrEqual.Name);
                    e.Table.Function = lessOrEqual;
                    e.Table.Heading = lessOrEqual.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = lessOrEqual.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
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

                functions.Add(lessOrEqual);


                #endregion

                #region /// Equal

                var modulo = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Equal (==)",
                    Prefix = "equal",
                    Description = "Returns the truth of the expression \"value1 == value2\"",
                    Identifier = new Properties.Settings().LibraryName + ".Equal",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                modulo.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                modulo.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GreaterLessEqua_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(modulo.Name);
                    e.Table.Function = modulo;
                    e.Table.Heading = modulo.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = modulo.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
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

                functions.Add(modulo);

                #endregion

                return functions;
            }
        }
    }
}
