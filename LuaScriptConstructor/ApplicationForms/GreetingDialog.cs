using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace LuaScriptConstructor.ApplicationForms
{
    class GreetingDialog : Form
    {
        public GreetingDialog()
        {
            #region /// Initialization

            #region /// Form

            this.Size = new System.Drawing.Size(1080, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Icon = Properties.Resources.ico;
            this.BackColor = UserSettings.ColorScheme.SecondaryColor;
            this.ForeColor = UserSettings.ColorScheme.ForeColor;

            #endregion

            #region /// Logo

            var pnLogo = new PictureBox
            {
                Image = Properties.Resources.ico.ToBitmap(),
                Size = new System.Drawing.Size(this.ClientSize.Width / 4, this.ClientSize.Width / 4),
                Left = this.ClientSize.Width / 4 * 3 - this.ClientSize.Width / 6,
                Top = this.ClientSize.Height / 2 ,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Parent = this
            };

            #endregion

            #region /// Greating

            var lbGreating = new Label
            {
                Text = "Welcome to \nStvDEV Lua script constructor!",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Width = pnLogo.Width * 2,
                Height = pnLogo.Height,
                Font = new System.Drawing.Font("Arial", 25, System.Drawing.FontStyle.Bold),
                Left = pnLogo.Left - pnLogo.Width / 2,
                Top = pnLogo.Top - this.ClientSize.Width / 4,
                Parent = this
            };

            #endregion

            #region /// GameGuru Folder

            var lbTitle = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 15, System.Drawing.FontStyle.Bold),
                Text = "GameGuru folder",
                Top = this.ClientSize.Height / 4,
                Parent = this
            };
            lbTitle.Left = this.ClientSize.Width / 5 - lbTitle.Width / 2;

            var tbPath = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Left = 5,
                Width = this.ClientSize.Width / 3,
                Font = new System.Drawing.Font("Arial", 13),
                Multiline = true,
                Height = 20,
                Top = lbTitle.Top + lbTitle.Height,
                Parent = this,
            };
 

            try
            {

                RegistryKey key;

                if (!Environment.Is64BitOperatingSystem)
                {
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                }
                else
                {
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                }

                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    var displayName = subkey.GetValue("DisplayName") as string;
                    if ((!String.IsNullOrEmpty(displayName)) && (displayName.Contains("GameGuru")))
                    {
                        tbPath.Text = subkey.GetValue("InstallLocation") as string;
                        break;
                    }
                }
            }
            catch { }
            

            var btPath = new Button
            {
                FlatStyle = FlatStyle.Popup,
                BackColor = UserSettings.ColorScheme.SecondaryColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                Text = "...",
                Height = tbPath.Height,
                Left = tbPath.Left + tbPath.Width,
                Top = tbPath.Top,
                Parent = this
            };


            #endregion

            #region /// Color Theme

            var lbScheme = new Label
            {
                AutoSize = true,

                Font = new System.Drawing.Font("Arial", 15, System.Drawing.FontStyle.Bold),
                Top = tbPath.Top + tbPath.Height + this.ClientSize.Height / 8,
                Text = "Color theme",
                Parent = this

            };
            lbScheme.Left = this.ClientSize.Width / 5 - lbScheme.Width / 2;

            var cbColor = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = UserSettings.ColorScheme.MainColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                FlatStyle = FlatStyle.Popup,
                Left = tbPath.Left,
                Top = lbScheme.Top + lbScheme.Height,
                Width = tbPath.Width + btPath.Width,
                Parent = this,
            };
            foreach (string themeName in UserSettings.ColorThemes.Themes.Keys)
            {
                cbColor.Items.Add(themeName);
            }
            foreach (var item in cbColor.Items)
            {
                if (item.ToString() == UserSettings.ColorScheme.Name)
                {
                    cbColor.SelectedItem = item;
                    break;
                }
            }

            #endregion

            #region /// Library

            var lbLibrary = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 15, FontStyle.Bold),
                Top = cbColor.Top + cbColor.Height + +this.ClientSize.Height / 8,
                Text = "Script constructor library",
                Parent = this
            };
            lbLibrary.Left = this.ClientSize.Width / 5 - lbLibrary.Width / 2;

            var chbLibrary = new CheckBox
            {
                
                Text = "Install",
                BackColor = UserSettings.ColorScheme.SecondaryColor,
                ForeColor = UserSettings.ColorScheme.ForeColor,
                AutoSize = true,
                Left = cbColor.Left,
                Top = lbLibrary.Top + lbLibrary.Height,
                Font = new Font("Arial", 13),
                Height = 20,
                Parent = this,
                Checked = true
            };
            chbLibrary.Left = this.ClientSize.Width / 5 - chbLibrary.Width / 2 - 8;

            var pbQuestion = new PictureBox
            {
                Image = Properties.Resources.Question_16x,
                Width = 16,
                Height = 16,
                Left = chbLibrary.Left + chbLibrary.Width,
                Top = chbLibrary.Top + ((chbLibrary.Height - 16) / 2),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Parent = this
            };

            #endregion

            #region /// Continue

            var btContinue = new Button
            {
                AutoSize = true,
                FlatStyle = btPath.FlatStyle,
                Text = "Continue",
                Cursor = Cursors.Hand,
                Parent = this
            };
            btContinue.Top = this.ClientSize.Height - btContinue.Height * 2;
            btContinue.Left = this.ClientSize.Width / 2 - btContinue.Width / 2;
            btContinue.Focus();


            #endregion

            #endregion

            #region /// Events

            tbPath.TextChanged += (s, e) =>
            {
                if (tbPath.Text.Contains("\n"))
                {
                    tbPath.Text = tbPath.Text.Replace("\n", "");
                }
            };

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

            cbColor.SelectedIndexChanged += (s, e) =>
            {
                this.BackColor = UserSettings.ColorThemes.Themes[cbColor.Text].SecondaryColor;
                this.ForeColor = UserSettings.ColorThemes.Themes[cbColor.Text].ForeColor;
                tbPath.BackColor = UserSettings.ColorThemes.Themes[cbColor.Text].MainColor;
                tbPath.ForeColor = UserSettings.ColorThemes.Themes[cbColor.Text].ForeColor;
                btPath.BackColor = UserSettings.ColorThemes.Themes[cbColor.Text].SecondaryColor;
                btPath.ForeColor = UserSettings.ColorThemes.Themes[cbColor.Text].ForeColor;
                cbColor.BackColor = UserSettings.ColorThemes.Themes[cbColor.Text].MainColor;
                cbColor.ForeColor = UserSettings.ColorThemes.Themes[cbColor.Text].ForeColor;
                chbLibrary.BackColor = UserSettings.ColorThemes.Themes[cbColor.Text].SecondaryColor;
                chbLibrary.ForeColor = UserSettings.ColorThemes.Themes[cbColor.Text].ForeColor;
            };

            pbQuestion.Click += (s, e) =>
            {
                MessageBox.Show("Script constructor library contains the functions necessary for the " +
                    "functioning of scripts assembled on the constructor. You can find it along the path " + tbPath.Text +
                    "\\Files\\scriptbank\\StvDEVScriptConstructor.bin. " +
                    "Do not forget to copy it to the standalone version of your project. " +
                    "\nYou can install the library later by selecting \"Install script constructor library\" in the program menu.", "Script constructor library", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btContinue.Click += (s, e) =>
            {
                UserSettings.GameGuruPath = tbPath.Text;
                UserSettings.ColorScheme = UserSettings.ColorThemes.Themes[cbColor.Text];
                if (chbLibrary.Checked)
                {
                    System.IO.Directory.CreateDirectory(UserSettings.GameGuruPath + "\\Files\\scriptbank");
                    System.IO.File.WriteAllBytes(UserSettings.GameGuruPath + "\\Files\\scriptbank\\StvDEVScriptConstructor.bin", Properties.Resources.StvDEVScriptConstructor);
                }

                this.DialogResult = DialogResult.OK;
            };

            #endregion
        }
    }
}
