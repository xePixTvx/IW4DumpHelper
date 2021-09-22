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
        public MenuButtonProgress ButtonProgress { private set; get; }

        public int Renderlayer { private set; get; }

        public string MenuName { private set; get; }
        public string ButtonName { private set; get; }

        public bool IsHidden { private set; get; } = true;
        public bool IsLocked { private set; get; } = false;
        public bool IsProgressbarHidden { private set; get; } = true;

        public MenuButton(string name, string menuName, int index, string text, Action action = null)
        {
            MenuName = menuName;
            ButtonName = name;
            int renderLayer = 2;

            //Position Stuff
            Vector2f POS_LEFT_CENTER = ElemUtils.GetPositionOnScreen(Alignment.LEFT_CENTER);
            Vector2f POS_LEFT_TOP = ElemUtils.GetPositionOnScreen(Alignment.LEFT_TOP);
            Alignment Origin_Align = Alignment.LEFT_CENTER;
            float Width = 420;
            float Height = 30;

            //Create Button Rect + Text + Progress
            ButtonRect = new MenuButtonRect(ButtonName + "_rect", Origin_Align, POS_LEFT_CENTER.X, (POS_LEFT_TOP.Y + 100) + (40 * index), Width, Height, new Color(0, 0, 0, 130), action);
            ButtonText = new TextElem(ButtonName + "_text", Alignment.RIGHT_CENTER, POS_LEFT_CENTER.X, (POS_LEFT_TOP.Y + 100) + (40 * index), new Color(255, 255, 255, 255), "capture", 18, Text.Styles.Regular, text);
            ButtonProgress = new MenuButtonProgress(ButtonName + "_progress", POS_LEFT_CENTER.X, (POS_LEFT_TOP.Y + 100) + (40 * index), Width, Height, new Color(0, 0, 0, 80));

            //Align Button Text
            ButtonText.Position = new Vector2f((POS_LEFT_CENTER.X + ButtonRect.Size.X) - 10, (POS_LEFT_TOP.Y + 100) + (40 * index) - 3);

            //Set Renderlayer
            ButtonRect.RenderLayer = renderLayer;
            ButtonProgress.RenderLayer = renderLayer + 1;
            ButtonText.RenderLayer = renderLayer + 2;

            //Set Active State(default is false)
            ButtonRect.IsActive = false;
            ButtonText.IsActive = false;
            ButtonProgress.IsActive = false;
        }


        public void Hide()
        {
            ButtonRect.IsActive = false;
            ButtonText.IsActive = false;
            ButtonProgress.IsActive = false;
            IsHidden = true;
        }

        public void Show()
        {
            ButtonRect.IsActive = true;
            ButtonText.IsActive = true;
            if(!IsProgressbarHidden)
            {
                ButtonProgress.IsActive = true;
            }
            IsHidden = false;
        }

        public void Lock()
        {
            ButtonRect.IsLocked = true;
            ButtonText.Color = new Color(255, 255, 255, 150);
            IsLocked = true;
        }

        public void Unlock()
        {
            ButtonRect.IsLocked = false;
            ButtonText.Color = new Color(255, 255, 255, 255);
            IsLocked = false;
        }

        public void ProgressbarHide()
        {
            ButtonProgress.IsActive = false;
            IsProgressbarHidden = true;
        }

        public void ProgressbarShow()
        {
            if(!IsHidden)
            {
                ButtonProgress.IsActive = true;
            }
            IsProgressbarHidden = false;
        }

        public void ChangeProgress(float value)
        {
            ButtonProgress.Value = value;
        }

        public void Destroy()
        {
            ButtonRect.Destroy();
            ButtonText.Destroy();
            ButtonProgress.Destroy();
        }
    }
}
