using System.Numerics;

namespace Utilities
{
    public enum Location
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
        public static Vector2 ToTopLeft(this Vector2 point, Vector2 size, Location pos)
        {
            switch(pos)
            {
                case Location.Top:
                    point.X -= size.X / 2;
                    break;
                case Location.TopRight:
                    point.X -= size.X;
                    break;
                case Location.Right:
                    point -= new Vector2(size.X, size.Y / 2);
                    break;
                case Location.BottomRight:
                    point -= size;
                    break;
                case Location.Bottom:
                    point -= new Vector2(size.X / 2, size.Y);
                    break;
                case Location.BottomLeft:
                    point.Y -= size.Y;
                    break;
                case Location.Left:
                    point.Y -= size.Y / 2;
                    break;
                case Location.TopLeft:
                    break;
                case Location.Center:
                    point -= (size / 2);
                    break;
            }

            return point;
        }
    }
}
