using System;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;
using IW4DumpHelperGUI.Core.Graphics.Bases;

namespace IW4DumpHelperGUI.Menus
{
    class MenuButtonRect : ClickableElemBase
    {
        private RectangleShape Shape;
        private Vector2f _Size;
        private Vector2f _Position;
        private Alignment _Origin_Alignment;
        private Color _Color;

        private bool _IsLocked;

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

        public bool IsLocked
        {
            get { return _IsLocked; }
            set
            {
                _IsLocked = value;
            }
        }


        public MenuButtonRect(string _Name, Alignment Origin_Align, float Pos_X, float Pos_Y, float Width, float Height, Color RGBA, Action action = null)
        {
            Name = _Name;
            Shape = new RectangleShape();
            Size = new Vector2f(Width, Height);
            Origin_Alignment = Origin_Align;
            Position = new Vector2f(Pos_X, Pos_Y);
            Color = RGBA;
            Action = action;

            IsLocked = false;

            IW4DumpHelper.Renderer.AddToList(this);
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

        public override void UpdateSelection()
        {
            if (!IsLocked)
            {
                IsSelected = (ElemUtils.IsHovered(Shape) == true) ? true : false;

                if (IsSelected)
                {
                    Shape.FillColor = new Color(Color.R, Color.G, Color.B, 180);
                }
                else
                {
                    Shape.FillColor = new Color(Color.R, Color.G, Color.B, 130);
                }
            }
            else
            {
                IsSelected = false;
            }
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
