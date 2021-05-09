using System;
using System.Windows.Forms;

namespace LuaScriptConstructor.Forms.ConstructorTreeView
{
    /// <summary>
    /// Tree node with constructor table.
    /// </summary>
    class ConstructorTreeNode : TreeNode
    {
        private Types.Constant nodeObject;
        /// <summary>
        /// Table.
        /// </summary>
        public Shapes.ConstructorTable Table
        {
            get
            {
                if (nodeObject is Types.Function || nodeObject is Types.ProgrammaticallyDefinedFunction)
                {
                    return new Shapes.ConstructorTable((nodeObject as Types.Function).Table);
                }
                else if (nodeObject is Types.Variable)
                {
                    return new Shapes.ConstructorTable((nodeObject as Types.Variable).Table);
                }
                else
                {
                    return new Shapes.ConstructorTable(nodeObject.Table);
                }
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
        public ConstructorTreeNode(Types.Constant type)
        {
            nodeObject = type;
            Text = type.Table.Heading.Replace("_", " ");
            ToolTipText = type.Table.SubHeading;

            if (type is Types.Function || type is Types.ProgrammaticallyDefinedFunction)
            {
                Image = (type as Types.Function).Table.Icon;
            }
            else if (type is Types.Variable)
            {
                Image = (type as Types.Variable).Table.Icon;
            }
            else
            {
                Image = type.Table.Icon;
            }
        }

    }
}
