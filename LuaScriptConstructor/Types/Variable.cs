using LuaScriptConstructor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Types
{
    /// <summary>
    /// Lua variable.
    /// </summary>
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
                var table = new ConstructorTable
                {
                    Heading = Name,
                    SubHeading = "",
                    Label = new Crainiate.Diagramming.Label(Name),
                    Type = ConstructorTable.ConstructionTableTypes.Variable,
                    Variable = this
                };
                table.SetKey(Prefix + "_" + Name + DateTime.Now.GetHashCode());

                if ((AccessType == VariableAccessTypes.Input) || (AccessType == VariableAccessTypes.InputOutput))
                {
                    var input = new Crainiate.Diagramming.Port
                    {
                        Direction = Crainiate.Diagramming.Direction.In,
                        Orientation = Crainiate.Diagramming.PortOrientation.Left,
                        Style = Crainiate.Diagramming.PortStyle.Input,
                        AllowMove = false
                    };
                    input.SetKey("input_" + Prefix + "_" + Name + DateTime.Now.GetHashCode());
                    table.Ports.Add(input);
                    
                }

                if ((AccessType == VariableAccessTypes.Output) || (AccessType == VariableAccessTypes.InputOutput))
                {
                    var output = new Crainiate.Diagramming.Port
                    {
                        Direction = Crainiate.Diagramming.Direction.Out,
                        Orientation = Crainiate.Diagramming.PortOrientation.Right,
                        Style = Crainiate.Diagramming.PortStyle.Output,
                        AllowMove = false
                    };
                    output.SetKey("output_" + Prefix + "_" + Name + DateTime.Now.GetHashCode());
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
