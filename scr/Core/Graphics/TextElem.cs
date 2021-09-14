using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics.Bases;

namespace IW4DumpHelperGUI.Core.Graphics
{
    public class TextElem : RenderableElemBase
    {
        public Text Shape { private set; get; }
        private string _FontName;
        private uint _CharSize;
        private Text.Styles _TextStyle;
        private string _String;
        private Vector2f _Position;
        private Alignment _Origin_Alignment;
        private Color _Color;



        public string FontName
        {
            get { return _FontName; }
            set
            {
                _FontName = value;
                NeedsUpdate = true;
            }
        }

        public uint CharSize
        {
            get { return _CharSize; }
            set
            {
                _CharSize = value;
                NeedsUpdate = true;
            }
        }

        public Text.Styles TextStyle
        {
            get { return _TextStyle; }
            set
            {
                _TextStyle = value;
                NeedsUpdate = true;
            }
        }

        public string String
        {
            get { return _String; }
            set
            {
                _String = value;
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




        public TextElem(string _Name, Alignment Origin_Align, float Pos_X, float Pos_Y, Color RGBA, string Font_Name, uint Char_Size, Text.Styles Text_Style, string TextToDisplay = "")
        {
            Name = _Name;
            Shape = new Text();
            FontName = Font_Name;
            CharSize = Char_Size;
            TextStyle = Text_Style;
            String = TextToDisplay;
            Origin_Alignment = Origin_Align;
            Position = new Vector2f(Pos_X, Pos_Y);
            Color = RGBA;

            App.Renderer.AddToList(this);
        }

        public override void Update()
        {
            //Font
            Shape.Font = App.ResourceManager.GetFont(FontName);

            //Char Size
            Shape.CharacterSize = CharSize;

            //Text Style
            Shape.Style = TextStyle;

            //Displayed String
            Shape.DisplayedString = String;

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
