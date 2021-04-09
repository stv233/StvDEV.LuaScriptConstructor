using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LuaScriptConstructor.Forms;

namespace LuaScriptConstructor
{
    public partial class frMain : Form
    {
        /// <summary>
        /// Project functions as object.
        /// </summary>
        public Dictionary<string, object> ProjectFunctions { get; set; }

        private Forms.ConstructorTreeView.ConstructorTreeView ctvMain;
        private TradeWright.UI.Forms.TabControlExtra tcMain;

        private int functionsCounter = 0;

        public frMain()
        {
            #region /// Initialization

            #region /// Form

            this.Size = new System.Drawing.Size(800, 600);

            #endregion

            #region /// Properties

            ProjectFunctions = new Dictionary<string, object>();

            #endregion

            #region /// Menu Strip

            var msMain = new MenuStrip
            {
                Parent = this
            };

            #region /// File

            var tsmiFile = new ToolStripMenuItem
            {
                Text = "File"
            };
            msMain.Items.Add(tsmiFile);

            var tsmiNew = new ToolStripMenuItem
            {
                Text = "New",
                ShortcutKeyDisplayString = "Ctrl+N",
                ShortcutKeys = Keys.Control | Keys.N,
                Image = Properties.Resources.NewFile_16x
            };
            tsmiFile.DropDownItems.Add(tsmiNew);

            var tsmiOpen = new ToolStripMenuItem
            {
                Text = "Open...",
                ShortcutKeyDisplayString = "Ctrl+O",
                ShortcutKeys = Keys.Control | Keys.O,
                Image = Properties.Resources.OpenFile_16x
            };
            tsmiFile.DropDownItems.Add(tsmiOpen);

            var tsmiSave = new ToolStripMenuItem
            {
                Text = "Save",
                ShortcutKeyDisplayString = "Ctrl+S",
                ShortcutKeys = Keys.Control | Keys.S,
                Image = Properties.Resources.Save_16x
            };
            tsmiFile.DropDownItems.Add(tsmiSave);

            var tsmiSaveAs = new ToolStripMenuItem
            {
                Text = "Save as...",
                Image = Properties.Resources.SaveAs_16x
            };
            tsmiFile.DropDownItems.Add(tsmiSaveAs);

            tsmiFile.DropDownItems.Add(new ToolStripSeparator());

            var tsmiClose = new ToolStripMenuItem
            {
                Text = "Close",
                ShortcutKeyDisplayString = "Alt+F4",
                ShortcutKeys = Keys.Alt | Keys.F4,
                Image = Properties.Resources.Close_16x
            };
            tsmiFile.DropDownItems.Add(tsmiClose);

            #endregion

            #region /// Build

            var tsmiBuild = new ToolStripMenuItem
            {
                Text = "Build"
            };
            msMain.Items.Add(tsmiBuild);

            var tsmiBuildFunction = new ToolStripMenuItem
            {
                Text = "Build function",
                ShortcutKeyDisplayString = "Shift+F6",
                Image = Properties.Resources.BuildSelection_16x
            };
            tsmiBuild.DropDownItems.Add(tsmiBuildFunction);

            var tsmiBuildAll = new ToolStripMenuItem
            {
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
                Text = "New function graph",
                Image = Properties.Resources.NewGraph_16x
            };
            tsmiFunctions.DropDownItems.Add(tsmiAddFunction);
            tsmiAddFunction.Click += (s, e) =>
            {
                functionsCounter++;
                var tabPage = new DiagramTabPage("Function " + functionsCounter.ToString());
                tabPage.Diagram.Type = ConstructorDiagram.ConstructorDiagramTypes.Regular;
                tcMain.TabPages.Add(tabPage);
                tcMain.SelectedTab = tabPage;
            };

            var tsmiRemoveFunction = new ToolStripMenuItem
            {
                Text = "Close function graph",
                Image = Properties.Resources.Close_red_16x
            };
            tsmiFunctions.DropDownItems.Add(tsmiRemoveFunction);
            tsmiRemoveFunction.Click += (s, e) =>
            {
                if (((DiagramTabPage)tcMain.SelectedTab).Diagram.Type != ConstructorDiagram.ConstructorDiagramTypes.Main)
                {
                    if (MessageBox.Show("Are you sure you want to close the function graph? This action cannot be undone.",
                        "Close function graph",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tcMain.TabPages.Remove(tcMain.SelectedTab);
                    }
                }
            };

            #endregion

            #endregion

            #region /// ToolStrip

            var tsMenu = new ToolStrip
            {
                LayoutStyle = ToolStripLayoutStyle.StackWithOverflow,
                Parent = this
            };
            tsMenu.BringToFront();

            #region /// File

            var tsbNew = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiNew.Image,
                ToolTipText = tsmiNew.Text
            };
            tsbNew.Click += (s, e) => { tsmiNew.PerformClick(); };
            tsMenu.Items.Add(tsbNew);

            var tsbOpen = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiOpen.Image,
                ToolTipText = tsmiOpen.Text
            };
            tsbOpen.Click += (s, e) => { tsmiOpen.PerformClick(); };
            tsMenu.Items.Add(tsbOpen);

