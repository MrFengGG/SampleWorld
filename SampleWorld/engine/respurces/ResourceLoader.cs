using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace SampleWorld.engine.respurces
{
    class ResourceLoader
    {
        private static Dictionary<String, Texture2D> textureDict = new Dictionary<String, Texture2D>();

        //获取纹理
        public static Texture2D GetTexture(String textureName)
        {
            return textureDict[textureName];
        }

        //加载纹理
        public static Texture2D LoadTexture2D(GraphicsDevice graphicsDevice, String textureName, String texturePath)
        {
            if (textureDict.ContainsKey(textureName))
            {
                return textureDict[textureName];
            }
            using (var stream = new System.IO.FileStream(texturePath, FileMode.Open))
            {
                Texture2D texture = Texture2D.FromStream(graphicsDevice, stream);
                textureDict[textureName] = texture;
                return texture;
            }
        }
    }
}
