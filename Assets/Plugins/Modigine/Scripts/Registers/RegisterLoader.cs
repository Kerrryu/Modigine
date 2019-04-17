using UnityEngine;
using System.Collections;

namespace Modigine
{
    public class RegisterLoader : MonoBehaviour
    {
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            // Add the register managers
            Modigine.registerManager.AddRegister(new FileRegister(new LuaRegister(), "lua"));
        }
    }
}