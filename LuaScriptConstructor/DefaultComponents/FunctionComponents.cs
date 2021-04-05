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
                input.Name = "functionargument";
                variable.Add(input);

                var output = new Types.Variable();
                output.Name = "functionreturns";
                variable.Add(output);

                return variable;
            }
        }


    }
}
