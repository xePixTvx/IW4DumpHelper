using System;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;

namespace IW4DumpHelperGUI.Menus
{
    class MenuButton
    {
        public MenuButtonRect ButtonRect { private set; get; }
        public TextElem ButtonText { private set; get; }

        public int Renderlayer { private set; get; }

        public string MenuName { private set; get; }

        public MenuButton(string name, string menuName, int index, string text, Action action = null)
        {
            MenuName = menuName;
            int renderLayer = 2;

            //Position Stuff
            Vector2f POS_LEFT_CENTER = ElemUtils.GetPositionOnScreen(Alignment.LEFT_CENTER);
            Vector2f POS_LEFT_TOP = ElemUtils.GetPositionOnScreen(Alignment.LEFT_TOP);
            Alignment Origin_Align = Alignment.LEFT_CENTER;
            float Width = 420;
            float Height = 30;

            //Create Button Rect + Text
            ButtonRect = new MenuButtonRect(name + "_rect", Origin_Align, POS_LEFT_CENTER.X, (POS_LEFT_TOP.Y + 100) + (40 * index), Width, Height, new Color(0, 0, 0, 130), action);
            ButtonText = new TextElem(name + "_text", Alignment.RIGHT_CENTER, POS_LEFT_CENTER.X, (POS_LEFT_TOP.Y + 100) + (40 * index), new Color(255, 255, 255, 255), "capture", 18, Text.Styles.Regular, text);

            //Align Button Text
            ButtonText.Position = new Vector2f((POS_LEFT_CENTER.X + ButtonRect.Size.X) - 10, (POS_LEFT_TOP.Y + 100) + (40 * index) - 3);

            //Set Renderlayer
            ButtonRect.RenderLayer = renderLayer;
            ButtonText.RenderLayer = renderLayer + 1;

            //Set Active State(default is false)
            ButtonRect.IsActive = false;
            ButtonText.IsActive = false;
        }


        public void Hide()
        {
            ButtonRect.IsActive = false;
            ButtonText.IsActive = false;
        }

        public void Show()
        {
            ButtonRect.IsActive = true;
            ButtonText.IsActive = true;
        }

        public void Destroy()
        {
            ButtonRect.Destroy();
            ButtonText.Destroy();
        }
    }
}
