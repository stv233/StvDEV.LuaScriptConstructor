using System;
using System.Drawing;
using Crainiate.Diagramming;

namespace LuaScriptConstructor.Shapes
{
    /// <summary>
    /// Represents a line in a diagram that connects diagram shapes.
    /// </summary>
    class ConstructorConnector : Connector, Saves.IConstructorSerializable
    {
        /// <summary>
        /// Gets the port to which the start of the connector is connected.
        /// </summary>
        public Port StartPort
        {
            get
            {
                return Start.Port;
            }
        }

        /// <summary>
        /// Gets the port to which the end of the connector is connected.
        /// </summary>
        public Port EndPort
        {
            get
            {
                return End.Port;
            }
        }

        /// <summary>
        /// Serializes a connector to a string.
        /// </summary>
        /// <returns>Serialized connector</returns>
        public string SerializeToString()
        {
            string result = "{";
            result += "Key=" + Key + ";";
            if (StartPort != null)
            {
                if (!((StartPort.Label != null) && (StartPort.Label.Text == "[Port_Removed]")))
                {
                    result += "StartLocation=" + Start.Location.X + "-" + Start.Location.Y + ";";
                    result += "StartPortKey=" + StartPort.Key + ";";
                }
                else
                {
                    result += "EndLocation=" + this.FirstPoint.X + "-" + this.FirstPoint.Y + ";";
                }
            }
            else
            {
                result += "StartLocation=" + Start.Location.X + "-" + Start.Location.Y + ";";
            }
            result += "EndLocation=" + End.Location.X + "-" + End.Location.Y + ";";
            if (EndPort != null)
            {
                if (!((EndPort.Label != null) && (EndPort.Label.Text == "[Port_Removed]")))
                {
                    result += "EndLocation=" + End.Location.X + "-" + End.Location.Y + ";";
                    result += "EndPortKey=" + EndPort.Key + ";";
                }
                else
                {  
                    result += "EndLocation=" + this.LastPoint.X + "-" + this.LastPoint.Y + ";";
                }
            }

            result += "}";

            return result;
        }

        /// <summary>
        /// Deserializes a connector from a string.
        /// </summary>
        /// <param name="serializedConnector">Serialized connector</param>
        public void DeserializeFromString(string serializedConnector)
        {
            serializedConnector = serializedConnector.Substring(1, serializedConnector.Length - 2);
            while (serializedConnector.Length > 0)
            {
                int propertySign = serializedConnector.IndexOf('=');
                string propertyName = serializedConnector.Substring(0, propertySign);
                int delimiter = Saves.Saves.FindPropertyDelemiter(serializedConnector, propertySign);
                switch (propertyName)
                {
                    case "Key":
                        this.SetKey(serializedConnector.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedConnector = serializedConnector.Substring(delimiter + 1);
                        break;
                    case "StartLocation":
                        string[] startLocation = (serializedConnector.Substring(propertySign + 1, delimiter - (propertySign + 1)).Split('-'));
                        this.Start.Location = new System.Drawing.PointF((float)Convert.ToDouble(startLocation[0]), (float)Convert.ToDouble(startLocation[1]));
                        serializedConnector = serializedConnector.Substring(delimiter + 1);
                        break;
                    case "StartPortKey":
                        this.Start.Port = new Port();
                        this.Start.Port.SetKey(serializedConnector.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedConnector = serializedConnector.Substring(delimiter + 1);
                        break;
                    case "EndLocation":
                        string[] endLocation = (serializedConnector.Substring(propertySign + 1, delimiter - (propertySign + 1)).Split('-'));
                        this.End.Location = new System.Drawing.PointF((float)Convert.ToDouble(endLocation[0]), (float)Convert.ToDouble(endLocation[1]));
                        serializedConnector = serializedConnector.Substring(delimiter + 1);
                        break;
                    case "EndPortKey":
                        this.End.Port = new Port();
                        this.End.Port.SetKey(serializedConnector.Substring(propertySign + 1, delimiter - (propertySign + 1)));
                        serializedConnector = serializedConnector.Substring(delimiter + 1);
                        break;
                }
            }
        }

    }
}
