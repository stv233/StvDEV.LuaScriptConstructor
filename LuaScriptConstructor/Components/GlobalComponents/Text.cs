using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components.GlobalComponents
{
    /// <summary>
    /// Represent text components from GameGuru global.
    /// </summary>
    class Text
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

                #region // Prompt

                var prompt = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Prompt",
                    Prefix = "prompt",
                    Description = "Displays text (str) at the base and centre of the screen",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                prompt.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                prompt.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = prompt;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;
                    
                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "str");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(prompt.Name, prompt);

                #endregion

                #region // PromptDuration

                var promptDuration = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "PromptDuration",
                    Prefix = "promptDuration",
                    Description = "Displays text (str) for V millisecs at the base and centre of the screen",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                promptDuration.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in0out));
                promptDuration.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = promptDuration;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 120);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "str");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(promptDuration.Name, promptDuration);

                #endregion

                #region // PromptTextSize

                var promptTextSize = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "PromptTextSize",
                    Prefix = "promptTextSize",
                    Description = "Sets the prompt size (V) – this has a value of between 1 and 5 with 1 being the smallest",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                promptTextSize.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                promptTextSize.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = promptTextSize;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(promptTextSize.Name, promptTextSize);

                #endregion

                #region // PromptLocal

                var promptLocal = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "PromptLocal",
                    Prefix = "promptLocal",
                    Description = "Displays text (str) at the current entities location",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                promptLocal.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                promptLocal.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = promptLocal;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "str");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(promptLocal.Name, promptLocal);

                #endregion

                #region // Text

                var text = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Text",
                    Prefix = "text",
                    Description = "Displays text (txt) using (size) at the relative screen position X,Y which have a value between 1-100. This is percentage based with 100 being the full width or height of the screen",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                text.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._4in0out));
                text.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = text;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "x");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "y");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "size");
                    e.Table.Groups[0].Rows[3].Text = e.Table.Groups[0].Rows[3].Text.Replace("Argument", "txt");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(text.Name, text);

                #endregion

                #region // TextCenterOnX

                var textCenterOnX = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "TextCenterOnX",
                    Prefix = "textCenterOnX",
                    Description = "Displays text (txt) using (size) centred at the relative screen position X,Y which have a value between 1-100. This is percentage based with 100 being the full width or height of the screen",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                textCenterOnX.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._4in0out));
                textCenterOnX.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = textCenterOnX;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "x");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "y");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "size");
                    e.Table.Groups[0].Rows[3].Text = e.Table.Groups[0].Rows[3].Text.Replace("Argument", "txt");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(textCenterOnX.Name, textCenterOnX);

                #endregion

                #region // TextColor

                var textColor = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "TextColor",
                    Prefix = "textColor",
                    Description = "Display text (txt) in color (red,greem,blue) using (size) at the relative screen position X, Y which have a value between 1-100. This is percentage based with 100 being the full width or height of the screen",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                textColor.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._7in0out));
                textColor.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = textColor;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 200);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "x");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "y");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "size");
                    e.Table.Groups[0].Rows[3].Text = e.Table.Groups[0].Rows[3].Text.Replace("Argument", "txt");
                    e.Table.Groups[0].Rows[4].Text = e.Table.Groups[0].Rows[4].Text.Replace("Argument", "red");
                    e.Table.Groups[0].Rows[5].Text = e.Table.Groups[0].Rows[5].Text.Replace("Argument", "green");
                    e.Table.Groups[0].Rows[6].Text = e.Table.Groups[0].Rows[6].Text.Replace("Argument", "blue");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(textColor.Name, textColor);

                #endregion

                #region // TextCenterOnXColor

                var textCenterOnXColor = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "TextCenterOnXColor",
                    Prefix = "textCenterOnXColor",
                    Description = "Displays text (txt) in color (red,greem,blue) using (size) centred at the relative screen position X,Y which have a value between 1-100. This is percentage based with 100 being the full width or height of the screen",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                textCenterOnXColor.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._7in0out));
                textCenterOnXColor.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = textCenterOnXColor;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 200);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "x");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "y");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "size");
                    e.Table.Groups[0].Rows[3].Text = e.Table.Groups[0].Rows[3].Text.Replace("Argument", "txt");
                    e.Table.Groups[0].Rows[4].Text = e.Table.Groups[0].Rows[4].Text.Replace("Argument", "red");
                    e.Table.Groups[0].Rows[5].Text = e.Table.Groups[0].Rows[5].Text.Replace("Argument", "green");
                    e.Table.Groups[0].Rows[6].Text = e.Table.Groups[0].Rows[6].Text.Replace("Argument", "blue");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(textCenterOnXColor.Name, textCenterOnXColor);

                #endregion

                return functions;
            }
        }
    }
}
