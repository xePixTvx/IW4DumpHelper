using System;
using System.IO;
using SFML.Graphics;

namespace IW4DumpHelperGUI.Core.Assets
{
    class FontAsset
    {
        public string Name;
        public Font Font;

        public FontAsset(string file, string name)
        {
            Name = name;
            try
            {
                Font = new Font(Path.Combine(App.ResourceFolder, "fonts", file));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
