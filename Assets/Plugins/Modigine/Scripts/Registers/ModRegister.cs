using UnityEngine;
using System.Collections.Generic;

namespace Modigine
{
    public abstract class ModRegister : MonoBehaviour
    {
        // This is a list of the supported file types for the register
        public List<string> supportedFileTypes = new List<string>();
        
        /// <summary>
        /// This is used to load the file information into it's respective category
        /// </summary>
        /// <param name="filePath"></param>
        public virtual void Load(string filePath)
        {
            Modigine.print("Register not setup for file path: " + filePath);
        }
    }
}