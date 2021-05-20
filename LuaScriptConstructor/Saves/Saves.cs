using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaScriptConstructor.Saves
{
    static class Saves
    {
        /// <summary>
        /// Searches for the property delimiter in the serialized string.
        /// </summary>
        /// <param name="serializedString">Serialized string</param>
        /// <param name="propertySign">Property start sign index</param>
        /// <returns>Property delemiter index</returns>
        public static int FindPropertyDelemiter(string serializedString, int propertySign)
        {
            int level = 0;
            bool ignore = false;
            for (var i = propertySign + 1; i < serializedString.Length; i++)
            {
                if (serializedString[i] == '∴')
                {
                    ignore = !ignore;
                }
                if ((serializedString[i] == '=') && (!ignore))
                {
                    level++;
                }
                if ((serializedString[i] == ';') && (!ignore))
                {
                    if (level == 0)
                    {
                        return i;
                    }
                    else
                    {
                        level--;
                    }
                }
            }

            throw new Exception("Could not find delimiter. Level difference: " + level.ToString());
            //return -1;
        }
    }
}
