using System;
using System.Windows.Forms;

namespace LuaScriptConstructor.Forms.ConstructorTreeView
{
    class ConstructorTreeView : Kesoft.Windows.Forms.Win7StyleTreeView.Win7StyleTreeView
    {
        ToolTip toolTip = new ToolTip();

        private TreeNode mouseCureentNode; 

        public ConstructorTreeView() : base() {}

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

            foreach (TreeNode categoryNode in Nodes)
            {
                if (categoryNode.Name == category)
                {
                    categoryNode.Nodes.Add(node);
                    return;
                }
            }

            var newCategory = new TreeNode
            {
                Name = category,
                Text = category
            };

            newCategory.Nodes.Add(node);
            Nodes.Add(newCategory);
        }

        /// <summary>
        /// Adds a category with the given name.
        /// </summary>
        /// <param name="category">Category name</param>
        public virtual void AddCategory(string category)
        {
            foreach (TreeNode categoryNode in Nodes)
            {
                if (categoryNode.Name == category)
                {
                    throw new Exception("Tree already contains a category with the given name.");
                }
            }

            var newCategory = new TreeNode
            {
                Name = category,
                Text = category
            };
            Nodes.Add(newCategory);
        }
        
        /// <summary>
        /// Remove category from tree by name.
        /// </summary>
        /// <param name="category">Category name</param>
        public virtual void RemoveCategory(string category)
        {
            foreach (TreeNode categoryNode in Nodes)
            {
                if (categoryNode.Name == category)
                {
                    Nodes.Remove(categoryNode);
                    return;
                }
            }
        }

        /// <summary>
        /// Clear category items by category name.
        /// </summary>
        /// <param name="category">Category name.</param>
        public virtual void ClearCategory(string category)
        {
            foreach (TreeNode categoryNode in Nodes)
            {
                if (categoryNode.Name == category)
                {
                    categoryNode.Nodes.Clear();
                    return;
                }
            }
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