            var tsbSave = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiSave.Image,
                ToolTipText = tsmiSave.Text
            };
            tsbSave.Click += (s, e) => { tsmiSave.PerformClick(); };
            tsMenu.Items.Add(tsbSave);

            #endregion

            #region /// Build

            tsMenu.Items.Add(new ToolStripSeparator());

            var tsbBuildFunction = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiBuildFunction.Image,
                ToolTipText = tsmiBuildFunction.Text,
            };
            tsbBuildFunction.Click += (s, e) => { tsmiBuildFunction.PerformClick(); };
            tsMenu.Items.Add(tsbBuildFunction);

            var tsbBuildAll = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiBuildAll.Image,
                ToolTipText = tsmiBuildAll.Text
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
                ToolTipText = tsmiAddFunction.Text,
            };
            tsbAddFunction.Click += (s, e) => { tsmiAddFunction.PerformClick(); };
            tsMenu.Items.Add(tsbAddFunction);

            var tsbRemoveFunction = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = tsmiRemoveFunction.Image,
                ToolTipText = tsmiRemoveFunction.Text,
            };
            tsbRemoveFunction.Click += (s, e) => { tsmiRemoveFunction.PerformClick(); };
            tsMenu.Items.Add(tsbRemoveFunction);

            #endregion

            #endregion



            #region /// SplitContainer

            var scMain = new SplitContainer
            {
                Width = this.ClientSize.Width,
                Height = this.ClientSize.Height - msMain.Height - tsMenu.Height,
                SplitterDistance = this.ClientSize.Width / 10 * 4,
                Left = 0,
                Top = msMain.Height + tsMenu.Height,
                Parent = this
            };

            #region /// Tree view

            ctvMain = new Forms.ConstructorTreeView.ConstructorTreeView
            {
                Width = scMain.Panel1.ClientSize.Width,
                Height = scMain.Panel1.ClientSize.Height,
                Font = new System.Drawing.Font(Font.FontFamily, 10, System.Drawing.FontStyle.Regular),
                //ShowNodeToolTips = true,
                Parent = scMain.Panel1
            };
            ctvMain.AddCategory("Basic");

            foreach (Types.Variable variable in Components.FunctionComponents.Variables)
            {
                 ctvMain.Add("Function components", new Forms.ConstructorTreeView.ConstructorTreeNode(variable.Table));
            }

            foreach (var functionObject in ProjectFunctions.Values)
            {
                if (functionObject is Types.Function)
                {
                    var function = functionObject as Types.Function;
                    ctvMain.Add("Projects finctions",new Forms.ConstructorTreeView.ConstructorTreeNode(function.Table));
                }
            }

                #endregion

            #region /// Tab Control

             tcMain = new TradeWright.UI.Forms.TabControlExtra
            {
                Width = scMain.Panel2.ClientSize.Width,
                Height = scMain.Panel2.ClientSize.Height,
                Parent = scMain.Panel2
            };

            var tpMain = new DiagramTabPage()
            {
                Text = "Main",
            };
            tpMain.Diagram.Type = ConstructorDiagram.ConstructorDiagramTypes.Main;
            tcMain.TabPages.Add(tpMain);

            #endregion

            #endregion

            #endregion

            #region /// Events

            #region /// Resizes

            scMain.Panel1.Resize += (s, e) =>
            {
                ctvMain.Width = scMain.Panel1.ClientSize.Width;
                ctvMain.Height = scMain.Panel1.ClientSize.Height;
            };

            scMain.Panel2.Resize += (s, e) =>
            {
                tcMain.Width = scMain.Panel2.ClientSize.Width;
                tcMain.Height = scMain.Panel2.ClientSize.Height;
            };

            this.Resize += (s, e) =>
            {
                scMain.Width = this.ClientSize.Width;
                scMain.Height = this.ClientSize.Height - msMain.Height - tsMenu.Height;
            };

            #endregion

            #endregion
        }
        
        public void RefreshProjectFunction()
        {
            ctvMain.ClearCategory("Projects finctions");

            foreach (var functionObject in ProjectFunctions.Values)
            {
                if (functionObject is Types.Function)
                {
                    var function = functionObject as Types.Function;
                    ctvMain.Add("Projects finctions", new Forms.ConstructorTreeView.ConstructorTreeNode(function.Table));
                }
            }
        }

    }
}
