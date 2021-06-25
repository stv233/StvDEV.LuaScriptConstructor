using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor
{
    /// <summary>
    /// Represents a class for working with program projects.
    /// </summary>
    static class Projects
    {
        private static Stack<string> projects = new Stack<string>();
        private static string currentPath = "";

        /// <summary>
        /// List of projects as a stack.
        /// </summary>
        public static Stack<string> Stack
        {
            get
            {
                return projects;
            }
        }

        /// <summary>
        /// List of projects as a list.
        /// </summary>
        public static List<string> List
        {
            get
            {
                return new List<string>(projects);
            }
        }

        /// <summary>
        /// Adds a project to the list.
        /// </summary>
        /// <param name="project">Project</param>
        public static void Add(string project)
        {
            projects.Push(project);
            SaveProjects(currentPath);
        }

        /// <summary>
        /// If the project exists, it moves it to the top of the list, if not, then adds it to the list.
        /// </summary>
        /// <param name="project">Project</param>
        public static void Update(string project)
        {
            if (projects.Contains(project))
            {
                var tempArray = projects.ToArray();
                var tempProjet = tempArray[Array.IndexOf(tempArray, project)];
                for (var i = Array.IndexOf(tempArray, project); i < tempArray.Length - 1; i++)
                {
                    tempArray[i] = tempArray[i + 1];
                }
                tempArray[tempArray.Length - 1] = tempProjet;
                projects = new Stack<string>(tempArray);
            }
            else
            {
                Add(project);
            }
            SaveProjects(currentPath);
        }

        /// <summary>
        /// Removes a project from the list.
        /// </summary>
        /// <param name="project"></param>
        public static void Remove(string project)
        {
            if (project.Contains(project))
            {
                var tempList = projects.ToList<string>();
                tempList.Remove(project);
                projects = new Stack<string>(tempList);
            }
            SaveProjects(currentPath);
            LoadProjects(currentPath);
        }

        /// <summary>
        /// Loads a list of projects from a file.
        /// </summary>
        /// <param name="path">File path</param>
        public static void LoadProjects(string path)
        {
            try
            {
                projects = Newtonsoft.Json.JsonConvert.DeserializeObject<Stack<string>>(System.IO.File.ReadAllText(path));
            }
            catch 
            {
                projects = new Stack<string>();
            }
            currentPath = path;
        }

        /// <summary>
        /// Saves a list of projects to a file.
        /// </summary>
        /// <param name="path">File path</param>
        public static void  SaveProjects(string path)
        {
            System.IO.File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(projects));
            currentPath = path;
        }
    }
}
