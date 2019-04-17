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
        public static LuaManager luaManager;

        public static void print(string message, string color = "white")
        {
            Debug.Log(string.Format("<color={0}>MODIGINE: {1}</color>", color, message));
        }
    }
}