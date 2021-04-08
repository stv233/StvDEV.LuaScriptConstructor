using System;
using System.Collections.Generic;
using Crainiate.Diagramming;

namespace LuaScriptConstructor.Shapes
{
    /// <summary>
    /// Constructor table.
    /// </summary>
    class ConstructorTable : Table
    {
        public enum ConstructionTableTypes
        {
            Function,
            Variable,
            Constant
        }

        /// <summary>
        /// Table type.
        /// </summary>
        public ConstructionTableTypes Type { get; set; }

        /// <summary>
        /// Table function.
        /// </summary>
        public Types.Function Function { get; set; }

        /// <summary>
        /// Table variable.
        /// </summary>
        public Types.Variable Variable { get; set; }

        /// <summary>
        /// Table constant.
        /// </summary>
        public Types.Constant Constant { get; set; }

        /// <summary>
        /// Table owner.
        /// </summary>
        public Types.Constant Owner
        {
            get
            {
                if (Type == ConstructionTableTypes.Variable)
                {
                    return Variable;
                }
                else if (Type == ConstructionTableTypes.Function)
                {
                    return Function;
                }
                else
                {
                    return Constant;
                }
            }
        }

        /// <summary>
        /// Values of connected inputs;
        /// </summary>
        public List<string> ArgumentsValues { get; set; }

        /// <summary>
        /// Values of connected return;
        /// </summary>
        public List<string> RetrurnsValues { get; set; }

        /// <summary>
        /// Can edit table Heading.
        /// </summary>
        public bool CanEditHeading { get; set; }

        private System.Drawing.Image _icon;
        /// <summary>
        /// Table icon.
        /// </summary>
        public System.Drawing.Image Icon
        {
            get
            {
                return new System.Drawing.Bitmap(_icon);
            }
            set
            {
                _icon = value;
            }
        }

        public ConstructorTable() : base() {}

        public ConstructorTable(ConstructorTable prototype) : base(prototype)
        {
            Type = prototype.Type;
            Function = prototype.Function;
            Variable = prototype.Variable;
            Constant = prototype.Constant;
            ArgumentsValues = prototype.ArgumentsValues;
            RetrurnsValues = prototype.RetrurnsValues;
            CanEditHeading = prototype.CanEditHeading;
            Size = prototype.Size;

            Ports.Clear();
            foreach (Port port in prototype.Ports.Values)
            {
                if (port is TablePort)
                {
                    var tablePort = (TablePort)port;
                    TablePort clone = new TablePort(tablePort.TableItem);
                    clone.Direction = tablePort.Direction;
                    clone.Orientation = tablePort.Orientation;
                    clone.Alignment = tablePort.Alignment;
                    clone.Style = tablePort.Style;
                    Ports.Add(port.Key, clone);
                }
                else
                {
                    Port clone = (Port)port.Clone();
                    Ports.Add(port.Key, clone);
                }
            }
        }

    }
}
