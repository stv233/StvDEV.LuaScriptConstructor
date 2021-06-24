using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        /// <summary>
        /// Loads all components available in the program.
        /// </summary>
        public static void FillComponents()
        {
            #region /// Basic

            _constants = _constants.Concat(BasicComponents.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(BasicComponents.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(BasicComponents.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// Comparsion

            _constants = _constants.Concat(ComparisonComponents.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(ComparisonComponents.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(ComparisonComponents.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// Function

            _constants = _constants.Concat(FunctionComponents.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(FunctionComponents.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(FunctionComponents.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// Logical

            _constants = _constants.Concat(LogicalComponents.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(LogicalComponents.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(LogicalComponents.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// Mathematical

            _constants = _constants.Concat(MathematicalComponents.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(MathematicalComponents.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(MathematicalComponents.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// Script

            _constants = _constants.Concat(ScriptСomponents.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(ScriptСomponents.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(ScriptСomponents.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// Types

            _constants = _constants.Concat(TypesComponents.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(TypesComponents.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(TypesComponents.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// String

            _constants = _constants.Concat(StringComponents.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(StringComponents.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(StringComponents.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// Values

            _constants = _constants.Concat(ValuesComponents.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(ValuesComponents.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(ValuesComponents.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// Trigger

            #region /// Player

            _constants = _constants.Concat(TriggerComponents.Player.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(TriggerComponents.Player.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(TriggerComponents.Player.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #endregion

            #region /// Global

            #region /// Text

            _constants = _constants.Concat(GlobalComponents.Text.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.Text.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.Text.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion;

            #region /// Visuals

            _constants = _constants.Concat(GlobalComponents.Visuals.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.Visuals.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.Visuals.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// LevelControl

            _constants = _constants.Concat(GlobalComponents.LevelControl.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.LevelControl.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.LevelControl.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// World

            _constants = _constants.Concat(GlobalComponents.World.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.World.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.World.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// PlayerControl

            _constants = _constants.Concat(GlobalComponents.PlayerControl.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.PlayerControl.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.PlayerControl.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// Particles

            _constants = _constants.Concat(GlobalComponents.Particles.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.Particles.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.Particles.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// EntityControl

            _constants = _constants.Concat(GlobalComponents.EntityControl.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.EntityControl.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.EntityControl.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// Scripts

            _constants = _constants.Concat(GlobalComponents.Scripts.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.Scripts.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.Scripts.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// CharacterAndAIControl

            _constants = _constants.Concat(GlobalComponents.CharacterAndAIControl.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.CharacterAndAIControl.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.CharacterAndAIControl.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// Zones

            _constants = _constants.Concat(GlobalComponents.Zones.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.Zones.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.Zones.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// SoundAndMusic

            _constants = _constants.Concat(GlobalComponents.SoundAndMusic.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.SoundAndMusic.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.SoundAndMusic.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// Lights

            _constants = _constants.Concat(GlobalComponents.Lights.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.Lights.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.Lights.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// Images

            _constants = _constants.Concat(GlobalComponents.Images.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.Images.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.Images.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// Sprites

            _constants = _constants.Concat(GlobalComponents.Sprites.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.Sprites.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.Sprites.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #region /// MultiPlayer

            _constants = _constants.Concat(GlobalComponents.MultiPlayer.Constants).ToDictionary(x => x.Key, x => x.Value);

            _variables = _variables.Concat(GlobalComponents.MultiPlayer.Variables).ToDictionary(x => x.Key, x => x.Value);

            _functions = _functions.Concat(GlobalComponents.MultiPlayer.Functions).ToDictionary(x => x.Key, x => x.Value);

            #endregion

            #endregion

        }

        /// <summary>
        /// Loads all components available in the program async.
        /// </summary>
        public static void FillComponentsAsync()
        {
            var thread = new Thread(() =>
            {
                FillComponents();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
