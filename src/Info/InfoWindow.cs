using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;

namespace IW4DumpHelperGUI.Info
{
    class InfoWindow
    {

        private RectElem BG_Rect;


        private TextElem TestText;

        public InfoWindow()
        {
            Vector2f POS_LEFT_BOTTOM = ElemUtils.GetPositionOnScreen(Alignment.LEFT_BOTTOM);
            Vector2f Base_Position_Text = new Vector2f(POS_LEFT_BOTTOM.X + 5, POS_LEFT_BOTTOM.Y - 10);


            //BG(used for helping or something like that)
            BG_Rect = new RectElem("InfoWindow_BG_Rect", Alignment.LEFT_BOTTOM, POS_LEFT_BOTTOM.X, POS_LEFT_BOTTOM.Y, 300, 200, new Color(0, 0, 0, 130));
            IW4DumpHelper.Renderer.GetElemByName("InfoWindow_BG_Rect").RenderLayer = 2;





            TestText = new TextElem("InfoWindow_TestText", Alignment.LEFT_BOTTOM, Base_Position_Text.X, Base_Position_Text.Y, new Color(255, 255, 255, 255), "default", 12, Text.Styles.Regular, "Test String YAY");
            IW4DumpHelper.Renderer.GetElemByName("InfoWindow_TestText").RenderLayer = 3;


            //Console.WriteLine("Elems: " + IW4DumpHelper.Renderer.GetRenderList().Count);

        }
    }
}
