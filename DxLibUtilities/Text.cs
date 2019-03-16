using System;
using DxLibDLL;
using DxLibUtilities;
using Utilities;

namespace DxLibUtilities
{
    public class Text
    {
        private int handle;

        public Text(int size)
        {
            handle = DX.CreateFontToHandle(null, size, -1);
        }

        public void Draw(string text)
        {
            Draw(text, Vector2D.GetZero, Palette.White);
        }
        
        public void Draw(string text, Vector2D pos, Color color)
        {
            DX.DrawStringToHandle(pos.X, pos.Y, text, color.ToDxColor(), handle);
        }
    }
}
