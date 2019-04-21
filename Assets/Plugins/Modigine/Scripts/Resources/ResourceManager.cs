using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Modigine
{
    public enum ResourceType { Script, Model, Texture, Audio }

    public class ResourceManager : MonoBehaviour
    {
        // List of all resources loaded in the game from mods
        public Dictionary<string, Object> resources = new Dictionary<string, Object>(); 

        /// <summary>
        /// Adds a new resource to the loaded resources
        /// </summary>
        /// <param name="filePath">The file path to the resource</param>
        /// <param name="value">The value for the resource</param>
        public void AddResource(string filePath, Object value)
        {
            var fileName = Path.GetFileName(filePath.Split('.')[0]);
            resources.Add(fileName, value);
        }

        /// <summary>
        /// Gets a resource from the resources list and returns its value
        /// </summary>
        /// <param name="resourceName">The name of the resource you would like to retrieve</param>
        /// <returns>The resources value as an object type</returns>
        public Object GetResource(string resourceName)
        {
            if(resources.ContainsKey(resourceName))
            {
                var resource = resources[resourceName];
                return resource; 
            }

            return null;
        }
    }
}