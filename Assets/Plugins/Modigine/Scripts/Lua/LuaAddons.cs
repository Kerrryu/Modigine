using System.Collections;
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

        public GameObject CreateObjectFromMesh(string resourceName, Vector3 pos)
        {
            Object objResource = Modigine.resourceManager.GetResource(resourceName);
            if(objResource != null)
            {
                // Create Gameobject
                var go = new GameObject(resourceName);
                go.transform.position = pos;
                go.AddComponent<MeshRenderer>();
                var renderer = go.AddComponent<MeshFilter>();
                Mesh mesh = (Mesh)objResource;
                renderer.mesh = mesh;
                return go;
            }
            return null;
        }

        public void SetTexture(GameObject go, string textureResourceName, float timeOut = 5.0f) { Modigine.luaManager.StartCoroutine(DelaySetTexture(go, textureResourceName, timeOut)); }
        private IEnumerator DelaySetTexture(GameObject go, string textureResourceName, float timeOut)
        {
            Texture2D texture = null;
            var timer = 0.0f;
            while((texture = (Texture2D)Modigine.resourceManager.GetResource("log")) == null && timer < timeOut)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            if(texture != null)
                go.GetComponent<Renderer>().material.mainTexture = texture;
        }

        public Object getResource(string name)
        {
            return Modigine.resourceManager.GetResource(name);
        }
    }
}