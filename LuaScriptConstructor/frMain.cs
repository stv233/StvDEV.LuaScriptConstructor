using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LuaScriptConstructor.Forms;
using System.IO;

namespace LuaScriptConstructor
{
    public partial class frMain : Form
    {
        /// <summary>
        /// Project functions as object.
        /// </summary>
        private Dictionary<string, Types.Function> projectFunctions { get; set; }

        private Forms.ConstructorTreeView.ConstructorTreeView ctvMain;
        private TradeWright.UI.Forms.TabControlExtra tcMain;

        private int functionsCounter = 0;
        private string projectPath = "";

        public frMain()
        {
            #region /// Initialization

            #region /// Form

            this.Size = new System.Drawing.Size(800, 600);

            #endregion

            #region /// Properties

            projectFunctions = new Dictionary<string, Types.Function>();

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
                RefreshProjectFunction();
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
                Parent = scMain.Panel1
            };
            ctvMain.AddCategory("Basic");

            foreach (Types.Variable variable in Components.FunctionComponents.Variables)
            {
                 ctvMain.Add("Function components", new Forms.ConstructorTreeView.ConstructorTreeNode(variable));
            }

            foreach (var functionObject in projectFunctions.Values)
            {
                if (functionObject is Types.Function)
                {
                    var function = functionObject as Types.Function;
                    ctvMain.Add("Projects finctions",new Forms.ConstructorTreeView.ConstructorTreeNode(function));
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

            tsmiSave.Click += (s, e) =>
            {
                if (String.IsNullOrEmpty(projectPath))
                {
                    tsmiSaveAs.PerformClick();
                }
                else
                {
                    Save(projectPath, tcMain);
                }
            };

            tsmiSaveAs.Click += (s, e) =>
            {
                using (var sfd = new SaveFileDialog
                {
                    FileName = projectPath,
                    Filter = "Lua script project (*.LUASP)|*.luasp|All files(*.*)|*.*"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        projectPath = sfd.FileName;
                        Save(projectPath, tcMain);
                    }
                }
            };

            tsmiOpen.Click += (s, e) =>
            {
                using (var ofd = new OpenFileDialog
                {
                    FileName = projectPath,
                    Filter = "Lua script project (*.LUASP)|*.luasp|All files(*.*)|*.*"
                })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        projectPath = ofd.FileName;
                        Open(projectPath, tcMain);
                    }
                }
            };

            #endregion
        }
        
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

        private void ReconectFunctions()
        {
            foreach (DiagramTabPage tabPage in tcMain.TabPages)
            {
                if (projectFunctions.ContainsKey(tabPage.Text.Replace(" ","_")))
                {
                    projectFunctions[tabPage.Text.Replace(" ", "_")].Diagram = tabPage.Diagram;
                }
            }

            foreach (DiagramTabPage tabPage in tcMain.TabPages)
            {
                foreach(Shapes.ConstructorTable table in tabPage.Diagram.Tables.Values)
                {
                    if (table.Type == Shapes.ConstructorTable.ConstructorTableTypes.Function)
                    {
                        Types.Function function = FindFunctionByName(table.Function.Name);
                        if (function != null)
                        {
                            table.Function = function;
                        }
                    }
                }
            }
        }

        public void Save(string path, TabControl tabControl)
        {
            File.Create(path).Close();
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    List<Types.Function> functions = new List<Types.Function>();
                    foreach(var function in projectFunctions.Values)
                    {
                        functions.Add((Types.Function)function);
                    }

                    string file = "{";
                    file += "Counter=" + functionsCounter + ";";
                    file += "Functions=" + SerializeFunctions(functions) + ";";
                    file += "TabPages=" + SerializeTabPages(tcMain.TabPages) + ";";
                    file += "}";
                    streamWriter.Write(file);
                }
            }
        }

        public void Open(string path, TabControl tabControl)
        {
            string file = File.ReadAllText(path);
            tabControl.TabPages.Clear();
            
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
                        foreach(Types.Function function in functions)
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

            ReconectFunctions();
            RefreshProjectFunction();
        }

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

        private string SerializeTabPage(DiagramTabPage tabPage)
        {
            string result = "{";
            result += "Text=∴Text=>" + tabPage.Text + "<=Text∴;";
            result += "Diagram=" + tabPage.Diagram.SerializeToString() + ";";
            result += "}";
            return result;
        }

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


        private Types.Function FindFunctionByName(string name)
        {
            foreach(var function in Components.FunctionComponents.Functions)
            {
                if (name == function.Name)
                {
                    return function;
                };
            }

            foreach(var function in Components.ScriptСomponents.Functions)
            {
                if(name == function.Name)
                {
                    return function;
                }
            }

            foreach(var objectFuction in projectFunctions.Values)
            {
                Types.Function function = objectFuction as Types.Function;
                if (function.Name == name)
                {
                    return function;
                }
            }

            return null;
        }
    }
}
