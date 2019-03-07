using UnityEngine;

namespace Modigine
{
    class LuaAddons
    {
        public GameObject CreateNewGO(string name)
        {
            return new GameObject(name);
        }

        public GameObject CreatePrimitive(string objectType, string name)
        {
            GameObject go = null;
            switch (objectType)
            {
                case "Cube":
                    go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;
                case "Sphere":
                    go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    break;
                case "Capsule":
                    go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    break;
                case "Cylinder":
                    go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    break;
                case "Plane":
                    go = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    break;
                case "Quad":
                    go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    break;
                default:
                    go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;
            }
            go.name = name;
            return go;
        }
    }
}