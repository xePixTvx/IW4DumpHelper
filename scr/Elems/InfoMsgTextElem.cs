using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;
using IW4DumpHelperGUI.Core.Graphics.Bases;

namespace IW4DumpHelperGUI.Elems
{
    class InfoMsgTextElem : RenderableElemBase
    {
        private Text Shape;
        private int _Index;
        private Vector2f _BasePosition;

        public int Index
        {
            get { return _Index; }
            set 
            { 
                _Index = value;
                NeedsUpdate = true;
            }
        }

        public Vector2f BasePosition
        {
            get { return _BasePosition; }
            private set
            {
                _BasePosition = value;
                NeedsUpdate = true;
            }
        }

        public InfoMsgTextElem(string _Name, int index, string msg = "UNKNOWN MSG!")
        {
            Name = _Name;
            _Index = index;
            BasePosition = new Vector2f(ElemUtils.GetPositionOnScreen(Alignment.LEFT_BOTTOM).X + 5, ElemUtils.GetPositionOnScreen(Alignment.LEFT_BOTTOM).Y - 10);

            Shape = new Text()
            {
                CharacterSize = 14,
                Style = Text.Styles.Bold,
                FillColor = new Color(255, 0, 0, 255),
                DisplayedString = msg
            };
            Shape.Font = IW4DumpHelper.ResourceManager.GetFont("default");

            this.RenderLayer = 999;
            IW4DumpHelper.Renderer.AddToList(this);
        }

        public override void Update()
        {
            Shape.Origin = ElemUtils.GetAlignOrigin(Alignment.LEFT_BOTTOM, Shape);
            Shape.Position = new Vector2f(BasePosition.X, BasePosition.Y - (Index * 20));

            NeedsUpdate = false;
        }

        public override void Render()
        {
            IW4DumpHelper.Window.Draw(Shape);
        }

        public override void Destroy()
        {
            IW4DumpHelper.Renderer.RemoveFromList(this);
            Shape.Dispose();
        }
    }
}
