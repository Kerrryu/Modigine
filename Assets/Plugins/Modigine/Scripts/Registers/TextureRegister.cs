using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modigine
{
    public class TextureRegister : IRegister
    {
        private MonoBehaviour _mb;

        public void Load(string filePath)
        {
            Modigine.luaManager.StartCoroutine(TextureLoad("file://"+filePath));  
        }

        private IEnumerator TextureLoad(string filePath)
        {
            Texture2D texture;
            texture = new Texture2D(4,4,TextureFormat.DXT1,false);

            using (WWW www = new WWW(filePath))
            {
                if(www != null)
                {
                    yield return www;
                    www.LoadImageIntoTexture(texture);
                    Modigine.resourceManager.AddResource(filePath, texture) ;
                    Modigine.print("Added new texture " + filePath);
                }
            }
        }
    }
}
