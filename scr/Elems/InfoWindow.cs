using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;
using IW4DumpHelperGUI.Core.Graphics.Bases;
using IW4DumpHelperGUI.Core.Graphics.Interfaces;


//Currently Not In Use!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

namespace IW4DumpHelperGUI.Elems
{
    class InfoWindow : RenderableElemBase, IScrollableElem
    {
        //Shapes
        private RectangleShape TitleBgShape;
        private Text TitleTextShape;
        private RectangleShape BgShape;
        private Text[] LineTextShapes = new Text[20];
        private RectangleShape SelectbarShape;


        //Vars
        private Vector2f _Position;
        private Vector2f _Size;
        private string _TitleText;

        private int Scroller = 0;
        private List<string> LineStrings = new List<string>();


        #region Get & Set
        public Vector2f Position
        {
            get { return _Position; }
            set
            {
                _Position = value;
                NeedsUpdate = true;
            }
        }

        public Vector2f Size
        {
            get { return _Size; }
            private set
            {
                _Size = value;
                NeedsUpdate = true;
            }
        }

        public string TitleText
        {
            get { return _TitleText; }
            set
            {
                _TitleText = value;
                NeedsUpdate = true;
            }
        }
        #endregion Get & Set




        public InfoWindow(string _Name, float X, float Y, string title)
        {
            Name = _Name;
            Position = new Vector2f(X, Y);
            Size = new Vector2f(700, 408);
            TitleText = title;



            //Create Title BG Shape
            TitleBgShape = new RectangleShape();
            TitleBgShape.FillColor = new Color(0, 0, 0, 180);
            TitleBgShape.Size = new Vector2f(Size.X, 40);
            TitleBgShape.Origin = ElemUtils.GetAlignOrigin(Alignment.RIGHT_TOP, TitleBgShape);
            TitleBgShape.Position = Position;

            //Create Title Text Shape
            TitleTextShape = new Text()
            {
                CharacterSize = 20,
                Style = Text.Styles.Bold,
                FillColor = new Color(255, 255, 255, 255)
            };
            TitleTextShape.Font = IW4DumpHelper.ResourceManager.GetFont("default");

            //Create BG Shape
            BgShape = new RectangleShape();
            BgShape.FillColor = new Color(0, 0, 0, 180);
            BgShape.Size = Size;
            BgShape.Origin = ElemUtils.GetAlignOrigin(Alignment.RIGHT_TOP, BgShape);
            BgShape.Position = new Vector2f(TitleBgShape.Position.X, TitleBgShape.Position.Y + 45);

            //Create Line Text Shapes
            for (int i = 0; i < 20; i++)
            {
                LineTextShapes[i] = new Text()
                {
                    CharacterSize = 14,
                    Style = Text.Styles.Regular,
                    FillColor = new Color(255, 255, 255, 255),
                    Font = IW4DumpHelper.ResourceManager.GetFont("default")
                };
            }

            //Create Selectbar Shape
            SelectbarShape = new RectangleShape();
            SelectbarShape.FillColor = new Color(0, 0, 0, 130);
            SelectbarShape.Size = new Vector2f(Size.X, 20);
            SelectbarShape.Origin = ElemUtils.GetAlignOrigin(Alignment.RIGHT_TOP, SelectbarShape);

            //Clear Line Strings
            LineStrings.Clear();

            IW4DumpHelper.Renderer.AddToList(this);
        }

        public override void Update()
        {
            //Title Text
            TitleTextShape.DisplayedString = TitleText;

            //Position + Alignment Title Text
            Vector2f origin_title = ElemUtils.GetAlignOrigin(Alignment.CENTER_CENTER, TitleTextShape);
            TitleTextShape.Origin = origin_title;
            TitleTextShape.Position = new Vector2f(TitleBgShape.Position.X - (TitleBgShape.Size.X / 2), (TitleBgShape.Position.Y + (TitleBgShape.Size.Y / 2)) - (TitleTextShape.GetGlobalBounds().Height / 2));

            //Position + Alignment Line Texts
            for(int i = 0; i < LineTextShapes.Length; i++)
            {
                LineTextShapes[i].Position = new Vector2f((BgShape.Position.X - BgShape.Size.X) + 4, (BgShape.Position.Y + 7) + (20 * i));
            }

            UpdateStringsAndScrolling();

            NeedsUpdate = false;
        }

        public override void Render()
        {
            IW4DumpHelper.Window.Draw(TitleBgShape);
            IW4DumpHelper.Window.Draw(TitleTextShape);
            IW4DumpHelper.Window.Draw(BgShape);
            IW4DumpHelper.Window.Draw(SelectbarShape);
            foreach(Text TextShape in LineTextShapes)
            {
                IW4DumpHelper.Window.Draw(TextShape);
            }
        }

        public override void Destroy()
        {
            IW4DumpHelper.Renderer.RemoveFromList(this);
            TitleBgShape.Dispose();
            TitleTextShape.Dispose();
            BgShape.Dispose();
            foreach (Text TextShape in LineTextShapes)
            {
                TextShape.Dispose();
            }
            SelectbarShape.Dispose();
        }



        public void AddLine(string text)
        {
            LineStrings.Add(text);
            UpdateStringsAndScrolling();
        }






        //////////////SCROLLING



        public void UpdateMouseWheelMovement(float direction)
        {
            if(ElemUtils.IsHovered(BgShape))
            {
                if(direction < 0)
                {
                    Console.WriteLine("Scroll Down");
                    Scroller++;
                    UpdateStringsAndScrolling();
                }
                else if(direction > 0)
                {
                    Console.WriteLine("Scroll Up");
                    Scroller--;
                    UpdateStringsAndScrolling();
                }
            }
        }


        private void UpdateStringsAndScrolling()
        {
            if(Scroller < 0)
            {
                Scroller = 0;
            }
            if(Scroller > LineStrings.Count - 1)
            {
                Scroller = LineStrings.Count - 1;
            }



            for(int i = 0; i < LineStrings.Count; i++)
            {
                LineTextShapes[i].DisplayedString = LineStrings[i];
            }
            SelectbarShape.Position = new Vector2f(Position.X, LineTextShapes[Scroller].Position.Y);

            //NOPE
            /*if((LineStrings[Scroller - 10] != null) || (LineStrings.Count - 1 <= 20))
            {
                Console.WriteLine("YES");
            }*/


        }




















    }
}
