
using System;
using Utilities;

namespace Diagram
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
        public static Vector2D<T> ToTopLeft<T>(this Vector2D<T> point, Vector2D<T> size, Location pos)
            where T : struct, IComparable<T>
        {
            var two = (T) Convert.ChangeType(2, typeof(T));
            var div = Operator<T>.Divide;
            var sub = Operator<T>.Subtract;

            switch (pos)
            {
                case Location.Top:
                    point.X = sub(point.X, div(size.X, two));
                    break;
                case Location.TopRight:
                    point.X = sub(point.X, size.X);
                    break;
                case Location.Right:
                    point -= new Vector2D<T>(size.X, div(size.Y, two));
                    break;
                case Location.BottomRight:
                    point -= size;
                    break;
                case Location.Bottom:
                    point -= new Vector2D<T>(div(size.X, two), size.Y);
                    break;
                case Location.BottomLeft:
                    point.Y = sub(point.Y, size.Y);
                    break;
                case Location.Left:
                    point.Y = sub(point.Y, div(size.Y, two));
                    break;
                case Location.TopLeft:
                    break;
                case Location.Center:
                    point -= (size / two);
                    break;
            }

            return point;
        }
    }
}