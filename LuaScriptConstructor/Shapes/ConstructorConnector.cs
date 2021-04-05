using System;
using System.Drawing;
using Crainiate.Diagramming;

namespace LuaScriptConstructor.Shapes
{
    /// <summary>
    /// Represents a line in a diagram that connects diagram shapes.
    /// </summary>
    class ConstructorConnector : Connector
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
    }
}
