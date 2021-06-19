using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace LuaScriptConstructor
{
    /// <summary>
    /// Load screen.
    /// </summary>
    static class LoadScreen
    {
        private static Image _image = new Bitmap(1, 1);
        private static Image _backgroundImage = new Bitmap(1, 1);
        private static Icon _icon = Icon.FromHandle(new Bitmap(1, 1).GetHicon());
        private static String _status = "";
        private static loadScreenForm loadScreen = new loadScreenForm();

        /// <summary>
        /// Load screen form.
        /// </summary>
        private class loadScreenForm : Form
        {
            private PictureBox _image;
            private Label _status;

            /// <summary>
            /// Picture box with load screen image.
            /// </summary>
            public PictureBox Image
            {
                get
                {
                    return _image;
                }
                set
                {
                    _image = value;
                }
            }

            /// <summary>
            /// Label with load screen status.
            /// </summary>
            public Label Status
            {
                get
                {
                    return _status;
                }
                set
                {
                    _status = value;
                }
            }

            public loadScreenForm()
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Size = new Size(600, 300);
                this.FormBorderStyle = FormBorderStyle.None;
                this.BackColor = UserSettings.ColorScheme.SecondaryColor;
                this.ForeColor = UserSettings.ColorScheme.ForeColor;

                _image = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = LoadScreen._image,
                    Size = new Size(this.ClientSize.Height / 2 - this.ClientSize.Height / 20, this.ClientSize.Height / 2 - this.ClientSize.Height / 20),
                    Top = this.Height / 20,
                    Parent = this
                };
                _image.Left = this.ClientSize.Width / 2 - _image.ClientSize.Width / 2;

                _status = new Label
                {
                    AutoSize = true,
                    Font = new Font("Arial", 15, FontStyle.Bold),
                    Text = LoadScreen._status,
                    Top = _image.Top + _image.Height + 10,
                    Parent = this
                };
                _status.Left = this.ClientSize.Width / 2 - _status.Width / 2;
                _status.TextChanged += (s, e) => { this.OnResize(new EventArgs()); };

                this.Resize += (s, e) =>
                {
                    _image.Size = new Size(this.ClientSize.Height / 2 - this.ClientSize.Height / 20, this.ClientSize.Height / 2 - this.ClientSize.Height / 20);
                    _image.Left = this.ClientSize.Width / 2 - _image.ClientSize.Width / 2;
                    _image.Top = this.Height / 20;
                    _status.Top = _image.Top + _image.Height + 10;
                    _status.Left = this.ClientSize.Width / 2 - _status.Width / 2;
                };
            }
        }

        /// <summary>
        /// Load screen image.
        /// </summary>
        public static Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;

                if (loadScreen.InvokeRequired)
                {
                    loadScreen.Invoke(new MethodInvoker(() =>
                    {
                        loadScreen.Image.Image = _image;
                    }));
                }
                else
                {
                    loadScreen.Image.Image = _image;
                }
                
            }
        }

        /// <summary>
        /// Background image on load screen.
        /// </summary>
        public static Image BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
            set
            {
                _backgroundImage = value;
                if (loadScreen.InvokeRequired)
                {
                    loadScreen.Invoke(new MethodInvoker(() =>
                    {
                        loadScreen.BackgroundImage = _backgroundImage;
                    }));
                }
                else
                {
                    loadScreen.BackgroundImage = _backgroundImage;
                }
            }
        }

        /// <summary>
        /// Load screen icon.
        /// </summary>
        public static Icon Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                if (loadScreen.InvokeRequired)
                {
                    loadScreen.Invoke(new MethodInvoker(() =>
                   {
                       loadScreen.Icon = _icon;
                   }));
                }
                else
                {
                    loadScreen.Icon = _icon;
                }
                
            }
        }

        /// <summary>
        /// Load screen status.
        /// </summary>
        public static String Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                if (loadScreen.InvokeRequired)
                {
                    loadScreen.Invoke(new MethodInvoker(() =>
                    {
                        loadScreen.Status.Text = _status;
                        loadScreen.Text = _status;
                    }));
                }
                else
                {
                    loadScreen.Status.Text = _status;
                    loadScreen.Text = _status;
                }
                
            }
        }
    
        /// <summary>
        /// Show load screen.
        /// </summary>
        public static void Show()
        {
            Task.Run(() =>
            {
                loadScreen.ShowDialog();
            });
        }

        /// <summary>
        /// Hide load screen.
        /// </summary>
        public static void Hide()
        {
            if (loadScreen.InvokeRequired)
            {
                loadScreen.Invoke(new MethodInvoker(() =>
                {
                    loadScreen.Hide();
                }));
            }
            else
            {
                loadScreen.Hide();
            }
        }

        /// <summary>
        /// Close load screen.
        /// </summary>
        public static void Close()
        {
            if (loadScreen.InvokeRequired)
            {
                loadScreen.Invoke(new MethodInvoker(() =>
                {
                    loadScreen.Close();
                }));
            }
            else
            {
                loadScreen.Close();
            }
            
        }
    }
}
