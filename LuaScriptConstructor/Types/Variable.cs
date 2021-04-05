using LuaScriptConstructor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Types
{
    class Variable : Constant
    {
        /// <summary>
        /// Variable name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Variable value.
        /// </summary>
        public override string Value
        {
            get
            {
                return Name;
            }
        }

        public override ConstructorTable Table
        {
            get 
            {
                var table = new ConstructorTable();
                table.SetKey(Name + DateTime.Now.GetHashCode());
                table.Heading = Name;
                table.SubHeading = "";
                table.Label = new Crainiate.Diagramming.Label(Name);
                table.Type = ConstructorTable.ConstructionTableTypes.Variable;
                table.Variable = this;

                var input = new Crainiate.Diagramming.Port();
                input.Direction = Crainiate.Diagramming.Direction.In;
                input.Orientation = Crainiate.Diagramming.PortOrientation.Left;
                input.Style = Crainiate.Diagramming.PortStyle.Input;
                input.AllowMove = false;
                table.Ports.Add(input);

                var output = new Crainiate.Diagramming.Port();
                output.Direction = Crainiate.Diagramming.Direction.Out;
                output.Orientation = Crainiate.Diagramming.PortOrientation.Right;
                output.Style = Crainiate.Diagramming.PortStyle.Output;
                output.AllowMove = false;
                table.Ports.Add(output);

                return table;
            }
        }

        /// <summary>
        /// Function declaration string.
        /// </summary>
        public virtual string Declaration
        {
            get
            {
                return Name;
            }
        }
    
    }
}
