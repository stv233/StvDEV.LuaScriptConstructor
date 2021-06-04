using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components.GlobalComponents
{
    /// <summary>
    /// Represent gameguru global world components.
    /// </summary>
    static class World
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

                #region // HideTerrain

                var hideTerrain = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "HideTerrain",
                    Prefix = "hideTerrain",
                    Description = "Hides the terrain, ideal for indoor scenes that don't use it",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                hideTerrain.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                hideTerrain.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = hideTerrain;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(hideTerrain.Name, hideTerrain);

                #endregion

                #region // ShowTerrain

                var showTerrain = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "ShowTerrain",
                    Prefix = "showTerrain",
                    Description = "Displays previously hidden terrain",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                showTerrain.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                showTerrain.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = showTerrain;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(showTerrain.Name, showTerrain);

                #endregion

                #region // HideWater

                var hideWater = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "HideWater",
                    Prefix = "hideWater",
                    Description = "Hides the water plane",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                hideWater.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                hideWater.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = hideWater;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(hideWater.Name, hideWater);

                #endregion

                #region // ShowWater

                var showWater = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "ShowWater",
                    Prefix = "showWater",
                    Description = "Displays previously hidden water plane",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                showWater.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                showWater.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = showWater;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(showWater.Name, showWater);

                #endregion

                #region // HideHuds

                var hideHuds = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "HideHuds",
                    Prefix = "hideHuds",
                    Description = "Hides all onscreen huds",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                hideHuds.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                hideHuds.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = hideHuds;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(hideHuds.Name, hideHuds);

                #endregion

                #region // ShowHuds

                var showHuds = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "ShowHuds",
                    Prefix = "showHuds",
                    Description = "Displays previously hidden huds",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                showHuds.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                showHuds.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = showHuds;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(showHuds.Name, showHuds);

                #endregion

                return functions;
            }
        }
    }
}
