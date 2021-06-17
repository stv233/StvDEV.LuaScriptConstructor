using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components.GlobalComponents
{
    /// <summary>
    /// Represent gameguru global sprites components.
    /// </summary>
    static class Sprites
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

                #region /// LoadImage

                var loadImage = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "LoadImage",
                    Prefix = "loadImage",
                    Description = "Loads a picture from a given path",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                loadImage.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                loadImage.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = loadImage;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 120);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "path");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "image");
                };

                functions.Add(loadImage.Name, loadImage);

                #endregion

                #region /// CreateSprite

                var createSprite = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "CreateSprite",
                    Prefix = "createSprite",
                    Description = "Creates a sprite from a given image",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                createSprite.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in1out));
                createSprite.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = createSprite;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 120);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "image");
                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "sprite");
                };

                functions.Add(createSprite.Name, createSprite);

                #endregion

                #region /// DeleteSprite

                var deleteSprite = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "DeleteSprite",
                    Prefix = "deleteSprite",
                    Description = "Deletes the sprite",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                deleteSprite.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                deleteSprite.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = deleteSprite;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "sprite");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(deleteSprite.Name, deleteSprite);

                #endregion

                #region /// SetSpritePosition

                var setSpritePosition = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSpritePosition",
                    Prefix = "setSpritePosition",
                    Description = "Set sprite positions are percentage based",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSpritePosition.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._3in0out));
                setSpritePosition.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSpritePosition;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "sprite");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "x");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "y");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSpritePosition.Name, setSpritePosition);

                #endregion

                #region /// SetSpriteSize

                var setSpriteSize = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSpriteSize",
                    Prefix = "setSpriteSize",
                    Description = "Set sprite size are percentage based",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSpriteSize.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._3in0out));
                setSpriteSize.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSpriteSize;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "sprite");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "sizeX");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "sizeY");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSpriteSize.Name, setSpriteSize);

                #endregion

                #region /// SetSpriteDepth

                var setSpriteDepth = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSpriteDepth",
                    Prefix = "setSpriteDepth",
                    Description = "Set the order in which the sprite will be drawn",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSpriteDepth.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in0out));
                setSpriteDepth.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSpriteDepth;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 120);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "sprite");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "depth");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSpriteDepth.Name, setSpriteDepth);

                #endregion

                #region /// SetSpriteColor

                var setSpriteColor = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSpriteColor",
                    Prefix = "setSpriteColor",
                    Description = "Sets the sprite RGB values and alpha, each value has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSpriteColor.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._5in0out));
                setSpriteColor.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSpriteColor;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 200);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "sprite");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "red");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "green");
                    e.Table.Groups[0].Rows[3].Text = e.Table.Groups[0].Rows[3].Text.Replace("Argument", "blue");
                    e.Table.Groups[0].Rows[4].Text = e.Table.Groups[0].Rows[4].Text.Replace("Argument", "alpha");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSpriteColor.Name, setSpriteColor);

                #endregion

                #region /// SetSpriteAngle

                var setSpriteAngle = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSpriteAngle",
                    Prefix = "setSpriteAngle",
                    Description = "Sets the sprite rotation in degrees",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSpriteAngle.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in0out));
                setSpriteAngle.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSpriteAngle;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 120);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "sprite");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "angle");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSpriteAngle.Name, setSpriteAngle);

                #endregion

                #region /// SetSpriteOffset

                var setSpriteOffset = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSpriteOffset",
                    Prefix = "setSpriteOffset",
                    Description = "Set sprite offset are percentage based",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSpriteOffset.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._3in0out));
                setSpriteOffset.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSpriteOffset;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "sprite");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "offsetX");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "offsetY");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSpriteOffset.Name, setSpriteOffset);

                #endregion

                #region /// SetSpriteImage

                var setSpriteImage = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSpriteImage",
                    Prefix = "setSpriteImage",
                    Description = "Sets the sprite rotation in degrees",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSpriteImage.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in0out));
                setSpriteImage.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSpriteImage;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 120);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "sprite");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "image");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSpriteImage.Name, setSpriteImage);

                #endregion

                return functions;
            }
        }
    }
}
