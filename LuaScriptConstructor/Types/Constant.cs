using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Types
{
    /// <summary>
    /// Represents a constant type class for a script constructor.
    /// </summary>
    class Constant
    {
        /// <summary>
        /// Represents a class containing data for a <see cref="Constant.TableRebuilding"/> event.
        /// </summary>
        public class RebuildEventArgs : EventArgs
        {
            /// <summary>
            /// Rebuilded table.
            /// </summary>
            public Shapes.ConstructorTable Table { get; protected set; }

            /// <summary>
            /// Represents a class containing data for a <see cref="Variable.TableRebuilding"/> event.
            /// </summary>
            /// <param name="table">Rebuilded table</param>
            public RebuildEventArgs(ref Shapes.ConstructorTable table)
            {
                Table = table;
            }
        }

        /// <summary>
        /// Represents a method that handles <see cref="Variable.TableRebuilding"/> event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public delegate void RebuildTableEvents(object sender, RebuildEventArgs e);

        /// <summary>
        /// Fires during table rebuild.
        /// </summary>
        public virtual event RebuildTableEvents TableRebuilding;

        /// <summary>
        /// Constant value.
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Constant prefix.
        /// </summary>
        public virtual string Prefix { get; set; }

        /// <summary>
        /// Constant table.
        /// </summary>
        public virtual Shapes.ConstructorTable Table 
        {
            get
            {
                var table = new Shapes.ConstructorTable
                {
                    Heading = Value,
                    SubHeading = "",
                    Label = new Crainiate.Diagramming.Label("Constant"),
                    Type = Shapes.ConstructorTable.ConstructorTableTypes.Constant,
                    CanEditHeading = true,
                    GradientColor = System.Drawing.Color.LightCoral,
                    BackColor = System.Drawing.Color.LightCoral,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                    Forecolor = UserSettings.ColorScheme.ForeColor,
                    Icon = Properties.Resources.Constant_16x,
                    Constant = this
                };
                table.GradientColor = table.BackColor;
                table.SetKey(Prefix + "_Constant" + "_" + DateTime.Now.GetHashCode());

                var @return = new Crainiate.Diagramming.Port
                {
                    Direction = Crainiate.Diagramming.Direction.Out,
                    Orientation = Crainiate.Diagramming.PortOrientation.Right,
                    Style = Crainiate.Diagramming.PortStyle.Output,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                    AllowMove = false
                };
                @return.SetKey("return_" + Prefix + "_Constant" + "_" + DateTime.Now.GetHashCode());
                table.Ports.Add(@return);

                try
                {
                    TableRebuilding(this, new RebuildEventArgs(ref table));
                }
                catch (NullReferenceException) { }
                return table;

            }
        }

    }
}
