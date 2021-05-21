using LuaScriptConstructor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Types
{
    /// <summary>
    /// Represents a function for which code and table are set programmatically type class for a script constructor
    /// </summary>
    class ProgrammaticallyDefinedFunction : Function
    {
        private ConstructorTable _table = new ConstructorTable();

        /// <summary>
        /// Sets or returns whether the given function should be placed in the library.
        /// </summary>
        public bool IsLibraryFunction { get; set; }

        /// <summary>
        /// Sets or returns whether to rebuild the function table
        /// </summary>
        public bool NeedRebuild { get; set; }

        /// <summary>
        /// Fires during table rebuild.
        /// </summary>
        public override event RebuildTableEvents TableRebuilding;

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
                        try
                        {
                            TableRebuilding(this, new RebuildEventArgs(ref _table));
                        }
                        catch (NullReferenceException) { }
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
        /// Returns or sets whether an identifier is specified with arguments.
        /// </summary>
        public virtual bool IdentifierWithArguments { get; set; }

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

        public ProgrammaticallyDefinedFunction()
        {
            TableRebuilding += (s, e) => { };
        }
    }
}
