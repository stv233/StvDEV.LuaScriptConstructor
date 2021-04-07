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
                    Constant = this
                };
                table.SetKey(Prefix + "_Constant" + DateTime.Now.GetHashCode());

                var @return = new Crainiate.Diagramming.Port
                {
                    Direction = Crainiate.Diagramming.Direction.Out,
                    Orientation = Crainiate.Diagramming.PortOrientation.Right,
                    Style = Crainiate.Diagramming.PortStyle.Output,
                    AllowMove = false
                };
                @return.SetKey("output_" + Prefix + "_Constant" + DateTime.Now.GetHashCode());
                table.Ports.Add(@return);

                return table;

            }
        }


    }
}
