using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Components
{
    /// <summary>
    /// Represents the main components of the script.
    /// </summary>
    static class ScriptСomponents
    {
        /// <summary>
        /// Constants.
        /// </summary>
        public static Dictionary<string, Types.Constant> Constants { get { return new Dictionary<string, Types.Constant>(); } }

        /// <summary>
        /// Variables.
        /// </summary>
        public static Dictionary<string, Types.Variable> Variables { get { return new Dictionary<string, Types.Variable>(); } }

        /// <summary>
        /// Functions.
        /// </summary>
        public static Dictionary<string, Types.Function> Functions
        {
            get
            {
                Dictionary<string, Types.Function> functions = new Dictionary<string, Types.Function>();

                #region /// Main

                var main = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Main",
                    Prefix = "main",
                    Type = Types.Function.FuntionTypes.Main,
                    AccessType = Types.Variable.VariableAccessTypes.Output
                };

                var mainTable = new Shapes.ConstructorTable
                {
                    Type = Shapes.ConstructorTable.ConstructorTableTypes.Function,
                    Function = main,
                    Heading = main.Name,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    Forecolor = UserSettings.ColorScheme.ForeColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                    SubHeading = "Main script function"
                };
                mainTable.SetKey(main.Prefix + "_" + main.Name + Math.Abs(DateTime.Now.GetHashCode()).ToString());

                var mainPort = new Crainiate.Diagramming.Port
                {
                    AllowMove = false,
                    Direction = Crainiate.Diagramming.Direction.Out,
                    Orientation = Crainiate.Diagramming.PortOrientation.Bottom,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                };
                mainPort.SetKey("mainoutput_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                mainTable.Ports.Add(mainPort);

                main.Table = mainTable;

                functions.Add(main.Name, main);

                #endregion

                #region /// Init

                var init = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Init",
                    Prefix = "init",
                    Type = Types.Function.FuntionTypes.Init,
                    AccessType = Types.Variable.VariableAccessTypes.Output
                };

                var initTable = new Shapes.ConstructorTable
                {
                    Type = Shapes.ConstructorTable.ConstructorTableTypes.Function,
                    Function = init,
                    Heading = init.Name,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    Forecolor = UserSettings.ColorScheme.ForeColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                    SubHeading = "Init script function"
                };
                initTable.SetKey(init.Prefix + "_" + init.Name + Math.Abs(DateTime.Now.GetHashCode()).ToString());

                var initPort = new Crainiate.Diagramming.Port
                {
                    AllowMove = false,
                    Direction = Crainiate.Diagramming.Direction.Out,
                    Orientation = Crainiate.Diagramming.PortOrientation.Bottom,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                };
                initPort.SetKey("initoutput_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                initTable.Ports.Add(initPort);

                init.Table = initTable;

                functions.Add(init.Name, init);

                #endregion

                #region /// Start

                var start = new Types.ProgrammaticallyDefinedFunction
                {
                    Name = "Function start",
                    Prefix = "functionstart",
                    Type = Types.Function.FuntionTypes.Init,
                    AccessType = Types.Variable.VariableAccessTypes.Output
                };

                var startTable = new Shapes.ConstructorTable
                {
                    Type = Shapes.ConstructorTable.ConstructorTableTypes.Function,
                    Function = start,
                    Heading = start.Name,
                    CanEditHeading = true,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    Forecolor = UserSettings.ColorScheme.ForeColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                    SubHeading = "Function start"
                };
                startTable.SetKey(start.Prefix + "_" + start.Name + Math.Abs(DateTime.Now.GetHashCode()).ToString());

                var startPort = new Crainiate.Diagramming.Port
                {
                    AllowMove = false,
                    Direction = Crainiate.Diagramming.Direction.Out,
                    Orientation = Crainiate.Diagramming.PortOrientation.Bottom,
                    BackColor = UserSettings.ColorScheme.MainColor,
                    GradientColor = UserSettings.ColorScheme.MainColor,
                    BorderColor = UserSettings.ColorScheme.ForeColor,
                };
                startPort.SetKey("startoutput_" + Math.Abs(DateTime.Now.GetHashCode()).ToString());
                startTable.Ports.Add(startPort);

                start.Table = startTable;

                functions.Add(start.Name, start);

                return functions;

                #endregion
            }
        }
    }
}
