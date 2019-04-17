using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

namespace Modigine
{
    public class ModManager : MonoBehaviour
    {
        // This is the list of Mods loaded into the game. It can only be refreshed using the RefreshModInfo() method
        public static List<Mod> Mods = new List<Mod>();

        /// <summary>
        /// Called upon Awake
        /// </summary>
        private void Awake()
        {
            var instance = Modigine.modManager;

            // Check to see if this is the only unique instance
            if (instance != null && instance != this)
                Destroy(gameObject);

            Modigine.modManager = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            // Initialize Mod Manager
            Initialize();
        }

        /// <summary>
        /// Initializes the Mod Manager
        /// </summary>
        private void Initialize()
        {
            // Create a Lua Manager
            var luaManagerGo = new GameObject("Lua Manager");
            luaManagerGo.transform.SetParent(transform);
            Modigine.luaManager = luaManagerGo.AddComponent<LuaManager>();
            Modigine.luaManager.Initialize();

            // Create a Register Manager
            var registerManagerGo = new GameObject("Register Manager");
            registerManagerGo.transform.SetParent(transform);
            Modigine.registerManager = registerManagerGo.AddComponent<RegisterManager>();
            registerManagerGo.AddComponent<RegisterLoader>();

            // Load file path and Mod Infos
            string rootLocation = Path.GetFullPath(".");
            string modLocation = rootLocation + "/Mods/";

            // Create a mod folder if one doesn't exist
            if (!Directory.Exists(modLocation))
                Directory.CreateDirectory(modLocation);
            
            // Get all current Mod infos
            RefreshModInfo(modLocation);
            
            // Now we can start the mods by doing a RunMods
            RunMods();
        }

        /// <summary>
        /// Clears the current list of Mods then updates it with an up to date version
        /// </summary>
        /// <param name="modLocation">The file path to the Mods root folder</param>
        private void RefreshModInfo(string modLocation)
        {
            // Clear the current list of mods to avoid conflicts
            Mods.Clear();

            // Get Mod folders then iterate them
            var modFolders = Directory.GetDirectories(modLocation);
            foreach (var modFolder in modFolders)
            {
                // Check for Mod Info json
                var modInfoPath = modFolder + "/ModInfo.json";
                if (!File.Exists(modInfoPath)) continue;
                
                // Read the text from the ModInfo then create a Mod object from it and add it to the list
                var modInfoContent = File.ReadAllText(modInfoPath);
                Mod newMod = JsonUtility.FromJson<Mod>(modInfoContent);
                newMod.ModPath = modFolder;
                Mods.Add(newMod);
                Modigine.print("Loaded " + newMod.ModName  + " by " + newMod.ModAuthor, "green");
            }
        }

        /// <summary>
        /// This searches all the mod folders for scripts and resources by file extension then implements them into the game using their required modules
        /// </summary>
        private void RunMods()
        {
            // Iterate the mods loaded
            foreach (Mod mod in Mods)
            {
                var files = Directory.GetFiles(mod.ModPath, "*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Modigine.registerManager.RegisterFile(file);
                }
            }
        }
    }
}