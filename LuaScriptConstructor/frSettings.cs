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
            cbColor.Items.Add("Light");
            cbColor.Items.Add("Dark");
            cbColor.Items.Add("Chocolate brownie");
            cbColor.Items.Add("Sunny town");
            cbColor.Items.Add("Library");
            cbColor.Items.Add("Sea wave");
            cbColor.Items.Add("Water blue");
            cbColor.Items.Add("Forest");
            cbColor.Items.Add("Greens");
            cbColor.Items.Add("From sunset to dusk");
            cbColor.Items.Add("Amber and azure");
            cbColor.Items.Add("Neon sign");
            cbColor.Items.Add("Flower meadow");
            cbColor.Items.Add("Graffiti");
            cbColor.Items.Add("Cappuccino");
            cbColor.Items.Add("Blueberry");
            cbColor.Items.Add("Tulips");
            cbColor.Items.Add("Strawberry with cream");
            cbColor.Items.Add("Day and night");
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
                if (cbColor.SelectedItem.ToString() == "Light")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = System.Drawing.Color.FromArgb(239, 239, 239);
                    UserSettings.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(252, 252, 252);
                    UserSettings.ColorScheme.ForeColor = Color.Black;
                    UserSettings.ColorScheme.GridColor = System.Drawing.Color.FromArgb(128, 192, 192, 192);
                }
                else if (cbColor.SelectedItem.ToString() == "Dark")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(64, 64, 64);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(30, 30, 30);
                    UserSettings.ColorScheme.ForeColor = Color.White;
                    UserSettings.ColorScheme.GridColor = System.Drawing.Color.FromArgb(128, 192, 192, 192);
                }
                else if (cbColor.SelectedItem.ToString() == "Chocolate brownie")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(82, 54, 52);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(48, 26, 40);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(221, 197, 163);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(181, 67, 44);
                }
                else if (cbColor.SelectedItem.ToString() == "Sunny town")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(235, 138, 62);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(210, 65, 54);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(226, 196, 153);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(235, 181, 130);
                }
                else if (cbColor.SelectedItem.ToString() == "Library")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(108, 45, 44);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(66, 49, 58);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(241, 220, 201);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(159, 70, 54);
                }
                else if (cbColor.SelectedItem.ToString() == "Sea wave")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(6, 87, 91);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(0, 59, 70);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(196, 223, 230);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(102, 165, 173);
                }
                else if (cbColor.SelectedItem.ToString() == "Water blue")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(18, 130, 119);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(0, 77, 71);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(185, 196, 201);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(82, 149, 139);
                }
                else if (cbColor.SelectedItem.ToString() == "Forest")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(72, 107, 0);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(46, 70, 0);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(125, 68, 39);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(162, 197, 35);
                }
                else if (cbColor.SelectedItem.ToString() == "Greens")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(0, 68, 69);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(1, 27, 28);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(111, 185, 143);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(44, 120, 115);
                }
                else if (cbColor.SelectedItem.ToString() == "From sunset to dusk")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(45, 66, 98);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(54, 50, 55);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(208, 150, 131);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(115, 96, 91);
                }
                else if (cbColor.SelectedItem.ToString() == "Amber and azure")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(144, 175, 197);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(51, 107, 135);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(255, 191, 0);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(42, 49, 50);
                }
                else if (cbColor.SelectedItem.ToString() == "Neon sign") 
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(38, 47, 52);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(241, 211, 188);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(243, 74, 74);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(97, 80, 73);
                }
                else if (cbColor.SelectedItem.ToString() == "Flower meadow") 
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(137, 218, 89); 
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(63, 104, 28);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(255, 240, 0);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(55, 94, 151);
                }
                else if (cbColor.SelectedItem.ToString() == "Graffiti") 
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(225, 49, 91);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(244, 125, 74);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(0, 141, 203);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(255, 236, 92);
                } 
                else if (cbColor.SelectedItem.ToString() == "Cappuccino") 
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(221, 188, 149);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(179, 136, 103);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(98, 109, 113); 
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(205, 205, 192);
                }
                else if (cbColor.SelectedItem.ToString() == "Blueberry") 
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(40, 54, 85);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(30, 31, 38);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(208, 225, 249);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(77, 100, 141);
                }
                else if (cbColor.SelectedItem.ToString() == "Tulips") 
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(152, 219, 198);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(91, 200, 172);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(241, 141, 158);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(230, 215, 42);
                }
                else if (cbColor.SelectedItem.ToString() == "Strawberry with cream")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(254, 122, 71); 
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(216, 65, 47);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(252, 253, 254);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(245, 202, 153);
                }
                else if (cbColor.SelectedItem.ToString() == "Day and night")
                {
                    UserSettings.ColorScheme.Name = cbColor.SelectedItem.ToString();
                    UserSettings.ColorScheme.MainColor = Color.FromArgb(5, 56, 82);
                    UserSettings.ColorScheme.SecondaryColor = Color.FromArgb(0, 26, 39);
                    UserSettings.ColorScheme.ForeColor = Color.FromArgb(230, 223, 68);
                    UserSettings.ColorScheme.GridColor = Color.FromArgb(241, 129, 15);
                }
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
