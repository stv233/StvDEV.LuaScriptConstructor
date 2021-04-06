using System;
using System.Windows.Forms;
using LuaScriptConstructor.Forms;

namespace LuaScriptConstructor
{
    public partial class frMain : Form
    {
        public frMain()
        {
            #region /// Initialization

            #region /// Form

            this.Size = new System.Drawing.Size(800, 600);

            #endregion

            #region /// Menu Strip

            var msMain = new MenuStrip
            {
                Parent = this
            };

            #endregion

            #region /// SplitContainer

            var scMain = new SplitContainer
            {
                Width = this.ClientSize.Width,
                Height = this.ClientSize.Height - msMain.Height,
                SplitterDistance = this.ClientSize.Width / 10 * 4,
                Left = 0,
                Top = msMain.Height,
                Parent = this
            };

            #region /// Palette

            var cplMain = new ConstructorPalette
            {
                Width = scMain.Panel1.ClientSize.Width,
                Height = scMain.Panel1.ClientSize.Height,
                Parent = scMain.Panel1
            };
            cplMain.Tabs = new ConstructorPalette.ConstructorPaleteTabs(cplMain.Model);
            cplMain.Model.Layers = cplMain.Tabs;
            cplMain.Tabs[0].Name = "Basic";
            cplMain.Tabs.Add(new Crainiate.Diagramming.Forms.Tab());
            cplMain.Tabs[1].Name = "Function components";

            ((ConstructorPalette.ConstructorPaleteTabs)(cplMain.Tabs)).CurrentTabChanged += (s, e) =>
            {
                cplMain.Clear();

                if (cplMain.Tabs.CurrentTab.Name == "Function components")
                {
                    
                    foreach (Types.Variable variable in DefaultComponents.FunctionComponents.Variables)
                    {
                        cplMain.AddTable(variable.Table);
                    }
                }

                cplMain.Refresh();
            };

            //cplMain.AddTable(new Shapes.ConstructorTable());

            #endregion

            #region /// Tab Control

            var tcMain = new TabControl
            {
                Width = scMain.Panel2.ClientSize.Width,
                Height = scMain.Panel2.ClientSize.Height,
                Parent = scMain.Panel2
            };

            var tpMain = new DiagramTabPage
            {
                Text = "Main",
            };
            tcMain.TabPages.Add(tpMain);

            #endregion

            #endregion

            #endregion

            #region /// Events

            #region /// Resizes

            scMain.Panel1.Resize += (s, e) =>
            {
                cplMain.Width = scMain.Panel1.ClientSize.Width;
                cplMain.Height = scMain.Panel1.ClientSize.Height;
            };

            scMain.Panel2.Resize += (s, e) =>
            {
                tcMain.Width = scMain.Panel2.ClientSize.Width;
                tcMain.Height = scMain.Panel2.ClientSize.Height;
            };

            this.Resize += (s, e) =>
            {
                scMain.Width = this.ClientSize.Width;
                scMain.Height = this.ClientSize.Height - msMain.Height;
            };

            #endregion

            #endregion
        }
    }
}
