using UnityEngine;
using System.Collections;
using System.IO;

namespace Modigine
{
    public class LuaRegister : IRegister
    {
        public void Load(string filePath)
        {
            string content = File.ReadAllText(filePath);
            Modigine.luaManager.AddScript(content);
            Modigine.print("Loaded " + filePath);
        }
    }
}