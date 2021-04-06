using System;
using System.Collections.Generic;

namespace LuaScriptConstructor.DefaultComponents
{
    static class FunctionComponents
    {
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


    }
}
