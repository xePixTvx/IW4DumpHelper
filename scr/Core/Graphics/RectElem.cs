using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics.Bases;

namespace IW4DumpHelperGUI.Core.Graphics
{
    public class RectElem : RenderableElemBase
    {
        public RectangleShape Shape { private set; get; }
        private Vector2f _Size;
        private Vector2f _Position;
        private Alignment _Origin_Alignment;
        private Color _Color;


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
            set
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


        public RectElem(string _Name, Alignment Origin_Align, float Pos_X, float Pos_Y, float Width, float Height, Color RGBA)
        {
            Name = _Name;
            Shape = new RectangleShape();
            Size = new Vector2f(Width, Height);
            Origin_Alignment = Origin_Align;
            Position = new Vector2f(Pos_X, Pos_Y);
            Color = RGBA;

            App.Renderer.AddToList(this);
        }

        public override void Update()
        {
            //Size
            Shape.Size = Size;

            //Origin Align
            Vector2f Origin_Pos = ElemUtils.GetAlignOrigin(Origin_Alignment, Shape);
            Shape.Origin = Origin_Pos;

            //Position + Position Align
            Shape.Position = new Vector2f(Position.X, Position.Y);

            //Color
            Shape.FillColor = Color;

            NeedsUpdate = false;
        }

        public override void Render()
        {
            App.Window.Draw(Shape);
        }

        public override void Destroy()
        {
            App.Renderer.RemoveFromList(this);
            Shape.Dispose();
        }

    }
}
