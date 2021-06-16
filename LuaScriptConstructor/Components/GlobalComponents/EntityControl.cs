using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components.GlobalComponents
{
    //// <summary>
    //// Represent gameguru global entitys control components.
    //// </summary>
    static class EntityControl
    {
        //// <summary>
        //// Constants.
        //// </summary>
        public static Dictionary<string, Types.Constant> Constants { get { return new Dictionary<string, Types.Constant>(); } }

        //// <summary>
        //// Variables.
        //// </summary>
        public static Dictionary<string, Types.Variable> Variables { get { return new Dictionary<string, Types.Variable>(); } }

        //// <summary>
        //// Functions.
        //// </summary>
        public static Dictionary<string, Types.Function> Functions
        {
            get
            {
                var functions = new Dictionary<string, Types.Function>();

                #region /// SetEntityHealth

                var setEntityHealth = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetEntityHealth",
                    Prefix = "setEntityHealth",
                    Description = "Set entity health to (v)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setEntityHealth.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setEntityHealth.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setEntityHealth;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setEntityHealth.Name, setEntityHealth);

                #endregion

                #region /// StartTimer

                var startTimer = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "StartTimer",
                    Prefix = "startTimer",
                    Description = "Starts an entity dependant timer",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                startTimer.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                startTimer.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = startTimer;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(startTimer.Name, startTimer);

                #endregion

                #region /// GetTimer

                var getTimer = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GetTimer",
                    Prefix = "getTimer",
                    Description = "Returns the current entity time",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                getTimer.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in1out));
                getTimer.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = getTimer;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                };

                functions.Add(getTimer.Name, getTimer);

                #endregion

                #region /// Destroy

                var destroy = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Destroy",
                    Prefix = "destroy",
                    Description = "Destroys the current entity, removing it from the current game",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                destroy.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                destroy.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = destroy;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(destroy.Name, destroy);

                #endregion

                #region /// CollisionOn

                var collisionOn = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "CollisionOn",
                    Prefix = "collisionOn",
                    Description = "Turn an entity collision on (for example for a closed door)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                collisionOn.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                collisionOn.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = collisionOn;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(collisionOn.Name, collisionOn);

                #endregion

                #region /// CollisionOff

                var collisionOff = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "CollisionOff",
                    Prefix = "collisionOff",
                    Description = "Turn an entity collision off (for example for an open door)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                collisionOff.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                collisionOff.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = collisionOff;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(collisionOff.Name, collisionOff);

                #endregion

                #region /// GravityOff

                var gravityOff = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GravityOff",
                    Prefix = "gravityOff",
                    Description = "Turn off entity Gravity",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                gravityOff.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                gravityOff.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = gravityOff;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(gravityOff.Name, gravityOff);

                #endregion

                #region /// GravityOn

                var gravityOn = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GravityOn",
                    Prefix = "gravityOn",
                    Description = "Turn on entity Gravity",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                gravityOn.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                gravityOn.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = gravityOn;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(gravityOn.Name, gravityOn);

                #endregion

                #region /// LookAtPlayer

                var lookAtPlayer = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "LookAtPlayer",
                    Prefix = "lookAtPlayer",
                    Description = "Forces the entity to face the player",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                lookAtPlayer.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                lookAtPlayer.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = lookAtPlayer;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(lookAtPlayer.Name, lookAtPlayer);

                #endregion

                #region /// RotateToPlayer

                var rotateToPlayer = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "RotateToPlayer",
                    Prefix = "rotateToPlayer",
                    Description = "Rotates the entity to face the player",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                rotateToPlayer.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                rotateToPlayer.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = rotateToPlayer;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(rotateToPlayer.Name, rotateToPlayer);

                #endregion

                #region /// RotateToPlayerSlowly

                var rotateToPlayerSlowly = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "RotateToPlayerSlowly",
                    Prefix = "rotateToPlayerSlowly",
                    Description = "Rotates the entity to face the player at (v) speed",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                rotateToPlayerSlowly.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                rotateToPlayerSlowly.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = rotateToPlayerSlowly;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(rotateToPlayerSlowly.Name, rotateToPlayerSlowly);

                #endregion

                #region /// Hide

                var hide = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Hide",
                    Prefix = "hide",
                    Description = "Makes the entity invisible",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                hide.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                hide.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = hide;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(hide.Name, hide);

                #endregion

                #region /// Show

                var show = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Show",
                    Prefix = "show",
                    Description = "Makes the entity visible",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                show.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                show.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = show;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(show.Name, show);

                #endregion

                #region /// Spawn

                var spawn = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Spawn",
                    Prefix = "spawn",
                    Description = "Forces the entity to spawn if not set to spawn at start, except for characters in multiplayer mode",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                spawn.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                spawn.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = spawn;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(spawn.Name, spawn);

                #endregion

                #region /// SetActivated

                var setActivated = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetActivated",
                    Prefix = "setActivated",
                    Description = "Sets the entity as active (v=1) or inactive (v=0)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setActivated.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setActivated.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setActivated;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setActivated.Name, setActivated);

                #endregion

                #region /// ActivateIfUsed

                var activateIfUsed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "ActivateIfUsed",
                    Prefix = "activateIfUsed",
                    Description = "Activates the entity named in the IfUsed properties field",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                activateIfUsed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                activateIfUsed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = activateIfUsed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(activateIfUsed.Name, activateIfUsed);

                #endregion

                #region /// Collected

                var collected = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Collected",
                    Prefix = "collected",
                    Description = "Flag the entity as collected (e.g a key)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                collected.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                collected.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = collected;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(collected.Name, collected);

                #endregion

                #region /// MoveUp

                var moveUp = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "MoveUp",
                    Prefix = "moveUp",
                    Description = "Move the entity up and (v) speed",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                moveUp.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                moveUp.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = moveUp;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(moveUp.Name, moveUp);

                #endregion

                #region /// MoveForward

                var moveForward = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "MoveForward",
                    Prefix = "moveForward",
                    Description = "Move the entity forward and (v) speed",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                moveForward.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                moveForward.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = moveForward;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(moveForward.Name, moveForward);

                #endregion

                #region /// MoveBackward

                var moveBackward = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "MoveBackward",
                    Prefix = "moveBackward",
                    Description = "Move the entity backward and (v) speed",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                moveBackward.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                moveBackward.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = moveBackward;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(moveBackward.Name, moveBackward);

                #endregion

                #region /// SetPosition

                var setPosition = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetPosition",
                    Prefix = "setPosition",
                    Description = "Move the entity to map position x,y,z",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setPosition.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._3in0out));
                setPosition.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setPosition;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "x");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "y");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "z");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setPosition.Name, setPosition);

                #endregion

                #region /// ResetPosition

                var resetPosition = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "ResetPosition",
                    Prefix = "resetPosition",
                    Description = "Reposition a physics entity",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                resetPosition.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._3in0out));
                resetPosition.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = resetPosition;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "x");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "y");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "z");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(resetPosition.Name, resetPosition);

                #endregion

                #region /// SetRotation

                var setRotation = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetRotation",
                    Prefix = "setRotation",
                    Description = "Rotates the entity to angle x,y,z",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setRotation.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._3in0out));
                setRotation.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setRotation;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 150);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "x");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "y");
                    e.Table.Groups[0].Rows[2].Text = e.Table.Groups[0].Rows[2].Text.Replace("Argument", "z");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setRotation.Name, setRotation);

                #endregion

                #region /// ModulateSpeed

                var modulateSpeed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "ModulateSpeed",
                    Prefix = "modulateSpeed",
                    Description = "Modulate the speed of all entity actions by (v)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                modulateSpeed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                modulateSpeed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = modulateSpeed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(modulateSpeed.Name, modulateSpeed);

                #endregion

                #region /// RotateX

                var rotateX = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "RotateX",
                    Prefix = "rotateX",
                    Description = "Rotate the X angle of the entity by (v)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                rotateX.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                rotateX.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = rotateX;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(rotateX.Name, rotateX);

                #endregion

                #region /// RotateY

                var rotateY = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "RotateY",
                    Prefix = "rotateY",
                    Description = "Rotate the Y angle of the entity by (v)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                rotateY.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                rotateY.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = rotateY;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(rotateY.Name, rotateY);

                #endregion

                #region /// RotateZ

                var rotateZ = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "RotateZ",
                    Prefix = "rotateZ",
                    Description = "Rotate the Z angle of the entity by (v)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                rotateZ.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                rotateZ.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = rotateZ;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(rotateZ.Name, rotateZ);

                #endregion

                #region /// Scale

                var scale = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Scale",
                    Prefix = "scale",
                    Description = "Scales an entity to (v) percentage",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                scale.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                scale.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = scale;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(scale.Name, scale);

                #endregion

                #region /// SetAnimation

                var setAnimation = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetAnimation",
                    Prefix = "setAnimation",
                    Description = "Set an animation index value for later use",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setAnimation.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                setAnimation.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setAnimation;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(setAnimation.Name, setAnimation);

                #endregion

                #region /// SetAnimationFrames

                var setAnimationFrames = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetAnimationFrames",
                    Prefix = "setAnimationFrames",
                    Description = "Set the entity animation frame to the range (a) to (b)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setAnimationFrames.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._2in0out));
                setAnimationFrames.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setAnimationFrames;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "a");
                    e.Table.Groups[0].Rows[1].Text = e.Table.Groups[0].Rows[1].Text.Replace("Argument", "b");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setAnimationFrames.Name, setAnimationFrames);

                #endregion

                #region /// PlayAnimation

                var playAnimation = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "PlayAnimation",
                    Prefix = "playAnimation",
                    Description = "Play the current animation range once",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                playAnimation.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                playAnimation.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = playAnimation;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(playAnimation.Name, playAnimation);

                #endregion

                #region /// LoopAnimation

                var loopAnimation = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "LoopAnimation",
                    Prefix = "loopAnimation",
                    Description = "Loop the current animation range",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                loopAnimation.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                loopAnimation.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = loopAnimation;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(loopAnimation.Name, loopAnimation);

                #endregion

                #region /// StopAnimation

                var stopAnimation = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "StopAnimation",
                    Prefix = "stopAnimation",
                    Description = "Stop all animations for the current entity",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                stopAnimation.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                stopAnimation.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = stopAnimation;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(stopAnimation.Name, stopAnimation);

                #endregion

                #region /// SetAnimationSpeed

                var setAnimationSpeed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetAnimationSpeed",
                    Prefix = "setAnimationSpeed",
                    Description = "Set the animation speed of the entity",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setAnimationSpeed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setAnimationSpeed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setAnimationSpeed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setAnimationSpeed.Name, setAnimationSpeed);

                #endregion

                #region /// SetAnimationFrame

                var setAnimationFrame = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetAnimationFrame",
                    Prefix = "setAnimationFrame",
                    Description = "Set the entities animation frame to (v)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setAnimationFrame.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setAnimationFrame.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setAnimationFrame;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setAnimationFrame.Name, setAnimationFrame);

                #endregion

                #region /// GetAnimationFrame

                var getAnimationFrame = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GetAnimationFrame",
                    Prefix = "getAnimationFrame",
                    Description = "Get the animation frame number from the entity",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                getAnimationFrame.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                getAnimationFrame.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = getAnimationFrame;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(getAnimationFrame.Name, getAnimationFrame);

                #endregion

                #region /// SpawnIfUsed

                var spawnIfUsed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SpawnIfUsed",
                    Prefix = "spawnIfUsed",
                    Description = "Spawns the entity named in the IfUsed field of the current entity",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                spawnIfUsed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                spawnIfUsed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = spawnIfUsed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(spawnIfUsed.Name, spawnIfUsed);

                #endregion

                return functions;
            }
        }
    }
}
