using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represent all programm components.
    /// </summary>
    static class Components
    {
        private static Dictionary<string, Types.Constant> _constants = new Dictionary<string, Types.Constant>();
        private static Dictionary<string, Types.Variable> _variables = new Dictionary<string, Types.Variable>();
        private static Dictionary<string, Types.Function> _functions = new Dictionary<string, Types.Function>();

        /// <summary>
        /// Constants.
        /// </summary>
        public static Dictionary<string, Types.Constant> Constants
        {
            get
            {
                return _constants;
            }
        }

        /// <summary>
        /// Variables.
        /// </summary>
        public static Dictionary<string, Types.Variable> Variables
        {
            get
            {
                return _variables;
            }
        }

        /// <summary>
        /// Functions.
        /// </summary>
        public static Dictionary<string ,Types.Function> Functions
        {
            get
            {
                return _functions;
            }
        }

        static Components()
        {
            #region /// Basic

            foreach (var key in BasicComponents.Constants.Keys)
            {
                _constants[key] = BasicComponents.Constants[key];
            }

            foreach (var key in BasicComponents.Variables.Keys)
            {
                _variables[key] = BasicComponents.Variables[key];
            }

            foreach(var key in BasicComponents.Functions.Keys)
            {
                _functions[key] = BasicComponents.Functions[key];
            }

            #endregion;

            #region /// Comparsion

            foreach (var key in ComparisonComponents.Constants.Keys)
            {
                _constants[key] = ComparisonComponents.Constants[key];
            }

            foreach (var key in ComparisonComponents.Variables.Keys)
            {
                _variables[key] = ComparisonComponents.Variables[key];
            }

            foreach (var key in ComparisonComponents.Functions.Keys)
            {
                _functions[key] = ComparisonComponents.Functions[key];
            }

            #endregion;

            #region /// Function

            foreach (var key in FunctionComponents.Constants.Keys)
            {
                _constants[key] = FunctionComponents.Constants[key];
            }

            foreach (var key in FunctionComponents.Variables.Keys)
            {
                _variables[key] = FunctionComponents.Variables[key];
            }

            foreach (var key in FunctionComponents.Functions.Keys)
            {
                _functions[key] = FunctionComponents.Functions[key];
            }

            #endregion;

            #region /// Logical

            foreach (var key in LogicalComponents.Constants.Keys)
            {
                _constants[key] = LogicalComponents.Constants[key];
            }

            foreach (var key in LogicalComponents.Variables.Keys)
            {
                _variables[key] = LogicalComponents.Variables[key];
            }

            foreach (var key in LogicalComponents.Functions.Keys)
            {
                _functions[key] = LogicalComponents.Functions[key];
            }

            #endregion;

            #region /// Mathematical

            foreach (var key in MathematicalComponents.Constants.Keys)
            {
                _constants[key] = MathematicalComponents.Constants[key];
            }

            foreach (var key in MathematicalComponents.Variables.Keys)
            {
                _variables[key] = MathematicalComponents.Variables[key];
            }

            foreach (var key in MathematicalComponents.Functions.Keys)
            {
                _functions[key] = MathematicalComponents.Functions[key];
            }

            #endregion;

            #region /// Script

            foreach (var key in ScriptСomponents.Constants.Keys)
            {
                _constants[key] = ScriptСomponents.Constants[key];
            }

            foreach (var key in ScriptСomponents.Variables.Keys)
            {
                _variables[key] = ScriptСomponents.Variables[key];
            }

            foreach (var key in ScriptСomponents.Functions.Keys)
            {
                _functions[key] = ScriptСomponents.Functions[key];
            }

            #endregion;

            #region /// Types

            foreach (var key in TypesComponents.Constants.Keys)
            {
                _constants[key] = TypesComponents.Constants[key];
            }

            foreach (var key in TypesComponents.Variables.Keys)
            {
                _variables[key] = TypesComponents.Variables[key];
            }

            foreach (var key in TypesComponents.Functions.Keys)
            {
                _functions[key] = TypesComponents.Functions[key];
            }

            #endregion;

            #region /// Values

            foreach (var key in ValuesComponents.Constants.Keys)
            {
                _constants[key] = ValuesComponents.Constants[key];
            }

            foreach (var key in ValuesComponents.Variables.Keys)
            {
                _variables[key] = ValuesComponents.Variables[key];
            }

            foreach (var key in ValuesComponents.Functions.Keys)
            {
                _functions[key] = ValuesComponents.Functions[key];
            }

            #endregion;

            #region /// Global

            #region /// Text

            foreach (var key in GlobalComponents.Text.Constants.Keys)
            {
                _constants[key] = GlobalComponents.Text.Constants[key];
            }

            foreach (var key in GlobalComponents.Text.Variables.Keys)
            {
                _variables[key] = GlobalComponents.Text.Variables[key];
            }

            foreach (var key in GlobalComponents.Text.Functions.Keys)
            {
                _functions[key] = GlobalComponents.Text.Functions[key];
            }

            #endregion;

            #region /// Visuals

            foreach (var key in GlobalComponents.Visuals.Constants.Keys)
            {
                _constants[key] = GlobalComponents.Visuals.Constants[key];
            }

            foreach (var key in GlobalComponents.Visuals.Variables.Keys)
            {
                _variables[key] = GlobalComponents.Visuals.Variables[key];
            }

            foreach (var key in GlobalComponents.Visuals.Functions.Keys)
            {
                _functions[key] = GlobalComponents.Visuals.Functions[key];
            }

            #endregion

            #region /// LevelControl

            foreach (var key in GlobalComponents.LevelControl.Constants.Keys)
            {
                _constants[key] = GlobalComponents.LevelControl.Constants[key];
            }

            foreach (var key in GlobalComponents.LevelControl.Variables.Keys)
            {
                _variables[key] = GlobalComponents.LevelControl.Variables[key];
            }

            foreach (var key in GlobalComponents.LevelControl.Functions.Keys)
            {
                _functions[key] = GlobalComponents.LevelControl.Functions[key];
            }

            #endregion

            #region /// World

            foreach (var key in GlobalComponents.World.Constants.Keys)
            {
                _constants[key] = GlobalComponents.World.Constants[key];
            }

            foreach (var key in GlobalComponents.World.Variables.Keys)
            {
                _variables[key] = GlobalComponents.World.Variables[key];
            }

            foreach (var key in GlobalComponents.World.Functions.Keys)
            {
                _functions[key] = GlobalComponents.World.Functions[key];
            }

            #endregion

            #region /// PlayerControl

            foreach (var key in GlobalComponents.PlayerControl.Constants.Keys)
            {
                _constants[key] = GlobalComponents.PlayerControl.Constants[key];
            }

            foreach (var key in GlobalComponents.PlayerControl.Variables.Keys)
            {
                _variables[key] = GlobalComponents.PlayerControl.Variables[key];
            }

            foreach (var key in GlobalComponents.PlayerControl.Functions.Keys)
            {
                _functions[key] = GlobalComponents.PlayerControl.Functions[key];
            }

            #endregion

            #region /// Particles

            foreach (var key in GlobalComponents.Particles.Constants.Keys)
            {
                _constants[key] = GlobalComponents.Particles.Constants[key];
            }

            foreach (var key in GlobalComponents.Particles.Variables.Keys)
            {
                _variables[key] = GlobalComponents.Particles.Variables[key];
            }

            foreach (var key in GlobalComponents.Particles.Functions.Keys)
            {
                _functions[key] = GlobalComponents.Particles.Functions[key];
            }

            #endregion

            #endregion

        }

        /// <summary>
        /// An empty method, designed to activate the constructor in the right place.
        /// </summary>
        public static void ManualActivation() { }

    }
}
