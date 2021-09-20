using SFML.System;
using SFML.Graphics;

namespace IW4DumpHelperGUI.Core.Graphics.Interfaces
{
    public interface IRenderableElem
    {
        string Name { get; set; }
        int RenderLayer { get; set; }
        bool IsActive { get; set; }
        bool IsVisible { get; set; }
        bool NeedsUpdate { get; set; }
        void Update();
        void Render();
        void Destroy();
    }
}
