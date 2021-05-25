using System;
using System.Windows.Forms;
using System.Drawing;

namespace LuaScriptConstructor.Forms.ConstructorTreeView
{
    /// <summary>
    /// Tree for displaying a list of constructor items.
    /// </summary>
    class ConstructorTreeView : Kesoft.Windows.Forms.Win7StyleTreeView.Win7StyleTreeView
    {
        private ToolTip toolTip = new ToolTip(); 
        private TreeNode mouseCureentNode;

        /// <summary>
        /// Tree for displaying a list of constructor items
        /// </summary>
        public ConstructorTreeView() : base() 
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
            toolTip.BackColor = UserSettings.ColorScheme.MainColor;
            toolTip.ForeColor = UserSettings.ColorScheme.ForeColor;
            toolTip.OwnerDraw = true;
            toolTip.Draw += (s, e) =>
            {
                e.DrawBackground();
                e.DrawBorder();
                e.DrawText();
            };
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            TreeNodeStates state = e.State;
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color fore = e.Node.ForeColor;
            if (fore == Color.Empty)
                fore = e.Node.TreeView.ForeColor;
            if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
            {
                //e.Graphics.FillRectangle(new SolidBrush(UserSettings.ColorScheme.MainColor), e.Bounds);
                //ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, UserSettings.ColorScheme.MainColor);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
            }
        }

        /// <summary>
        /// Adds node.
        /// </summary>
        /// <param name="node">Constructor tree node</param>
        public virtual void Add(ConstructorTreeNode node) { Add("Basic", node); }

        /// <summary>
        /// Add node to category.
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="node">Constructor tree node</param>
        public virtual void Add(string category, ConstructorTreeNode node)
        {
            if (this.ImageList == null)
            {
                this.ImageList = new ImageList();
                this.ImageList.Images.Add(new System.Drawing.Bitmap(1, 1));
            }

            if (node.Image != null)
            {
                this.ImageList.Images.Add(node.Image);
                node.ImageIndex = this.ImageList.Images.Count - 1;
            }

            Add(category, this.Nodes, node);
        }

        /// <summary>
        /// Add node to category.
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="nodes">Parent nodes collection</param>
        /// <param name="node">Constructor tree node</param>
        public static void Add(string category, TreeNodeCollection nodes, ConstructorTreeNode node)
        {
            string subCategory = "";

            if (category.Contains("\\"))
            {
                subCategory = category.Substring(0, category.IndexOf('\\'));
                category = category.Substring(category.IndexOf('\\') + 1);
            }
            else
            {
                subCategory = category;
                category = "";
            }

            foreach (TreeNode categoryNode in nodes)
            {
                if (categoryNode.Text == subCategory)
                {
                    if (String.IsNullOrEmpty(category))
                    {
                        categoryNode.Nodes.Add(node);
                        return;
                    }
                    else
                    {
                        Add(category, categoryNode.Nodes, node);
                        return;
                    }
                }
            }
            AddCategory(subCategory, nodes);
            Add(subCategory + "\\" + category, nodes, node);

        }

        /// <summary>
        /// Adds a category with the given name.
        /// </summary>
        /// <param name="category">Category name</param>
        public virtual void AddCategory(string category)
        {
            AddCategory(category, this.Nodes);
        }

        /// <summary>
        /// Adds a category with the given name.
        /// </summary>
        /// <param name="category">Category name</param>
        /// <param name="nodes">Parent nodes collection</param>
        public static void AddCategory(string category, TreeNodeCollection nodes)
        {
            string subCategory = "";

            if (category.Contains("\\"))
            {
                subCategory = category.Substring(0, category.IndexOf('\\'));
                category = category.Substring(category.IndexOf('\\') + 1);
            }
            else
            {
                subCategory = category;
                category = "";
            }

            foreach (TreeNode categoryNode in nodes)
            {
                if ((categoryNode.Name == subCategory) && (String.IsNullOrEmpty(category)))
                {
                    throw new Exception("Tree already contains a category with the given name.");
                }
            }

            var newCategory = new TreeNode
            {
                Name = subCategory,
                Text = subCategory
            };
            nodes.Add(newCategory);

            if (!String.IsNullOrEmpty(category))
            {
                AddCategory(category, newCategory.Nodes);
            }
        }
        
        /// <summary>
        /// Remove category from tree by name.
        /// </summary>
        /// <param name="category">Category name</param>
        public virtual void RemoveCategory(string category)
        {
            RemoveCategory(category, this.Nodes);
        }

