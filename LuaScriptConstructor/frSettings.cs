using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace LuaScriptConstructor
{
    /// <summary>
    /// User settings form.
    /// </summary>
    class frSettings : System.Windows.Forms.Form
    {
        public frSettings()
        {
            this.Text = "Settings";
            this.AutoScroll = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Width = 800;
            this.Height = 600;
            this.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.Settings_16x.GetHicon());
            this.BackColor = UserSettings.ColorScheme.MainColor;
            this.ForeColor = UserSettings.ColorScheme.ForeColor;

            var lbHeading = new Label
            {
                AutoSize = true,
                Text = "Settings",
                Dock = DockStyle.Top,
                Font = new Font("Arial", 24, FontStyle.Bold),
                Parent = this
            };
            lbHeading.BringToFront();

            var lbSubHeading = new Label
            {
                AutoSize = true,
                Text = "* - settings that you need to restart the program to fully apply.",
                Dock = DockStyle.Top,
                Top = lbHeading.Height,
                Parent = this
            };
            lbSubHeading.SendToBack();

            var pnSettings = new Panel
            {
                AutoScroll = true,
                //AutoSize = true,
                Height = this.ClientSize.Height - lbSubHeading.Height - lbHeading.Height,
                BorderStyle = BorderStyle.None,
                BackColor = UserSettings.ColorScheme.SecondaryColor,
                Dock = DockStyle.Top,
                Parent = this
            };
            pnSettings.SendToBack();

            #region /// Auto snapshot delay

            var pnAutoSnapshotDelay = new Panel
            {
                //AutoScroll = true,
                Dock = DockStyle.Top,
                Parent = pnSettings
            };

            var lbAutoSnapshotDelayTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 15, FontStyle.Bold),
                Text = "Automatic snapshots period (min)",
                Parent = pnAutoSnapshotDelay
            };
            lbAutoSnapshotDelayTitle.Top = pnAutoSnapshotDelay.Height / 2 - lbAutoSnapshotDelayTitle.Height / 2;

            var nupDelay = new NumericUpDown
            {
                Left = lbAutoSnapshotDelayTitle.Width + 10,
                BorderStyle = BorderStyle.None,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Width = pnAutoSnapshotDelay.ClientSize.Width - 20 - lbAutoSnapshotDelayTitle.Width,
                Font = new Font("Arial", 13),
                Height = 20,
                Parent = pnAutoSnapshotDelay,
                Minimum = 1,
                Maximum = 120,
                Value = UserSettings.AutoSnapshotDelay,
            };
            nupDelay.Top = pnAutoSnapshotDelay.Height / 2 - nupDelay.Height / 2;
            nupDelay.ValueChanged += (s, e) =>
            {
                UserSettings.AutoSnapshotDelay = (int)nupDelay.Value;
            };

            var lbDelayHelp = new Label
            {
                AutoSize = true,
                Text = "Changes will take effect at the next cycle of automatic snapshots or program restart.",
                Left = nupDelay.Left - 3,
                Top = nupDelay.Top + nupDelay.Height,
                Parent = pnAutoSnapshotDelay,
            };

            pnAutoSnapshotDelay.Resize += (s, e) =>
            {
                nupDelay.Width = pnAutoSnapshotDelay.ClientSize.Width - 20 - lbAutoSnapshotDelayTitle.Width;
            };

            #endregion

            #region /// Auto snapshots

            var pnAutoSnapshots = new Panel
            {
                //AutoScroll = true,
                Dock = DockStyle.Top,
                Parent = pnSettings
            };

            var lbAutoSnapshotsTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 15, FontStyle.Bold),
                Text = "Automatic snapshots",
                Parent = pnAutoSnapshots
            };
            lbAutoSnapshotsTitle.Top = pnAutoSnapshots.Height / 2 - lbAutoSnapshotsTitle.Height / 2;

            var cbSnapshots = new CheckBox
            {
                Left = lbAutoSnapshotsTitle.Width + 10,
                Text = "Take automatic snapshots",
                BackColor = UserSettings.ColorScheme.SecondaryColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Width = pnAutoSnapshots.ClientSize.Width - 20 - lbAutoSnapshotsTitle.Width,
                Font = new Font("Arial", 13),
                Height = 20,
                Parent = pnAutoSnapshots,
                Checked = UserSettings.AutoSnapshot
            };
            cbSnapshots.Top = pnAutoSnapshots.Height / 2 - cbSnapshots.Height / 2;
            cbSnapshots.CheckedChanged += (s, e) =>
            {
                UserSettings.AutoSnapshot = cbSnapshots.Checked;
            };

            var lbSnapshotsHelp = new Label
            {
                AutoSize = true,
                Text = "Changes will take effect at the next cycle of automatic snapshots or program restart.",
                Left = cbSnapshots.Left - 3,
                Top = cbSnapshots.Top + cbSnapshots.Height,
                Parent = pnAutoSnapshots,
            };

            pnAutoSnapshots.Resize += (s, e) =>
            {
                cbSnapshots.Width = lbAutoSnapshotsTitle.ClientSize.Width - 20 - lbAutoSnapshotsTitle.Width;
            };

            #endregion

            #region /// Diagram size

            var pnDiagramSize = new Panel
            {
                //AutoScroll = true,
                Dock = DockStyle.Top,
                Parent = pnSettings
            };

            var lbDiagramSizeTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 15, FontStyle.Bold ),
                Text = "Diagram size*",
                Parent = pnDiagramSize
            };
            lbDiagramSizeTitle.Top = pnDiagramSize.Height / 2 - lbDiagramSizeTitle.Height / 2;

            var nupSize = new NumericUpDown
            {
                Left = lbDiagramSizeTitle.Width + 10,
                BorderStyle = BorderStyle.None,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Width = pnDiagramSize.ClientSize.Width - 20 - lbDiagramSizeTitle.Width,
                Font = new Font("Arial", 13),
                Height = 20,
                Parent = pnDiagramSize,
                Minimum = 2000,
                Maximum = 15000,
                Value = UserSettings.DiagramSize,
            };
            nupSize.Top = pnDiagramSize.Height / 2 - nupSize.Height / 2;
            nupSize.ValueChanged += (s, e) =>
            {
                UserSettings.DiagramSize = (int)nupSize.Value;
            };

            var lbSizeHelp = new Label
            {
                AutoSize = true,
                Text = "The size of the diagram directly affects the performance of the program; setting it too high can lead to program freezes on some systems.",
                Left = nupSize.Left - 3,
                Top = nupSize.Top + nupSize.Height,
                Parent = pnDiagramSize,
            };

            pnDiagramSize.Resize += (s, e) =>
            {
                nupSize.Width = pnDiagramSize.ClientSize.Width - 20 - lbDiagramSizeTitle.Width;
            };

            #endregion

            #region /// Color scheme

            var pnColorScheme = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Top,
                Parent = pnSettings
            };

            var lbScheme = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 15, FontStyle.Bold),
                Text = "Color theme*",
                Parent = pnColorScheme
            };
            lbScheme.Top = pnColorScheme.Height / 2 - lbScheme.Height / 2;

            var cbColor = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                FlatStyle = FlatStyle.Popup,
                Left = lbScheme.Width + 10,
                Width = pnColorScheme.ClientSize.Width - 20 - lbScheme.Width,
                Parent = pnColorScheme,
            };
            cbColor.Top = pnColorScheme.Height / 2 - cbColor.Height / 2;
            foreach (string themeName in UserSettings.ColorThemes.Themes.Keys)
            {
                cbColor.Items.Add(themeName);
            }
            foreach(var item in cbColor.Items)
            {
                if (item.ToString() == UserSettings.ColorScheme.Name)
                {
                    cbColor.SelectedItem = item;
                    break;
                }
            }
            cbColor.SelectedIndexChanged += (s, e) =>
            {
                UserSettings.ColorScheme = UserSettings.ColorThemes.Themes[cbColor.Text];
            };

            pnColorScheme.Resize += (s, e) =>
            {
                cbColor.Width = pnColorScheme.ClientSize.Width - 20 - lbScheme.Width;
            };

            #endregion

            #region /// GameGuru path

            var pnGameGuruPath = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Top,
                Parent = pnSettings
            };

            var lbTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 15, FontStyle.Bold ),
                Text = "GameGuru folder",
                Parent = pnGameGuruPath
            };
            lbTitle.Top = pnGameGuruPath.Height / 2 - lbTitle.Height / 2;

            var tbPath = new TextBox
            {
                Left = lbTitle.Width + 10,
                BorderStyle = BorderStyle.None,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Width = pnGameGuruPath.ClientSize.Width - 20 - lbTitle.Width - 75,
                Font = new Font("Arial", 13),
                Multiline = true,
                Height = 20,
                Text = UserSettings.GameGuruPath,
                Parent = pnGameGuruPath,
            };
            tbPath.Top = pnGameGuruPath.Height / 2 - tbPath.Height / 2;
            tbPath.TextChanged += (s, e) =>
            {
                if (tbPath.Text.Contains("\n"))
                {
                    tbPath.Text = tbPath.Text.Replace("\n", "");
                }
                try
                {
                    UserSettings.GameGuruPath = System.IO.Path.GetFullPath(tbPath.Text);
                }
                catch { }

            };

            var btPath = new Button
            {
                FlatStyle = FlatStyle.Popup,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "...",
                Height = tbPath.Height,
                Top = tbPath.Top,
                Parent = pnGameGuruPath
            };
            btPath.Top = tbPath.Top;
            btPath.Left = tbPath.Left + tbPath.Width;
            btPath.BringToFront();
            btPath.Click += (s, e) =>
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog() { SelectedPath = UserSettings.GameGuruPath, Description = "GameGuru folder" })
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        tbPath.Text = fbd.SelectedPath;
                    }
                }
            };

            pnGameGuruPath.Resize += (s, e) =>
            {
                tbPath.Width = pnGameGuruPath.ClientSize.Width - 20 - lbTitle.Width - 75;
                btPath.Top = tbPath.Top;
                btPath.Left = tbPath.Left + tbPath.Width;
            };

            #endregion
            


            this.Resize += (s, e) =>
            {
                pnSettings.Height = this.ClientSize.Height - lbSubHeading.Height - lbHeading.Height;
            };
            lbSubHeading.SendToBack();
            lbHeading.SendToBack();
            this.OnResize(new EventArgs());
        }
    }
}
