using System;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics.Bases;

namespace IW4DumpHelperGUI.Core.Graphics
{
    public class SpriteButton : ClickableElemBase
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


        public SpriteButton(string _Name, Alignment Origin_Align, float Pos_X, float Pos_Y, string Texture_Name, Action action = null)
        {
            Name = _Name;
            Shape = new Sprite();
            TextureName = Texture_Name;
            Origin_Alignment = Origin_Align;
            Position = new Vector2f(Pos_X, Pos_Y);
            Action = action;

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

        public override void UpdateSelection()
        {
            IsSelected = (ElemUtils.IsHovered(Shape) == true) ? true : false;

            if (IsSelected)
            {
                Shape.Color = new Color(255, 255, 255, 255);
            }
            else
            {
                Shape.Color = new Color(255, 255, 255, 130);
            }
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
