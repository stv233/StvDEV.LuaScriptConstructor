using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components.GlobalComponents
{
    /// <summary>
    /// Represent gameguru global character and ai control components.
    /// </summary>
    static class CharacterAndAIControl
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

                #region // CharacterControlUnarmed

                var characterControlUnarmed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "CharacterControlUnarmed",
                    Prefix = "characterControlUnarmed",
                    Description = "Switch character to unarmed state",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                characterControlUnarmed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                characterControlUnarmed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = characterControlUnarmed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(characterControlUnarmed.Name, characterControlUnarmed);

                #endregion

                #region // CharacterControlLimbo

                var characterControlLimbo = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "CharacterControlLimbo",
                    Prefix = "characterControlLimbo",
                    Description = "Switch character to limbo state",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                characterControlLimbo.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                characterControlLimbo.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = characterControlLimbo;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(characterControlLimbo.Name, characterControlLimbo);

                #endregion

                #region // CharacterControlLimbo

                var characterControlArmed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "CharacterControlArmed",
                    Prefix = "characterControlArmed",
                    Description = "Switch character to armed state",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                characterControlArmed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                characterControlArmed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = characterControlArmed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(characterControlArmed.Name, characterControlArmed);

                #endregion

                #region // CharacterControlFidget

                var characterControlFidget = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "CharacterControlFidget",
                    Prefix = "characterControlFidget",
                    Description = "Switch character to fidget state",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                characterControlFidget.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                characterControlFidget.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = characterControlFidget;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(characterControlFidget.Name, characterControlFidget);

                #endregion

                #region // CharacterControlDucked

                var characterControlDucked = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "CharacterControlDucked",
                    Prefix = "characterControlDucked",
                    Description = "Switch character to crouched state",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                characterControlDucked.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                characterControlDucked.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = characterControlDucked;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(characterControlDucked.Name, characterControlDucked);

                #endregion

                #region // CharacterControlStand

                var characterControlStand = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "CharacterControlStand",
                    Prefix = "characterControlStand",
                    Description = "Switch character to stood state",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                characterControlStand.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                characterControlStand.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = characterControlStand;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(characterControlStand.Name, characterControlStand);

                #endregion

                #region // SetCharacterToWalk

                var setCharacterToWalk = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetCharacterToWalk",
                    Prefix = "setCharacterToWalk",
                    Description = "Set the character to walk when moving",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setCharacterToWalk.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                setCharacterToWalk.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setCharacterToWalk;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(setCharacterToWalk.Name, setCharacterToWalk);

                #endregion

                #region // SetCharacterToRun

                var setCharacterToRun = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetCharacterToRun",
                    Prefix = "setCharacterToRun",
                    Description = "Set the character to run when moving",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setCharacterToRun.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                setCharacterToRun.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setCharacterToRun;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(setCharacterToRun.Name, setCharacterToRun);

                #endregion

                #region // SetCharacterToStrafeLeft

                var setCharacterToStrafeLeft = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetCharacterToStrafeLeft",
                    Prefix = "setCharacterToStrafeLeft",
                    Description = "Set the character to strafe left",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setCharacterToStrafeLeft.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                setCharacterToStrafeLeft.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setCharacterToStrafeLeft;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(setCharacterToStrafeLeft.Name, setCharacterToStrafeLeft);

                #endregion

                #region // SetCharacterToStrafeRight

                var setCharacterToStrafeRight = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetCharacterToStrafeRight",
                    Prefix = "setCharacterToStrafeRight",
                    Description = "Set the character to strafe right",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setCharacterToStrafeRight.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                setCharacterToStrafeRight.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setCharacterToStrafeRight;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(setCharacterToStrafeRight.Name, setCharacterToStrafeRight);

                #endregion

                #region // SetCharacterVisionDelay

                var setCharacterVisionDelay = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetCharacterVisionDelay",
                    Prefix = "setCharacterVisionDelay",
                    Description = "Set the speed at which the entity will react after seeing the player",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setCharacterVisionDelay.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setCharacterVisionDelay.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setCharacterVisionDelay;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setCharacterVisionDelay.Name, setCharacterVisionDelay);

                #endregion

                #region // SetAttachmentVisible

                var setAttachmentVisible = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetAttachmentVisible",
                    Prefix = "setAttachmentVisible",
                    Description = "1 sets the entities attachment to be visible (such as their weapon), 0 switches it off",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                setAttachmentVisible.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setAttachmentVisible.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setAttachmentVisible;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(setAttachmentVisible.Name, setAttachmentVisible);

                #endregion

                #region // LockCharacterPosition

                var lockCharacterPosition = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "LockCharacterPosition",
                    Prefix = "lockCharacterPosition",
                    Description = "Lock a character in place. Parameter reserved for future use",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                lockCharacterPosition.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                lockCharacterPosition.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = lockCharacterPosition;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(lockCharacterPosition.Name, lockCharacterPosition);

                #endregion

                #region // UnlockCharacterPosition

                var unlockCharacterPosition = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "UnlockCharacterPosition",
                    Prefix = "unlockCharacterPosition",
                    Description = "UnLock a character. Parameter reserved for future use",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                unlockCharacterPosition.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                unlockCharacterPosition.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = unlockCharacterPosition;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);
                };

                functions.Add(unlockCharacterPosition.Name, unlockCharacterPosition);

                #endregion

                #region // FreezeAI

                var freezeAI = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "FreezeAI",
                    Prefix = "freezeAI",
                    Description = "Freeze all AI",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                freezeAI.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                freezeAI.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = freezeAI;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(freezeAI.Name, freezeAI);

                #endregion

                #region // UnFreezeAI

                var unFreezeAI = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "UnFreezeAI",
                    Prefix = "unFreezeAI",
                    Description = "Unfreeze all AI",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                unFreezeAI.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                unFreezeAI.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = unFreezeAI;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(unFreezeAI.Name, unFreezeAI);

                #endregion

                #region // FireWeapon

                var fireWeapon = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "FireWeapon",
                    Prefix = "fireWeapon",
                    Description = "Unfreeze all AI",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = true,
                };
                fireWeapon.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                fireWeapon.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = fireWeapon;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);
                };

                functions.Add(fireWeapon.Name, fireWeapon);

                #endregion

                return functions;
            }
        }
    }
}
