using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components.GlobalComponents
{
    /// <summary>
    /// Represent gameguru global entitys control components.
    /// </summary>
    static class EntityControl
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

                #region // SetEntityHealth

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

                #region // StartTimer

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

                #region // GetTimer

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

                #region // Destroy

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

                #region // CollisionOn

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

                #region // CollisionOff

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

                #region // GravityOff

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

                #region // GravityOn

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

                #region // LookAtPlayer

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

                #region // RotateToPlayer

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

                #region // RotateToPlayerSlowly

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

                #region // Hide

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

                #region // Show

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

                #region // Spawn

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

                #region // SetActivated

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

                #region // ActivateIfUsed

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

                #region // Collected

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

                #region // MoveUp

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

                #region // MoveForward

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

                #region // MoveBackward

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

                #region // SetPosition

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

                #region // ResetPosition

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

                #region // setRotation

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

                return functions;
            }
        }
    }
}
