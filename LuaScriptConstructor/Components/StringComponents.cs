using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represent lua string components.
    /// </summary>
    static class StringComponents
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

                #region /// Byte

                var @byte = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Byte",
                    Prefix = "byte",
                    Description = "Returns the numeric code of the character in the string at index i",
                    Identifier = "string.byte",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                @byte.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                @byte.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = @byte;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "i");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Numeric code");

                };

                functions.Add(@byte.Name, @byte);

                #endregion

                #region /// Char

                var @char = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Char",
                    Prefix = "char",
                    Description = "Returns a character by numeric codes",
                    Identifier = "string.char",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                @char.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                @char.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = @char;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Numeric code");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Character");

                };

                functions.Add(@char.Name, @char);

                #endregion

                #region /// Dump

                var dump = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Dump",
                    Prefix = "dump",
                    Description = "Returns the binary representation of the func function",
                    Identifier = "string.dump",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                dump.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                dump.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = dump;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "Func");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Binary");

                };

                functions.Add(dump.Name, dump);

                #endregion

                #region /// Find

                var find = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Find",
                    Prefix = "find",
                    Description = "Searches for an occurrence of a substring in a string and returns the index of the beginning of the occurrence, or nil if no match is found",
                    Identifier = "string.find",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                find.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                find.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = find;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "Substring");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Binary");

                };

                functions.Add(find.Name, find);

                #endregion

                #region /// Format

                var format = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Format",
                    Prefix = "format",
                    Description = "Outputs a formatted string",
                    Identifier = "string.format",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                format.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                format.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = format;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "Substitution");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Formatted string");

                };

                functions.Add(format.Name, format);

                #endregion

                #region /// Match

                var match = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Match",
                    Prefix = "match",
                    Description = "Searches for the first occurrence of a pattern in a String starting at character i, if found, returns a match, otherwise nil",
                    Identifier = "string.match",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                match.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._3in1out));
                match.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = match;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 170);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "Pattern");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "i");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "First occurrence");

                };

                functions.Add(match.Name, match);

                #endregion

                #region /// GMatch

                var gmatch = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GMatch",
                    Prefix = "gmatch",
                    Description = "Returns an iterator that, on each call, returns the next occurrence of the pattern in String",
                    Identifier = "string.gmatch",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                gmatch.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                gmatch.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = gmatch;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "Pattern");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Iterator");

                };

                functions.Add(gmatch.Name, gmatch);

                #endregion

                #region /// GSub

                var gsub = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GSub",
                    Prefix = "gsub",
                    Description = "Returns a copy of String, in which all occurrences of the Search Pattern are replaced by the Replacement Pattern, " +
                        "which can be a string, table or function, the second value returns the total number of substitutions performed",
                    Identifier = "string.gsub",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                gsub.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._3in2out));
                gsub.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = gsub;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 200);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "Search Pattern");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "Replacement Pattern");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Copy of String");
                    e.Table.Groups[1].Rows[1].Text = e.Table.Groups[1].Rows[1].Text.Replace("Return", "Number of substitutions performed");

                };

                functions.Add(gsub.Name, gsub);

                #endregion

                #region /// Len

                var len = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Len",
                    Prefix = "len",
                    Description = "Returns the length of the String",
                    Identifier = "string.len",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                len.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                len.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = len;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Length");

                };

                functions.Add(len.Name, len);

                #endregion

                #region /// Upper

                var upper = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Upper",
                    Prefix = "upper",
                    Description = "Returns a copy of the String with all lowercase letters replaced with uppercase letters",
                    Identifier = "string.upper",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                upper.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                upper.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = upper;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "String with uppercase letters");

                };

                functions.Add(upper.Name, upper);

                #endregion

                #region /// Lower

                var lower = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Lower",
                    Prefix = "lower",
                    Description = "Returns a copy of the String with all uppercase letters replaced with lowercase letters",
                    Identifier = "string.lower",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                lower.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                lower.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = lower;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "String with lowercase letters");

                };

                functions.Add(lower.Name, lower);

                #endregion

                #region /// Rep

                var rep = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Rep",
                    Prefix = "rep",
                    Description = "Returns a string that contains n copies of the String",
                    Identifier = "string.rep",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                rep.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in1out));
                rep.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = rep;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "n");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Rep string");

                };

                functions.Add(rep.Name, rep);

                #endregion

                #region /// Reverse

                var reverse = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Reverse",
                    Prefix = "reverse",
                    Description = "Returns a string in which the characters of the String are in reverse order",
                    Identifier = "string.reverse",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                reverse.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                reverse.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = reverse;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Reversed string");

                };

                functions.Add(reverse.Name, reverse);

                #endregion

                #region /// Sub

                var sub = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Sub",
                    Prefix = "sub",
                    Description = "Returns a substring of String that starts at character at index i and ends at character at index j",
                    Identifier = "string.sub",
                    IsLibraryFunction = true,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    Type = Types.Function.FuntionTypes.Regular,
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false
                };
                sub.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._3in1out));
                sub.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.String_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Function = sub;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Name);
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(250, 170);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "String");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "i");
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "j");

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "Substring");

                };

                functions.Add(sub.Name, sub);

                #endregion

                return functions;
            }
        }
    }
}
