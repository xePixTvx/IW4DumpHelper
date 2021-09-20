using SFML.System;
using SFML.Graphics;
using SFML.Window;
using IW4DumpHelperGUI.Core.Graphics;

namespace IW4DumpHelperGUI.Core.Graphics
{
    public class ElemUtils
    {
        public static Vector2f GetPositionOnScreen(Alignment Align)
        {
            uint win_width = App.WindowSize.Width;
            uint win_height = App.WindowSize.Height;
            string[] _Align = Align.ToString().Split('_');
            float x = (_Align[0] == "CENTER") ? (win_width / 2) : (_Align[0] == "RIGHT") ? win_width : 0;
            float y = (_Align[1] == "CENTER") ? (win_height / 2) : (_Align[1] == "BOTTOM") ? win_height : 0;
            return new Vector2f(x, y);
        }


        public static Vector2f GetAlignOrigin(Alignment Align, RectangleShape Shape)
        {
            string[] _Align = Align.ToString().Split('_');
            float x = (_Align[0] == "CENTER") ? (Shape.Size.X * (float)0.5) : (_Align[0] == "RIGHT") ? Shape.Size.X : 0;
            float y = (_Align[1] == "CENTER") ? (Shape.Size.Y * (float)0.5) : (_Align[1] == "BOTTOM") ? Shape.Size.Y : 0;
            return new Vector2f(x, y);
        }

        public static Vector2f GetAlignOrigin(Alignment Align, CircleShape Shape)
        {
            string[] _Align = Align.ToString().Split('_');
            float x = (_Align[0] == "CENTER") ? Shape.Radius : (_Align[0] == "RIGHT") ? (Shape.Radius * 2) : 0;
            float y = (_Align[1] == "CENTER") ? Shape.Radius : (_Align[1] == "BOTTOM") ? (Shape.Radius * 2) : 0;
            return new Vector2f(x, y);
        }

        public static Vector2f GetAlignOrigin(Alignment Align, Text Shape)
        {
            string[] _Align = Align.ToString().Split('_');
            float x = (_Align[0] == "CENTER") ? (Shape.GetGlobalBounds().Width * (float)0.5) : (_Align[0] == "RIGHT") ? Shape.GetGlobalBounds().Width : 0;
            float y = (_Align[1] == "CENTER") ? (Shape.GetGlobalBounds().Height * (float)0.5) : (_Align[1] == "BOTTOM") ? Shape.GetGlobalBounds().Height : 0;
            return new Vector2f(x, y);
        }

        public static Vector2f GetAlignOrigin(Alignment Align, Sprite Shape)
        {
            string[] _Align = Align.ToString().Split('_');
            float x = (_Align[0] == "CENTER") ? (Shape.Texture.Size.X * (float)0.5) : (_Align[0] == "RIGHT") ? Shape.Texture.Size.X : 0;
            float y = (_Align[1] == "CENTER") ? (Shape.Texture.Size.Y * (float)0.5) : (_Align[1] == "BOTTOM") ? Shape.Texture.Size.Y : 0;
            return new Vector2f(x, y);
        }

        public static bool IsHovered(Sprite sprite)
        {
            RenderWindow window = App.Window;
            if (sprite.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y) && window.HasFocus())
            {
                return true;
            }
            return false;
        }
        public static bool IsHovered(RectangleShape rect)
        {
            RenderWindow window = App.Window;
            if (rect.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y) && window.HasFocus())
            {
                return true;
            }
            return false;
        }
    }
}
