using System;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;
using IW4DumpHelperGUI.Core.Graphics.Bases;

namespace IW4DumpHelperGUI.Elems
{
    class ProgressBar : RenderableElemBase
    {
        private RectangleShape Shape;
        private RectangleShape FillShape;
        private Vector2f _Size;
        private Vector2f _Position;
        private Alignment _Origin_Alignment;
        private float _Value;


        public Vector2f Size
        {
            get { return _Size; }
            set
            {
                _Size = value;
                NeedsUpdate = true;
            }
        }

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

        public float Value
        {
            get { return _Value; }
            set
            {
                _Value = (value > 100) ? 100 : (value < 0) ? 0 : value;
                NeedsUpdate = true;
            }
        }


        public ProgressBar(string _Name, float Pos_X, float Pos_Y, float Width, float Height)
        {
            Name = _Name;
            Shape = new RectangleShape();
            Shape.FillColor = new Color(0, 0, 0, 180);

            FillShape = new RectangleShape();
            FillShape.FillColor = new Color(255, 0, 0, 255);


            Size = new Vector2f(Width, Height);
            Origin_Alignment = Alignment.LEFT_TOP;
            Position = new Vector2f(Pos_X, Pos_Y);
            Value = 0;

            IW4DumpHelper.Renderer.AddToList(this);
        }

        public override void Update()
        {
            //Size
            Shape.Size = Size;

            float fillSize = (Size.X / 100) * Value;
            FillShape.Size = new Vector2f(fillSize, Size.Y);

            //Origin Align
            Vector2f Origin_Pos = ElemUtils.GetAlignOrigin(Origin_Alignment, Shape);
            Shape.Origin = Origin_Pos;
            FillShape.Origin = Origin_Pos;

            //Position + Position Align
            Shape.Position = new Vector2f(Position.X, Position.Y);
            FillShape.Position = new Vector2f(Position.X, Position.Y);

            NeedsUpdate = false;
        }

        public override void Render()
        {
            IW4DumpHelper.Window.Draw(Shape);
            IW4DumpHelper.Window.Draw(FillShape);
        }

        public override void Destroy()
        {
            IW4DumpHelper.Renderer.RemoveFromList(this);
            Shape.Dispose();
            FillShape.Dispose();
        }
    }
}