        /// <summary>
        /// Remove category from tree by name.
        /// </summary>
        /// <param name="category">Category name</param>
        /// <param name="nodes">Parent nodes collection</param>
        public static void RemoveCategory(string category, TreeNodeCollection nodes)
        {
            string subCategory = "";

            if (category.Contains("\\"))
            {
                subCategory = category.Substring(0, category.IndexOf('\\'));
                category = category.Substring(category.IndexOf('\\') + 1);
            }
            else
            {
                subCategory = category;
                category = "";
            }

            foreach (TreeNode categoryNode in nodes)
            {
                if (categoryNode.Name == subCategory)
                {
                    if (String.IsNullOrEmpty(category))
                    {
                        nodes.Remove(categoryNode);
                        return;
                    }
                    else
                    {
                        RemoveCategory(category, categoryNode.Nodes);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Clear category items by category name.
        /// </summary>
        /// <param name="category">Category name</param>
        public virtual void ClearCategory(string category)
        {
            ClearCategory(category, this.Nodes);
        }

        /// <summary>
        /// Clear category items by category name.
        /// </summary>
        /// <param name="category">Category name</param>
        /// <param name="nodes">Parent nodes collection</param>
        public static void ClearCategory(string category, TreeNodeCollection nodes)
        {
            string subCategory = "";

            if (category.Contains("\\"))
            {
                subCategory = category.Substring(0, category.IndexOf('\\') - 1);
                category = category.Substring(category.IndexOf('\\') + 1);
            }
            else
            {
                subCategory = category;
                category = "";
            }

            foreach(TreeNode categoryNode in nodes)
            {
                if (categoryNode.Name == subCategory)
                {
                    if (String.IsNullOrEmpty(category))
                    {
                        categoryNode.Nodes.Clear();
                        return;
                    }
                    else
                    {
                        ClearCategory(category, categoryNode.Nodes);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Searches for Node containing the given text.
        /// </summary>
        /// <param name="target">Search target</param>
        public virtual void Search(string target)
        {

            Search(target, this.Nodes);
        }

        /// <summary>
        /// Searches for Node containing the given text.
        /// </summary>
        /// <param name="target">Search target</param>
        /// <param name="nodes">Parent nodes collection</param>
        public static bool Search(string target, TreeNodeCollection nodes)
        {
            bool result = String.IsNullOrEmpty(target);

            foreach (TreeNode node in nodes)
            {
                bool localResult = String.IsNullOrEmpty(target);
                if ((node.Text.ToLower().Contains(target.ToLower())) || (String.IsNullOrEmpty(target)))
                {
                    result = true;
                    localResult = true;
                }

                //if ((!Search(target, node.Nodes)) && (!localResult))
                Search(target, node.Nodes);
                if (!localResult)
                {
                    
                    node.ForeColor = Color.FromArgb(((UserSettings.ColorScheme.SecondaryColor.R > 128) ? UserSettings.ColorScheme.SecondaryColor.R - 40 : UserSettings.ColorScheme.SecondaryColor.R + 40),
                        ((UserSettings.ColorScheme.SecondaryColor.G > 128) ? UserSettings.ColorScheme.SecondaryColor.G - 40 : UserSettings.ColorScheme.SecondaryColor.G + 40),
                        ((UserSettings.ColorScheme.SecondaryColor.B > 128) ? UserSettings.ColorScheme.SecondaryColor.B - 40 : UserSettings.ColorScheme.SecondaryColor.B + 40));
                }
                else
                {
                    if (!String.IsNullOrEmpty(target))
                    {
                        node.EnsureVisible();
                    }
                    node.ForeColor = UserSettings.ColorScheme.ForeColor;//FromArgb(28, 196, 247);
                }
            }

            return result;
        }
        protected override void OnNodeMouseHover(TreeNodeMouseHoverEventArgs e)
        {
            mouseCureentNode = e.Node;
            toolTip.Hide(this);
            toolTip.Show(e.Node.ToolTipText, this);
            base.OnNodeMouseHover(e);
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            mouseCureentNode = e.Node;
            base.OnNodeMouseClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (mouseCureentNode != null)
                {
                    if (mouseCureentNode is ConstructorTreeNode)
                    {
                        SelectedNode = SelectedNode;
                        DoDragDrop(((ConstructorTreeNode)mouseCureentNode).Table, DragDropEffects.All);
                    }
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
            base.OnBeforeSelect(e);
        }
        
    }
}
