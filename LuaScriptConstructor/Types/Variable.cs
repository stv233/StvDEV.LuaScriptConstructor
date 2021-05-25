using LuaScriptConstructor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Types
{
    /// <summary>
    /// Represents a variable type class for a script constructor.
    /// </summary>
    class Variable : Constant
    {
        public string _identifern = null;

        /// <summary>
        /// Fires during table rebuild.
        /// </summary>
        public override event RebuildTableEvents TableRebuilding;

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
                    Forecolor = UserSettings.ColorScheme.ForeColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                    CanEditHeading = true,
                    Icon = Properties.Resources.LocalVariable_16x,
                    Variable = this
                };
                if (UserSettings.ColorScheme.Name == "Blueberry")
                {
                    table.BackColor = System.Drawing.Color.DarkTurquoise;
                    table.GradientColor = System.Drawing.Color.DarkTurquoise;
                    table.Forecolor = UserSettings.ColorScheme.ForeColor;
                    table.BorderColor = UserSettings.ColorScheme.ForeColor;
                }
                else
                {
                    table.BackColor = System.Drawing.Color.Aquamarine;
                    table.GradientColor = System.Drawing.Color.Aquamarine;
                    table.Forecolor = UserSettings.ColorScheme.ForeColor;
                    table.BorderColor = UserSettings.ColorScheme.ForeColor;
                }
                table.SetKey(Prefix + "_" + Name + "_" + DateTime.Now.GetHashCode());

                if ((InteractionType == ValueInteractionTypes.Set) || (InteractionType == ValueInteractionTypes.GetSet))
                {
                    var argument = new Crainiate.Diagramming.Port
                    {
                        Direction = Crainiate.Diagramming.Direction.In,
                        Orientation = Crainiate.Diagramming.PortOrientation.Left,
                        Style = Crainiate.Diagramming.PortStyle.Input,
                        BackColor = UserSettings.ColorScheme.MainColor,
                        GradientColor = UserSettings.ColorScheme.MainColor,
                        BorderColor = UserSettings.ColorScheme.ForeColor,
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
                        BackColor = UserSettings.ColorScheme.MainColor,
                        GradientColor = UserSettings.ColorScheme.MainColor,
                        BorderColor = UserSettings.ColorScheme.ForeColor,
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
                        BackColor = UserSettings.ColorScheme.MainColor,
                        GradientColor = UserSettings.ColorScheme.MainColor,
                        BorderColor = UserSettings.ColorScheme.ForeColor,
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
                        BackColor = UserSettings.ColorScheme.MainColor,
                        GradientColor = UserSettings.ColorScheme.MainColor,
                        BorderColor = UserSettings.ColorScheme.ForeColor,
                        AllowMove = false
                    };
                    output.SetKey("output_" + Prefix + "_" + Name + "_" + DateTime.Now.GetHashCode());
                    table.Ports.Add(output);
                }

                try
                {
                    TableRebuilding(this, new RebuildEventArgs(ref table));
                }
                catch (NullReferenceException) { }
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
