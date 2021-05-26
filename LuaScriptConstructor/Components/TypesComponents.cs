using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represent types components.
    /// </summary>
    static class TypesComponents
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

                #region /// ToString

                var toString = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "To string",
                    Prefix = "tostring",
                    Description = "Returns the argument value to a string",
                    Identifier = "tostring",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    NeedEntityId = false,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };

                toString.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                toString.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(toString.Name);
                    e.Table.Function = toString;
                    e.Table.Heading = toString.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = toString.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(260, 130);
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

                functions.Add(toString);


                #endregion

                #region /// ToNumber

                var toNumber = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "To number",
                    Prefix = "tonumber",
                    Description = "Returns the value of the argument to a number",
                    Identifier = "tonumber",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    NeedEntityId = false,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput
                };
                toNumber.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                toNumber.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.Double_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(toNumber.Name);
                    e.Table.Function = toNumber;
                    e.Table.Heading = toNumber.Name;
                    //e.Table.GradientColor = System.Drawing.Color.White;
                    e.Table.SubHeading = toNumber.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 130);
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

                functions.Add(toNumber);


                #endregion

                return functions;
            }
        }
        }
}
