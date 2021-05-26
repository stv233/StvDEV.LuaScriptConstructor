using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuaScriptConstructor
{
    /// <summary>
    /// Represents a list of selected users function diagrams.
    /// </summary>
    static class Favorites
    {
        private static Dictionary<string, string> _dictionary = new Dictionary<string, string>();
        private static string favoritesPath = Program.AppDataPath + "\\Favorites";

        /// <summary>
        /// Represents a class containing data for a <see cref="Favorites"/> class events.
        /// </summary>
        public class FavoirutesEventArgs : EventArgs
        {
            /// <summary>
            /// Dictionary of selected diagrams.
            /// </summary>
            public static Dictionary<string, string> Dictianory
            {
                get
                {
                    return _dictionary;
                }
            }

        }

        /// <summary>
        /// Represents a method that handles <see cref=" FavoritesRefreshed"/>, <see cref="FavoriteAdded"/> and <see cref="FavoriteRemoved"/> events.
        /// </summary>
        /// <param name="e">Favorites events arguments</param>
        public delegate void FavoritesEvents(FavoirutesEventArgs e);

        /// <summary>
        /// Dictionary of selected diagrams.
        /// </summary>
        public static Dictionary<string, string> Dictionary
        {
            get
            {
                return _dictionary;
            }
        }

        /// <summary>
        /// Occurs when favorites refreshed.
        /// </summary>
        public static event FavoritesEvents FavoritesRefreshed;

        /// <summary>
        /// Occurs when a new favorite is added.
        /// </summary>
        public static event FavoritesEvents FavoriteAdded;

        /// <summary>
        /// Occurs when the favorite removed.
        /// </summary>
        public static event FavoritesEvents FavoriteRemoved;

        /// <summary>
        /// Represents a list of selected users function diagrams.
        /// </summary>
        static Favorites()
        {
            Refresh();
        }

        /// <summary>
        /// Refreshes the favorites dictianory.
        /// </summary>
        public static void Refresh()
        {
            try
            {
                
                List<string> fileList = new List<string>();
                try
                {
                    fileList = Directory.GetFiles(favoritesPath).ToList();
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(favoritesPath);
                    return;
                }

                _dictionary.Clear();

                foreach (string file in fileList)
                {
                    _dictionary.Add(Path.GetFileNameWithoutExtension(file), File.ReadAllText(file));
                }

                if (FavoritesRefreshed != null)
                {
                    FavoritesRefreshed(new FavoirutesEventArgs());
                }
            }
            catch { }
        }

        /// <summary>
        /// Adds a new favorite diagram.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="serializedDiagram">Serialized diagram</param>
        /// <param name="askingAboutRewriting">Whether it is necessary to ask for confirmation of the entry if the favorites already contain an entry with the specified name</param>
        public static void Add(string name, string serializedDiagram, bool askingAboutRewriting = true)
        {
            if (askingAboutRewriting)
            {
                if (_dictionary.ContainsKey(name))
                {
                    if (!(System.Windows.Forms.MessageBox.Show("Favorites already contain an entry with the given name. Do you want to rewrite it?",
                        "Rewrite entry?",System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
                    {
                        return;
                    }
                }
            }

            try
            {
                File.WriteAllText(favoritesPath + "\\" + name, serializedDiagram);
            }
            catch { }

            Refresh();
            if (FavoriteAdded != null)
            {
                FavoriteAdded(new FavoirutesEventArgs());
            }
        }

        /// <summary>
        /// Removes an entry from favorites.
        /// </summary>
        /// <param name="name">Name</param>
        public static void Remove(string name)
        {
            if (_dictionary.ContainsKey(name))
            {
                try
                {
                    File.Delete(favoritesPath + "\\" + name);
                }
                catch { }

                Refresh();
                if (FavoriteRemoved != null)
                {
                    FavoriteRemoved(new FavoirutesEventArgs());
                }
            }
        }
    }
}
