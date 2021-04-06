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
                var table = new Shapes.ConstructorTable();
                table.SetKey(Prefix + "_Constant" + DateTime.Now.GetHashCode());
                table.Heading = "";
                table.SubHeading = "";
                table.Label = new Crainiate.Diagramming.Label("Constant");
                table.Type = Shapes.ConstructorTable.ConstructionTableTypes.Constant;
                table.Constant = this;

                var output = new Crainiate.Diagramming.Port();
                output.SetKey("output_" + Prefix + "_Constant" + DateTime.Now.GetHashCode());
                output.Direction = Crainiate.Diagramming.Direction.Out;
                output.Orientation = Crainiate.Diagramming.PortOrientation.Right;
                output.Style = Crainiate.Diagramming.PortStyle.Output;
                output.AllowMove = false;
                table.Ports.Add(output);

                return table;

            }
        }


    }
}
