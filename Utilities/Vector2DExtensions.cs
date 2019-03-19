using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Graphics
{

    public static class Vector2DExtensions
    {
        public static Vector2D ToTopLeft(this Vector2D point, (int w, int h) size, Location pos)
        {
            return ToTopLeft(point, new Vector2D(size.w, size.h), pos);
        }

        /// <summary>
        /// 長方形上の起点の位置から左上の位置を求める
        /// </summary>
        /// <param name="point">起点の位置</param>
        /// <param name="size">長方形の大きさ</param>
        /// <param name="pos">起点の場所</param>
        /// <returns>長方形の左上の位置</returns>
        public static Vector2D ToTopLeft(this Vector2D point, Vector2D size, Location pos)
        {
            switch (pos)
            {
                case Location.TopCenter:
                    point.X -= size.X / 2;
                    break;
                case Location.TopRight:
                    point.X -= size.X;
                    break;
                case Location.RightCenter:
                    point -= new Vector2D(size.X, size.Y / 2);
                    break;
                case Location.BottomRight:
                    point -= size;
                    break;
                case Location.BottomCenter:
                    point -= new Vector2D(size.X / 2, size.Y);
                    break;
                case Location.BottomLeft:
                    point.Y -= size.Y;
                    break;
                case Location.LeftCenter:
                    point.Y -= size.Y / 2;
                    break;
                case Location.TopLeft:
                    break;
                case Location.Center:
                    point -= size / 2;
                    break;
            }

            return point;
        }
    }
}
