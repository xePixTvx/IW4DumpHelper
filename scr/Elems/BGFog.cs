using System;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;
using IW4DumpHelperGUI.Core.Graphics.Bases;

namespace IW4DumpHelperGUI.Elems
{
    class BGFog : RenderableElemBase
    {
        private Sprite Shape;
        private Sprite Shape2;
        private Vector2f _Position;
        private bool _IsFogMoving;
        private Clock FogClock;

        public Vector2f Position
        {
            get { return _Position; }
            set
            {
                _Position = value;
                NeedsUpdate = true;
            }
        }

        public bool IsFogMoving
        {
            get { return _IsFogMoving; }
            set
            {
                _IsFogMoving = value;
                NeedsUpdate = true;
            }
        }


        public BGFog(string _Name)
        {
            Name = _Name;
            Shape = new Sprite();
            Shape2 = new Sprite();

            Shape.Texture = IW4DumpHelper.ResourceManager.GetTexture("bgFog");
            Shape2.Texture = IW4DumpHelper.ResourceManager.GetTexture("bgFog");
            Shape.Color = new Color(255, 255, 255, 80);
            Shape2.Color = new Color(255, 255, 255, 80);

            Vector2f Origin_Pos = ElemUtils.GetAlignOrigin(Alignment.LEFT_TOP, Shape);
            Shape.Origin = Origin_Pos;
            Shape2.Origin = Origin_Pos;

            FogClock = new Clock();
            Position = new Vector2f(0, 0);

            IsFogMoving = true;

            IW4DumpHelper.Renderer.AddToList(this);
        }


        public override void Update()
        {
            //Position + Position Align
            if (IsFogMoving)
            {
                double fog_cos = Math.Cos(FogClock.ElapsedTime.AsSeconds());
                Shape.Position = new Vector2f(-100 - ((float)fog_cos * -20), 0);
                Shape2.Position = new Vector2f(-100 + ((float)fog_cos * -20), 0);
                NeedsUpdate = true;
            }
            else
            {
                Shape.Position = new Vector2f(Position.X, Position.Y);
                Shape2.Position = new Vector2f(Position.X, Position.Y);
                NeedsUpdate = false;
            }
        }

        public override void Render()
        {
            IW4DumpHelper.Window.Draw(Shape);
            IW4DumpHelper.Window.Draw(Shape2);
        }

        public override void Destroy()
        {
            IW4DumpHelper.Renderer.RemoveFromList(this);
            Shape.Dispose();
            Shape2.Dispose();
        }
    }
}
