using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Types
{
    class Constant
    {
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
                    Heading = "",
                    SubHeading = "",
                    Label = new Crainiate.Diagramming.Label("Constant"),
                    Type = Shapes.ConstructorTable.ConstructionTableTypes.Constant,
                    CanEditHeading = true,
                    GradientColor = System.Drawing.Color.LightCoral,
                    BackColor = System.Drawing.Color.LightCoral,
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
                    AllowMove = false
                };
                @return.SetKey("return_" + Prefix + "_Constant" + "_" + DateTime.Now.GetHashCode());
                table.Ports.Add(@return);

                return table;

            }
        }


    }
}
