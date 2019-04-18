using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modigine
{
    public class ObjRegister : IRegister
    {
        public void Load(string filePath)
        {
            Mesh newMesh = FastObjImporter.Instance.ImportFile(filePath);  
            Modigine.resourceManager.AddResource(filePath, newMesh);
        }
    }
}
