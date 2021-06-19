using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LuaScriptConstructor
{
    static class UserSettings
    {
        private static string currentPath = "";
        private static bool autoSave = true;

        private static ColorSchemeClass _colorScheme = new ColorSchemeClass();
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
        /// Color scheme class.
        /// </summary>
        public class ColorSchemeClass
        {
            private  System.Drawing.Color _mainColor = System.Drawing.Color.FromArgb(239, 239, 239);
            private  System.Drawing.Color _secondaryColor = System.Drawing.Color.FromArgb(252, 252, 252);
            private  System.Drawing.Color _foreColor = System.Drawing.Color.Black;
            private  System.Drawing.Color _gridColor = System.Drawing.Color.FromArgb(128, 192, 192, 192);

            /// <summary>
            /// Color scheme name.
            /// </summary>
            public  string Name { get; set; }

            /// <summary>
            /// Main color.
            /// </summary>
            public  System.Drawing.Color MainColor
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
            public System.Drawing.Color SecondaryColor
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
            public System.Drawing.Color ForeColor
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
            public System.Drawing.Color GridColor
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
        /// Represents all color themes in the programю
        /// </summary>
        public static class ColorThemes
        {
            private static Dictionary<string, UserSettings.ColorSchemeClass> _themes = new Dictionary<string, UserSettings.ColorSchemeClass>();

            /// <summary>
            /// Dictionary of color themes.
            /// </summary>
            public static Dictionary<string, UserSettings.ColorSchemeClass> Themes
            {
                get
                {
                    return _themes;
                }
            }

            static ColorThemes()
            {
                _themes.Add("Light", new UserSettings.ColorSchemeClass
                {
                    Name = "Light",
                    MainColor = System.Drawing.Color.FromArgb(239, 239, 239),
                    SecondaryColor = System.Drawing.Color.FromArgb(252, 252, 252),
                    ForeColor = Color.Black,
                    GridColor = System.Drawing.Color.FromArgb(128, 192, 192, 192),
                });

                _themes.Add("Dark", new UserSettings.ColorSchemeClass
                {
                    Name = "Dark",
                    MainColor = Color.FromArgb(64, 64, 64),
                    SecondaryColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.White,
                    GridColor = Color.FromArgb(128, 192, 192, 192),
                });

                _themes.Add("Chocolate brownie", new UserSettings.ColorSchemeClass
                {
                    Name = "Chocolate brownie",
                    MainColor = Color.FromArgb(82, 54, 52),
                    SecondaryColor = Color.FromArgb(48, 26, 40),
                    ForeColor = Color.FromArgb(221, 197, 163),
                    GridColor = Color.FromArgb(181, 67, 44),
                });

                _themes.Add("Sunny town", new UserSettings.ColorSchemeClass
                {
                    Name = "Sunny town",
                    MainColor = Color.FromArgb(235, 138, 62),
                    SecondaryColor = Color.FromArgb(210, 65, 54),
                    ForeColor = Color.FromArgb(226, 196, 153),
                    GridColor = Color.FromArgb(235, 181, 130),
                });

                _themes.Add("Library", new UserSettings.ColorSchemeClass
                {
                    Name = "Library",
                    MainColor = Color.FromArgb(108, 45, 44),
                    SecondaryColor = Color.FromArgb(66, 49, 58),
                    ForeColor = Color.FromArgb(241, 220, 201),
                    GridColor = Color.FromArgb(159, 70, 54),
                });

                _themes.Add("Sea wave", new UserSettings.ColorSchemeClass
                {
                    Name = "Sea wave",
                    MainColor = Color.FromArgb(6, 87, 91),
                    SecondaryColor = Color.FromArgb(0, 59, 70),
                    ForeColor = Color.FromArgb(196, 223, 230),
                    GridColor = Color.FromArgb(102, 165, 173),
                });

                _themes.Add("Water blue", new UserSettings.ColorSchemeClass
                {
                    Name = "Water blue",
                    MainColor = Color.FromArgb(18, 130, 119),
                    SecondaryColor = Color.FromArgb(0, 77, 71),
                    ForeColor = Color.FromArgb(185, 196, 201),
                    GridColor = Color.FromArgb(82, 149, 139),
                });

                _themes.Add("Forest", new UserSettings.ColorSchemeClass
                {
                    Name = "Forest",
                    MainColor = Color.FromArgb(72, 107, 0),
                    SecondaryColor = Color.FromArgb(46, 70, 0),
                    ForeColor = Color.FromArgb(125, 68, 39),
                    GridColor = Color.FromArgb(162, 197, 35),
                });

                _themes.Add("Greens", new UserSettings.ColorSchemeClass
                {
                    Name = "Greens",
                    MainColor = Color.FromArgb(0, 68, 69),
                    SecondaryColor = Color.FromArgb(1, 27, 28),
                    ForeColor = Color.FromArgb(111, 185, 143),
                    GridColor = Color.FromArgb(44, 120, 115),
                });

                _themes.Add("From sunset to dusk", new UserSettings.ColorSchemeClass
                {
                    Name = "From sunset to dusk",
                    MainColor = Color.FromArgb(45, 66, 98),
                    SecondaryColor = Color.FromArgb(54, 50, 55),
                    ForeColor = Color.FromArgb(208, 150, 131),
                    GridColor = Color.FromArgb(115, 96, 91),
                });

                _themes.Add("Amber and azure", new UserSettings.ColorSchemeClass
                {
                    Name = "Amber and azure",
                    MainColor = Color.FromArgb(144, 175, 197),
                    SecondaryColor = Color.FromArgb(51, 107, 135),
                    ForeColor = Color.FromArgb(255, 191, 0),
                    GridColor = Color.FromArgb(42, 49, 50),
                });

                _themes.Add("Neon sign", new UserSettings.ColorSchemeClass
                {
                    Name = "Neon sign",
                    MainColor = Color.FromArgb(38, 47, 52),
                    SecondaryColor = Color.FromArgb(241, 211, 188),
                    ForeColor = Color.FromArgb(243, 74, 74),
                    GridColor = Color.FromArgb(97, 80, 73),
                });

                _themes.Add("Flower meadow", new UserSettings.ColorSchemeClass
                {
                    Name = "Flower meadow",
                    MainColor = Color.FromArgb(137, 218, 89),
                    SecondaryColor = Color.FromArgb(63, 104, 28),
                    ForeColor = Color.FromArgb(255, 240, 0),
                    GridColor = Color.FromArgb(55, 94, 151),
                });

                _themes.Add("Graffiti", new UserSettings.ColorSchemeClass
                {
                    Name = "Graffiti",
                    MainColor = Color.FromArgb(225, 49, 91),
                    SecondaryColor = Color.FromArgb(244, 125, 74),
                    ForeColor = Color.FromArgb(0, 141, 203),
                    GridColor = Color.FromArgb(255, 236, 92),
                });

                _themes.Add("Cappuccino", new UserSettings.ColorSchemeClass
                {
                    Name = "Cappuccino",
                    MainColor = Color.FromArgb(221, 188, 149),
                    SecondaryColor = Color.FromArgb(179, 136, 103),
                    ForeColor = Color.FromArgb(98, 109, 113),
                    GridColor = Color.FromArgb(205, 205, 192),
                });

                _themes.Add("Blueberry", new UserSettings.ColorSchemeClass
                {
                    Name = "Blueberry",
                    MainColor = Color.FromArgb(40, 54, 85),
                    SecondaryColor = Color.FromArgb(30, 31, 38),
                    ForeColor = Color.FromArgb(208, 225, 249),
                    GridColor = Color.FromArgb(77, 100, 141),
                });

                _themes.Add("Tulips", new UserSettings.ColorSchemeClass
                {
                    Name = "Tulips",
                    MainColor = Color.FromArgb(152, 219, 198),
                    SecondaryColor = Color.FromArgb(91, 200, 172),
                    ForeColor = Color.FromArgb(241, 141, 158),
                    GridColor = Color.FromArgb(230, 215, 42),
                });

                _themes.Add("Strawberry with cream", new UserSettings.ColorSchemeClass
                {
                    Name = "Strawberry with cream",
                    MainColor = Color.FromArgb(254, 122, 71),
                    SecondaryColor = Color.FromArgb(216, 65, 47),
                    ForeColor = Color.FromArgb(252, 253, 254),
                    GridColor = Color.FromArgb(245, 202, 153),
                });

                _themes.Add("Day and night", new UserSettings.ColorSchemeClass
                {
                    Name = "Day and night",
                    MainColor = Color.FromArgb(5, 56, 82),
                    SecondaryColor = Color.FromArgb(0, 26, 39),
                    ForeColor = Color.FromArgb(230, 223, 68),
                    GridColor = Color.FromArgb(241, 129, 15),
                });
            }

        }

        /// <summary>
        /// Users setting Color scheme .
        /// </summary>
        public static ColorSchemeClass ColorScheme
        {
            get
            {
                return _colorScheme;
            }
            set
            {
                _colorScheme = value;
                if (autoSave)
                {
                    SaveSettings(currentPath);
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

                ColorScheme = new ColorSchemeClass();
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
                ColorScheme = ColorThemes.Themes["Dark"];
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
