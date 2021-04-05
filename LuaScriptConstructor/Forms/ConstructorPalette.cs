using System;
using System.Windows.Forms;
using System.Drawing;
using Crainiate.Diagramming;
using Crainiate.Diagramming.Forms;
using System.ComponentModel;

namespace LuaScriptConstructor.Forms
{
    /// <summary>
    /// Represents the palette of the constructor.
    /// </summary>
    class ConstructorPalette : Palette
    {
        /// <summary>
        /// Represents the palette tab of the constructor.
        /// </summary>
        public class ConstructorPaleteTabs : Tabs
        {
            public event TabEventHandler CurrentTabChanged;

            public ConstructorPaleteTabs(Model model) : base(model)
            {
                CurrentTabChanged += (s,e) => {  };
            }

            public override Tab CurrentTab 
            {
                get
                {
                    return base.CurrentTab;
                }
                set
                {
                    CurrentTabChanged(this, new TabEventArgs(value));
                    base.CurrentTab = value;
                }
            }

        }

        public ConstructorPalette() : base()
        {
            Render.AddRenderer(typeof(Shapes.ConstructorTable), new Forms.Rendering.ConctructorTableRender());
        }

        protected override void OnElementMouseDown(Element element, MouseEventArgs e)
        {
            if (element is Shapes.ConstructorTable)
            {
                //Start the drag operation
                Shapes.ConstructorTable prototype = (Shapes.ConstructorTable)element;

                Shapes.ConstructorTable table = new Shapes.ConstructorTable(prototype);
                table.MinimumSize = new Size(100, 100);

                table.Label = null;
                table.Image = null;

                DoDragDrop(table, DragDropEffects.All);
                return;
            }

            if (element is Table)
            {
                //Start the drag operation
                Table prototype = (Table)element;

                Table table = new Table(prototype);
                table.MinimumSize = new Size(100, 100);

                table.Label = null;
                table.Image = null;

                DoDragDrop(table, DragDropEffects.All);
                return;
            }

            base.OnElementMouseDown(element, e);
        }

        /// <summary>
        /// Adds a table to the diagram.
        /// </summary>
        /// <param name="table">Table</param>
        /// <returns>Table</returns>
        public Table AddTable(Table table)
        {
            return AddTableImplementation("", table, new PointF(), null, new SizeF());
        }

        /// <summary>
        /// Adds a table to the diagram.
        /// </summary>
        /// <param name="key">New table key</param>
        /// <param name="table">Table</param>
        /// <returns>Table</returns>
        public Table AddTable(string key, Table table)
        {
            return AddTableImplementation(key, table, new PointF(), null, new SizeF());
        }

        /// <summary>
        /// Adds a table to the diagram.
        /// </summary>
        /// <param name="key">New table key</param>
        /// <param name="table">Table</param>
        /// <param name="location">New table location</param>
        /// <param name="stencil">New table stencil</param>
        /// <param name="size">New table size</param>
        /// <returns>Table</returns>
        public Table AddTable(string key, Table table, PointF location, StencilItem stencil, SizeF size)
        {
            return AddTableImplementation(key, table, location, stencil, size);
        }

        /// <summary>
        /// Adds a table to the diagram.
        /// </summary>
        /// <param name="table">Table</param>
        /// <returns>Table</returns>
        public Table AddTable(Shapes.ConstructorTable table)
        {
            return AddTableImplementation("", table, new PointF(), null, new SizeF());
        }

        /// <summary>
        /// Adds a table to the diagram.
        /// </summary>
        /// <param name="key">New table key</param>
        /// <param name="table">Table</param>
        /// <returns>Table</returns>
        public Table AddTable(string key, Shapes.ConstructorTable table)
        {
            return AddTableImplementation(key, table, new PointF(), null, new SizeF());
        }

        /// <summary>
        /// Adds a table to the diagram.
        /// </summary>
        /// <param name="key">New table key</param>
        /// <param name="table">Table</param>
        /// <param name="location">New table location</param>
        /// <param name="stencil">New table stencil</param>
        /// <param name="size">New table size</param>
        /// <returns>Table</returns>
        public Table AddTable(string key, Shapes.ConstructorTable table, PointF location, StencilItem stencil, SizeF size)
        {
            return AddTableImplementation(key, table, location, stencil, size);
        }

        private Table AddTableImplementation(string key, Table table, PointF location, StencilItem stencil, SizeF size)
        {
            Table newTable = (Table)table.Clone();

            if (!location.IsEmpty)
            {
                newTable.Location = location;
            }


            //Set values if not provided
            if (key == null || key == "")
            {
                key = Model.Shapes.CreateKey();
            }
            if (stencil == null)
            {
                stencil = Singleton.Instance.DefaultStencilItem;
            }

            //Set size
            if (!size.IsEmpty)
            {
                newTable.Size = size;
            }

            //Set shape's stencil
            newTable.StencilItem = stencil;
            stencil.CopyTo(newTable);

            newTable.Label = new Crainiate.Diagramming.Label(table.Label.Text);
            //Add and return the new shape
            Controller.Model.Shapes.Add(key, newTable);
            return newTable;
        }

        private Table AddTableImplementation(string key, Shapes.ConstructorTable table, PointF location, StencilItem stencil, SizeF size)
        {
            Suspend();
            Shapes.ConstructorTable newTable = new Shapes.ConstructorTable(table);

            if (!location.IsEmpty)
            {
                newTable.Location = location;
            }


            //Set values if not provided
            if (key == null || key == "")
            {
                key = Model.Shapes.CreateKey();
            }
            if (stencil == null)
            {
                stencil = Singleton.Instance.DefaultStencilItem;
            }

            //Set size
            if (!size.IsEmpty)
            {
                newTable.Size = size;
            }

            //Set shape's stencil
         
            newTable.StencilItem = stencil;
            stencil.CopyTo(newTable);

            //Add and return the new shape
            newTable.Label = new Crainiate.Diagramming.Label(table.Label.Text);
            Controller.Model.Shapes.Add(key, newTable);
            return newTable;
        }

    }
}
