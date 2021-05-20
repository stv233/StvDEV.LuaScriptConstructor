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
        public string _identifern = null;

        /// <summary>
        /// Variable access types.
        /// </summary>
        public enum VariableAccessTypes
        {
            InputOutput,
            Input,
            Output,
            None
        }

        /// <summary>
        /// Value interaction types.
        /// </summary>
        public enum ValueInteractionTypes
        {
            GetSet,
            Get,
            Set,
            None
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
        /// Variable value interaction type.
        /// </summary>
        public virtual ValueInteractionTypes InteractionType { get; set; }

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
                    Type = ConstructorTable.ConstructorTableTypes.Variable,
                    BackColor = System.Drawing.Color.Aquamarine,
                    GradientColor = System.Drawing.Color.Aquamarine,
                    CanEditHeading = true,
                    Icon = Properties.Resources.LocalVariable_16x,
                    Variable = this
                };
                table.SetKey(Prefix + "_" + Name + "_" + DateTime.Now.GetHashCode());

                if ((InteractionType == ValueInteractionTypes.Set) || (InteractionType == ValueInteractionTypes.GetSet))
                {
                    var argument = new Crainiate.Diagramming.Port
                    {
                        Direction = Crainiate.Diagramming.Direction.In,
                        Orientation = Crainiate.Diagramming.PortOrientation.Left,
                        Style = Crainiate.Diagramming.PortStyle.Input,
                        AllowMove = false
                    };
                    argument.SetKey("argument_" + Prefix + "_" + Name + "_" + DateTime.Now.GetHashCode());
                    table.Ports.Add(argument);


                    
                }

                if ((InteractionType == ValueInteractionTypes.Get) || (InteractionType == ValueInteractionTypes.GetSet))
                {
                    var @return = new Crainiate.Diagramming.Port
                    {
                        Direction = Crainiate.Diagramming.Direction.Out,
                        Orientation = Crainiate.Diagramming.PortOrientation.Right,
                        Style = Crainiate.Diagramming.PortStyle.Output,
                        AllowMove = false
                    };
                    @return.SetKey("return_" + Prefix + "_" + Name + "_" + DateTime.Now.GetHashCode());
                    table.Ports.Add(@return);
                }

                if ((AccessType == VariableAccessTypes.Input) || (AccessType == VariableAccessTypes.InputOutput))
                {
                    var input = new Crainiate.Diagramming.Port
                    {
                        Direction = Crainiate.Diagramming.Direction.In,
                        Orientation = Crainiate.Diagramming.PortOrientation.Top,
                        Style = Crainiate.Diagramming.PortStyle.Simple,
                        AllowMove = false
                    };
                    input.SetKey("input_" + Prefix + "_" + Name + "_" + DateTime.Now.GetHashCode());
                    table.Ports.Add(input);
                }

                if ((AccessType == VariableAccessTypes.Output) || (AccessType == VariableAccessTypes.InputOutput))
                {
                    var output = new Crainiate.Diagramming.Port
                    {
                        Direction = Crainiate.Diagramming.Direction.Out,
                        Orientation = Crainiate.Diagramming.PortOrientation.Bottom,
                        Style = Crainiate.Diagramming.PortStyle.Simple,
                        AllowMove = false
                    };
                    output.SetKey("output_" + Prefix + "_" + Name + "_" + DateTime.Now.GetHashCode());
                    table.Ports.Add(output);
                }

                return table;
            }
        }



        /// <summary>
        /// Function identifier string.
        /// </summary>
        public virtual string Identifier
        {
            get
            {
                if (_identifern == null)
                {
                    return Name;
                }
                else
                {
                    return _identifern;
                }
            }
            protected set
            {
                _identifern = value;
            }
        }

    }
}
