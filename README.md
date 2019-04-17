### Unity Open Source Modding Tool

#### (Early Development) Not ready for use in projects

***

Currently Supports:
- Lua
- More coming soon

***

Need to handle custom file types?
Here is how you can add a new FileRegister:
1) Create a new class implementing the IFileRegister Interface
```C#
using Modigine;

public class LuaRegister : IRegister
{
    public void Load(string filePath)
    {
        string content = File.ReadAllText(filePath);
        Modigine.luaManager.AddScript(content);
        Modigine.print("Loaded " + filePath);
    }
}
```
2) Register the new FileRegister with the RegisterLoader class
```C#
void Awake()
{
    // FORMAT: Modigine.registerManager.AddRegister(new FileRegister(new RegisterClassName(), fileType1, fileType2, fileType3,...));
    Modigine.registerManager.AddRegister(new FileRegister(new LuaRegister(), "lua"));
}
```

***
