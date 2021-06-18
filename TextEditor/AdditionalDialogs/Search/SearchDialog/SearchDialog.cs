using System;
using System.Windows.Forms;

namespace AdditionalDialogs.Search.SearchDialog
{

    /// <summary>
    /// Window for searching a piece of text. 
    /// </summary>
    class SearchDialog : Form
    {
        /// <summary>
        /// Represents data for an event <see cref="SearchDialog.Find"/>.
        /// </summary>
        public class SearchEventArgs : EventArgs
        {
            /// <summary>
            /// Returns the search text.
            /// </summary>
            public string FindText { get; protected set; }

            /// <summary>
            /// Search for instances of text with an exact case match.
            /// </summary>
            public bool MatchCase { get; protected set; }

            /// <summary>
            /// The search starts at the end of the document and continues until the beginning of the document..
            /// </summary>
            public bool Reverse { get; protected set; }

            /// <summary>
            /// Search only instances with whole words.
            /// </summary>
            public bool WholeWord { get; protected set; }

            /// <summary>
            /// Represents data for an event <see cref="SearchDialog.Find"/>.
            /// </summary>
            /// <param name="findText">Search text</param>
            /// <param name="matchCase">Search for instances of text with an exact case match</param>
            /// <param name="reverse">The search starts at the end of the document and continues until the beginning of the document.</param>
            /// <param name="wholeWord">Search only instances with whole words</param>
            public SearchEventArgs(string findText = "", bool matchCase = false, 
                bool reverse = false, bool wholeWord = false)
            {
                FindText = findText;
                MatchCase = matchCase;
                Reverse = reverse;
                WholeWord = wholeWord;
            }

        }

        /// <summary>
        /// Represents an event delegate <see cref="SearchDialog"/>.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public delegate void SearchDialogEvent(object sender, SearchEventArgs e);

        /// <summary>
        /// Fires when the "Find" button is pressed.
        /// </summary>
        public event SearchDialogEvent Find;

        /// <summary>
        /// Returns the maximum size the dialog can be enlarged to.
        /// </summary>
        public new System.Drawing.Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            protected set
            {
                base.MaximumSize = value;
            }
        }

        /// <summary>
        /// Returns the minimum size to which the dialog can be reduced.
        /// </summary>
        public new System.Drawing.Size MinimumSize 
        {
            get
            {
                return base.MinimumSize;
            }
            protected set
            {
                base.MinimumSize = value;
            }
        }

        /// <summary>
        /// Text input field for search.
        /// </summary>
        protected TextBox tbFind;

        /// <summary>
        /// Returns or sets the search text.
        /// </summary>
        public string FindText
        {
            get
            {
                return tbFind.Text;
            }
            set
            {
                tbFind.Text = value;
            }

        }

        /// <summary>
        /// Field for specifying search by case.
        /// </summary>
        protected CheckBox cbMatchCase;

        /// <summary>
        /// Search for instances of text with an exact case match.
        /// </summary>
        public bool MatchCase
        {
            get
            {
                return cbMatchCase.Checked;
            }
            set
            {
                cbMatchCase.Checked = value;
            }
        }

        /// <summary>
        /// Search direction field.
        /// </summary>
        protected CheckBox cbReverse;

        /// <summary>
        /// The search starts at the end of the document and continues until the beginning of the document.
        /// </summary>
        public bool Reverse
        {
            get
            {
                return cbReverse.Checked;
            }
            set
            {
                cbReverse.Checked = value;
            }
        }

        /// <summary>
        /// Field for specifying the search for whole words.
        /// </summary>
        protected CheckBox cbWholeWord;

        /// <summary>
        /// Search only for instances with whole words.
        /// </summary>
        public bool WholeWord
        {
            get
            {
                return cbWholeWord.Checked;
            }
            set
            {
                cbWholeWord.Checked = value;
            }
        }

        /// <summary>
        /// Returns or sets the response of the dialog window to closing.
        /// </summary>
        public DialogCloseTypes CloseType { get; set; }

        /// <summary>
        /// Search button.
        /// </summary>
        protected Button btFind;

        /// <summary>
        /// Cancel button.
        /// </summary>
        protected Button btCancel;

        /// <summary>
        /// Window for searching for a text fragment. 
        /// </summary>
        public SearchDialog() : this("")
        { }

        /// <summary>
        /// Window for searching for a text fragment. 
        /// </summary>
        /// <param name="findText">Search text</param>
        public SearchDialog(string findText)
        {
            #region /// Initialization

            #region /// Form

            this.Width = 400;
            this.Height = 150;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = Localization.Find;

            #endregion

            #region /// Components

            var lbWhat = new Label
            {
                AutoSize = true,
                Text = Localization.What + ":",
                Left = 5,
                Top = 10,
                Parent = this
            };

            tbFind = new TextBox
            {
                Text = findText,
                Width = (int)(this.ClientSize.Width / 4 * 2.5 - 10),
                Left = lbWhat.Left + lbWhat.Width + 5,
                Top = lbWhat.Top,
                Parent = this
            };

            cbReverse = new CheckBox
            {
                AutoSize = true,
                Text = Localization.ReverseSearchDirection,
                Left = tbFind.Left,
                Top = tbFind.Top + tbFind.Height + 10,
                Parent = this
            };

            cbWholeWord = new CheckBox
            {
                AutoSize = true,
                Text = Localization.WholeWordsOnly,
                Left = cbReverse.Left,
                Top = cbReverse.Top + cbReverse.Height + 5,
                Parent = this
            };

            cbMatchCase = new CheckBox
            {
                AutoSize = true,
                Text = Localization.CaseSensitive,
                Left = cbWholeWord.Left,
                Top = cbWholeWord.Top + cbWholeWord.Height + 5,
                Parent = this
            };

            btFind = new Button
            {
                Text = Localization.FindNext,
                Cursor = Cursors.Hand,
                Width = this.ClientSize.Width - (tbFind.Left + tbFind.Width + 5) - 5,
                Height = tbFind.Height,
                Left = tbFind.Left + tbFind.Width + 5,
                Top = tbFind.Top,
                Parent = this
            };

            btCancel = new Button
            {
                Text = Localization.Cancel,
                Cursor = Cursors.Hand,
                Width = btFind.Width,
                Height = btFind.Height,
                Left = btFind.Left,
                Top = btFind.Top + btFind.Height + 10,
                Parent = this
            };

            #endregion

            #endregion

            #region /// Events

            btFind.Click += (s, e) =>
            {
                Find(this, new SearchEventArgs(FindText, MatchCase, Reverse, WholeWord));
            };

            btCancel.Click += (s, e) =>
            {
                this.Close();
            };

            this.FormClosing += (s, e) =>
            {
                if (CloseType == DialogCloseTypes.Hide)
                {
                    this.Hide();
                    e.Cancel = true;
                }
            };

            this.Find += (s, e) => { };

            #endregion
        }

        /// <summary>
        /// Triggers the event <see cref="SearchDialog.Find"/>
        /// </summary>
        public void OnFind()
        {
            Find(this, new SearchEventArgs(FindText, MatchCase, Reverse, WholeWord));
        }

    }
}
