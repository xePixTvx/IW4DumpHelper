using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics.Bases;
using IW4DumpHelperGUI.Core.Graphics.Interfaces;

namespace IW4DumpHelperGUI.Core.Graphics
{
    public class RectElem : RenderableElemBase, IMoveableElem
    {
        public RectangleShape Shape { private set; get; }
        private Vector2f _Size;
        private Vector2f _Position;
        private Alignment _Origin_Alignment;
        private Color _Color;

        //MoveTo TESTING
        private bool _IsMoving = false;
        public double SpeedMulitplier { get; private set; } = 0.1;
        public MoveDirections DirectionX { get; private set; } = MoveDirections.MINUS;
        public MoveDirections DirectionY { get; private set; } = MoveDirections.MINUS;

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

        public bool IsMoving
        {
            get { return _IsMoving; }
            private set
            {
                _IsMoving = value;
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
            if(!IsMoving)
            {
                //Size
                Shape.Size = Size;

                //Origin Align
                Vector2f Origin_Pos = ElemUtils.GetAlignOrigin(Origin_Alignment, Shape);
                Shape.Origin = Origin_Pos;

                //Position + Position Align
                Shape.Position = new Vector2f(Position.X, Position.Y);
            }

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



        //MoveTo TESTING
        public void MoveTo(Vector2f pos, double speed = 1)
        {
            if(!IsMoving)
            {
                IsMoving = true;
                SpeedMulitplier = speed;
                Position = pos;

                DirectionX = (Shape.Position.X < Position.X) ? MoveDirections.PLUS : MoveDirections.MINUS;
                DirectionY = (Shape.Position.Y < Position.Y) ? MoveDirections.PLUS : MoveDirections.MINUS;
            }
        }

        public void UpdateMoveToPosition(float frameTime)
        {
            bool tmp_x_done = false;
            bool tmp_y_done = false;

            float tmp_current_pos_x = Shape.Position.X;
            float tmp_current_pos_y = Shape.Position.Y;

            //X
            if(DirectionX == MoveDirections.MINUS)
            {
                if(tmp_current_pos_x > Position.X)
                {
                    tmp_current_pos_x -= frameTime * (float)SpeedMulitplier;
                }
                else
                {
                    tmp_x_done = true;
                }
            }
            else
            {
                if(tmp_current_pos_x < Position.X)
                {
                    tmp_current_pos_x += frameTime * (float)SpeedMulitplier;
                }
                else
                {
                    tmp_x_done = true;
                }
            }

            //Y
            if(DirectionY == MoveDirections.MINUS)
            {
                if(tmp_current_pos_y > Position.Y)
                {
                    tmp_current_pos_y -= frameTime * (float)SpeedMulitplier;
                }
                else
                {
                    tmp_y_done = true;
                }
            }
            else
            {
                if(tmp_current_pos_y < Position.Y)
                {
                    tmp_current_pos_y += frameTime * (float)SpeedMulitplier;
                }
                else
                {
                    tmp_y_done = true;
                }
            }

            //Update Shape Position
            Shape.Position = new Vector2f(tmp_current_pos_x, tmp_current_pos_y);

            //Check if done
            if(tmp_x_done && tmp_y_done)
            {
                IsMoving = false;
                //Console.WriteLine("MoveTo Done");///////REMOVE ME!!!!
            }

        }

    }
}
