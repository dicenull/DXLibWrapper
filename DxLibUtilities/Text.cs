using System;
using DxLibDLL;
using DxLibUtilities;
using Utilities;

namespace DxLibUtilities
{
    public class Text
    {
        private readonly int handle;

        /// <param name="size">文字の大きさ</param>
        public Text(int size)
            : this(null, size) { }

        /// <param name="fontName">フォント名</param>
        /// <param name="size">文字の大きさ</param>
        public Text(string fontName, int size)
        {
            handle = DX.CreateFontToHandle(fontName, size, -1);
        }

        /// <summary>
        /// 文字を描画する
        /// </summary>
        /// <param name="text">文字列</param>
        public void Draw(string text)
        {
            Draw(text, Vector2D.GetZero, Palette.White);
        }
        
        /// <summary>
        /// 文字を描画する
        /// </summary>
        /// <param name="text">文字列</param>
        /// <param name="pos">描画を始める座標</param>
        /// <param name="color">文字色</param>
        public void Draw(string text, Vector2D pos, Color color)
        {
            DX.DrawStringToHandle(pos.X, pos.Y, text, color.ToDxColor(), handle);
		}
    }
}
