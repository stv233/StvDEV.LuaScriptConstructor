using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components.GlobalComponents
{
    /// <summary>
    /// Represent GameGuru global visuals components.
    /// </summary>
    static class Visuals
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

                #region // SetFogNearest

                var setFogNearest = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetFogNearest",
                    Prefix = "setFogNearest",
                    Description = "Sets the fog near distance to (V)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setFogNearest.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setFogNearest.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setFogNearest;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setFogNearest.Name, setFogNearest);

                #endregion

                #region // SetFogDistance

                var setFogDistance = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetFogDistance",
                    Prefix = "setFogDistance",
                    Description = "Sets the fog near furthers far distance to (V)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setFogDistance.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setFogDistance.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setFogDistance;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setFogDistance.Name, setFogDistance);

                #endregion

                #region // SetFogRed

                var setFogRed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetFogRed",
                    Prefix = "setFogRed",
                    Description = "Sets the red colour value of the fog. This has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setFogRed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setFogRed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setFogRed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setFogRed.Name, setFogRed);

                #endregion

                #region // SetFogGreen

                var setFogGreen = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetFogGreen",
                    Prefix = "setFogGreen",
                    Description = "Sets the green colour value of the fog. This has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setFogGreen.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setFogGreen.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setFogGreen;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setFogGreen.Name, setFogGreen);

                #endregion

                #region // SetFogBlue

                var setFogBlue = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetFogBlue",
                    Prefix = "setFogBlue",
                    Description = "Sets the blue colour value of the fog. This has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setFogBlue.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setFogBlue.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setFogBlue;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setFogBlue.Name, setFogBlue);

                #endregion

                #region // SetFogIntensity

                var setFogIntensity = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetFogIntensity",
                    Prefix = "setFogIntensity",
                    Description = "Sets the thickness value of the fog. This has a range of 0-100",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setFogIntensity.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setFogIntensity.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setFogIntensity;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setFogIntensity.Name, setFogIntensity);

                #endregion

                #region // SetAmbienceIntensity

                var setAmbienceIntensity = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetAmbienceIntensity",
                    Prefix = "setAmbienceIntensity",
                    Description = "Sets the Ambience Intensity to V. This has a range of 0-100",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setAmbienceIntensity.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setAmbienceIntensity.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setAmbienceIntensity;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setAmbienceIntensity.Name, setAmbienceIntensity);

                #endregion

                #region // SetAmbienceRed

                var setAmbienceRed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetAmbienceRed",
                    Prefix = "setAmbienceRed",
                    Description = "Sets the red colour value of the overall ambient light. This has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setAmbienceRed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setAmbienceRed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setAmbienceRed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setAmbienceRed.Name, setAmbienceRed);

                #endregion

                #region // SetAmbienceGreen

                var setAmbienceGreen = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetAmbienceGreen",
                    Prefix = "setAmbienceGreen",
                    Description = "Sets the green colour value of the overall ambient light. This has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setAmbienceGreen.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setAmbienceGreen.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setAmbienceGreen;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setAmbienceGreen.Name, setAmbienceGreen);

                #endregion

                #region // SetAmbienceBlue

                var setAmbienceBlue = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetAmbienceBlue",
                    Prefix = "setAmbienceBlue",
                    Description = "Sets the blue colour value of the overall ambient light. This has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setAmbienceBlue.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setAmbienceBlue.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setAmbienceBlue;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setAmbienceBlue.Name, setAmbienceBlue);

                #endregion

                #region // SetSurfaceRed

                var setSurfaceRed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSurfaceRed",
                    Prefix = "setSurfaceRed",
                    Description = "Sets the red colour value of light applied to the surface of entities. This has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSurfaceRed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setSurfaceRed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSurfaceRed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSurfaceRed.Name, setSurfaceRed);

                #endregion

                #region // SetSurfaceGreen

                var setSurfaceGreen = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSurfaceGreen",
                    Prefix = "setSurfaceGreen",
                    Description = "Sets the green colour value of light applied to the surface of entities. This has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSurfaceGreen.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setSurfaceGreen.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSurfaceGreen;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSurfaceGreen.Name, setSurfaceGreen);

                #endregion

                #region // SetSurfaceBlue

                var setSurfaceBlue = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetSurfaceBlue",
                    Prefix = "setSurfaceBlue",
                    Description = "Sets the blue colour value of light applied to the surface of entities. This has a range of 0-255",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setSurfaceBlue.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setSurfaceBlue.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setSurfaceBlue;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setSurfaceBlue.Name, setSurfaceBlue);

                #endregion

                #region // SetPostVignetteRadius

                var setPostVignetteRadius = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetPostVignetteRadius",
                    Prefix = "setPostVignetteRadius",
                    Description = "Adjusts the radius of the Vignette effect",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setPostVignetteRadius.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setPostVignetteRadius.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setPostVignetteRadius;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setPostVignetteRadius.Name, setPostVignetteRadius);

                #endregion

                #region // SetPostVignetteIntensity

                var setPostVignetteIntensity = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetPostVignetteIntensity",
                    Prefix = "setPostVignetteIntensity",
                    Description = "Sets the intensity of the vignette effect",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setPostVignetteIntensity.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setPostVignetteIntensity.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setPostVignetteIntensity;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setPostVignetteIntensity.Name, setPostVignetteIntensity);

                #endregion

                #region // SetPostMotionDistance

                var setPostMotionDistance = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetPostMotionDistance",
                    Prefix = "setPostMotionDistance",
                    Description = "Set the distance affected when motion blur is applied",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setPostMotionDistance.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setPostMotionDistance.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setPostMotionDistance;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setPostMotionDistance.Name, setPostMotionDistance);

                #endregion

                #region // SetPostMotionIntensity

                var setPostMotionIntensity = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetPostMotionIntensity",
                    Prefix = "setPostMotionIntensity",
                    Description = "Set the intensity of motion blur",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setPostMotionIntensity.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setPostMotionIntensity.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setPostMotionIntensity;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setPostMotionIntensity.Name, setPostMotionIntensity);

                #endregion

                #region // SetPostDepthOfFieldDistance

                var setPostDepthOfFieldDistance = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetPostDepthOfFieldDistance",
                    Prefix = "setPostDepthOfFieldDistance",
                    Description = "Sets the distance Depth of Field is applied",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setPostDepthOfFieldDistance.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setPostDepthOfFieldDistance.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setPostDepthOfFieldDistance;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setPostDepthOfFieldDistance.Name, setPostDepthOfFieldDistance);

                #endregion

                #region // SetPostDepthOfFieldIntensity

                var setPostDepthOfFieldIntensity = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetPostDepthOfFieldIntensity",
                    Prefix = "setPostDepthOfFieldIntensity",
                    Description = "Sets the Depth of Field intensity",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setPostDepthOfFieldIntensity.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setPostDepthOfFieldIntensity.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setPostDepthOfFieldIntensity;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setPostDepthOfFieldIntensity.Name, setPostDepthOfFieldIntensity);

                #endregion

                return functions;
            }
        }
    }
}
