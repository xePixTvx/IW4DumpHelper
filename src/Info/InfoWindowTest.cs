using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;

namespace IW4DumpHelperGUI.Info
{
    class InfoWindowTest
    {

        private RectElem BGRect;
        private TextElem MainTitle;
        private RectElem MainTitleSeparatorLine;


        public InfoWindowTest()
        {
            Vector2f POS_RIGHT_TOP = ElemUtils.GetPositionOnScreen(Alignment.RIGHT_TOP);


            BGRect = new RectElem("TestInfo_BG", Alignment.RIGHT_TOP, POS_RIGHT_TOP.X - 50, POS_RIGHT_TOP.Y + 30, 600, 400, new Color(0, 0, 0, 180));
            BGRect.RenderLayer = 2;

            MainTitle = new TextElem("TestInfo_MainTitle", Alignment.CENTER_TOP, BGRect.Position.X - (BGRect.Size.X / 2), BGRect.Position.Y, new Color(255, 255, 255, 255), "capture", 20, Text.Styles.Bold, "INFO");
            MainTitle.RenderLayer = 3;

            MainTitleSeparatorLine = new RectElem("TestInfo_MainTitleSeparatorLine", Alignment.RIGHT_TOP, BGRect.Position.X, MainTitle.Position.Y + (MainTitle.Shape.CharacterSize - 5), 600, 2, new Color(255, 255, 255, 255));
            MainTitleSeparatorLine.RenderLayer = 3;
        }
    }
}
