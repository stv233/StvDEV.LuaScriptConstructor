using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components.GlobalComponents
{
    /// <summary>
    /// Represent gameguru global multi-player components
    /// </summary>
    static class MultiPlayer
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

                #region /// MP_IsServer

                var mP_IsServer = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "MP_IsServer",
                    Prefix = "mP_IsServer",
                    Description = "When developing a multiplayer script, you will need to have code for both the client and the server. " +
                        "Some may be shared (such as a function for displaying the score) but some will need to be server or client only. " +
                        "This command enables you to do just that. a return value of 1 indicates this script is running on the server, " +
                        "0 means this is a client machine",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                mP_IsServer.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in1out));
                mP_IsServer.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = mP_IsServer;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "isServer");

                };

                functions.Add(mP_IsServer.Name, mP_IsServer);

                #endregion

                #region /// SetMultiplayerGameMode

                var setMultiplayerGameMode = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetMultiplayerGameMode",
                    Prefix = "setMultiplayerGameMode",
                    Description = "A game cycle will typically be made up of more than one mode. The simplest example would be: " +
                    "1. Starting the game, setting scores to 0, then heading to mode 2. " +
                    "2. The main game itself, runs until somebody has deemed to have won, then switches to 3. " +
                    "3. Displays the ending scores, stops play and counts down to the next game. heads back to 1. " +
                    "The server is in charge of settings these modes and does so via this command to inform all clients of the mode. " +
                    "It is wise for the server to keep a variable with the mode locally so it doesn't loose track of the mode itself",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setMultiplayerGameMode.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setMultiplayerGameMode.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setMultiplayerGameMode;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "mode");

                    e.Table.Groups.Remove(e.Table.Groups[1]);

                };

                functions.Add(setMultiplayerGameMode.Name, setMultiplayerGameMode);

                #endregion

                #region /// GetMultiplayerGameMode

                var getMultiplayerGameMode = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GetMultiplayerGameMode",
                    Prefix = "getMultiplayerGameMode",
                    Description = "This command enables clients to check which mode the game is in currently. " +
                    "This will have been set by the server previously via SetMultiplayerGameMode(mode)",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                getMultiplayerGameMode.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in1out));
                getMultiplayerGameMode.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = getMultiplayerGameMode;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "mode");

                };

                functions.Add(getMultiplayerGameMode.Name, getMultiplayerGameMode);

                #endregion

                #region /// SetServerTimer

                var setServerTimer = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetServerTimer",
                    Prefix = "setServerTimer",
                    Description = "Enables the server to set a timer (perhaps to trigger the end of the game) That can be picked up by clients via GetServerTimer()",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setServerTimer.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setServerTimer.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setServerTimer;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "t");

                    e.Table.Groups.Remove(e.Table.Groups[1]);

                };

                functions.Add(setServerTimer.Name, setServerTimer);

                #endregion

                #region /// GetServerTimer

                var getServerTimer = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GetServerTimer",
                    Prefix = "getServerTimer",
                    Description = "Returns the time the timer was set by the server using SetServerTimer()",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                getServerTimer.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in1out));
                getServerTimer.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = getServerTimer;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "t");

                };

                functions.Add(getServerTimer.Name, getServerTimer);

                #endregion

                #region /// GetServerTimerPassed

                var getServerTimerPassed = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GetServerTimerPassed",
                    Prefix = "getServerTimerPassed",
                    Description = "Returns how much time has passed since the server first set the timer up",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                getServerTimerPassed.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in1out));
                getServerTimerPassed.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = getServerTimerPassed;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "time");

                };

                functions.Add(getServerTimerPassed.Name, getServerTimerPassed);

                #endregion

                #region /// ServerRespawnAll

                var serverRespawnAll = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "ServerRespawnAll",
                    Prefix = "serverRespawnAll",
                    Description = "This command is the companion to ServerEndPlay() and will allow for play to carry on, by first triggering everyone to spawn in. T" +
                    "his will be used to kick off a new round after the completion of the previous round",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                serverRespawnAll.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                serverRespawnAll.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = serverRespawnAll;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);

                };

                functions.Add(serverRespawnAll.Name, serverRespawnAll);

                #endregion

                #region /// ServerEndPlay

                var serverEndPlay = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "ServerEndPlay",
                    Prefix = "serverEndPlay",
                    Description = "When a game has been won, this command can be used to stop any further gameplay taking place. " +
                    "The camera will change to a top down view of the current level and presents the perfect time to show scores and perhaps set a countdown to the next round. " +
                    "If anyone is dead they will spawn back in still, but then switch to the top down view along with everyone else",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                serverEndPlay.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in0out));
                serverEndPlay.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = serverEndPlay;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 40);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups.Remove(e.Table.Groups[0]);
                    e.Table.Groups.Remove(e.Table.Groups[0]);

                };

                functions.Add(serverEndPlay.Name, serverEndPlay);

                #endregion

                #region /// GetShowScores

                var getShowScores = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "GetShowScores",
                    Prefix = "getShowScores",
                    Description = "If a player presses tab in game to show the scores, GetShowScores() will return a 1. " +
                    "After a short delay of a player pressing tab it is set back to 0. " +
                    "Use this command when game play is in full swing to show the current scoring of all playings",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                getShowScores.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._0in1out));
                getShowScores.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = getShowScores;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[1].Rows[0].Text = e.Table.Groups[1].Rows[0].Text.Replace("Return", "showScores");

                };

                functions.Add(getShowScores.Name, getShowScores);

                #endregion

                #region /// SetServerKillsToWin

                var setServerKillsToWin = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "SetServerKillsToWin",
                    Prefix = "setServerKillsToWin",
                    Description = "This command allows the LUA script to inform the game engine how many kills are needed to win (if any). " +
                    "This is needed so the game engine knows when to stop updating kills in a match. " +
                    "For example when someone has won a game, any kills after that need to be not counted. " +
                    "This command enables that functionality",
                    Type = Types.Function.FuntionTypes.Regular,
                    NeedRebuild = true,
                    Diagram = new Forms.ConstructorDiagram(),
                    AccessType = Types.Variable.VariableAccessTypes.InputOutput,
                    NeedEntityId = false,
                };
                setServerKillsToWin.Diagram.DeserializeFromString(System.Text.Encoding.UTF8.GetString(Properties.Resources._1in0out));
                setServerKillsToWin.TableRebuilding += (object s, Types.ProgrammaticallyDefinedFunction.RebuildEventArgs e) =>
                {
                    e.Table.Icon = Properties.Resources.GG_16x;
                    e.Table.Type = Shapes.ConstructorTable.ConstructorTableTypes.Function;
                    e.Table.Label = new Crainiate.Diagramming.Label(e.Table.Function.Description);
                    e.Table.Function = setServerKillsToWin;
                    e.Table.Heading = e.Table.Function.Name;
                    e.Table.SubHeading = e.Table.Function.Description;
                    e.Table.MinimumSize = new System.Drawing.SizeF(e.Table.Size.Width + 40, 100);
                    e.Table.Size = e.Table.MinimumSize;

                    e.Table.Groups[0].Rows[0].Text = e.Table.Groups[0].Rows[0].Text.Replace("Argument", "v");

                    e.Table.Groups.Remove(e.Table.Groups[1]);

                };

                functions.Add(setServerKillsToWin.Name, setServerKillsToWin);

                #endregion

                return functions;
            }
        }
    }
}
