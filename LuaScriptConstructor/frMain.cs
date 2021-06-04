using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using LuaScriptConstructor.Forms;
using System.IO;

namespace LuaScriptConstructor
{
    public partial class frMain : Form
    {
        private static string _status = "";
        private Forms.ConstructorTreeView.ConstructorTreeView ctvMain;
        private TradeWright.UI.Forms.TabControlExtra tcMain;
        private int functionsCounter = 0;
        private string projectPath = "";
        private static ToolStripLabel tslStatus;

        #region /// Console

        /// <summary>
        /// Script constructor console.
        /// </summary>
        public static ConsoleControl.ConsoleControl ConstructorConsole { get; set; }

        /// <summary>
        /// Print message in console.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="color">Color</param>
        public static void ConsoleMessage(string message, System.Drawing.Color color, bool time = true)
        {
            ConstructorConsole.WriteOutput( ((time == true) ? "[" + System.DateTime.Now.ToLongTimeString() + "]:> " : "") + message, color);
        }

        /// <summary>
        /// Print log in console.
        /// </summary>
        /// <param name="log">Log</param>
        public static void ConsoleLog(string log)
        {
            ConsoleMessage(log + "\n", UserSettings.ColorScheme.ForeColor);
        }

        /// <summary>
        /// Print warning in console.
        /// </summary>
        /// <param name="warning">Warning</param>
        public static void ConsoleWarning(string warning)
        {
            ConsoleMessage("Warrning! " + warning + "\n", System.Drawing.Color.Gold);
        }

        /// <summary>
        /// Print error in console.
        /// </summary>
        /// <param name="error">Error</param>
        public static void ConsoleError(string error)
        {
            ConsoleMessage("Error! " + error + "\n", System.Drawing.Color.Red);
        }

        #endregion

        /// <summary>
        /// Programm status.
        /// </summary>
        public static string Status
        {
            get
            {
                return _status;
            }
            set
            {
                ConsoleLog(value);
                tslStatus.Text = value;
                _status = value;
            }
        }

        /// <summary>
        /// Project functions as object.
        /// </summary>
        private Dictionary<string, Types.Function> projectFunctions { get; set; }

        public frMain()
        {

            #region /// Initialization

            #region /// Form

            this.Size = UserSettings.Size;
            this.SizeChanged += (s, e) =>
            {
                UserSettings.Size = this.Size;
            };
            this.Location = UserSettings.Location;
            this.LocationChanged += (s, e) =>
            {
                UserSettings.Location = this.Location;
            };
            this.Text = Application.ProductName;
            this.BackColor = UserSettings.ColorScheme.MainColor;
            this.ForeColor = UserSettings.ColorScheme.ForeColor;

            #endregion

            #region /// Auto snapshots

            var tmSnapshotTimer = new Timer { Interval = UserSettings.AutoSnapshotDelay * 60 * 1000 };
            tmSnapshotTimer.Tick += (s, e) =>
            {
                if (UserSettings.AutoSnapshot)
                {
                    foreach (DiagramTabPage tabPage in tcMain.TabPages)
                    {
                        tabPage.Diagram.TakeSnapshot();
                    }

                    tmSnapshotTimer.Interval = UserSettings.AutoSnapshotDelay * 60 * 1000;
                }
            };
            tmSnapshotTimer.Start();

            #endregion

            #region /// Crainiate

            Crainiate.Diagramming.Singleton.Instance.KeyCreateMode = Crainiate.Diagramming.KeyCreateMode.HashCode;

            #endregion

            #region /// Properties

            projectFunctions = new Dictionary<string, Types.Function>();

            #endregion

            #region /// Menu Strip

            var msMain = new MenuStrip
            {
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Parent = this
            };
            msMain.Renderer = new Forms.Rendering.ConstructorMenuStripRender();

            #region /// File

            var tsmiFile = new ToolStripMenuItem
            {
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "File"
            };
            msMain.Items.Add(tsmiFile);

            var tsmiNew = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "New",
                ShortcutKeyDisplayString = "Ctrl+N",
                ShortcutKeys = Keys.Control | Keys.N,
                Image = Properties.Resources.NewFile_16x
            };
            tsmiFile.DropDownItems.Add(tsmiNew);

            var tsmiOpen = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Open...",
                ShortcutKeyDisplayString = "Ctrl+O",
                ShortcutKeys = Keys.Control | Keys.O,
                Image = Properties.Resources.OpenFile_16x
            };
            tsmiFile.DropDownItems.Add(tsmiOpen);

