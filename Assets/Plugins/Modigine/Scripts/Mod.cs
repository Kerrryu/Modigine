using UnityEngine;

namespace Modigine
{
    [System.Serializable]
    public class Mod
    {
        /*
         *  Mod Details
         */
        public string ModName;
        public string ModPath;
        public string ModAuthor;
        public string ModVersion;
        public string ModID;

        /// <summary>
        /// General constructor for each Mod which contains all the information
        /// </summary>
        /// <param name="modName">The name specified for the mod. This is only for display.</param>
        /// <param name="modPath">The filepath to the root folder of where the ModInfo is located</param>
        /// <param name="modAuthor">The authors name of the mod</param>
        /// <param name="modVersion">The mods current version this is used to know if an update is needed</param>
        /// <param name="modID">This is the unique modifier which is used in the code to identify each mod</param>
        public Mod(string modName, string modPath, string modAuthor, string modVersion, string modID)
        {
            this.ModName = modName;
            this.ModPath = modPath;
            this.ModAuthor = modAuthor;
            this.ModVersion = modVersion;
            this.ModID = modID;
        }
    }
}