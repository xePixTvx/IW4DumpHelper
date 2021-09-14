using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;
using IW4DumpHelperGUI.Core.Graphics.Bases;

//Vector2f POS_LEFT_BOTTOM = new Vector2f(ElemUtils.GetPositionOnScreen(Alignment.LEFT_BOTTOM).X + 5, ElemUtils.GetPositionOnScreen(Alignment.LEFT_BOTTOM).Y - 10);


//Bottom Align = ElemUtils.GetAlignOrigin(Alignment.LEFT_BOTTOM, InfoShape);      
//       POS = new Vector2f(POS_LEFT_BOTTOM.X, POS_LEFT_BOTTOM.Y);


namespace IW4DumpHelperGUI.Elems
{
    class InfoMsg
    {
        public InfoMsg()
        {

            //Some Test Text Stuff
            new InfoMsgTextElem("InfoMsg_Test_0", 0, "MSG 1");
            new InfoMsgTextElem("InfoMsg_Test_1", 1, "MSG 2");
            new InfoMsgTextElem("InfoMsg_Test_2", 2, "MSG 3");
            new InfoMsgTextElem("InfoMsg_Test_3", 3, "MSG 4");
            new InfoMsgTextElem("InfoMsg_Test_4", 4, "MSG 5");
            new InfoMsgTextElem("InfoMsg_Test_5", 5, "MSG 6");
        }


        public void Println(string msg)
        {
        }

    }
}
