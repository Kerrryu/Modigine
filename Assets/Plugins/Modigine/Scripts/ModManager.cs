using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ModManager : MonoBehaviour
{
    // This keeps track of an instance (Singleton)
    public static ModManager Instance;

    // Lua Manager
    public LuaManager luaManager;
    
    /// <summary>
    /// Called upon Awake
    /// </summary>
    private void Awake()
    {
        // Check to see if this is the only unique instance
        if(Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // Initialize Mod Manager
        Initialize();
    }

    /// <summary>
    /// Initializes the Mod Manager
    /// </summary>
    private void Initialize()
    {
        // Create a Lua Manager
        GameObject luaManagerGo = new GameObject("Lua Manager");
        luaManager = luaManagerGo.AddComponent<LuaManager>();
        
        
        luaManager.AddScript("print('testing')");
    }
}
