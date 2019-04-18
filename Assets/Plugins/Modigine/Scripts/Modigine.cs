using UnityEngine;

namespace Modigine
{
    public static class Modigine
    {
        // The version of Modigine
        public const string VERSION = "0.0.1";

        // Modigine Components
        public static ModManager modManager;
        public static RegisterManager registerManager;
        public static ResourceManager resourceManager;
        public static LuaManager luaManager;

        /// <summary>
        /// Prints a message using Modigine to differ the message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void print(string message, string color = "white")
        {
            Debug.Log(string.Format("<color={0}>MODIGINE: {1}</color>", color, message));
        }
    }
}