using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuaScriptConstructor
{
    static class Program
    {
        private static string _appDataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\StvDEV.PRO\\ScriptConstructor\\";

        public static string AppDataPath
        {
            get
            {
                return _appDataPath;
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserSettings.LoadSettings(AppDataPath + "UserSettings.uset");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Components.Components.ManualActivation();

            Application.Run(new frMain());
        }
    }
}
