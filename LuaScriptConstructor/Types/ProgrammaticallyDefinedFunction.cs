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
                return _table;
            }
            set
            {
                _table = value;
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
