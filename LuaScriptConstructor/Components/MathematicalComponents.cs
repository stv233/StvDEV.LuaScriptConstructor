using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represents math components.
    /// </summary>
    static class MathematicalComponents
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

                #region /// Addition

                var addition = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Addition (+)",
                    Prefix = "addition",
                    Description = "Adding two values",
                    Type = Types.Function.FuntionTypes.Regular,
                    Identifier = new Properties.Settings().LibraryName + ".Addition",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                addition.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                addition.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(addition.Name);
                    e.Table.Function = addition;
                    e.Table.Heading = addition.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = addition.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    foreach (Crainiate.Diagramming.TableGroup group in e.Table.Groups)
                    {
                        group.Text = group.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        foreach (Crainiate.Diagramming.TableRow row in group.Rows)
                        {
                            row.Text = row.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        }
                    }
                };

                functions.Add(addition.Name, addition);

                #endregion

                #region /// Subtraction

                var subtraction = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Subtraction (-)",
                    Prefix = "subtraction",
                    Description = "Subtracts the second value from the first",
                    Identifier = new Properties.Settings().LibraryName + ".Subtraction",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                subtraction.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                subtraction.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(subtraction.Name);
                    e.Table.Function = subtraction;
                    e.Table.Heading = subtraction.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = subtraction.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    foreach (Crainiate.Diagramming.TableGroup group in e.Table.Groups)
                    {
                        group.Text = group.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        foreach (Crainiate.Diagramming.TableRow row in group.Rows)
                        {
                            row.Text = row.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        }
                    }
                };

                functions.Add(subtraction.Name, subtraction);


                #endregion

                #region /// Multiplication

                var multiplication = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Multiplication (*)",
                    Prefix = "multiplication",
                    Description = "Multiplies two values",
                    Identifier = new Properties.Settings().LibraryName + ".Multiplication",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                multiplication.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                multiplication.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(multiplication.Name);
                    e.Table.Function = multiplication;
                    e.Table.Heading = multiplication.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = multiplication.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    foreach (Crainiate.Diagramming.TableGroup group in e.Table.Groups)
                    {
                        group.Text = group.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        foreach (Crainiate.Diagramming.TableRow row in group.Rows)
                        {
                            row.Text = row.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        }
                    }
                };

                functions.Add(multiplication.Name, multiplication);


                #endregion

                #region /// Division

                var division = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Division (/)",
                    Prefix = "division",
                    Description = "Divides the first value by the second",
                    Identifier = new Properties.Settings().LibraryName + ".Division",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                division.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                division.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(division.Name);
                    e.Table.Function = division;
                    e.Table.Heading = division.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = division.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    foreach (Crainiate.Diagramming.TableGroup group in e.Table.Groups)
                    {
                        group.Text = group.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        foreach (Crainiate.Diagramming.TableRow row in group.Rows)
                        {
                            row.Text = row.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        }
                    }
                };

                functions.Add(division.Name, division);


                #endregion

                #region /// Modulo

                var modulo = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Modulo (%)",
                    Prefix = "modulo",
                    Description = "Divides the first value by the second modulo",
                    Identifier = new Properties.Settings().LibraryName + ".Modulo",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                modulo.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                modulo.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
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
                            row.Text = row.Text.Replace("Argument", "Value").Replace("Return", "Result");
                        }
                    }
                };

                functions.Add(modulo.Name, modulo);

                #endregion

                #region /// Absolute

                var absolute = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Absolute value (abs)",
                    Prefix = "absolute",
                    Description = "Returns the absolute valu of a number",
                    Identifier = "math.abs",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                absolute.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                absolute.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = absolute;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(absolute.Name, absolute);

                #endregion

                #region /// Ceil

                var ceil = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Ceil (ceil)",
                    Prefix = "ceil",
                    Description = "Returns the smallest integer greater than or equal to the specified one (rounds up)",
                    Identifier = "math.ceil",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                ceil.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                ceil.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = ceil;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(ceil.Name, ceil);

                #endregion

                #region /// Floor

                var floor = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Floor (floor)",
                    Prefix = "floor",
                    Description = "Returns the largest integer less than or equal to the specified number (rounds down)",
                    Identifier = "math.floor",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                floor.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                floor.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = floor;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(floor.Name, floor);

                #endregion

                #region /// Power

                var pow = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Power (pow)",
                    Prefix = "floor",
                    Description = "Raises a number to a power",
                    Identifier = "math.pow",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                pow.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                pow.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = pow;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(pow.Name, pow);

                #endregion

                #region /// Square root

                var sqrt = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Square root (sqrt)",
                    Prefix = "sqrt",
                    Description = "Calculates the square root of a number",
                    Identifier = "math.sqrt",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                sqrt.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                sqrt.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = sqrt;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(sqrt.Name, sqrt);

                #endregion

                #region /// Natural logarithm

                var log = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Natural logarithm (log)",
                    Prefix = "log",
                    Description = "Calculates natural logarithm",
                    Identifier = "math.log",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                log.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                log.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = log;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(log.Name, log);

                #endregion

                #region /// Logarithm base 10

                var log10 = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Logarithm base 10 (log10)",
                    Prefix = "log10",
                    Description = "Calculates log base 10",
                    Identifier = "math.log",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                log10.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                log10.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = log10;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(log10.Name, log10);

                #endregion

                #region /// Cosine

                var cos = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Cosine (cos)",
                    Prefix = "cos",
                    Description = "Calculates the cosine of an angle, given in radians",
                    Identifier = "math.cos",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                cos.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                cos.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = cos;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(cos.Name, cos);

                #endregion

                #region /// Sinus

                var sin = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Sinus (sin)",
                    Prefix = "sin",
                    Description = "Calculates the sine of an angle given in radians",
                    Identifier = "math.sin",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                sin.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                sin.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = sin;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(sin.Name, sin);

                #endregion

                #region /// Tangent

                var tan = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Tangent (tan)",
                    Prefix = "tan",
                    Description = "Calculates the tangent of an angle given in radians",
                    Identifier = "math.tan",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                tan.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                tan.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = tan;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(tan.Name, tan);

                #endregion

                #region /// Degrees

                var deg = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Degrees (deg)",
                    Prefix = "deg",
                    Description = "Converts an angle value from radians to degrees",
                    Identifier = "math.deg",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                deg.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                deg.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = deg;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(deg.Name, deg);

                #endregion

                #region /// Radians

                var rad = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Radians (rad)",
                    Prefix = "rad",
                    Description = "Converts an angle value from degrees to radians",
                    Identifier = "math.rad",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                rad.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                rad.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = rad;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(rad.Name, rad);

                #endregion

                #region /// Random number

                var random = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Random number (random)",
                    Prefix = "random",
                    Description = "Returns a random number between two given values",
                    Identifier = "math.random",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                random.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                random.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Calculator_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = random;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Text = e.Table.Groups[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Value");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "Value");

                    e.Table.Groups[1].Text = e.Table.Groups[1].Text.Replace("Return", "Result");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Result");

                };

                functions.Add(random.Name, random);

                #endregion

                return functions;
            }
        }
    }
}
