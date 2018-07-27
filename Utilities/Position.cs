using System.Numerics;

namespace Utilities
{
    public enum Position
    {
        Top,
        TopRight,
        Right,
        BottomRight,
        Bottom,
        BottomLeft,
        Left,
        TopLeft,
        Center
    }

    public static class Vector2Extensions
    {
        /// <summary>
        /// 長方形上の起点の位置から左上の位置を求める
        /// </summary>
        /// <param name="point">起点の位置</param>
        /// <param name="size">長方形の大きさ</param>
        /// <param name="pos">起点の場所</param>
        /// <returns>長方形の左上の位置</returns>
        public static Vector2 ToTopLeft(this Vector2 point, Vector2 size, Position pos)
        {
            switch(pos)
            {
                case Position.Top:
                    point.X -= size.X / 2;
                    break;
                case Position.TopRight:
                    point.X -= size.X;
                    break;
                case Position.Right:
                    point -= new Vector2(size.X, size.Y / 2);
                    break;
                case Position.BottomRight:
                    point -= size;
                    break;
                case Position.Bottom:
                    point -= new Vector2(size.X / 2, size.Y);
                    break;
                case Position.BottomLeft:
                    point.Y -= size.Y;
                    break;
                case Position.Left:
                    point.Y -= size.Y / 2;
                    break;
                case Position.TopLeft:
                    break;
                case Position.Center:
                    point -= (size / 2);
                    break;
            }

            return point;
        }
    }
}