            var tsmiSave = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Save",
                ShortcutKeyDisplayString = "Ctrl+S",
                ShortcutKeys = Keys.Control | Keys.S,
                Image = Properties.Resources.Save_16x
            };
            tsmiFile.DropDownItems.Add(tsmiSave);

            var tsmiSaveAs = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Save as...",
                Image = Properties.Resources.SaveAs_16x
            };
            tsmiFile.DropDownItems.Add(tsmiSaveAs);

            tsmiFile.DropDownItems.Add(new ToolStripSeparator());

            var tsmiClose = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Close",
                ShortcutKeyDisplayString = "Alt+F4",
                ShortcutKeys = Keys.Alt | Keys.F4,
                Image = Properties.Resources.Close_16x
            };
            tsmiFile.DropDownItems.Add(tsmiClose);

            #endregion

            #region /// Edit

            var tsmiEdit = new ToolStripMenuItem
            {
                Text = "Edit"
            };
            msMain.Items.Add(tsmiEdit);

            var tsmiTakeSnapshot = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Take snapshot",
                ShortcutKeyDisplayString = "F5",
                ShortcutKeys = Keys.F5,
                Image = Properties.Resources.TakeSnapshot_16x
            };
            tsmiEdit.DropDownItems.Add(tsmiTakeSnapshot);

            var tsmiRestoreLastSnapshot = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Restore last snapshot",
                ShortcutKeyDisplayString = "F9",
                ShortcutKeys = Keys.F9,
                Image = Properties.Resources.RestoreSnapshot_16x
            };
            tsmiEdit.DropDownItems.Add(tsmiRestoreLastSnapshot);

            var tsmiSnapshots = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Snapshots...",
                ShortcutKeyDisplayString = "Shift+F9",
                ShortcutKeys = Keys.Shift | Keys.F9,
                Image = Properties.Resources.ViewSnapshots_16x
            };
            tsmiEdit.DropDownItems.Add(tsmiSnapshots);

            #endregion

            #region /// Build

            var tsmiBuild = new ToolStripMenuItem
            {
                Text = "Build"
            };
            msMain.Items.Add(tsmiBuild);

            var tsmiBuildFunction = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Build function",
                ShortcutKeyDisplayString = "Shift+F6",
                Image = Properties.Resources.BuildSelection_16x
            };
            tsmiBuild.DropDownItems.Add(tsmiBuildFunction);

            var tsmiBuildAll = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Build all...",
                ShortcutKeyDisplayString = "F6",
                ShortcutKeys = Keys.F6,
                Image = Properties.Resources.BuildSolution_16x
            };
            tsmiBuild.DropDownItems.Add(tsmiBuildAll);

            #endregion

            #region /// Functions

            var tsmiFunctions = new ToolStripMenuItem
            {
                Text = "Functions"
            };
            msMain.Items.Add(tsmiFunctions);

            var tsmiAddFunction = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "New function graph",
                Image = Properties.Resources.NewGraph_16x,
                ShortcutKeyDisplayString = "Ctrl+G",
                ShortcutKeys = Keys.Control | Keys.G
            };
            tsmiFunctions.DropDownItems.Add(tsmiAddFunction);

            var tsmiRemoveFunction = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Close function graph",
                Image = Properties.Resources.Close_red_16x,
                ShortcutKeyDisplayString = "Ctrl+Shift+G",
                ShortcutKeys = Keys.Control | Keys.Shift | Keys.G
            };
            tsmiFunctions.DropDownItems.Add(tsmiRemoveFunction);

            var tsmiAddFavorite = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Add function graph to favorites",
                Image = Properties.Resources.AddFavorite_16x,
                ShortcutKeyDisplayString = "Ctrl+F",
                ShortcutKeys = Keys.Control | Keys.F,
                Enabled = false
            };
            tsmiFunctions.DropDownItems.Add(tsmiAddFavorite);

            var tsmiFavorites = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Favorites graphs",
                Image = Properties.Resources.Favorite_16x,
                Visible = (Favorites.Dictionary.Count > 0)
            };
            tsmiFunctions.DropDownItems.Add(tsmiFavorites);
            Favorites.FavoritesRefreshed += (e) =>
            {
                tsmiFavorites.Visible = (Favorites.Dictionary.Count > 0);
                tsmiFavorites.DropDownItems.Clear();
                foreach (string key in Favorites.Dictionary.Keys)
                {
                    var tsmiFavorite = new ToolStripMenuItem
                    {
                        ForeColor = UserSettings.ColorScheme.ForeColor,
                        Text = key,
                        Image = Properties.Resources.UserFunction_16x,
                    };
                    tsmiFavorites.DropDownItems.Add(tsmiFavorite);

                    var tsmiLoad = new ToolStripMenuItem
                    {
                        ForeColor = UserSettings.ColorScheme.ForeColor,
                        Text = "Open",
                        Image = Properties.Resources.Open_16x,
                    };
                    tsmiLoad.Click += (s, ev) =>
                    {
                        if (projectFunctions.ContainsKey(key))
                        {
                            if (MessageBox.Show("The project already contains a function with the given name. Rewrite it?",
                                "Open favorite graph", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                foreach (DiagramTabPage tabPage in tcMain.TabPages)
                                {
                                    if (tabPage.Text == key)
                                    {
                                        tabPage.Diagram.DeserializeFromString(Favorites.Dictionary[key]);
                                        ReconnectDiagramTables(tabPage.Diagram);
                                        break;
                                    }
                                }
                                return;
                            }
                            else { return; }
                        }
                        else
                        {
                            var tabPage = NewFunctionTabPage();
                            tabPage.Diagram.DeserializeFromString(Favorites.Dictionary[key]);
                            ReconnectDiagramTables(tabPage.Diagram);
                        }
                    };
                    tsmiFavorite.DropDownItems.Add(tsmiLoad);

                    var tsmiRemove = new ToolStripMenuItem
                    {
                        ForeColor = UserSettings.ColorScheme.ForeColor,
                        Text = "Remove",
                        Image = Properties.Resources.Close_red_16x
                    };
                    tsmiRemove.Click += (s, ev) =>
                    {
                        if (!(MessageBox.Show("Are you sure you want to remove the function graph from your favorites? This action cannot be undone.",
                            "Remove from favorites", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            return;
                        }

                        Favorites.Remove(key);
                    };
                    tsmiFavorite.DropDownItems.Add(tsmiRemove);
                }
            };
            Favorites.Refresh();

            #endregion

            #region /// Options

            var tsmiProgram = new ToolStripMenuItem
            {
                Text = "Options"
            };
            msMain.Items.Add(tsmiProgram);

            var tsmiSettings = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Settings...",
                Image = Properties.Resources.Settings_16x
            };
            tsmiProgram.DropDownItems.Add(tsmiSettings);

            var tsmiInstallLibrary = new ToolStripMenuItem
            {
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "Install script constructor library...",
                Image = Properties.Resources.Library_16x
            };
            tsmiProgram.DropDownItems.Add(tsmiInstallLibrary);

            #endregion

            #endregion

            #region /// MenuToolStrip

            var tsMenu = new ToolStrip
            {
                AutoSize = false,
                ShowItemToolTips = true,
                GripStyle = ToolStripGripStyle.Hidden,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Renderer = new Forms.Rendering.ConstructorToolStripRender(),
                Parent = this
            };
            tsMenu.BringToFront();

            #region /// File

            var tsbNew = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiNew.Image,
                ToolTipText = tsmiNew.Text + " (" + tsmiNew.ShortcutKeyDisplayString + ")"
            };
            tsbNew.Click += (s, e) => { tsmiNew.PerformClick(); };
            tsMenu.Items.Add(tsbNew);

            var tsbOpen = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiOpen.Image,
                ToolTipText = tsmiOpen.Text + " (" + tsmiOpen.ShortcutKeyDisplayString + ")"
            };
            tsbOpen.Click += (s, e) => { tsmiOpen.PerformClick(); };
            tsMenu.Items.Add(tsbOpen);

            var tsbSave = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiSave.Image,
                ToolTipText = tsmiSave.Text + " (" + tsmiSave.ShortcutKeyDisplayString + ")"
            };
            tsbSave.Click += (s, e) => { tsmiSave.PerformClick(); };
            tsMenu.Items.Add(tsbSave);

            #endregion

            #region /// Edit

            tsMenu.Items.Add(new ToolStripSeparator());

            var tsbTakeSnapshot = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiTakeSnapshot.Image,
                ToolTipText = tsmiTakeSnapshot.Text + " (" + tsmiTakeSnapshot.ShortcutKeyDisplayString + ")"
            };
            tsbTakeSnapshot.Click += (s, e) => { tsmiTakeSnapshot.PerformClick(); };
            tsMenu.Items.Add(tsbTakeSnapshot);

            var tsbRestoreLastSnapshot = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiRestoreLastSnapshot.Image,
                ToolTipText = tsmiRestoreLastSnapshot.Text  + " (" + tsmiRestoreLastSnapshot.ShortcutKeyDisplayString + ")"
            };
            tsbRestoreLastSnapshot.Click += (s, e) => { tsmiRestoreLastSnapshot.PerformClick(); };
            tsMenu.Items.Add(tsbRestoreLastSnapshot);

            var tsbShapshots = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiSnapshots.Image,
                ToolTipText = tsmiSnapshots.Text + " (" + tsmiSnapshots.ShortcutKeyDisplayString + ")"
            };
            tsbShapshots.Click += (s, e) => { tsmiSnapshots.PerformClick(); };
            tsMenu.Items.Add(tsbShapshots);

            #endregion

            #region /// Build

            tsMenu.Items.Add(new ToolStripSeparator());

            var tsbBuildFunction = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiBuildFunction.Image,
                ToolTipText = tsmiBuildFunction.Text + " (" + tsmiBuildFunction.ShortcutKeyDisplayString + ")",
            };
            tsbBuildFunction.Click += (s, e) => { tsmiBuildFunction.PerformClick(); };
            tsMenu.Items.Add(tsbBuildFunction);

            var tsbBuildAll = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiBuildAll.Image,
                ToolTipText = tsmiBuildAll.Text + " (" + tsmiBuildAll.ShortcutKeyDisplayString + ")"
            };
            tsbBuildAll.Click += (s, e) => { tsmiBuildAll.PerformClick(); };
            tsMenu.Items.Add(tsbBuildAll);


            #endregion

            #region /// Functions

            tsMenu.Items.Add(new ToolStripSeparator());

            var tsbAddFunction = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiAddFunction.Image,
                ToolTipText = tsmiAddFunction.Text + " (" + tsmiAddFunction.ShortcutKeyDisplayString + ")"
            };
            tsbAddFunction.Click += (s, e) => { tsmiAddFunction.PerformClick(); };
            tsMenu.Items.Add(tsbAddFunction);

            var tsbRemoveFunction = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiRemoveFunction.Image,
                ToolTipText = tsmiRemoveFunction.Text + " (" + tsmiRemoveFunction.ShortcutKeyDisplayString + ")"
            };
            tsbRemoveFunction.Click += (s, e) => { tsmiRemoveFunction.PerformClick(); };
            tsMenu.Items.Add(tsbRemoveFunction);

            var tsbAddFavorite = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiAddFavorite.Image,
                ToolTipText = tsmiAddFavorite.Text + " (" + tsmiAddFavorite.ShortcutKeyDisplayString + ")",
                Enabled = tsmiAddFavorite.Enabled
            };
            tsbAddFavorite.Click += (s, e) => { tsmiAddFavorite.PerformClick(); };
            tsMenu.Items.Add(tsbAddFavorite);

            #endregion

            #endregion

            #region /// StatusToolStrup

            var tsStatus = new ToolStrip
            {
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Parent = this,
                AutoSize = false,
                GripStyle = ToolStripGripStyle.Hidden,
                Renderer = new Forms.Rendering.ConstructorToolStripRender(),
                Dock = DockStyle.Bottom,
            };

            tslStatus = new ToolStripLabel
            {
                Dock = DockStyle.Left
            };
            tsStatus.Items.Add(tslStatus);

            var tslCopyright = new ToolStripLabel
            {
                Text = "Copyright © 2021 StvDev.PRO",
                Alignment = ToolStripItemAlignment.Right,
                Dock = DockStyle.Right
            };
            tsStatus.Items.Add(tslCopyright);

            #endregion

            #region /// SplitContainer

            var scMain = new SplitContainer
            {
                Width = this.ClientSize.Width,
                Height = this.ClientSize.Height - msMain.Height - tsMenu.Height - tslStatus.Height - 3,
                SplitterDistance = this.ClientSize.Width / 10 * 4,
                Left = 0,
                Top = msMain.Height + tsMenu.Height,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Parent = this
            };

            var htbSearch = new Windows.Forms.HintTextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = UserSettings.ColorScheme.SecondaryColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                TextForeColor = UserSettings.ColorScheme.ForeColor,
                HintColor = UserSettings.ColorScheme.GridColor,
                HintValue = "⁣S⁣e⁣a⁣r⁣c⁣h⁣",
                Height = 5,
                Dock = DockStyle.Top,  
                Parent = scMain.Panel1
            };

            #region /// Tree view

            ctvMain = new Forms.ConstructorTreeView.ConstructorTreeView
            {
                BackColor = UserSettings.ColorScheme.SecondaryColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                LineColor = UserSettings.ColorScheme.ForeColor,
                Width = scMain.Panel1.ClientSize.Width,
                Height = scMain.Panel1.ClientSize.Height - htbSearch.Height + 1,
                Top = htbSearch.Height - 1,
                Font = new System.Drawing.Font(Font.FontFamily, 10, System.Drawing.FontStyle.Regular),
                Parent = scMain.Panel1
            };
            ctvMain.AddCategory("Basic");

            #region /// Basic

            foreach (Types.Constant constant in Components.BasicComponents.Constants.Values)
            {
                ctvMain.Add("Basic", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.BasicComponents.Variables.Values)
            {
                ctvMain.Add("Basic", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.BasicComponents.Functions.Values)
            {
                ctvMain.Add("Basic", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            #endregion

            #region /// Values

            foreach (Types.Constant constant in Components.ValuesComponents.Constants.Values)
            {
                ctvMain.Add("Basic\\Values", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.ValuesComponents.Variables.Values)
            {
                ctvMain.Add("Basic\\Values\\Variables", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.ValuesComponents.Functions.Values)
            {
                ctvMain.Add("Basic\\Values\\Variables", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            #endregion

            #region /// Math

            foreach (Types.Constant constant in Components.MathematicalComponents.Constants.Values)
            {
                ctvMain.Add("Basic\\Calculations", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.MathematicalComponents.Variables.Values)
            {
                ctvMain.Add("Basic\\Calculations", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.MathematicalComponents.Functions.Values)
            {
                ctvMain.Add("Basic\\Calculations", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            #endregion

            #region /// Comparison

            foreach (Types.Constant constant in Components.ComparisonComponents.Constants.Values)
            {
                ctvMain.Add("Basic\\Comparisons", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.ComparisonComponents.Variables.Values)
            {
                ctvMain.Add("Basic\\Comparisons", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.ComparisonComponents.Functions.Values)
            {
                ctvMain.Add("Basic\\Comparisons", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            #endregion

            #region /// Logical

            foreach (Types.Constant constant in Components.LogicalComponents.Constants.Values)
            {
                ctvMain.Add("Basic\\Logical", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.LogicalComponents.Variables.Values)
            {
                ctvMain.Add("Basic\\Logical", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.LogicalComponents.Functions.Values)
            {
                ctvMain.Add("Basic\\Logical", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            #endregion

            #region /// Types

            foreach (Types.Constant constant in Components.TypesComponents.Constants.Values)
            {
                ctvMain.Add("Basic\\Types", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.TypesComponents.Variables.Values)
            {
                ctvMain.Add("Basic\\Types", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            foreach (Types.Constant constant in Components.TypesComponents.Functions.Values)
            {
                ctvMain.Add("Basic\\Types", new Forms.ConstructorTreeView.ConstructorTreeNode(constant));
            }

            #endregion

            #region /// Function components

            foreach (Types.Variable variable in Components.FunctionComponents.Constants.Values)
            {
                ctvMain.Add("Function components", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            foreach (Types.Variable variable in Components.FunctionComponents.Variables.Values)
            {
                 ctvMain.Add("Function components", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            foreach (Types.Variable variable in Components.FunctionComponents.Functions.Values)
            {
                ctvMain.Add("Function components", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            #endregion

            #region /// GameGuru

            #region /// Global

            #region /// Text

            foreach (Types.Variable variable in Components.GlobalComponents.Text.Constants.Values)
            {
                ctvMain.Add("GameGur\\Global\\Text", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            foreach (Types.Variable variable in Components.GlobalComponents.Text.Variables.Values)
            {
                ctvMain.Add("GameGuru\\Global\\Text", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            foreach (Types.Variable variable in Components.GlobalComponents.Text.Functions.Values)
            {
                ctvMain.Add("GameGuru\\Global\\Text", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            #endregion

            #region /// Visuals

            foreach (Types.Variable variable in Components.GlobalComponents.Visuals.Constants.Values)
            {
                ctvMain.Add("GameGuru\\Global\\Visuals", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            foreach (Types.Variable variable in Components.GlobalComponents.Visuals.Variables.Values)
            {
                ctvMain.Add("GameGuru\\Global\\Visuals", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            foreach (Types.Variable variable in Components.GlobalComponents.Visuals.Functions.Values)
            {
                ctvMain.Add("GameGuru\\Global\\Visuals", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            #endregion

            #region /// LevelControl

            foreach (Types.Variable variable in Components.GlobalComponents.LevelControl.Constants.Values)
            {
                ctvMain.Add("GameGuru\\Global\\Level Control", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            foreach (Types.Variable variable in Components.GlobalComponents.LevelControl.Variables.Values)
            {
                ctvMain.Add("GameGuru\\Global\\Level Control", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            foreach (Types.Variable variable in Components.GlobalComponents.LevelControl.Functions.Values)
            {
                ctvMain.Add("GameGuru\\Global\\Level Control", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            #endregion

            #endregion

            #endregion

            foreach (var functionObject in projectFunctions.Values)
            {
                if (functionObject is Types.Function)
                {
                    var function = functionObject as Types.Function;
                    ctvMain.Add("Projects finctions",new Forms.ConstructorTreeView.ConstructorTreeNode(function));
                }
            }

            #endregion

            #region /// WorkArea

            var scWorkArea = new SplitContainer
            {
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                BorderStyle = BorderStyle.None,
                Orientation = Orientation.Horizontal,
                SplitterDistance = scMain.Panel2.Height / 3 * 2,
                Width = scMain.Panel2.ClientSize.Width,
                Height = scMain.Panel2.ClientSize.Height,
                Parent = scMain.Panel2
            };

            #region /// Tab Control

            tcMain = new TradeWright.UI.Forms.TabControlExtra
            {
                Width = scWorkArea.Panel1.ClientSize.Width,
                Height = scWorkArea.Panel1.ClientSize.Height,
                Parent = scWorkArea.Panel1
            };
            tcMain.DisplayStyleProvider.TabColorFocused1 = UserSettings.ColorScheme.SecondaryColor;
            tcMain.DisplayStyleProvider.TabColorHighLighted1 = UserSettings.ColorScheme.MainColor;
            tcMain.DisplayStyleProvider.TabColorHighLighted2 = UserSettings.ColorScheme.SecondaryColor;
            tcMain.DisplayStyleProvider.TextColorFocused = UserSettings.ColorScheme.ForeColor;
            tcMain.DisplayStyleProvider.TextColorSelected = UserSettings.ColorScheme.ForeColor;
            tcMain.DisplayStyleProvider.TextColorUnselected = UserSettings.ColorScheme.ForeColor;
            tcMain.DisplayStyleProvider.TextColorHighlighted = UserSettings.ColorScheme.ForeColor;
            //tcMain.DisplayStyleProvider.TabColorDisabled1 = UserSettings.ColorScheme.MainColor;
            tcMain.DisplayStyleProvider.TabColorSelected1 = UserSettings.ColorScheme.MainColor;
            tcMain.DisplayStyleProvider.TabColorUnSelected1 = UserSettings.ColorScheme.MainColor;

            var tpMain = new DiagramTabPage("Main");
            tpMain.Diagram.Type = ConstructorDiagram.ConstructorDiagramTypes.Main;
            tpMain.Diagram.OnSnapshotRestored += (s, e) =>
            {
                ReconnectDiagramTables(tpMain.Diagram);
            };

            tcMain.TabPages.Add(tpMain);

            #endregion

            #region /// Console

            ConstructorConsole = new ConsoleControl.ConsoleControl
            {
                BorderStyle = BorderStyle.None,
                BackColor = UserSettings.ColorScheme.SecondaryColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                IsInputEnabled = false,
                Width = scWorkArea.Panel2.ClientSize.Width - 2,
                Height = scWorkArea.Panel2.ClientSize.Height,
                Parent = scWorkArea.Panel2
            };
            ConstructorConsole.StartProcess(new System.Diagnostics.ProcessStartInfo());

            #endregion

            #endregion

            #endregion

            #region /// Status

            Status = "Ready";

            #endregion

            #endregion

            #region /// Events

            #region /// Resizes

            scMain.Panel1.Resize += (s, e) =>
            {
                ctvMain.Width = scMain.Panel1.ClientSize.Width;
                ctvMain.Height = scMain.Panel1.ClientSize.Height - htbSearch.Height + 1;
            };

            scMain.Panel2.Resize += (s, e) =>
            {
                float ratio = (float)scWorkArea.SplitterDistance / (float)scWorkArea.ClientSize.Height;
                scWorkArea.Width = scMain.Panel2.ClientSize.Width;
                scWorkArea.Height = scMain.Panel2.ClientSize.Height;
                scWorkArea.SplitterDistance = (int)(scWorkArea.ClientSize.Height * ratio);
            };

            scWorkArea.Panel1.Resize += (s, e) =>
            {
                tcMain.Width = scWorkArea.Panel1.ClientSize.Width;
                tcMain.Height = scWorkArea.Panel1.ClientSize.Height;
            };

            scWorkArea.Panel2.Resize += (s, e) =>
            {
                ConstructorConsole.Width = scWorkArea.Panel2.ClientSize.Width - 2;
                ConstructorConsole.Height = scWorkArea.Panel2.ClientSize.Height;
            };

            this.Resize += (s, e) =>
            {
                scMain.Width = this.ClientSize.Width;
                scMain.Height = this.ClientSize.Height - msMain.Height - tsMenu.Height - tslStatus.Height - 3;
            };

            #endregion

            this.Load += (s, e) =>
            {
                ConsoleMessage(Application.ProductName + " is loaded and ready to go\n", System.Drawing.Color.Blue);
            };

            tcMain.SelectedIndexChanged += (s, e) =>
            {
                tsmiAddFavorite.Enabled = tsbAddFavorite.Enabled = (tcMain.SelectedIndex != 0);
            };

            tsmiNew.Click += (s, e) =>
            {
                if (MessageBox.Show("Are you sure you want to create a new project?", "New project?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    New();
                }
            };

            tsmiSave.Click += (s, e) =>
            {
                if (String.IsNullOrEmpty(projectPath))
                {
                    tsmiSaveAs.PerformClick();
                }
                else
                {
                    this.Text = Application.ProductName + " - " + Path.GetFileName(projectPath);
                    Save(projectPath);
                }
            };

            tsmiSaveAs.Click += (s, e) =>
            {
                using (var sfd = new SaveFileDialog
                {
                    RestoreDirectory = true,
                    InitialDirectory = ((!String.IsNullOrEmpty(projectPath)) ? Path.GetDirectoryName(projectPath) : UserSettings.GameGuruPath + "\\Files"),
                    FileName = ((!String.IsNullOrEmpty(projectPath)) ? Path.GetFileName(projectPath) : "NewLuaSctiptProject"),
                    Filter = "Lua script project (*.LUASP)|*.luasp|All files (*.*)|*.*"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        projectPath = sfd.FileName;
                        this.Text = Application.ProductName + " - " + Path.GetFileName(projectPath);
                        Save(projectPath);
                    }
                }
            };

            tsmiOpen.Click += (s, e) =>
            {
                using (var ofd = new OpenFileDialog
                {
                    RestoreDirectory = true,
                    InitialDirectory = ((!String.IsNullOrEmpty(projectPath)) ? Path.GetDirectoryName(projectPath) : Path.GetFullPath(UserSettings.GameGuruPath + "\\Files")),
                    Filter = "Lua script project (*.LUASP)|*.luasp|All files (*.*)|*.*"
                })
                {
                   
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        projectPath = ofd.FileName;
                        this.Text = Application.ProductName + " - " + Path.GetFileName(projectPath);
                        Open(projectPath);
                    }
                }
            };

            tsmiTakeSnapshot.Click += (s, e) =>
            {
                (tcMain.SelectedTab as DiagramTabPage).Diagram.TakeSnapshot();
            };

            tsmiRestoreLastSnapshot.Click += (s, e) =>
            {
                (tcMain.SelectedTab as DiagramTabPage).Diagram.RestoreLastSnapshot();
            };

            tsmiSnapshots.Click += (s, e) =>
            {
                (tcMain.SelectedTab as DiagramTabPage).Diagram.RestoreSnapshot();
            };

            tsmiBuildFunction.Click += (s, e) =>
            {
                (tcMain.SelectedTab as DiagramTabPage).Diagram.Build();
            };

            tsmiBuildAll.Click += (s, e) =>
            {
                using (var sfd = new SaveFileDialog { Filter = "Lua script (*.lua)|*.lua|All files (*.*)|*.*" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        BuildAll(sfd.FileName);
                    }
                }
            };

            tsmiAddFunction.Click += (s, e) =>
            {
                NewFunctionTabPage();
            };

            tsmiRemoveFunction.Click += (s, e) =>
            {
                if (((DiagramTabPage)tcMain.SelectedTab).Diagram.Type != ConstructorDiagram.ConstructorDiagramTypes.Main)
                {
                    if (MessageBox.Show("Are you sure you want to close the function graph? This action cannot be undone.",
                        "Close function graph", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        projectFunctions.Remove(tcMain.SelectedTab.Text);
                        tcMain.TabPages.Remove(tcMain.SelectedTab);
                        RefreshProjectFunction();
                    }
                }
            };

            tsmiAddFavorite.Click += (s, e) =>
            {
                Favorites.Add(tcMain.SelectedTab.Text, (tcMain.SelectedTab as DiagramTabPage).Diagram.SerializeToString());
            };

            tsmiSettings.Click += (s, e) =>
            {
                new frSettings().ShowDialog();
            };

            tsmiInstallLibrary.Click += (s, e) =>
            {
                if (!(MessageBox.Show("The script constructor library contains the functions necessary for the " +
                    "functioning of scripts assembled on the constructor. You can find it along the path " + UserSettings.GameGuruPath +
                    "\\Files\\scriptbank\\StvDEVScriptConstructor.bin . " +
                    "Do not forget to copy it to the standalone version of your project. " +
                    "\nContinue with the installation?", "Installing the library", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    return;
                }

                try
                {
                    ConsoleLog("Installing the library ...");
                    Directory.CreateDirectory(UserSettings.GameGuruPath + "\\Files\\scriptbank");
                    File.WriteAllBytes(UserSettings.GameGuruPath + "\\Files\\scriptbank\\StvDEVScriptConstructor.bin", Properties.Resources.StvDEVScriptConstructor);
                    ConsoleLog("The library has been successfully installed in path " + UserSettings.GameGuruPath + "\\Files\\scriptbank\\StvDEVScriptConstructor.bin");
                }
                catch (Exception ex)
                {
                    ConsoleError("Failed to install library: " + ex.Message);
                }

            };

            htbSearch.TextChanged += (s, e) =>
            {
                if (htbSearch.Text != htbSearch.HintValue)
                {
                    ctvMain.Search(htbSearch.Text);
                }
            };

            tcMain.GotFocus += (s, e) =>
            {
                if ((!String.IsNullOrEmpty(projectPath)) && (!this.Text.Contains("*")))
                {
                    this.Text += "*";
                }
            };

            ctvMain.GotFocus += (s, e) =>
            {
                if ((!String.IsNullOrEmpty(projectPath)) && (!this.Text.Contains("*")))
                {
                    this.Text += "*";
                }
            };

            #endregion
        }

        /// <summary>
        /// Refreshes the display of functions created in the project.
        /// </summary>
        public void RefreshProjectFunction()
        {
            ctvMain.ClearCategory("Project functions");

            foreach (var functionObject in projectFunctions.Values)
            {
                if (functionObject is Types.Function)
                {
                    var function = functionObject as Types.Function;
                    ctvMain.Add("Project functions", new Forms.ConstructorTreeView.ConstructorTreeNode(function));
                }
            }
        }

        /// <summary>
        /// Reassigns all tables and diagram in the project to their functions.
        /// </summary>
        private void ReconnectFunctions()
        {
            foreach (DiagramTabPage tabPage in tcMain.TabPages)
            {
                if (projectFunctions.ContainsKey(tabPage.Text.Replace(" ","_")))
                {
                    var function = projectFunctions[tabPage.Text.Replace(" ", "_")];
                    function.Diagram = tabPage.Diagram;
                    tabPage.TextChanged += (s, e) =>
                    {
                        function.Name = tabPage.Text.Replace(" ", "_");
                        RefreshProjectFunction();
                    };
                    tabPage.Diagram.OnTakeSnapshot += (s, e) =>
                    {
                        ReconnectDiagramTables(tabPage.Diagram);
                    };
                    tabPage.Diagram.OnSnapshotRestored += (s, e) =>
                    {
                        ReconnectDiagramTables(tabPage.Diagram);
                    };
                }
            }

            foreach (DiagramTabPage tabPage in tcMain.TabPages)
            {
                ReconnectDiagramTables(tabPage.Diagram);
            }
        }

        /// <summary>
        /// Reassigns all tables in a tab page diagram to their function.
        /// </summary>
        /// <param name="tabPage"></param>
        public void ReconnectTabPage(TabPage tabPage)
        {
            if (tabPage is Forms.DiagramTabPage)
            {
                ReconnectDiagramTables((tabPage as Forms.DiagramTabPage).Diagram);
            }
        }

        /// <summary>
        /// Reassigns all tables in the diagram to their function or if table is script component variable, to variable.
        /// </summary>
        /// <param name="diagram"></param>
        private void ReconnectDiagramTables(Forms.ConstructorDiagram diagram)
        {
            foreach (Shapes.ConstructorTable table in diagram.Tables.Values)
            {
                if (table.Type == Shapes.ConstructorTable.ConstructorTableTypes.Function)
                {
                    Types.Function function = FindFunctionByName(table.Function.Name);
                    if (function != null)
                    {
                        var functionTable = function.Table;
                        table.Function = function;
                        table.BackColor = function.Table.BackColor;
                        table.GradientColor = function.Table.GradientColor;
                        table.BorderColor = function.Table.BorderColor;
                        table.Forecolor = function.Table.Forecolor;
                        foreach (Crainiate.Diagramming.TableGroup tableGroup in table.Groups)
                        {
                            try
                            {
                                Crainiate.Diagramming.TableGroup functionTableGroup = functionTable.FindTableItemWithText(tableGroup.Text) as Crainiate.Diagramming.TableGroup;
                                tableGroup.Backcolor = functionTableGroup.Backcolor;
                                tableGroup.Forecolor = functionTableGroup.Forecolor;
                            }
                            catch { }
                            foreach (Crainiate.Diagramming.TableRow tableRow in tableGroup.Rows)
                            {
                                Crainiate.Diagramming.TableRow functionTableRow = functionTable.FindTableItemWithText(tableRow.Text) as Crainiate.Diagramming.TableRow;
                                try
                                {
                                    tableRow.Backcolor = functionTableRow.Backcolor;
                                    tableRow.Forecolor = functionTableRow.Forecolor;
                                }
                                catch { }
                            }
                        }
                        foreach (Crainiate.Diagramming.TableRow tableRow in table.Rows)
                        {
                            Crainiate.Diagramming.TableRow functionTableRow = functionTable.FindTableItemWithText(tableRow.Text) as Crainiate.Diagramming.TableRow;
                            tableRow.Backcolor = functionTable.FindTableItemWithText(tableRow.Text).Backcolor;
                            tableRow.Forecolor = functionTable.FindTableItemWithText(tableRow.Text).Forecolor;
                        }
                        foreach (Crainiate.Diagramming.Port port in table.Ports.Values)
                        {
                            try
                            {
                                Crainiate.Diagramming.Port functionPort = functionTable.FindPortWithName(port.Key.Substring(0, port.Key.LastIndexOf("_"))) as Crainiate.Diagramming.Port;
                                port.BackColor = functionPort.BackColor;
                                port.GradientColor = functionPort.GradientColor;
                                port.BorderColor = functionPort.BorderColor;
                            }
                            catch { }
                        }
                        diagram.Refresh();
                    }
                }
                else if (table.Type == Shapes.ConstructorTable.ConstructorTableTypes.Variable)
                {
                    if ((table.SubHeading.Contains("Argument")) || (table.SubHeading.Contains("Return")))
                    {
                        if (table.SubHeading.Contains("Argument"))
                        {
                            table.Variable = Components.FunctionComponents.Variables["Argument"];
                            table.BackColor = table.GradientColor = table.Variable.Table.BackColor;
                            table.BackColor = table.GradientColor = table.Variable.Table.BackColor;
                            table.Forecolor = table.BorderColor = table.Variable.Table.Forecolor;
                        }
                        else
                        {
                            table.Variable = Components.FunctionComponents.Variables["Return"];
                            table.BackColor = table.GradientColor = table.Variable.Table.BackColor;
                            table.Forecolor = table.BorderColor = table.Variable.Table.Forecolor;
                        }
                        diagram.Refresh();
                    }

                    foreach (Crainiate.Diagramming.Port port in table.Ports.Values)
                    {
                        try
                        {
                            port.BackColor = UserSettings.ColorScheme.MainColor;
                            port.GradientColor = UserSettings.ColorScheme.MainColor;
                            port.BorderColor = UserSettings.ColorScheme.ForeColor;
                        }
                        catch { }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new function tab page
        /// </summary>
        /// <returns>Function tab page</returns>
        private DiagramTabPage NewFunctionTabPage()
        {
            functionsCounter++;
            var tabPage = new DiagramTabPage("Function " + functionsCounter.ToString());
            tabPage.Diagram.Type = ConstructorDiagram.ConstructorDiagramTypes.Regular;
            var function = new Types.Function(tabPage.Text.Replace(" ", "_"));
            function.AccessType = Types.Variable.VariableAccessTypes.InputOutput;
            function.Description = "User function";
            function.Diagram = tabPage.Diagram;
            projectFunctions[tabPage.Name] = function;
            tcMain.TabPages.Add(tabPage);
            tcMain.SelectedTab = tabPage;
            tabPage.TextChanged += (se, ev) =>
            {
                function.Name = tabPage.Text.Replace(" ", "_");
                RefreshProjectFunction();
            };
            tabPage.Diagram.OnSnapshotRestored += (se, ev) =>
            {
                ReconnectDiagramTables(tabPage.Diagram);
            };
            RefreshProjectFunction();

            return tabPage;
        }

        /// <summary>
        /// Launches a new copy of the program, closing the old one.
        /// </summary>
        public void New()
        {
            Program.Restart = true;
            this.Close();
        }

        /// <summary>
        /// Saves the project to a file.
        /// </summary>
        /// <param name="path">Path</param>
        public void Save(string path)
        {
            try
            {
                Status = "Initializing a save";
                File.Create(path).Close();
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    using (var streamWriter = new StreamWriter(fileStream))
                    {
                        List<Types.Function> functions = new List<Types.Function>();
                        foreach (var function in projectFunctions.Values)
                        {
                            functions.Add((Types.Function)function);
                        }

                        string file = "{";
                        file += "Counter=" + functionsCounter + ";";
                        Status = "Saving functions";
                        file += "Functions=" + SerializeFunctions(functions) + ";";
                        Status = "Saving graphs";
                        file += "TabPages=" + SerializeTabPages(tcMain.TabPages) + ";";
                        file += "}";
                        Status = "Record file " + path + "...";
                        streamWriter.Write(file);
                    }
                }
                Status = "Save completed";
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to save.\n" + e.Message, "Filed to save!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Status = "Failed to save";
            }
        }

        /// <summary>
        /// Opens a project from a file.
        /// </summary>
        /// <param name="path">Path</param>
        public void Open(string path) 
        {
            try
            {
                Status = "Initializing a open";
                string file = File.ReadAllText(path);
                tcMain.TabPages.Clear();

                Status = "Opening the file " + path + "...";
                file = file.Substring(1, file.Length - 2);
                List<Types.Function> functions = new List<Types.Function>();
                while (file.Length > 0)
                {
                    int propertySign = file.IndexOf('=');
                    string propertyName = file.Substring(0, propertySign);
                    int delimiter = Saves.Saves.FindPropertyDelemiter(file, propertySign);
                    switch (propertyName)
                    {
                        case "Counter":
                            functionsCounter = Convert.ToInt32(file.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                            file = file.Substring(delimiter + 1);
                            break;
                        case "Functions":
                            functions = DeserializeFunctions(file.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                            projectFunctions = new Dictionary<string, Types.Function>();
                            foreach (Types.Function function in functions)
                            {
                                projectFunctions[function.Name] = function;
                            }
                            file = file.Substring(delimiter + 1);
                            break;
                        case "TabPages":
                            DeserializeTabPages(file.Substring(propertySign + 1, delimiter - (propertySign + 1)), tcMain);
                            file = file.Substring(delimiter + 1);
                            break;
                    }
                }

                ReconnectFunctions();
                RefreshProjectFunction();

                Status = "Opening completed";
                ConstructorConsole.ClearOutput();
                ConsoleMessage("Project " + path + " loaded and ready to go\n", System.Drawing.Color.Blue);
        }
            catch (Exception e)
            {
                MessageBox.Show("Failed to open file.\n" + e.Message, "Failed to open file!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Status = "Failed to open file";
            }

}

        /// <summary>
        /// Builds the entire project into a file.
        /// </summary>
        /// <param name="path">Path</param>
        public void BuildAll(string path)
        {
            string scriptName = Path.GetFileNameWithoutExtension(path);

            frMain.ConsoleMessage("Building \"", System.Drawing.Color.LimeGreen);
            frMain.ConsoleMessage(scriptName, System.Drawing.Color.Green, false);
            frMain.ConsoleMessage("\" script...\n", System.Drawing.Color.LimeGreen, false);

            string file = "Include('StvDEVScriptConstructor.bin')\n";

            foreach (Types.Function function in projectFunctions.Values)
            {
                if (!function.Build(function.Diagram))
                {
                    frMain.ConsoleMessage("Build failed: ", System.Drawing.Color.DarkRed);
                    frMain.ConsoleMessage("script build faild on function ", System.Drawing.Color.Red, false);
                    frMain.ConsoleMessage(function.Name + "\n", System.Drawing.Color.DarkRed, false);
                    return;
                }
                file += function.Code;
                file += "\n\n";
            }

            Types.Function main = new Types.Function(scriptName, Types.Function.FuntionTypes.Main)
            {
                Diagram = (tcMain.TabPages[0] as DiagramTabPage).Diagram
            };

            main.Build(main.Diagram);
            file += main.Code;

            File.WriteAllText(path, file);

            frMain.ConsoleMessage("Build successful: ", System.Drawing.Color.LimeGreen);
            frMain.ConsoleMessage(path, System.Drawing.Color.Green, false);
            frMain.ConsoleMessage(" was successfully built\n", System.Drawing.Color.LimeGreen, false);

        }

        /// <summary>
        /// Serializes a list of functions to a string.
        /// </summary>
        /// <param name="functions">List of function</param>
        /// <returns>Serialized string</returns>
        private string SerializeFunctions(List<Types.Function> functions)
        {
            string result = "{";
            foreach(var function in functions)
            {
                result += "Function=" + function.SerializeToString() + ";";
            }
            result += "}";
            return result;
        }

        /// <summary>
        /// Serializes a tab pages collection to a string.
        /// </summary>
        /// <param name="tabPages">Tab pages collection</param>
        /// <returns>Serialized string</returns>
        private string SerializeTabPages(TabControl.TabPageCollection tabPages)
        {
            string result = "{";
            foreach(DiagramTabPage tabPage in tabPages)
            {
                result += "TabPage=" + SerializeTabPage(tabPage) + ";";
            }
            result += "}";
            return result;
        }

        /// <summary>
        /// Serializes tab page to string.
        /// </summary>
        /// <param name="tabPage">Tab page</param>
        /// <returns>Serialized string</returns>
        private string SerializeTabPage(DiagramTabPage tabPage)
        {
            string result = "{";
            result += "Text=∴Text=>" + tabPage.Text + "<=Text∴;";
            result += "Diagram=" + tabPage.Diagram.SerializeToString() + ";";
            result += "}";
            return result;
        }

        /// <summary>
        /// Deserializes a list of functions from string.
        /// </summary>
        /// <param name="serializedFunctions">Serialized string</param>
        /// <returns>List of functions</returns>
        private List<Types.Function> DeserializeFunctions(string serializedFunctions)
        {
            serializedFunctions = serializedFunctions.Substring(1, serializedFunctions.Length - 2);
            List<Types.Function> functions = new List<Types.Function>();
            while (serializedFunctions.Length > 0)
            {
                int propertySign = serializedFunctions.IndexOf('=');
                string propertyName = serializedFunctions.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedFunctions, propertySign);
                switch (propertyName)
                {
                    case "Function":
                        Types.Function function = new Types.Function("newFunction");
                        string functionString = (serializedFunctions.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        function.DeserializeFromString(functionString);
                        functions.Add(function);
                        serializedFunctions = serializedFunctions.Substring(delimiter + 1);
                        break;
                }
            }

            return functions;
        }

        /// <summary>
        /// Deserializes tab pages collection from string.
        /// </summary>
        /// <param name="serializedTabPages">Serialized string</param>
        /// <param name="tabControl">Tab control</param>
        /// <returns>Tab pages collection</returns>
        private TabControl.TabPageCollection DeserializeTabPages(string serializedTabPages,TabControl tabControl)
        {
            serializedTabPages = serializedTabPages.Substring(1, serializedTabPages.Length - 2);
            TabControl.TabPageCollection tabPages = new TabControl.TabPageCollection(tabControl);
            while (serializedTabPages.Length > 0)
            {
                int propertySign = serializedTabPages.IndexOf('=');
                string propertyName = serializedTabPages.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedTabPages, propertySign);
                switch (propertyName)
                {
                    case "TabPage":
                        tabPages.Add(DeserializeTabPage(serializedTabPages.Substring(propertySign + 1, delimiter - (propertySign + 1))));
                        serializedTabPages = serializedTabPages.Substring(delimiter + 1);
                        break;
                }
            }

            return tabPages;
        }

        /// <summary>
        /// Deserializes tab page from string.
        /// </summary>
        /// <param name="serializedTabPage">Serialized string</param>
        /// <returns>Tab page</returns>
        private DiagramTabPage DeserializeTabPage(string serializedTabPage)
        {
            serializedTabPage = serializedTabPage.Substring(1, serializedTabPage.Length - 2);
            
            DiagramTabPage tabPage = new DiagramTabPage();
            while (serializedTabPage.Length > 0)
            {
                int propertySign = serializedTabPage.IndexOf('=');
                string propertyName = serializedTabPage.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedTabPage, propertySign);
                switch (propertyName)
                {
                    case "Text":
                        tabPage.Text = (serializedTabPage.Substring(propertySign + 1, delimiter - (propertySign + 1)).Replace("∴Text=>","").Replace("<=Text∴",""));
                        serializedTabPage = serializedTabPage.Substring(delimiter + 1);
                        break;
                    case "Diagram":
                        tabPage.Diagram.DeserializeFromString(serializedTabPage.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedTabPage = serializedTabPage.Substring(delimiter + 1);
                        break;
                }
            }

            tabPage.Diagram.Refresh();
            return tabPage;
        }

        /// <summary>
        /// Searches in the project and in programmatically defined functions for a function with the specified name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Function</returns>
        private Types.Function FindFunctionByName(string name)
        {
            Types.Function value = null;
            
            if (Components.Components.Functions.TryGetValue(name, out value))
            {
                return value;
            }
            else
            {
                foreach (var function in projectFunctions.Values)
                {
                    if (function.Name == name)
                    {
                        return function;
                    }
                }
            }

            return value;
        }
    }
}
