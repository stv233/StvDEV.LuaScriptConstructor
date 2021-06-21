using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LuaScriptConstructor
{
    /// <summary>
    /// Dialogue for choosing a project.
    /// </summary>
    class ProjectDialog : Form
    { 
        List<string> _projects = new List<string>();
        string _project = "";
        bool _newProject = true;
        Panel projectsPanel;

        /// <summary>
        /// Whether to let the user select a new project.
        /// </summary>
        public bool ShowNewProjectButton
        {
            get
            {
                return _newProject;
            }
            set
            {
                _newProject = value;
            }
        }

        /// <summary>
        /// List of projects for selection.
        /// </summary>
        public List<string> Projects
        {
            get
            {
                return _projects;
            }
            set
            {
                _projects = value;
                RefreshProjects();
            }
        }

        /// <summary>
        /// Selected project.
        /// </summary>
        public string Project
        {
            get
            {
                return _project;
            }
            protected set
            {
                _project = value;
            }
        }

        /// <summary>
        /// Dialogue for choosing a project.
        /// </summary>
        public ProjectDialog()
        {
            #region /// Initialization

            #region /// Form

            this.Size = new Size(1080, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            #endregion

            #region /// Projects

            projectsPanel = new Panel
            {
                AutoScroll = true,
                BorderStyle = BorderStyle.None,
                Width = this.ClientSize.Width / 2,
                Height = this.ClientSize.Height - 60,
                Top = 60,
                Parent = this
            };

            var lbProjects = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Bold),
                Top = 10,
                Text = "Projects",
                Parent = this
            };
            lbProjects.Left = this.ClientSize.Width / 4 - lbProjects.Width / 2;

            RefreshProjects();

            #endregion

            #endregion
        }

        public void RefreshProjects()
        {
            projectsPanel.Controls.Clear();

            foreach (var project in _projects)
            {
                CreateProjectPanel(project, projectsPanel, DialogResult.OK).SendToBack();
            }

            if (_newProject)
            {
                CreateProjectPanel("New project", projectsPanel, DialogResult.Yes);
            }

        }

        /// <summary>
        /// Creates a new panel to display the project.
        /// </summary>
        /// <param name="project">Project</param>
        /// <param name="parent">Panel parent</param>
        /// <param name="dialogResult">Panel dialog result</param>
        /// <returns></returns>
        private Panel CreateProjectPanel(string project, Control parent, DialogResult dialogResult)
        {
            var pnPanel = new Panel
            {
                Height = 50,
                Dock = DockStyle.Top,
                Parent = parent
            };
            pnPanel.MouseEnter += (s, e) =>
            {
                pnPanel.BackColor = Color.FromArgb((parent.BackColor.R > 128 ? parent.BackColor.R - 10 : parent.BackColor.R + 10),
                    (parent.BackColor.G > 128 ? parent.BackColor.G - 10 : parent.BackColor.G + 10),
                    (parent.BackColor.B > 128 ? parent.BackColor.B - 10 : parent.BackColor.B + 10));
            };
            pnPanel.MouseLeave += (s, e) =>
            {
                pnPanel.BackColor = parent.BackColor;
            };


            var lbName = new Label
            {
                Text = System.IO.Path.GetFileNameWithoutExtension(project),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 15, FontStyle.Bold),
                Width = pnPanel.Width,
                Top = 5,
                Height = 25,
                Parent = pnPanel
            };
            lbName.Click += (s, e) =>
            {
                _project = project;
                parent.FindForm().DialogResult = dialogResult;
            };
            lbName.MouseEnter += (s, e) =>
            {
                pnPanel.BackColor = Color.FromArgb((parent.BackColor.R > 128 ? parent.BackColor.R - 10 : parent.BackColor.R + 10),
                    (parent.BackColor.G > 128 ? parent.BackColor.G - 10 : parent.BackColor.G + 10),
                    (parent.BackColor.B > 128 ? parent.BackColor.B - 10 : parent.BackColor.B + 10));
            };
            lbName.MouseLeave += (s, e) =>
            {
                pnPanel.BackColor = parent.BackColor;
            };

            var lbPath = new Label
            {
                Text = project,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Regular),
                Top = lbName.Top + lbName.Height,
                Width = pnPanel.Width,
                Height = 15,
                Parent = pnPanel
            };
            lbPath.Click += (s, e) =>
            {
                _project = project;
                parent.FindForm().DialogResult = dialogResult;
            };
            lbPath.MouseEnter += (s, e) =>
            {
                pnPanel.BackColor = Color.FromArgb((parent.BackColor.R > 128 ? parent.BackColor.R - 10 : parent.BackColor.R + 10),
                    (parent.BackColor.G > 128 ? parent.BackColor.G - 10 : parent.BackColor.G + 10),
                    (parent.BackColor.B > 128 ? parent.BackColor.B - 10 : parent.BackColor.B + 10));
            };
            lbPath.MouseLeave += (s, e) =>
            {
                pnPanel.BackColor = parent.BackColor;
            };

            return pnPanel;
        }

    }
}
