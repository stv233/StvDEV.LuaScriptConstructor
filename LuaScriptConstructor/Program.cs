﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuaScriptConstructor
{
    static class Program
    {
        private static string _appDataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\StvDEV.PRO\\ScriptConstructor\\";
        private static bool _readyToStart = false;

        public static string AppDataPath
        {
            get
            {
                return _appDataPath;
            }
        }

        public static string Title
        {
            get
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                return (assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), true).SingleOrDefault() as System.Reflection.AssemblyTitleAttribute)
                    .Title + " " + assembly.GetName().Version;
            }
        }
        public static bool Restart { get; set; }

        public static bool ReadyToStart
        {
            get
            {
                return _readyToStart;
            }
            set
            {
                _readyToStart = value;
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

            #endregion

            #region /// Projects

            if (!(argsList.Count > 0))
            {
                Projects.LoadProjects(AppDataPath + "Projects.list");
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

            Components.Components.FillComponents();

            Application.Run(new ApplicationForms.MainWindow((argsList.Count > 0) ? argsList[0] : ""));

            while(Restart)
            {
                Restart = false;
                LoadScreen.Show();
                new ApplicationForms.MainWindow("").ShowDialog();
            }
        }
    }
}
