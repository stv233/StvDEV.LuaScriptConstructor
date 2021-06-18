using System;
using System.Windows.Forms;

namespace AdditionalDialogs.Search.ReplacementDialog
{
    /// <summary>
    /// Window for searching and replacing a text fragment.
    /// </summary>
    class ReplacementDialog : SearchDialog.SearchDialog
    {
        /// <summary>
        /// Represents data for an event <see cref="SearchDialog.Replace"/> and <see cref="SearchDialog.ReplaceAll"/>.
        /// </summary>
        public class ReplacmentEventArgs : SearchEventArgs
        {
            /// <summary>
            /// Returns the replacement text.
            /// </summary>
            public string ReplaceText { get; protected set; }

            /// <summary>
            /// Represents data for an event <see cref="SearchDialog.Replace"/> and <see cref="SearchDialog.ReplaceAll"/>.
            /// </summary>
            /// <param name="findText">Search text</param>
            /// <param name="replaceText">Replacement text</param>
            /// <param name="matchCase">Search for instances of text with an exact case match</param>
            /// <param name="reverse">The search starts at the end of the document and continues until the beginning of the document</param>
            /// <param name="wholeWord">Search only for instances with whole words</param>
            public ReplacmentEventArgs(string findText = "", string replaceText = "",
                bool matchCase = false, bool reverse = false, bool wholeWord = false)
                : base(findText, matchCase, reverse, wholeWord)
            {
                ReplaceText = replaceText;
            }
        }

        /// <summary>
        /// Represents an event delegate <see cref="ReplacementDialog"/>.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public delegate void ReplacementDialogEvent(object sender, ReplacmentEventArgs e);

        /// <summary>
        /// Triggered when the "Replace" button is clicked".
        /// </summary>
        public event ReplacementDialogEvent Replace;

        /// <summary>
        /// Triggered when the "Replace All" button is clicked".
        /// </summary>
        public event ReplacementDialogEvent ReplaceAll;

        /// <summary>
        /// Field for entering replacement text.
        /// </summary>
        protected TextBox tbReplacment;

        /// <summary>
        /// Returns or sets the replacement text.
        /// </summary>
        public string ReplaceText
        {
            get
            {
                return tbReplacment.Text;
            }
            set
            {
                tbReplacment.Text = value;
            }
        }

        /// <summary>
        /// Replacement button.
        /// </summary>
        protected Button btReplace;

        /// <summary>
        /// Replace all button.
        /// </summary>
        protected Button btReplaceAll;

        /// <summary>
        /// Window for searching and replacing a text fragment.
        /// </summary>
        public ReplacementDialog() : this("", "")
        { }

        /// <summary>
        /// Window for searching and replacing a text fragment.
        /// </summary>
        /// <param name="findText">Search text</param>
        public ReplacementDialog(string findText) : this (findText, "")
        { }

        /// <summary>
        /// Window for searching and replacing a text fragment.
        /// </summary>
        /// <param name="findText">Search text</param>
        /// <param name="replaceText">Replacement text</param>
        public ReplacementDialog(string findText, string replaceText) : base(findText)
        {
            #region /// Initialization

            this.MaximumSize = new System.Drawing.Size(this.Width, 180);
            this.Text = Localization.Replace;
            this.Height = 180;

            #region /// Components

            var lbWith = new Label
            {
                AutoSize = true,
                Text = Localization.Than + ":",
                Left = 5,
                Top = tbFind.Top + tbFind.Height + 10,
                Parent = this
            };

            tbReplacment = new TextBox
            {
                Text = replaceText,
                TabIndex = 1,
                Width = tbFind.Width,
                Left = tbFind.Left,
                Top = lbWith.Top,
                Parent = this
            };

            cbReverse.Top = tbReplacment.Top + tbReplacment.Height + 10;
            cbReverse.TabIndex = 2;
            cbWholeWord.Top = cbReverse.Top + cbReverse.Height + 5;
            cbWholeWord.TabIndex = 3;
            cbMatchCase.Top = cbWholeWord.Top + cbWholeWord.Height + 5;
            cbMatchCase.TabIndex = 4;

            btFind.TabIndex = 5;

            btReplace = new Button
            {
                Text = Localization.Replace,
                Cursor = Cursors.Hand,
                TabIndex = 6,
                Width = btFind.Width,
                Height = btFind.Height,
                Left = btFind.Left,
                Top = btFind.Top + btFind.Height + 10,
                Parent = this
            };

            btReplaceAll = new Button
            {
                Text = Localization.ReplaceAll,
                Cursor = Cursors.Hand,
                TabIndex = 7,
                Width = btReplace.Width,
                Height = btReplace.Height,
                Left = btReplace.Left,
                Top = btReplace.Top + btReplace.Height + 10,
                Parent = this
            };

            btCancel.Top = btReplaceAll.Top + btReplaceAll.Height + 10;
            btCancel.TabIndex = 8;

            #endregion

            #endregion

            #region /// Events

            btReplace.Click += (s, e) =>
            {
                Replace(this, new ReplacmentEventArgs(FindText, ReplaceText, MatchCase, Reverse, WholeWord));
            };

            btReplaceAll.Click += (s, e) =>
            {
                ReplaceAll(this, new ReplacmentEventArgs(FindText, ReplaceText, MatchCase, Reverse, WholeWord));
            };

            this.Replace += (s, e) => { };
            this.ReplaceAll += (s, e) => { };

            #endregion
        }

        /// <summary>
        /// Triggers the event <see cref="ReplacementDialog.Replace"/>.
        /// </summary>
        public void OnReplace()
        {
            Replace(this, new ReplacmentEventArgs(FindText, ReplaceText, MatchCase, Reverse, WholeWord));
        }

        /// <summary>
        /// Triggers the event <see cref="ReplacementDialog.ReplaceAll"/>.
        /// </summary>
        public void OnReplaceAll()
        {
            ReplaceAll(this, new ReplacmentEventArgs(FindText, ReplaceText, MatchCase, Reverse, WholeWord));
        }

    }
}
