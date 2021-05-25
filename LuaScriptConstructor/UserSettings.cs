using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor
{
    static class UserSettings
    {
        private static string currentPath = "";
        private static bool autoSave = true;

        private static System.Drawing.Size _size = new System.Drawing.Size();
        private static System.Drawing.Point _location = new System.Drawing.Point();
        private static string _gameGuruPath = "";
        private static int _diagramSize;
        private static bool _autoSnapshot = true;
        private static int _autoShnapshotDelat = 5;

        /// <summary>
        /// Struct for save user settings color scheme.
        /// </summary>
        private struct ColorSchemeSave
        {
            public string Name;
            public System.Drawing.Color MainColor;
            public System.Drawing.Color SecondaryColor;
            public System.Drawing.Color ForeColor;
            public System.Drawing.Color GridColor;
        }

        /// <summary>
        /// Struct for save user settings.
        /// </summary>
        private struct Save
        {
            public ColorSchemeSave ColorScheme;
            public System.Drawing.Size Size;
            public System.Drawing.Point Location;
            public string GameGuruPath;
            public int DiagramSize;
            public bool AutoSnapshot;
            public int AutoSnapshotDelay;
        }

        /// <summary>
        /// Users setting Color scheme.
        /// </summary>
        public static class ColorScheme
        {
            private static System.Drawing.Color _mainColor = System.Drawing.Color.FromArgb(239, 239, 239);
            private static System.Drawing.Color _secondaryColor = System.Drawing.Color.FromArgb(252, 252, 252);
            private static System.Drawing.Color _foreColor = System.Drawing.Color.Black;
            private static System.Drawing.Color _gridColor = System.Drawing.Color.FromArgb(128, 192, 192, 192);

            /// <summary>
            /// Color scheme name.
            /// </summary>
            public static string Name { get; set; }

            /// <summary>
            /// Main color.
            /// </summary>
            public static System.Drawing.Color MainColor
            {
                get
                {
                    return _mainColor;
                }
                set
                {
                    _mainColor = value;
                    if (autoSave)
                    {
                        SaveSettings(currentPath);
                    }
                }
            }

            /// <summary>
            /// Secondary color.
            /// </summary>
            public static System.Drawing.Color SecondaryColor
            {
                get
                {
                    return _secondaryColor;
                }
                set
                {
                    _secondaryColor = value;
                    if (autoSave)
                    {
                        SaveSettings(currentPath);
                    }
                }
            }
            
            /// <summary>
            /// Fore color.
            /// </summary>
            public static System.Drawing.Color ForeColor
            {
                get
                {
                    return _foreColor;
                }
                set
                {
                    _foreColor = value;
                    if (autoSave)
                    {
                        SaveSettings(currentPath);
                    }
                }
            }

            /// <summary>
            /// Grid color/
            /// </summary>
            public static System.Drawing.Color GridColor
            {
                get
                {
                    return _gridColor;
                }
                set
                {
                    _gridColor = value;
                    if (autoSave)
                    {
                        SaveSettings(currentPath);
                    }
                }
            }
        }

        /// <summary>
        /// Program window size
        /// </summary>
        public static System.Drawing.Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                if (autoSave)
                {
                    SaveSettings(currentPath);
                }
            }
        }

        /// <summary>
        /// Program window location.
        /// </summary>
        public static System.Drawing.Point Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                if (autoSave)
                {
                    SaveSettings(currentPath);
                }
            }
        }

        /// <summary>
        /// Path to gameguru.
        /// </summary>
        public static string GameGuruPath
        {
            get
            {
                return _gameGuruPath;
            }
            set
            {
                _gameGuruPath = value;
                if (autoSave)
                {
                    SaveSettings(currentPath);
                }
            }
        }

        /// <summary>
        /// Diagram size.
        /// </summary>
        public static int DiagramSize
        {
            get
            {
                return _diagramSize;
            }
            set
            {
                _diagramSize = value;
                if (autoSave)
                {
                    SaveSettings(currentPath);
                }
            }
        }

        /// <summary>
        /// Take auto snapshot.
        /// </summary>
        public static bool AutoSnapshot
        {
            get
            {
                return _autoSnapshot;
            }
            set
            {
                _autoSnapshot = value;
                if (autoSave)
                {
                    SaveSettings(currentPath);
                }
            }
        }

        /// <summary>
        /// Auto snapshot delay.
        /// </summary>
        public static int AutoSnapshotDelay
        {
            get
            {
                return _autoShnapshotDelat;
            }
            set
            {
                _autoShnapshotDelat = value;
                if (autoSave)
                {
                    SaveSettings(currentPath);
                }
            }
        }

        /// <summary>
        /// Load user setting from file.
        /// </summary>
        /// <param name="path">Path</param>
        public static void LoadSettings(string path)
        {
            autoSave = false;
            try
            {
                Save save = Newtonsoft.Json.JsonConvert.DeserializeObject<Save>(System.IO.File.ReadAllText(path));

                ColorScheme.Name = save.ColorScheme.Name;
                ColorScheme.MainColor = save.ColorScheme.MainColor;
                ColorScheme.SecondaryColor = save.ColorScheme.SecondaryColor;
                ColorScheme.ForeColor = save.ColorScheme.ForeColor;
                ColorScheme.GridColor = save.ColorScheme.GridColor;
                Size = save.Size;
                Location = save.Location;
                GameGuruPath = save.GameGuruPath;
                DiagramSize = save.DiagramSize;
                AutoSnapshot = save.AutoSnapshot;
                AutoSnapshotDelay = save.AutoSnapshotDelay;

                currentPath = path;
            }
            catch
            {
                ColorScheme.Name = "Light";
                ColorScheme.MainColor = System.Drawing.Color.FromArgb(239, 239, 239);
                ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(252, 252, 252);
                ColorScheme.ForeColor = System.Drawing.Color.Black;
                ColorScheme.GridColor = System.Drawing.Color.FromArgb(128, 192, 192, 192);

                Size = new System.Drawing.Size(800, 600);
                Location = new System.Drawing.Point(500, 500);
                GameGuruPath = "";
                DiagramSize = 2000;
                AutoSnapshot = true;
                AutoSnapshotDelay = 2;

                SaveSettings(path);
            }
            autoSave = true;
        }

        /// <summary>
        /// Save users settings to file.
        /// </summary>
        /// <param name="path">Path</param>
        public static void SaveSettings(string path)
        {
            if (currentPath != path)
            {
                currentPath = path;
            }

            Save save = new Save();
            save.ColorScheme.Name = ColorScheme.Name;
            save.ColorScheme.MainColor = ColorScheme.MainColor;
            save.ColorScheme.SecondaryColor = ColorScheme.SecondaryColor;
            save.ColorScheme.ForeColor = ColorScheme.ForeColor;
            save.ColorScheme.GridColor = ColorScheme.GridColor;

            save.Size = Size;
            save.Location = Location;
            save.GameGuruPath = GameGuruPath;
            save.DiagramSize = DiagramSize;
            save.AutoSnapshot = AutoSnapshot;
            save.AutoSnapshotDelay = AutoSnapshotDelay;

            try
            {
                System.IO.File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(save));
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
                System.IO.File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(save));
            }
        }

    }
}
