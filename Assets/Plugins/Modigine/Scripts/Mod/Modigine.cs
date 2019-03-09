using UnityEngine;

namespace Modigine
{
    public static class Modigine
    {
        public static void print(string message, string color = "white")
        {
            Debug.Log(string.Format("<color={0}>MODIGINE: {1}</color>", color, message));
        }
    }
}