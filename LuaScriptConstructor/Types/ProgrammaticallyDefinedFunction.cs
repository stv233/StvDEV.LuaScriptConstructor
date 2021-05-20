using LuaScriptConstructor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Types
{
    /// <summary>
    /// Lua function for which code and table are set programmatically.
    /// </summary>
    class ProgrammaticallyDefinedFunction : Function
    {
        private ConstructorTable _table = new ConstructorTable();

        /// <summary>
        /// Represents a class containing data for a <see cref="ProgrammaticallyDefinedFunction.TableRebuilding"/> event.
        /// </summary>
        public class RebuildEventArgs: EventArgs
        {
            /// <summary>
            /// Rebuilded table.
            /// </summary>
            public ConstructorTable Table { get; protected set; }

            /// <summary>
            /// Represents a class containing data for a <see cref="ProgrammaticallyDefinedFunction.TableRebuilding"/> event.
            /// </summary>
            /// <param name="table">Rebuilded table</param>
            public RebuildEventArgs(ref ConstructorTable table)
            {
                Table = table;
            }
        }

        /// <summary>
        /// Represents a method that handles <see cref="ProgrammaticallyDefinedFunction.TableRebuilding"/> event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public delegate void RebuildTableEvents(object sender, RebuildEventArgs e);

        /// <summary>
        /// Fires during table rebuild.
        /// </summary>
        public event RebuildTableEvents TableRebuilding;

        /// <summary>
        /// Sets or returns whether the given function should be placed in the library.
        /// </summary>
        public bool IsLibraryFunction { get; set; }

        /// <summary>
        /// Sets or returns whether to rebuild the function table
        /// </summary>
        public bool NeedRebuild { get; set; }

        /// <summary>
        /// Funtion type.
        /// </summary>
        new public FuntionTypes Type
        {
            get
            {
                return base.Type;
            }
            set
            {
                base.Type = value;
            }
        }

        /// <summary>
        /// Funtion table.
        /// </summary>
        new public ConstructorTable Table
        {
            get
            {
                if (NeedRebuild)
                {
                    if (this.Diagram != null)
                    {
                        List<string> warnings = new List<string>();
                        _table = base.BuildTable(this.Diagram, ref warnings);
                        TableRebuilding(this, new RebuildEventArgs(ref _table));
                    }
                }
                return _table;
            }
            set
            {
                _table = value;
            }
        }

        /// <summary>
        /// Function identifier string.
        /// </summary>
        new public string Identifier
        {
            get
            {
                return base.Identifier;
            }
            set
            {
                base.Identifier = value;
            }
        }

        /// <summary>
        /// Function code.
        /// </summary>
        new public string Code
        {
            get
            {
                return base.Code;
            }
            set
            {
                base.Code = value;
            }
        }
    }
}
