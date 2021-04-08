using System;
using System.Windows.Forms;

namespace LuaScriptConstructor.Forms.ConstructorTreeView
{
    /// <summary>
    /// Tree node with constructor table.
    /// </summary>
    class ConstructorTreeNode : TreeNode
    {
        private Shapes.ConstructorTable _table;
        /// <summary>
        /// Table.
        /// </summary>
        public Shapes.ConstructorTable Table
        {
            get
            {
                return new Shapes.ConstructorTable (_table);
            }
            set
            {
                _table = value;
                Text = _table.Heading.Replace("_", " ");
                Image = _table.Icon;
                ToolTipText = _table.SubHeading;
                Name = _table.Heading;
            }
        }

        private System.Drawing.Image _image;
        /// <summary>
        /// Node image.
        /// </summary>
        public System.Drawing.Image Image
        {
            get
            {
                return new System.Drawing.Bitmap(_image);
            }
            set
            {
                _image = value;
            }
        }

        /// <summary>
        /// Tree node with constructor table.
        /// </summary>
        /// <param name="table">Constructor table</param>
        public ConstructorTreeNode(Shapes.ConstructorTable table)
        {
            Table = table;
            ToolTipText = table.SubHeading;
            Image = table.Icon;
        }

    }
}
