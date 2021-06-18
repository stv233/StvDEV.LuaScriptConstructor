using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace TextEditor
{
    /// <summary>
    /// Text editor.
    /// </summary>
    public partial class TextEditor : Form
    {

        private bool _staticFile = false;
        private readonly RichTextBox rtbText;
        private bool fileSaved;
        private string filePath = "";

        /// <summary>
        /// Returns whether the text in the editor is read-only.
        /// </summary>
        public bool ReadOnly { get; protected set; }

        /// <summary>
        /// Returns or sets the ability for users to change the file opened in the editor themselves.
        /// </summary>
        public bool StaticFile
        {
            get
            {
                return _staticFile;
            }
            set
            {
                if (!ReadOnly)
                {
                    _staticFile = value;
                    (this.MainMenuStrip.Items[0] as ToolStripMenuItem).DropDownItems[0].Visible = !value;
                    (this.MainMenuStrip.Items[0] as ToolStripMenuItem).DropDownItems[0].Enabled = !value;
                    (this.MainMenuStrip.Items[0] as ToolStripMenuItem).DropDownItems[1].Visible = !value;
                    (this.MainMenuStrip.Items[0] as ToolStripMenuItem).DropDownItems[1].Enabled = !value;
                    (this.MainMenuStrip.Items[0] as ToolStripMenuItem).DropDownItems[2].Visible = !value;
                    (this.MainMenuStrip.Items[0] as ToolStripMenuItem).DropDownItems[2].Enabled = !value;
                    (this.MainMenuStrip.Items[0] as ToolStripMenuItem).DropDownItems[3].Visible = !value;
                    (this.MainMenuStrip.Items[0] as ToolStripMenuItem).DropDownItems[3].Enabled = !value;
                    (this.MainMenuStrip.Items[0] as ToolStripMenuItem).DropDownItems[4].Visible = !value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the title of the editor window.
        /// </summary>
        public string Heading
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Triggered when the heading changes.
        /// </summary>
        public event EventHandler HeadingChanged;

        /// <summary>
        /// Returns or sets the text typed in the editor.
        /// </summary>
        new public string Text
        {
            get
            {
                return rtbText.Text;
            }
            set
            {
                rtbText.Text = value;
            }
        }

        /// <summary>
        /// Fires when text changes in the editor.
        /// </summary>
        public new  event EventHandler TextChanged;

        /// <summary>
        /// Text editor.
        /// </summary>
        public TextEditor():this(false) { }

        /// <summary>
        /// Text editor.
        /// </summary>
        /// <param name="readOnly">Sets whether the text in the editor is read-only</param>
        public TextEditor(bool readOnly)
        {

            ReadOnly = readOnly;
            HeadingChanged = null;
            TextChanged = null;

            #region /// Initialization

            #region /// Form

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Heading = Properties.Localization.TextEditor;
            this.BackColor = Color.White;

            #endregion

            #region /// Main menu

            var msMainMenu = new MenuStrip
            {
                BackColor = Color.Transparent,
                Parent = this
            };
            this.MainMenuStrip = msMainMenu;
            msMainMenu.SendToBack();

            #region /// File

            var smiFile = new ToolStripMenuItem
            {
                Text = Properties.Localization.File
            };
            msMainMenu.Items.Add(smiFile);

            var smiNew = new ToolStripMenuItem
            {
                Text = Properties.Localization.New,
                ShortcutKeyDisplayString = "Ctrl+N",
                ShortcutKeys = Keys.Control | Keys.N,
                Visible = !ReadOnly,
                Enabled = !ReadOnly,
                Image = Properties.Resources.NewFile_16x
            };
            smiFile.DropDownItems.Add(smiNew);

            var smiOpen = new ToolStripMenuItem
            {
                Text = Properties.Localization.Open + "...",
                ShortcutKeyDisplayString = "Ctrl+O",
                ShortcutKeys = Keys.Control | Keys.O,
                Visible = !ReadOnly,
                Enabled = !ReadOnly,
                Image = Properties.Resources.OpenFolder_16x
            };
            smiFile.DropDownItems.Add(smiOpen);

            var smiSave = new ToolStripMenuItem
            {
                Text = Properties.Localization.Save,
                ShortcutKeyDisplayString = "Ctrl+S",
                ShortcutKeys = Keys.Control | Keys.S,
                Visible = !ReadOnly,
                Enabled = !ReadOnly,
                Image = Properties.Resources.Save_16x
            };
            smiFile.DropDownItems.Add(smiSave);

            var smiSaveAs = new ToolStripMenuItem
            {
                Text = Properties.Localization.SaveAs,
                ShortcutKeyDisplayString = "Ctrl+Shift+S",
                ShortcutKeys = Keys.Control | Keys.Shift | Keys.S,
                Visible = !ReadOnly,
                Enabled = !ReadOnly,
                Image = Properties.Resources.SaveAs_16x
            };
            smiFile.DropDownItems.Add(smiSaveAs);

            if (!ReadOnly) { smiFile.DropDownItems.Add(new ToolStripSeparator()); }

            var smiClose = new ToolStripMenuItem
            {
                Text = Properties.Localization.Close,
                Image = Properties.Resources.Close_16x
            };

            smiFile.DropDownItems.Add(smiClose);

            #endregion

            #region /// Edit

            var smiEdit = new ToolStripMenuItem
            {
                Text = Properties.Localization.Edit
            };
            msMainMenu.Items.Add(smiEdit);

            var smiUndo = new ToolStripMenuItem
            {
                Text = Properties.Localization.Undo,
                ShortcutKeyDisplayString = "Ctrl+Z",
                Image = Properties.Resources.Undo_16x,
                Visible = !ReadOnly,
                Enabled = false
            };
            smiEdit.DropDownItems.Add(smiUndo);

            var smiCut = new ToolStripMenuItem
            {
                Text = Properties.Localization.Cut,
                ShortcutKeyDisplayString = "Ctrl+X",
                Image = Properties.Resources.Cut_16x,
                Visible = !ReadOnly,
                Enabled = false
            };
            smiEdit.DropDownItems.Add(smiCut);

            var smiCopy = new ToolStripMenuItem
            {
                Text = Properties.Localization.Copy,
                ShortcutKeyDisplayString = "Ctrl+C",
                Image = Properties.Resources.ASX_Copy_blue_16x,
                Enabled = false
            };
            smiEdit.DropDownItems.Add(smiCopy);

            var smiPaste = new ToolStripMenuItem
            {
                Text = Properties.Localization.Past,
                ShortcutKeyDisplayString = "Ctrl+V",
                Visible = !ReadOnly,
                Enabled = !ReadOnly,
                Image = Properties.Resources.ASX_Paste_blue_16x
            };
            smiEdit.DropDownItems.Add(smiPaste);

            #endregion

            #region /// Search

            var smiSearch = new ToolStripMenuItem
            {
                Text = Properties.Localization.Search
            };
            msMainMenu.Items.Add(smiSearch);

            var smiFind = new ToolStripMenuItem
            {
                Text = Properties.Localization.Search + "...",
                ShortcutKeyDisplayString = "Ctrl+F",
                ShortcutKeys = Keys.Control | Keys.F,
                Image = Properties.Resources.Search_16x
            };
            smiSearch.DropDownItems.Add(smiFind);

            var smiReplace = new ToolStripMenuItem
            {
                Text = Properties.Localization.Replace + "...",
                ShortcutKeyDisplayString = "Ctrl+H",
                ShortcutKeys = Keys.Control | Keys.H,
                Visible = !ReadOnly,
                Enabled = !ReadOnly,
                Image = Properties.Resources.ReplaceAll_16x
            };
            smiSearch.DropDownItems.Add(smiReplace);

            #endregion

            #endregion

            #region /// Menu

            var tsMenu = new ToolStrip
            {
                BackColor = Color.Transparent,
                Parent = this
            };
            tsMenu.BringToFront();

            var tsbNew = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.NewFile_16x,
                Visible = !ReadOnly,
                ToolTipText = smiNew.Text + "(" + smiNew.ShortcutKeyDisplayString + ")"
            };
            tsMenu.Items.Add(tsbNew);

            var tsbOpen = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.OpenFolder_16x,
                Visible = !ReadOnly,
                ToolTipText = smiOpen.Text + "(" + smiOpen.ShortcutKeyDisplayString + ")"
            };
            tsMenu.Items.Add(tsbOpen);

            var tsbSave = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.Save_16x,
                Visible = !ReadOnly,
                ToolTipText = smiSave.Text + "(" + smiSave.ShortcutKeyDisplayString + ")"
            };
            tsMenu.Items.Add(tsbSave);

            if (!ReadOnly) { tsMenu.Items.Add(new ToolStripSeparator()); }

            var tsbUndo = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.Undo_16x,
                Visible = !ReadOnly,
                ToolTipText = smiUndo.Text + "(" + smiUndo.ShortcutKeyDisplayString + ")",
                Enabled = false
            };
            tsMenu.Items.Add(tsbUndo);

            var tsbCut = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.Cut_16x,
                Visible = !ReadOnly,
                ToolTipText = smiCut.Text + "(" + smiCut.ShortcutKeyDisplayString + ")",
                Enabled = false
            };
            tsMenu.Items.Add(tsbCut);

            var tsbCopy = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.ASX_Copy_blue_16x,
                ToolTipText = smiCopy.Text + "(" + smiCopy.ShortcutKeyDisplayString + ")",
                Enabled = false
            };
            tsMenu.Items.Add(tsbCopy);

            var tsbPaste = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.ASX_Paste_blue_16x,
                Visible = !ReadOnly,
                ToolTipText = smiPaste.Text + "(" + smiPaste.ShortcutKeyDisplayString + ")"
            };
            tsMenu.Items.Add(tsbPaste);

            tsMenu.Items.Add(new ToolStripSeparator());

            var tsbFind = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.Search_16x,
                ToolTipText = smiFind.Text + "(" + smiFind.ShortcutKeyDisplayString + ")"
            };
            tsMenu.Items.Add(tsbFind);

            var tsbReplace = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.ReplaceAll_16x,
                Visible = !ReadOnly,
                ToolTipText = smiReplace.Text + "(" + smiReplace.ShortcutKeyDisplayString + ")"
            };
            tsMenu.Items.Add(tsbReplace);

            tsMenu.Items.Add(new ToolStripSeparator());

            #endregion

            #region /// Tools

            var tsTools = new ToolStrip
            {
                BackColor = Color.Transparent,
                Visible = !ReadOnly,
                Parent = this
            };
            tsTools.BringToFront();

            var tsbBold = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.Bold_16x,
                ToolTipText = Properties.Localization.Bold
            };
            tsTools.Items.Add(tsbBold);

            var tsbItalic = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.Italic_16x,
                ToolTipText = Properties.Localization.Italic
            };
            tsTools.Items.Add(tsbItalic);

            var tsbUnderline = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.Underline_16x,
                ToolTipText = Properties.Localization.Underline
            };
            tsTools.Items.Add(tsbUnderline);

            tsTools.Items.Add(new ToolStripSeparator());

            var tscbFont = new ToolStripComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            foreach (var family in FontFamily.Families)
            {
                tscbFont.Items.Add(family.Name);
            }
            tscbFont.Text = this.Font.FontFamily.Name;
            tsTools.Items.Add(tscbFont);

            var tscbFontSize = new ToolStripComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDown
            };
            tscbFontSize.Items.AddRange((new object[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 }));
            tscbFontSize.Text = this.Font.Size.ToString();
            tsTools.Items.Add(tscbFontSize);

            var tsbFont = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.Font_16x,
                ToolTipText = Properties.Localization.Font
            };
            tsTools.Items.Add(tsbFont);

            var tsbFontColor = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.FontColor_16x,
                ToolTipText = Properties.Localization.FontColor
            };
            tsTools.Items.Add(tsbFontColor);

            tsTools.Items.Add(new ToolStripSeparator());

            var tsbAlignLeft = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.AlignLeft_16x1,
                ToolTipText = Properties.Localization.AlignLeft,
                Checked = true
            };
            tsTools.Items.Add(tsbAlignLeft);

            var tsbAlignCenter = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.AlignCenter_16x,
                ToolTipText = Properties.Localization.AlignCenter
            };
            tsTools.Items.Add(tsbAlignCenter);

            var tsbAlignRight = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = Properties.Resources.AlignRight_16x,
                ToolTipText = Properties.Localization.AlignRight
            };
            tsTools.Items.Add(tsbAlignRight);

            tsTools.Items.Add(new ToolStripSeparator());

            #endregion

            #region /// Text

            rtbText = new RichTextBox
            {
                ReadOnly = ReadOnly,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Width = this.ClientSize.Width,
                Height = this.ClientSize.Height - msMainMenu.Height - tsMenu.Height - tsTools.Height,
                Left = 0,
                Top = msMainMenu.Height + tsMenu.Height + tsTools.Height,
                HideSelection = false,
                Parent = this
            };

            #endregion

            #endregion

            #region /// Events

            #region /// File

            smiNew.Click += (s, e) =>
            {
                if (!fileSaved)
                {
                    if (MessageBox.Show(Properties.Localization.UnsavedСhangesMessage,
                        Properties.Localization.UnsavedСhanges,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                rtbText.Clear();
                rtbText.ClearUndo();
                tscbFont.SelectedIndex = tscbFont.Items.IndexOf("Arial");
                tscbFontSize.SelectedIndex = 0;
                fileSaved = false;
                filePath = "";
                this.Heading = Properties.Localization.TextEditor;

            };
            smiNew.VisibleChanged += (s, e) => { tsbNew.Visible = smiNew.Visible; };

            smiOpen.Click += (s, e) =>
            {
                if (!fileSaved)
                {
                    if (MessageBox.Show(Properties.Localization.UnsavedСhangesMessage,
                        Properties.Localization.UnsavedСhanges,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                using (var ofd = new OpenFileDialog
                {
                    FileName = filePath,
                    Filter = "Rich Text Format (*.RTF)|*.rtf|" + Properties.Localization.AllFiles + " (*.*)|*.*"
                })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Open(ofd.FileName);
                    };
                }
            };
            smiOpen.VisibleChanged += (s, e) => { tsbOpen.Visible = smiOpen.Visible; };

            smiSave.Click += (s, e) =>
            {
                if (!String.IsNullOrEmpty(filePath))
                {
                    Save(filePath);
                }
                else
                {
                    smiSaveAs.PerformClick();
                }
            };
            smiSave.VisibleChanged += (s, e) => { tsbSave.Visible = smiSave.Visible; };

            smiSaveAs.Click += (s, e) =>
            {
                string name = filePath;
                if (String.IsNullOrEmpty(name))
                {
                    name = "New";
                }

                using (var sfd = new SaveFileDialog
                {
                    FileName = name,
                    Filter = "Rich Text Format (*.RTF)|*.rtf|" + Properties.Localization.AllFiles + " (*.*)|*.*"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        filePath = sfd.FileName;
                        Save(filePath);
                    }
                }
            };

            smiClose.Click += (s, e) => { this.Close(); };

            #endregion

            #region /// Edit

            smiUndo.Click += (s, e) =>
            {
                rtbText.Undo();
                smiUndo.Enabled = tsbUndo.Enabled = rtbText.CanUndo;
            };

            smiCut.Click += (s, e) =>
            {
                rtbText.Cut();
            };

            smiCopy.Click += (s, e) =>
            {
                rtbText.Copy();
            };

            smiPaste.Click += (s, e) =>
            {
                rtbText.Paste();
            };

            #endregion

            #region /// Search

            smiFind.Click += (s, e) =>
            {
                if (smiFind.Tag == null) // If the dialogue doesn't exist yet.
                {
                    var sdSearch = new AdditionalDialogs.Search.SearchDialog.SearchDialog(rtbText.SelectedText) // We create a new one.
                    {
                        TopMost = true, // On top of other windows.
                        Owner = this,
                        CloseType = AdditionalDialogs.DialogCloseTypes.Hide,
                        Icon = this.Icon,
                        Tag = new int[] { rtbText.SelectionStart, rtbText.TextLength }
                    };
                    sdSearch.Find += (se, ev) =>
                    {
                        RichTextBoxFinds arguments = RichTextBoxFinds.None; // Standard argument is None.

                        if (ev.MatchCase) // If the checkbox is checked.
                        {
                            if (arguments == RichTextBoxFinds.None) // If the standard argument.
                            {
                                arguments = RichTextBoxFinds.MatchCase; // We write down a new one.
                            }
                            else // If there are other arguments, we concatenate them.
                            {
                                arguments |= RichTextBoxFinds.MatchCase;
                            }
                        }

                        if (ev.Reverse)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.Reverse;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.Reverse;
                            }
                        }

                        if (ev.WholeWord)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.WholeWord;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.WholeWord;
                            }
                        }

                        int result = rtbText.Find(ev.FindText, ((int[])((AdditionalDialogs.Search.SearchDialog.SearchDialog)se).Tag)[0], ((int[])((AdditionalDialogs.Search.SearchDialog.SearchDialog)se).Tag)[1], arguments);

                        if (result >= 0)
                        {
                            if (!ev.Reverse) // If not reversed.
                            {
                                sdSearch.Tag = new int[] { result + rtbText.SelectedText.Length, rtbText.TextLength }; // We write the result as the beginning of the search, the end of the search as the end of the text.
                            }
                            else
                            {
                                sdSearch.Tag = new int[] { 0, result }; // We write 0 as the beginning of the search, the result as the end of the search.
                            }

                        }

                        this.Activate();
                    };

                    sdSearch.Show();
                    smiFind.Tag = sdSearch;
                }
                else // If the dialog is created.
                {
                    var sdSearch = ((AdditionalDialogs.Search.SearchDialog.SearchDialog)smiFind.Tag);

                    if (!sdSearch.Reverse) // If not reversed.
                    {
                        sdSearch.Tag = new int[] { rtbText.SelectionStart, rtbText.TextLength }; // We write down the cursor position as the start of the search, the end of the text as the end.
                    }
                    else
                    {
                        sdSearch.Tag = new int[] { 0, rtbText.TextLength }; // We write 0 as the start of the search, the end of the text as the end of the search.
                    }

                    sdSearch.Show(); // We show the dialogue.
                    sdSearch.Activate();

                }
            };

            smiReplace.Click += (s, e) =>
            {
                if (smiReplace.Tag == null) // If the dialogue doesn't exist yet.
                {
                    var rdReplace = new AdditionalDialogs.Search.ReplacementDialog.ReplacementDialog(rtbText.SelectedText) // We create a new one.
                    {
                        Owner = this,
                        TopMost = true,
                        CloseType = AdditionalDialogs.DialogCloseTypes.Hide,
                        Icon = this.Icon,
                        Tag = new int[] { rtbText.SelectionStart, rtbText.TextLength }
                    };
                    rdReplace.Find += (se, ev) =>
                    {
                        RichTextBoxFinds arguments = RichTextBoxFinds.None; // The standard argument is None.

                        if (ev.MatchCase) // If the checkbox is checked.
                        {
                            if (arguments == RichTextBoxFinds.None) // If the standard argument is.
                            {
                                arguments = RichTextBoxFinds.MatchCase; // Write a new one.
                            }
                            else // If there are other arguments, combine them.
                            {
                                arguments |= RichTextBoxFinds.MatchCase;
                            }
                        }

                        if (ev.Reverse)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.Reverse;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.Reverse;
                            }
                        }

                        if (ev.WholeWord)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.WholeWord;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.WholeWord;
                            }
                        }

                        int result = rtbText.Find(ev.FindText, ((int[])((AdditionalDialogs.Search.SearchDialog.SearchDialog)se).Tag)[0], ((int[])((AdditionalDialogs.Search.SearchDialog.SearchDialog)se).Tag)[1], arguments);

                        if (result >= 0)
                        {
                            if (!ev.Reverse) // If not reversed.
                            {
                                rdReplace.Tag = new int[] { result + rtbText.SelectedText.Length, rtbText.TextLength }; // We write the cursor position as the start of the search, and the end of the text as the end.
                            }
                            else
                            {
                                rdReplace.Tag = new int[] { 0, result }; // Write 0 as the beginning of the search, and the result as the end of the search.
                            }

                        }

                        this.Activate();
                    };

                    rdReplace.Replace += (se, ev) =>
                    {
                        RichTextBoxFinds arguments = RichTextBoxFinds.None;

                        if (ev.MatchCase)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.MatchCase;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.MatchCase;
                            }
                        }

                        if (ev.Reverse)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.Reverse;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.Reverse;
                            }
                        }

                        if (ev.WholeWord)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.WholeWord;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.WholeWord;
                            }
                        }

                        if (rtbText.SelectedText.Length == 0) // If there is no selected text, we look for the first occurrence to replace and terminate the method.
                        {
                            rdReplace.OnFind();
                            return;
                        }

                        rtbText.Find(ev.FindText, rtbText.SelectionStart, arguments); // Looking for the desired text from the cursor position.

                        if (rtbText.SelectedText.Length != 0) // If the selection is not empty.
                        {
                            var index = rtbText.SelectionStart;
                            rtbText.Text = rtbText.Text.Remove(index, rtbText.SelectedText.Length); // Deleting the old text.
                            rtbText.Text = rtbText.Text.Insert(index, ev.ReplaceText); // Insert a new one.
                        }

                        rtbText.Find(ev.FindText, rtbText.SelectionStart, arguments); // Looking for the next occurrence.
                        this.Activate();

                    };

                    rdReplace.ReplaceAll += (se, ev) =>
                    {
                        RichTextBoxFinds arguments = RichTextBoxFinds.None;

                        if (ev.MatchCase)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.MatchCase;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.MatchCase;
                            }
                        }

                        if (ev.Reverse)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.Reverse;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.Reverse;
                            }
                        }

                        if (ev.WholeWord)
                        {
                            if (arguments == RichTextBoxFinds.None)
                            {
                                arguments = RichTextBoxFinds.WholeWord;
                            }
                            else
                            {
                                arguments |= RichTextBoxFinds.WholeWord;
                            }
                        }

                        while (rtbText.Find(ev.FindText, arguments) >= 0) // As long as there is the desired text.
                        {
                            var index = rtbText.SelectionStart;
                            rtbText.Text = rtbText.Text.Remove(index, rtbText.SelectedText.Length); // Cut out the old text.
                            rtbText.Text = rtbText.Text.Insert(index, ev.ReplaceText); // Insert a new one.
                        }

                    };

                    rdReplace.Show();
                    smiReplace.Tag = rdReplace;
                }
                else
                {
                    var rdReplace = ((AdditionalDialogs.Search.SearchDialog.SearchDialog)smiReplace.Tag);

                    if (!rdReplace.Reverse)
                    {
                        rdReplace.Tag = new int[] { rtbText.SelectionStart, rtbText.TextLength };
                    }
                    else
                    {
                        rdReplace.Tag = new int[] { 0, rtbText.TextLength };
                    }

                    rdReplace.Show();
                    rdReplace.Activate();

                }
            };

            #endregion

            #region /// Menu

            tsbNew.Click += (s, e) => { smiNew.PerformClick(); };

            tsbOpen.Click += (s, e) => { smiOpen.PerformClick(); };

            tsbSave.Click += (s, e) => { smiSave.PerformClick(); };

            tsbUndo.Click += (s, e) => { smiUndo.PerformClick(); };

            tsbCut.Click += (s, e) => { smiCut.PerformClick(); };

            tsbCopy.Click += (s, e) => { smiCopy.PerformClick(); };

            tsbPaste.Click += (s, e) => { smiPaste.PerformClick(); };

            tsbFind.Click += (s, e) => { smiFind.PerformClick(); };

            tsbReplace.Click += (s, e) => { smiReplace.PerformClick(); };

            #endregion

            #region /// Tools

            tsbBold.Click += (s, e) =>
            {
                tsbBold.Checked = !tsbBold.Checked;

                if (tsbBold.Checked)
                {
                    FontStyle style = FontStyle.Bold;

                    if (tsbItalic.Checked)
                    {
                        style |= FontStyle.Italic;
                    }

                    if (tsbUnderline.Checked)
                    {
                        style |= FontStyle.Underline;
                    }

                    rtbText.SelectionFont = new Font(rtbText.SelectionFont, style);
                }
                else
                {
                    FontStyle style = FontStyle.Regular;

                    if (tsbItalic.Checked)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Italic;
                        }
                        else
                        {
                            style |= FontStyle.Italic;
                        }
                    }

                    if (tsbUnderline.Checked)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Underline;
                        }
                        else
                        {
                            style |= FontStyle.Underline;
                        }
                    }

                    rtbText.SelectionFont = new Font(rtbText.SelectionFont, style);
                }
            };

            tsbItalic.Click += (s, e) =>
            {
                tsbItalic.Checked = !tsbItalic.Checked;

                if (tsbItalic.Checked)
                {
                    FontStyle style = FontStyle.Italic;

                    if (tsbBold.Checked)
                    {
                        style |= FontStyle.Bold;
                    }

                    if (tsbUnderline.Checked)
                    {
                        style |= FontStyle.Underline;
                    }

                    rtbText.SelectionFont = new Font(rtbText.SelectionFont, style);
                }
                else
                {
                    FontStyle style = FontStyle.Regular;

                    if (tsbBold.Checked)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Bold;
                        }
                        else
                        {
                            style |= FontStyle.Bold;
                        }
                    }

                    if (tsbUnderline.Checked)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Underline;
                        }
                        else
                        {
                            style |= FontStyle.Underline;
                        }
                    }

                    rtbText.SelectionFont = new Font(rtbText.SelectionFont, style);
                }
            };

            tsbUnderline.Click += (s, e) =>
            {
                tsbUnderline.Checked = !tsbUnderline.Checked;

                if (tsbItalic.Checked)
                {
                    FontStyle style = FontStyle.Underline;

                    if (tsbBold.Checked)
                    {
                        style |= FontStyle.Bold;
                    }

                    if (tsbItalic.Checked)
                    {
                        style |= FontStyle.Italic;
                    }

                    rtbText.SelectionFont = new Font(rtbText.SelectionFont, style);
                }
                else
                {
                    FontStyle style = FontStyle.Regular;

                    if (tsbBold.Checked)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Bold;
                        }
                        else
                        {
                            style |= FontStyle.Bold;
                        }
                    }

                    if (tsbItalic.Checked)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Italic;
                        }
                        else
                        {
                            style |= FontStyle.Italic;
                        }
                    }

                    rtbText.SelectionFont = new Font(rtbText.SelectionFont, style);
                }
            };

            tscbFont.SelectedIndexChanged += (s, e) =>
            {
                FontStyle style = FontStyle.Regular;

                try
                {
                    if (rtbText.SelectionFont.Bold)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Bold;
                        }
                        else
                        {
                            style |= FontStyle.Bold;
                        }
                    }

                    if (rtbText.SelectionFont.Italic)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Italic;
                        }
                        else
                        {
                            style |= FontStyle.Italic;
                        }
                    }

                    if (rtbText.SelectionFont.Underline)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Underline;
                        }
                        else
                        {
                            style |= FontStyle.Underline;
                        }
                    }

                    rtbText.SelectionFont = new Font(tscbFont.Text, rtbText.SelectionFont.Size, style);

                }
                catch
                { }
            };

            tscbFontSize.TextChanged += (s, e) =>
            {
                try
                {
                    FontStyle style = FontStyle.Regular;

                    if (rtbText.SelectionFont.Bold)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Bold;
                        }
                        else
                        {
                            style |= FontStyle.Bold;
                        }
                    }

                    if (rtbText.SelectionFont.Italic)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Italic;
                        }
                        else
                        {
                            style |= FontStyle.Italic;
                        }
                    }

                    if (rtbText.SelectionFont.Underline)
                    {
                        if (style == FontStyle.Regular)
                        {
                            style = FontStyle.Underline;
                        }
                        else
                        {
                            style |= FontStyle.Underline;
                        }
                    }

                    rtbText.SelectionFont = new Font(rtbText.SelectionFont.FontFamily, (float)Convert.ToDouble(tscbFontSize.Text), style);
                }
                catch { }
            };

            tsbFont.Click += (s, e) =>
            {
                using (var fd = new FontDialog { Font = rtbText.SelectionFont })
                {
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        rtbText.SelectionFont = fd.Font;
                        tscbFont.Text = fd.Font.FontFamily.Name;
                        tscbFontSize.Text = fd.Font.Size.ToString();

                        if (fd.Font.Bold)
                        {
                            tsbBold.Checked = true;
                        }
                        else
                        {
                            tsbBold.Checked = false;
                        }

                        if (fd.Font.Italic)
                        {
                            tsbItalic.Checked = true;
                        }
                        else
                        {
                            tsbItalic.Checked = false;
                        }

                        if (fd.Font.Underline)
                        {
                            tsbUnderline.Checked = true;
                        }
                        else
                        {
                            tsbUnderline.Checked = false;
                        }
                    }
                }
            };

            tsbFontColor.Click += (s, e) =>
            {
                using (var cd = new ColorDialog { Color = rtbText.SelectionColor })
                {
                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        rtbText.SelectionColor = cd.Color;
                    }
                }
            };

            tsbAlignLeft.Click += (s, e) =>
            {
                if (!tsbAlignLeft.Checked)
                {
                    tsbAlignLeft.Checked = true;
                    tsbAlignCenter.Checked = false;
                    tsbAlignRight.Checked = false;
                    rtbText.SelectionAlignment = HorizontalAlignment.Left;
                }
            };

            tsbAlignCenter.Click += (s, e) =>
            {
                if (!tsbAlignCenter.Checked)
                {
                    tsbAlignLeft.Checked = false;
                    tsbAlignCenter.Checked = true;
                    tsbAlignRight.Checked = false;
                    rtbText.SelectionAlignment = HorizontalAlignment.Center;
                }
            };

            tsbAlignRight.Click += (s, e) =>
            {
                if (!tsbAlignRight.Checked)
                {
                    tsbAlignLeft.Checked = false;
                    tsbAlignCenter.Checked = false;
                    tsbAlignRight.Checked = true;
                    rtbText.SelectionAlignment = HorizontalAlignment.Right;
                }
            };

            #endregion

            #region /// Text

            rtbText.SelectionChanged += (s, e) =>
            {
                
                smiCut.Enabled = smiCopy.Enabled
                    = tsbCut.Enabled = tsbCopy.Enabled = (rtbText.SelectedText.Length != 0);
        
                if (ReadOnly) { return; }

                smiUndo.Enabled = tsbUndo.Enabled = rtbText.CanUndo;

                if (smiFind.Tag != null)
                {
                    var sdSearch = ((AdditionalDialogs.Search.SearchDialog.SearchDialog)smiFind.Tag);

                    if (!sdSearch.Reverse) // If not reversed.
                    {
                        sdSearch.Tag = new int[] { rtbText.SelectionStart, rtbText.TextLength }; // We write the cursor position as the start of the search, the end of the text as the end.
                    }
                    else
                    {
                        sdSearch.Tag = new int[] { 0, rtbText.TextLength }; // We write 0 as the start of the search, the end of the text as the end of the search.
                    }
                }

                if (smiReplace.Tag != null)
                {
                    var rdReplace = ((AdditionalDialogs.Search.ReplacementDialog.ReplacementDialog)smiReplace.Tag);

                    if (!rdReplace.Reverse) // If not reversed.
                    {
                        rdReplace.Tag = new int[] { rtbText.SelectionStart, rtbText.TextLength }; // We write the cursor position as the start of the search, the end of the text as the end.
                    }
                    else
                    {
                        rdReplace.Tag = new int[] { 0, rtbText.TextLength }; // We write 0 as the start of the search, the end of the text as the end of the search.
                    }
                }

                try
                {


                    if (rtbText.SelectionFont.Bold)
                    {
                        tsbBold.Checked = true;
                    }
                    else
                    {
                        tsbBold.Checked = false;
                    }

                    if (rtbText.SelectionFont.Italic)
                    {
                        tsbItalic.Checked = true;
                    }
                    else
                    {
                        tsbItalic.Checked = false;
                    }

                    if (rtbText.SelectionFont.Underline)
                    {
                        tsbUnderline.Checked = true;
                    }
                    else
                    {
                        tsbUnderline.Checked = false;
                    }

                    tscbFont.Text = rtbText.SelectionFont.FontFamily.Name;
                    tscbFontSize.Text = rtbText.SelectionFont.Size.ToString();

                }
                catch (System.NullReferenceException)
                {
                    tsbBold.Checked = false;
                    tsbItalic.Checked = false;
                    tsbUnderline.Checked = false;
                    tscbFont.Text = "";
                    tscbFontSize.Text = "";

                }

                if (rtbText.SelectionAlignment == HorizontalAlignment.Left)
                {
                    tsbAlignLeft.Checked = true;
                    tsbAlignCenter.Checked = false;
                    tsbAlignRight.Checked = false;
                }
                else if (rtbText.SelectionAlignment == HorizontalAlignment.Center)
                {
                    tsbAlignLeft.Checked = false;
                    tsbAlignCenter.Checked = true;
                    tsbAlignRight.Checked = false;
                }
                else if (rtbText.SelectionAlignment == HorizontalAlignment.Right)
                {
                    tsbAlignLeft.Checked = false;
                    tsbAlignCenter.Checked = false;
                    tsbAlignRight.Checked = true;
                }

            };

            rtbText.TextChanged += (s, e) =>
            {
                TextChanged?.Invoke(this, new EventArgs());
            };

            #endregion

            #region /// Form

            this.Resize += (s, e) =>
            {
                rtbText.Width = this.ClientSize.Width;
                rtbText.Height = this.ClientSize.Height - msMainMenu.Height - tsMenu.Height - tsTools.Height;
            };

            this.FormClosing += (s, e) =>
            {
                if ((!ReadOnly) && (!StaticFile))
                {
                    if (!fileSaved)
                    {
                        var result = MessageBox.Show(Properties.Localization.SaveDocument + "?",
                            Properties.Localization.SaveDocumentMessage, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        switch (result)
                        {
                            case DialogResult.Yes:
                                smiSave.PerformClick();
                                break;
                            case DialogResult.Cancel:
                                e.Cancel = true;
                                break;
                            case DialogResult.No:
                                e.Cancel = false;
                                break;
                        }
                    }
                }
                else
                {
                    e.Cancel = false;
                }
            };

            #endregion

            #endregion

        }

        /// <summary>
        /// Open file.
        /// </summary>
        /// <param name="path">Path to file</param>
        public void Open(string path)
        {
            rtbText.ReadOnly = false;
            rtbText.LoadFile(path);
            rtbText.ReadOnly = ReadOnly;
            filePath = path;
            fileSaved = true;
            this.Heading = System.IO.Path.GetFileName(filePath);
        }

        /// <summary>
        /// Save file.
        /// </summary>
        /// <param name="path">Path to file</param>
        public void Save(string path)
        {
            rtbText.SaveFile(path);
            fileSaved = true;
            this.Heading = System.IO.Path.GetFileName(path);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            HeadingChanged?.Invoke(this, new EventArgs());
            base.OnTextChanged(e);
        }

    }
}
