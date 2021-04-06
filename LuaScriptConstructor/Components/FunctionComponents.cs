using System;
using System.Collections.Generic;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represents the components for building a function.
    /// </summary>
    static class FunctionComponents
    { 
        /// <summary>
        /// Constants.
        /// </summary>
        public static List<Types.Constant> Constants { get { return new List<Types.Constant>(); } }

        /// <summary>
        /// Variables.
        /// </summary>
        public static List<Types.Variable> Variables
        {
            get
            {
                var variable = new List<Types.Variable>();

                var input = new Types.Variable();
                input.Name = "Argument";
                input.Prefix = "functionargument";
                input.AccessType = Types.Variable.VariableAccessTypes.Output;
                variable.Add(input);

                var output = new Types.Variable();
                output.Name = "Return";
                output.Prefix = "functionreturn";
                output.AccessType = Types.Variable.VariableAccessTypes.Input;
                variable.Add(output);

                return variable;
            }
        }

        /// <summary>
        /// Functions.
        /// </summary>
        public static List<Types.Function> Functions { get { return new List<Types.Function>(); } }
    }
}
