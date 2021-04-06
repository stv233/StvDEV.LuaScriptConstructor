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
        /// Variable access types.
        /// </summary>
        public enum VariableAccessTypes
        {
            InputOutput,
            Input,
            Output
        }

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

        /// <summary>
        /// Variable access type.
        /// </summary>
        public virtual VariableAccessTypes AccessType { get; set; }

        /// <summary>
        /// Variable table.
        /// </summary>
        public override ConstructorTable Table
        {
            get 
            {
                var table = new ConstructorTable();
                table.SetKey(Prefix + "_" + Name + DateTime.Now.GetHashCode());
                table.Heading = Name;
                table.SubHeading = "";
                table.Label = new Crainiate.Diagramming.Label(Name);
                table.Type = ConstructorTable.ConstructionTableTypes.Variable;
                table.Variable = this;

                if ((AccessType == VariableAccessTypes.Input) || (AccessType == VariableAccessTypes.InputOutput))
                {
                    var input = new Crainiate.Diagramming.Port();
                    input.SetKey("input_" + Prefix + "_" + Name + DateTime.Now.GetHashCode());
                    input.Direction = Crainiate.Diagramming.Direction.In;
                    input.Orientation = Crainiate.Diagramming.PortOrientation.Left;
                    input.Style = Crainiate.Diagramming.PortStyle.Input;
                    input.AllowMove = false;
                    table.Ports.Add(input);
                }

                if ((AccessType == VariableAccessTypes.Output) || (AccessType == VariableAccessTypes.InputOutput))
                {
                    var output = new Crainiate.Diagramming.Port();
                    output.SetKey("output_" + Prefix + "_" + Name + DateTime.Now.GetHashCode());
                    output.Direction = Crainiate.Diagramming.Direction.Out;
                    output.Orientation = Crainiate.Diagramming.PortOrientation.Right;
                    output.Style = Crainiate.Diagramming.PortStyle.Output;
                    output.AllowMove = false;
                    table.Ports.Add(output);
                }

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
