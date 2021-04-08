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

            #endregion

            #region /// ToolStrip

            var tsMenu = new ToolStrip
            {
                Parent = this
            };
            tsMenu.BringToFront();

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

            var tpFunction = new DiagramTabPage();
            tpFunction.Diagram.Type = ConstructorDiagram.ConstructorDiagramTypes.Regular;
            tcMain.TabPages.Add(tpFunction);

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
