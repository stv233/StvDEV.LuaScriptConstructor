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
        private static bool _abort = false;
        private static bool _devMode = false;
        private static System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

        /// <summary>
        /// Returns the path to the program data folder.
        /// </summary>
        public static string AppDataPath
        {
            get
            {
                return _appDataPath;
            }
        }

        /// <summary>
        /// Returns the program title.
        /// </summary>
        public static string Title
        {
            get
            {
                return Name + " " + Version;
            }
        }

        /// <summary>
        /// Returns the program name.
        /// </summary>
        public static string Name
        {
            get
            {
                return (assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), true).SingleOrDefault() as System.Reflection.AssemblyTitleAttribute)
                    .Title;
            }
        }

        /// <summary>
        /// Returns the program version.
        /// </summary>
        public static Version Version
        {
            get
            {
                return assembly.GetName().Version;
            }
        }

        /// <summary>
        /// Returns or sets whether to restart the main program window.
        /// </summary>
        public static bool Restart { get; set; }

        /// <summary>
        /// Returns or sets whether to abort the program download.
        /// </summary>
        public static bool Abort
        {
            get
            {
                return _abort;
            }
            set
            {
                _abort = value;
            }
        }

        /// <summary>
        /// Returns whether the program is running in developer mode.
        /// </summary>
        public static bool DeveloperMode
        {
            get
            {
                return _devMode;
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            #region /// Program Initialization

            List<string> argsList = new List<string>(args);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #endregion

            #region /// Arguments & Settings

            if (argsList.Contains("-reset")) // Reset settings.
            {
                System.IO.File.Delete(AppDataPath + "UserSettings.uset");
                argsList.RemoveAll(new Predicate<string>((delegate (string x) { return x == "-reset"; })));
            }

            if (!System.IO.File.Exists(AppDataPath + "UserSettings.uset")) { argsList.Add("-greeting"); }

            UserSettings.LoadSettings(AppDataPath + "UserSettings.uset");

            if (argsList.Contains("-greeting")) // Greeting form.
            {
                new ApplicationForms.GreetingDialog().ShowDialog();
                argsList.RemoveAll(new Predicate<string>((delegate (string x) { return x == "-greeting"; })));
            }

            if (argsList.Contains("-devmode")) // Developer mode
            {
                _devMode = true;
                argsList.RemoveAll(new Predicate<string>((delegate (string x) { return x == "-devmode"; })));
            }

            #endregion

            #region /// Projects

            Projects.LoadProjects(AppDataPath + "Projects.list");
            if (!(argsList.Count > 0))
            {    
                var pdProjects = new ProjectDialog
                {
                    Icon = Properties.Resources.ico,
                    Text = Program.Title + " projects",
                    Projects = Projects.List,
                    BackColor = UserSettings.ColorScheme.SecondaryColor, 
                    ForeColor = UserSettings.ColorScheme.ForeColor
                };
                pdProjects.RefreshProjects();
                if (pdProjects.ShowDialog() == DialogResult.OK)
                {
                    argsList.Add(pdProjects.Project);
                }
            }

            #endregion

            #region /// Load Screen

            LoadScreen.Icon = Properties.Resources.ico;
            LoadScreen.Status = Program.Title;
            LoadScreen.Image = Properties.Resources.ico.ToBitmap();
            LoadScreen.Show();

            #endregion

            if (Abort) { return; }

            Components.Components.FillComponents();

            if (Abort) { return; }

            Application.Run(new ApplicationForms.MainWindow((argsList.Count > 0) ? argsList[0] : ""));

            while (Restart)
            {
                Restart = false;
                LoadScreen.Show();
                new ApplicationForms.MainWindow("").ShowDialog();
            }
        }
    }
}
