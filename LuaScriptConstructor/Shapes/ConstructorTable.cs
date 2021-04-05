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
        /// Table value.
        /// </summary>
        public string Value
        {
            get
            {
                if (Type == ConstructionTableTypes.Variable)
                {
                    return Variable.Value;
                }
                else if (Type == ConstructionTableTypes.Function)
                {
                    return Function.Value;
                }
                else
                {
                    return Constant.Value;
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
        public List<string> RerurnsValues { get; set; }

        public ConstructorTable() : base() { }

        public ConstructorTable(ConstructorTable prototype) : base(prototype) { }


    }
}
