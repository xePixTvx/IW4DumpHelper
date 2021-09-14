using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics.Bases;

namespace IW4DumpHelperGUI.Core.Graphics
{
    public class SpriteElem : RenderableElemBase
    {
        private Sprite Shape;
        private string _TextureName;
        private Vector2f _Position;
        private Alignment _Origin_Alignment;


        public string TextureName
        {
            get { return _TextureName; }
            set
            {
                _TextureName = value;
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


        public SpriteElem(string _Name, Alignment Origin_Align, float Pos_X, float Pos_Y, string Texture_Name)
        {
            Name = _Name;
            Shape = new Sprite();
            TextureName = Texture_Name;
            Origin_Alignment = Origin_Align;
            Position = new Vector2f(Pos_X, Pos_Y);

            App.Renderer.AddToList(this);
        }


        public override void Update()
        {
            //Texture
            Shape.Texture = App.ResourceManager.GetTexture(TextureName);

            //Origin Align
            Vector2f Origin_Pos = ElemUtils.GetAlignOrigin(Origin_Alignment, Shape);
            Shape.Origin = Origin_Pos;

            //Position + Position Align
            Shape.Position = new Vector2f(Position.X, Position.Y);

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
