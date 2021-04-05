using LuaScriptConstructor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Types
{
    class DefaultFunction : Function
    {
        /// <summary>
        /// Funtion table.
        /// </summary>
        new public ConstructorTable Table
        {
            get
            {
                return base.Table;
            }
            set
            {
                base.Table = value;
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
