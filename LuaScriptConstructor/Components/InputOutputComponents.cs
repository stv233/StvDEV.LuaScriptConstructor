using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represent lua input/output components.
    /// </summary>
    static class InputOutputComponents
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

                #region /// Open

                var open = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Open",
                    Prefix = "open",
                    Description = "Opens a file in the specified mode",
                    Identifier = "io.open",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                open.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                open.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = open;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "File name");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Mode");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "File");

                };

                functions.Add(open.Name, open);

                #endregion

                #region /// Input

                var input = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Input",
                    Prefix = "input",
                    Description = "Opens a file (in text mode) and directs it to standard input",
                    Identifier = "io.input",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                input.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                input.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = input;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "File");

                    e.Table.Groups.Remove(e.Table.Groups[1]);

                };

                functions.Add(input.Name, input);

                #endregion

                #region /// Output

                var output = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Output",
                    Prefix = "output",
                    Description = "Opens a file (in text mode) and directs it to standard output",
                    Identifier = "io.output",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                output.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                output.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = output;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "File");

                    e.Table.Groups.Remove(e.Table.Groups[1]);

                };

                functions.Add(output.Name, output);

                #endregion

                #region /// Close

                var close = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Close",
                    Prefix = "close",
                    Description = "Closes the file. Called without a parameter, it closes the standard output file",
                    Identifier = "io.close",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                close.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                close.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = close;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "File");

                    e.Table.Groups.Remove(e.Table.Groups[1]);

                };

                functions.Add(close.Name, close);

                #endregion

                #region /// Read

                var read = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Read",
                    Prefix = "read",
                    Description = "Reads data from a file in standart input\\output according to the specified format",
                    Identifier = "io.read",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                read.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                read.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = read;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Format");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Data");

                };

                functions.Add(read.Name, read);

                #endregion

                #region /// Lines

                var lines = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Lines",
                    Prefix = "lines",
                    Description = "Opens the file with the given name in read mode and returns an iterator",
                    Identifier = "io.lines",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                lines.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                lines.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = lines;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "File name");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Iterator");

                };

                functions.Add(lines.Name, lines);

                #endregion

                #region /// Write

                var write = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Write",
                    Prefix = "write",
                    Description = "Writes the value of the argument to the file in standart input\\output",
                    Identifier = "io.write",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                write.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                write.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = write;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Argument");

                    e.Table.Groups.Remove(e.Table.Groups[1]);

                };

                functions.Add(write.Name, write);

                #endregion

                #region /// Flush

                var flush = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Flush",
                    Prefix = "flush",
                    Description = "Saves all data written to standard output",
                    Identifier = "io.flush",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                flush.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                flush.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = flush;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);

                };

                functions.Add(flush.Name, flush);

                #endregion

                #region /// Tmpfile

                var tmpfile = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Tmpfile",
                    Prefix = "tmpfile",
                    Description = "Returns a descriptor for a temporary file. This file opens in edit mode and is automatically deleted when the program exits",
                    Identifier = "io.tmpfile",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                tmpfile.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in1out));
                tmpfile.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x ;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = tmpfile;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Temp file");

                };

                functions.Add(tmpfile.Name, tmpfile);

                #endregion

                #region /// Type

                var type = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Type",
                    Prefix = "type",
                    Description = "Checks if the object passed as a parameter to a function is a valid file descriptor. " +
                        "Returns the string \"file\" if the object is an open file descriptor; the string \"closed file\" - if the object is a closed file descriptor; " +
                        "nil if the object is not a file descriptor",
                    Identifier = "io.type",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                type.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                type.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.InputOutput_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = type;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "File descriptor");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Validity");

                };

                functions.Add(type.Name, type);

                #endregion

                return functions;
            }
        }
    }
}
