using SFML.Window;
using SFML.System;

using IW4DumpHelperGUI.Core;
using IW4DumpHelperGUI.Core.Graphics;

//LAST WORKED ON: Info

namespace IW4DumpHelperGUI
{
    class IW4DumpHelper : App
    {
        private Menus.Menu MainMenu;

        //Testing
        private Info.InfoWindow Info;


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


            //Main BG
            new SpriteElem("Main_BG", Alignment.CENTER_CENTER, POS_CENTER_CENTER.X, POS_CENTER_CENTER.Y, "mainBg");
            Renderer.GetElemByName("Main_BG").RenderLayer = 0;

            //Main BG Fog
            new Elems.BGFog("Main_BGFog");
            Renderer.GetElemByName("Main_BGFog").RenderLayer = 1;

            //Menu
            MainMenu = new Menus.Menu();


            //Testing
            Info = new Info.InfoWindow();
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
            }
        }

        //On App Mousewheel Scrolled
        protected override void OnMouseWheelScrolled(object sender, MouseWheelScrollEventArgs e)
        {
        }
    }
}
