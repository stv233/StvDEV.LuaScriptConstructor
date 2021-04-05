using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Types
{
    class Constant
    {
        /// <summary>
        /// Constant value.
        /// </summary>
        public virtual string Value { get; set; }

        public virtual Shapes.ConstructorTable Table { get; protected set; }
    }
}
