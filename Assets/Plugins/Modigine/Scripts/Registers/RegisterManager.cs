using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Modigine
{
    public class RegisterManager : MonoBehaviour
    {
        // List of registers supported for the modding tool
        public List<FileRegister> registers = new List<FileRegister>();

        /// <summary>
        /// Add a new register
        /// </summary>
        /// <param name="register">The register that you would like to add to cache</param>
        public void AddRegister(FileRegister register)
        {
            if(registers.Contains(register)) return;
            // This adds the register to the list
            registers.Add(register);
            Modigine.print("Added " + register.ToString());
        }
        
        /// <summary>
        /// Send a file to it's proper register
        /// </summary>
        /// <param name="filePath">The file path of the file you'd like to register</param>
        public void RegisterFile(string filePath)
        {
            // Get the register by file type
            FileRegister fileRegister;
            if((fileRegister = GetRegisterByFilePath(filePath)) != null)
            {
                // Load the file
                fileRegister.register.Load(filePath);
            }
        }
        
        /// <summary>
        /// Returns a register that belongs to the file format of the file provided
        /// </summary>
        /// <param name="filePath">The file path of the file you'd like to get the register for</param>
        /// <returns></returns>
        private FileRegister GetRegisterByFilePath(string filePath)
        {
            // Split the string
            var stringContent = filePath.Split('.');
            var fileType = stringContent[stringContent.Length - 1];
            // Get the register by the file type
            return GetRegisterByFileType(fileType);
        }
        
        /// <summary>
        /// Get the register specifically by the file type
        /// </summary>
        /// <param name="fileType">The file type of the register you'd like to get</param>
        /// <returns></returns>
        private FileRegister GetRegisterByFileType(string fileType)
        {
            // Look through all the registers for the right file path
            var supportedRegister = registers.FirstOrDefault(x => x.supportedFileTypes.FirstOrDefault(y => y == fileType) != null);
            return supportedRegister;
        }
    }

    /// <summary>
    /// Base Register class for managing file types
    /// </summary>
    public class FileRegister
    {
        public string[] supportedFileTypes;
        public IRegister register;

        public FileRegister(IRegister register, params string[] supportedFileTypes)
        {
            this.register = register;
            this.supportedFileTypes = supportedFileTypes;
        }
    }
}