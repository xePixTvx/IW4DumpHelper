using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.System;

using IW4DumpHelperGUI.Core;
using IW4DumpHelperGUI.Core.Graphics;

//LAST WORKED ON: MoveTo on RectElem

namespace IW4DumpHelperGUI
{
    class IW4DumpHelper : App
    {
        private Menus.Menu MainMenu;


        public IW4DumpHelper(string ResourceFolderName, string WindowTitle, uint WindowWidth, uint WindowHeight) : base(ResourceFolderName, WindowTitle, WindowWidth, WindowHeight)
        {
            //Load Assets
            #region Asset Loading
            //Load Textures
            ResourceManager.Load(Core.Assets.AssetTypes.TEXTURE, "default.png", "default");
            ResourceManager.Load(Core.Assets.AssetTypes.TEXTURE, "BG\\MAIN_BG.jpg", "mainBg");
            ResourceManager.Load(Core.Assets.AssetTypes.TEXTURE, "BG\\BG_FOG.jpg", "bgFog");

            //Load Fonts
            ResourceManager.Load(Core.Assets.AssetTypes.FONT, "default.ttf", "default");
            ResourceManager.Load(Core.Assets.AssetTypes.FONT, "Capture.ttf", "capture");

            Log.Print("Assets Loaded = " + ResourceManager.GetLoadedAssetSize());
            #endregion Asset Loading


            //Get Positions in window
            Vector2f POS_CENTER_CENTER = ElemUtils.GetPositionOnScreen(Alignment.CENTER_CENTER);
            Vector2f POS_LEFT_CENTER = ElemUtils.GetPositionOnScreen(Alignment.LEFT_CENTER);
            Vector2f POS_LEFT_TOP = ElemUtils.GetPositionOnScreen(Alignment.LEFT_TOP);
            Vector2f POS_RIGHT_TOP = ElemUtils.GetPositionOnScreen(Alignment.RIGHT_TOP);


            //Main BG
            new SpriteElem("Main_BG", Alignment.CENTER_CENTER, POS_CENTER_CENTER.X, POS_CENTER_CENTER.Y, "mainBg");
            Renderer.GetElemByName("Main_BG").RenderLayer = 0;

            //Main BG Fog
            new Elems.BGFog("Main_BGFog");
            Renderer.GetElemByName("Main_BGFog").RenderLayer = 1;

            //Menu
            MainMenu = new Menus.Menu();


            new RectElem("testRect", Alignment.CENTER_CENTER, POS_CENTER_CENTER.X, POS_CENTER_CENTER.Y, 50, 50, new SFML.Graphics.Color(0, 0, 0, 255));
            Renderer.GetElemByName("testRect").RenderLayer = 999;


            //Info Window Testing
            /*new Elems.InfoWindow("TestInfoWindow", POS_RIGHT_TOP.X - 50, POS_RIGHT_TOP.Y + 30, "Test Info Window YAY");
            Elems.InfoWindow TestInfoWindow = Renderer.GetElemByName("TestInfoWindow") as Elems.InfoWindow;
            TestInfoWindow.RenderLayer = 2;
            //TestInfoWindow.IsActive = false;
            for (int i = 0; i < 20; i++)
            {
                TestInfoWindow.AddLine("Test Line " + i);
            }
            */
        }


        //On Update App
        protected override void OnAppUpdate()
        {
        }

        //On Close App
        protected override void OnAppClosing()
        {
        }


        //On App Key Released
        protected override void OnKeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                Exit();
            }

            //TESTING
            if (e.Code == Keyboard.Key.T)
            {
                RectElem relem = Renderer.GetElemByName("testRect") as RectElem;
                Vector2f POS_CENTER_CENTER = ElemUtils.GetPositionOnScreen(Alignment.CENTER_CENTER);
                relem.MoveTo(new Vector2f(POS_CENTER_CENTER.X + 200, POS_CENTER_CENTER.Y + 200), 0.1);
            }
        }

        //On App Mousewheel Scrolled
        protected override void OnMouseWheelScrolled(object sender, MouseWheelScrollEventArgs e)
        {
        }
    }
}
