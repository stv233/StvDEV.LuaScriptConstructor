﻿using System;
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
        public static Dictionary<string, Types.Constant> Constants { get { return new Dictionary<string, Types.Constant>(); } }

        /// <summary>
        /// Variables.
        /// </summary>
        public static Dictionary<string, Types.Variable> Variables
        {
            get
            {
                var variables = new Dictionary<string, Types.Variable>();

                var input = new Types.Variable
                {
                    Name = "Argument",
                    Prefix = "functionargument",
                    AccessType = Types.Variable.VariableAccessTypes.None,
                    InteractionType = Types.Variable.ValueInteractionTypes.Get
                };
                input.TableRebuilding += (s, e) =>
                {
                    e.Table.SubHeading = "Argument";
                    e.Table.BackColor = e.Table.GradientColor = System.Drawing.Color.DeepSkyBlue;
                };

                variables.Add(input.Name, input);

                var output = new Types.Variable
                {
                    Name = "Return",
                    Prefix = "functionreturn",
                    AccessType = Types.Variable.VariableAccessTypes.None,
                    InteractionType = Types.Variable.ValueInteractionTypes.Set
                };
                output.TableRebuilding += (s, e) =>
                {
                    e.Table.SubHeading = "Return";
                    e.Table.BackColor = e.Table.GradientColor = System.Drawing.Color.DeepSkyBlue;
                };

                variables.Add(output.Name, output);

                return variables;
            }
        }

        /// <summary>
        /// Functions.
        /// </summary>
        public static Dictionary<string, Types.Function> Functions { get { return new Dictionary<string, Types.Function>(); } }
    }
}
