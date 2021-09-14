using System;
using System.IO;
using System.Collections.Generic;
using SFML.Graphics;

namespace IW4DumpHelperGUI.Core.Assets
{
    public class AssetManager
    {
        private List<FontAsset> FontList = new List<FontAsset>();
        private List<TextureAsset> TextureList = new List<TextureAsset>();

        public AssetManager()
        {
            if (!Directory.Exists(Path.Combine(App.ResourceFolder, "textures")))
            {
                Directory.CreateDirectory(Path.Combine(App.ResourceFolder, "textures"));
            }
            if (!Directory.Exists(Path.Combine(App.ResourceFolder, "fonts")))
            {
                Directory.CreateDirectory(Path.Combine(App.ResourceFolder, "fonts"));
            }

            FontList.Clear();
            TextureList.Clear();
        }

        public void Load(AssetTypes Type, string File, string Name)
        {
            if (Type == AssetTypes.FONT)
            {
                FontList.Add(new FontAsset(File, Name));
            }
            else if (Type == AssetTypes.TEXTURE)
            {
                TextureList.Add(new TextureAsset(File, Name));
            }
            else
            {
                throw new Exception(Type + " --- Unknown AssetType!");
            }
        }

        public Font GetFont(string Name)
        {
            foreach (FontAsset _font in FontList)
            {
                if (_font.Name == Name)
                {
                    return _font.Font;
                }
            }
            return null;
        }
        public Texture GetTexture(string Name)
        {
            foreach (TextureAsset _texture in TextureList)
            {
                if (_texture.Name == Name)
                {
                    return _texture.Texture;
                }
            }
            return null;
        }

        public int GetLoadedAssetSize()
        {
            int s = 0;
            foreach (FontAsset f in FontList)
            {
                s++;
            }
            foreach (TextureAsset t in TextureList)
            {
                s++;
            }
            foreach (FontAsset f in FontList)
            {
                s++;
            }
            return s - 1;
        }
    }
}
