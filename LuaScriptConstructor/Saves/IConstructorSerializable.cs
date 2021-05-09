using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Saves
{
    interface IConstructorSerializable
    {
        string SerializeToString();

        void DeserializeFromString(string serialized);
    }
}
