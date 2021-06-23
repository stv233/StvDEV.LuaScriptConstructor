using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;

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
        Panel pnProjects;
        Panel pnUpdates;
        PictureBox pbUpdate;
        Label lbUpdate;
        Button btInstallUpdate;
        Button btDownloadUpdate;
        string updateLink = "https://github.com/stv233/LuaScriptConstructor/blob/master/LuaScriptConstructor/Version?raw=true";
        string updateContent = "";
        string updaterName = Program.AppDataPath + "LSC.updt";

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

            pnProjects = new Panel
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

            #region /// Updates

            pnUpdates = new Panel
            {
                BorderStyle = BorderStyle.None,
                Width = this.ClientSize.Width / 2,
                Height = this.ClientSize.Height,
                Left = this.ClientSize.Width / 2,
                Parent = this
            };

            pbUpdate = new PictureBox
            {
                Image = Properties.Resources.InProgress_128x,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 128,
                Height = 128,
                Left = pnUpdates.Width / 2 - 64,
                Top = pnUpdates.Height / 2 - 128,
                Parent = pnUpdates
            };
            lbUpdate = new Label
            {
                Size = new Size(pnUpdates.ClientSize.Width, 25),
                TextAlign = ContentAlignment.TopCenter,
                Text = "Сhecking for updates",
                Font = new Font("Arial", 15, FontStyle.Regular),
                Top = pbUpdate.Top + pbUpdate.Height + pbUpdate.Height / 2,
                Parent = pnUpdates
            };

            btInstallUpdate = new Button
            {
                Text = "Install",
                FlatStyle = FlatStyle.Popup,
                Cursor = Cursors.Hand,
                ForeColor = this.ForeColor,
                AutoSize = true,
                Font = new Font("Arial", 15, FontStyle.Bold),
                Visible = false,
                Parent = pnUpdates
            };
            btInstallUpdate.Left = pnUpdates.Width / 2 - btInstallUpdate.Width / 2;
            btInstallUpdate.Top = pnUpdates.Height / 2 - btInstallUpdate.Height;

            btDownloadUpdate = new Button
            {
                Text = "Dwonload",
                FlatStyle = FlatStyle.Popup,
                Cursor = Cursors.Hand,
                ForeColor = this.ForeColor,
                AutoSize = true,
                Font = new Font("Arial", 15, FontStyle.Bold),
                Visible = false,
                Parent = pnUpdates
            };
            btDownloadUpdate.Left = pnUpdates.Width / 2 - btDownloadUpdate.Width / 2;
            btDownloadUpdate.Top = pnUpdates.Height / 2 - btDownloadUpdate.Height;

            #endregion

            #region /// Clsoe

            var pbClose = new PictureBox
            {
                Size = new Size(16, 16),
                Top = 5,
                Left = this.ClientSize.Width - 5,
                Cursor = Cursors.Hand,
                Image = Properties.Resources.Close_16x,
                Parent = this
            };
            pbClose.BringToFront();

            #endregion

            #endregion

            #region /// Events

            this.Load += async (s, e) =>
            {
                try
                {
                    await CheckForUpdates();
                }
                catch { }
            };

            btDownloadUpdate.Click += async (s, e) =>
            {
                btDownloadUpdate.Visible = false;
                btDownloadUpdate.Enabled = false;
                pbUpdate.Visible = true;
                pbUpdate.Image = Properties.Resources.InProgress_128x;
                lbUpdate.Text = "Downloading update";
                await DownloadUpdateAsync();
            };

            btInstallUpdate.Click += (s, e) =>
            {
                btInstallUpdate.Visible = false;
                btInstallUpdate.Enabled = false;
                pbUpdate.Visible = true;
                pbUpdate.Image = Properties.Resources.InProgress_128x;
                lbUpdate.Text = "Installing update";
                InstallUpdate();
            };

            pbClose.Click += (s, e) =>
            {
                Program.Abort = true;
                this.Close();
            };

            #endregion
        }

        /// <summary>
        /// Refresh projects.
        /// </summary>
        public void RefreshProjects()
        {
            pnProjects.Controls.Clear();

            foreach (var project in _projects)
            {
                CreateProjectPanel(project, pnProjects, DialogResult.OK).SendToBack();
            }

            if (_newProject)
            {
                CreateProjectPanel("New project", pnProjects, DialogResult.Yes);
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

        /// <summary>
        /// Checks for update availability
        /// </summary>
        private async Task CheckForUpdates()
        {
            try
            {
                updateContent = await DownloadStringAsync(updateLink);
                Version updateVersion = new Version(updateContent.Split('|')[0]);
                if (Program.Version >= updateVersion)
                {

                    File.Delete(updaterName);
                    this.Invoke(new MethodInvoker(() =>
                    {
                        pbUpdate.Image = Properties.Resources.ico.ToBitmap();
                        lbUpdate.Text = "Latest available version";
                    }));
                    return;
                }

                if (File.Exists(updaterName))
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        pbUpdate.Visible = false;
                        btInstallUpdate.Visible = true;
                        btInstallUpdate.Visible = true;
                        btInstallUpdate.ForeColor = this.ForeColor;
                        lbUpdate.Text = "An update is available for installation";
                    }));
                    return;
                }
                else
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        pbUpdate.Visible = false;
                        btDownloadUpdate.Visible = true;
                        btDownloadUpdate.Visible = true;
                        btDownloadUpdate.ForeColor = this.ForeColor;
                        lbUpdate.Text = "Update available for download";
                    }));
                    return;
                }
            }
            catch
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    lbUpdate.Text = "Failed to check for updates";
                    pbUpdate.Image = Properties.Resources.StatusCriticalError_16x;
                }));
            }
        }

        /// <summary>
        /// Asynchronous string download.
        /// </summary>
        /// <param name="url">Link</param>
        /// <returns></returns>
        private async Task<string> DownloadStringAsync(string url)
        {
            return await Task.Run(() =>
            {
                string result;
                try
                {
                    result = new WebClient().DownloadString(url);
                }
                catch
                {
                    result = "";
                }
                return result;
            });
        }

        /// <summary>
        /// Download the update installer.
        /// </summary>
        private async Task DownloadUpdateAsync()
        {
            await Task.Run(() =>
            {
                string fileLink = (string)Invoke(new Func<string, int, string>((target, key) =>
                {
                    var chars = target.ToArray();
                    string newString = "";
                    foreach (var @char in chars)
                        newString += Invoke(new Func<char, int, char>((character, characterKey) =>
                         {
                           return (char)((character ^ characterKey));
                       }), new object[2] { @char, key });
                    return newString;
                }), new object[2] { updateContent.Split('|')[1], 0x0088 });
                //string fileLink = updateContent.Split('|')[1];
                string tempFileName = Path.GetTempPath() + Path.GetRandomFileName();

                try
                {
                    var webClient = new WebClient();
                    webClient.DownloadFileCompleted += async (s, e) =>
                    {
                        File.Copy(tempFileName, updaterName, true);

                        if (Environment.OSVersion.Version.Major == 6)
                        {
                            new Microsoft.Toolkit.Uwp.Notifications.ToastContentBuilder()
                            .AddArgument("action", "viewConversation")
                            .AddArgument("conversationId", 9813)
                            .AddText(Program.Name + " update")
                            .AddText(Program.Name + " update downloaded and ready to install.")
                            .Show();
                        }
                        else
                        {
                            NotifyIcon notifyIcon = new NotifyIcon
                            {
                                BalloonTipTitle = Program.Name + " update",
                                BalloonTipText = Program.Name + " update downloaded and ready to install.",
                                BalloonTipIcon = ToolTipIcon.Info,
                                Icon = this.Icon,
                                Visible = true
                            };
                            notifyIcon.BalloonTipClosed += (se, ev) =>
                            {
                                notifyIcon.Visible = false;
                            };
                            notifyIcon.ShowBalloonTip(100000);
                        }

                        try
                        {
                            this.Invoke(new MethodInvoker(() =>
                            {
                                pbUpdate.Visible = false;
                                btInstallUpdate.Visible = true;
                                btInstallUpdate.ForeColor = this.ForeColor;
                                lbUpdate.Text = "An update is available for installation";
                            }));
                        }
                        catch
                        {
                            return;
                        }
                    };

                    webClient.DownloadFileAsync(new Uri(fileLink), tempFileName);
                }
                catch
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            lbUpdate.Text = "Failed to download update";
                            pbUpdate.Image = Properties.Resources.StatusCriticalError_16x;
                        }));
                    }
                    catch { }
                }
            });
        }

        /// <summary>
        /// Launches the update installer.
        /// </summary>
        private void InstallUpdate()
        {
            File.Copy(updaterName, Program.AppDataPath + "LSC.msi", true);
            System.Diagnostics.Process.Start(Program.AppDataPath + "LSC.msi", "/qr");
            Program.Abort = true;
            this.Close();
        }
    }
}
