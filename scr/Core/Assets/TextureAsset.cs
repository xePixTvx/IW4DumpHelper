using System;
using System.IO;
using SFML.Graphics;

namespace IW4DumpHelperGUI.Core.Assets
{
    class TextureAsset
    {
        public string Name;
        public Texture Texture;

        public TextureAsset(string file, string name)
        {
            Name = name;
            try
            {
                Texture = new Texture(Path.Combine(App.ResourceFolder, "textures", file));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
