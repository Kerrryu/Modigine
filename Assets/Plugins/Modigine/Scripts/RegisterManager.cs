using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Modigine
{
    public class RegisterManager : MonoBehaviour
    {
        // List of registers supported for the modding tool
        public List<ModRegister> registers = new List<ModRegister>();

        // Add the new register
        public void AddRegister(ModRegister register)
        {
            // This adds the register to the list
            registers.Add(register);
        }
        
        // Register a file
        public void RegisterFile(string filePath)
        {
            // Get the register by file type
            ModRegister fileRegister;
            if((fileRegister = GetRegisterByFilePath(filePath)) != null)
            {
                //TODO: Register the files
            }
        }
        
        // Get Register for file path provided
        private ModRegister GetRegisterByFilePath(string filePath)
        {
            // Split the string
            var stringContent = filePath.Split('.');
            // Get the register by the file type
            return GetRegisterByFileType(stringContent[stringContent.Length - 1]);
        }
        
        // Get Register for file type provided
        private ModRegister GetRegisterByFileType(string fileType)
        {
            // Look through all the registers for the right file path
            var supportedRegister = registers.FirstOrDefault(x => x.supportedFileTypes.FirstOrDefault(y => y == fileType) != null);
            return supportedRegister;
        }
    }
}