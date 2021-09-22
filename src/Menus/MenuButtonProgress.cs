using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;
using IW4DumpHelperGUI.Core.Graphics.Bases;

namespace IW4DumpHelperGUI.Menus
{
    class MenuButtonProgress : RenderableElemBase
    {
        public RectangleShape Shape;
        public Text ShapeText;
        private Vector2f _Position;
        private Alignment _Origin_Alignment;
        private Color _Color;

        private float _Value = 0;
        private float _MaxWidth;
        private float _Height;

        public Vector2f Position
        {
            get { return _Position; }
            set
            {
                _Position = value;
                NeedsUpdate = true;
            }
        }

        public Alignment Origin_Alignment
        {
            get { return _Origin_Alignment; }
            private set
            {
                _Origin_Alignment = value;
                NeedsUpdate = true;
            }
        }

        public Color Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
                NeedsUpdate = true;
            }
        }

        public float Value
        {
            get { return _Value; }
            set
            {
                _Value = (value > 100) ? 100 : (value < 0) ? 0 : value;
                NeedsUpdate = true;
            }
        }

        public float MaxWidth
        {
            get { return _MaxWidth; }
            private set
            {
                _MaxWidth = value;
                NeedsUpdate = true;
            }
        }

        public float Height
        {
            get { return _Height; }
            private set
            {
                _Height = value;
                NeedsUpdate = true;
            }
        }


        public MenuButtonProgress(string _Name, float Pos_X, float Pos_Y, float widthMax, float height, Color RGBA)
        {
            Name = _Name;
            Shape = new RectangleShape();
            Origin_Alignment = Alignment.LEFT_CENTER;
            Position = new Vector2f(Pos_X, Pos_Y);
            Color = RGBA;
            MaxWidth = widthMax;
            Height = height;

            ShapeText = new Text()
            {
                CharacterSize = 18,
                Style = Text.Styles.Bold,
                FillColor = new Color(255, 0, 0, 255)//RGB = 130??
            };
            ShapeText.Font = IW4DumpHelper.ResourceManager.GetFont("capture");

            IW4DumpHelper.Renderer.AddToList(this);
        }

        public override void Update()
        {
            //Size
            float fillSize = (MaxWidth / 100) * Value;
            Shape.Size = new Vector2f(fillSize, Height);

            //String
            ShapeText.DisplayedString = Value + "%";

            //Origin Align
            Vector2f Origin_Pos = ElemUtils.GetAlignOrigin(Origin_Alignment, Shape);
            Shape.Origin = Origin_Pos;

            Vector2f Origin_Pos_Text = ElemUtils.GetAlignOrigin(Origin_Alignment, ShapeText);
            ShapeText.Origin = Origin_Pos_Text;

            //Position
            Shape.Position = new Vector2f(Position.X, Position.Y);
            ShapeText.Position = new Vector2f((Position.X + MaxWidth) + 5, Position.Y - 3);

            //Color
            Shape.FillColor = Color;

            NeedsUpdate = false;
        }

        public override void Render()
        {
            IW4DumpHelper.Window.Draw(Shape);
            IW4DumpHelper.Window.Draw(ShapeText);
        }

        public override void Destroy()
        {
            IW4DumpHelper.Renderer.RemoveFromList(this);
            Shape.Dispose();
            ShapeText.Dispose();
        }
    }
}
