using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Utilities;

namespace Diagram
{
    public class Rect<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// 長方形の大きさ
        /// </summary>
        public Vector2D<T> Size { get; set; }

        /// <summary>
        /// 長方形の左上の座標
        /// </summary>
        public Vector2D<T> Point { get; set; }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Rect()
        { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="size">大きさ</param>
        public Rect(Vector2D<T> size)
            : this(Vector2D<T>.GetZero, size) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        public Rect(T w, T h)
            : this(Vector2D<T>.GetZero, new Vector2D<T>(w, h)) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="x">基準となる位置のX座標</param>
        /// <param name="y">基準となる位置のY座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="pos">起点の位置</param>
        public Rect(T x, T y, T w, T h, Location pos = Location.TopLeft)
            : this(new Vector2D<T>(x, y), new Vector2D<T>(w, h), pos) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="x">基準となる位置のX座標</param>
        /// <param name="y">基準となる位置のY座標</param>
        /// <param name="size">大きさ</param>
        /// <param name="pos">起点の位置</param>
        public Rect(T x, T y, Vector2D<T> size, Location pos = Location.TopLeft)
            : this(new Vector2D<T>(x, y), size, pos) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="point">基準となる位置</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="pos">起点の位置</param>
        public Rect(Vector2D<T> point, T w, T h, Location pos = Location.TopLeft)
            : this(point, new Vector2D<T>(w, h), pos) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="point">基準となる位置</param>
        /// <param name="size">大きさ</param>
        /// <param name="pos">起点の位置</param>
        public Rect(Vector2D<T> point, Vector2D<T> size, Location pos = Location.TopLeft)
        {
            point = point.ToTopLeft(size, pos);
            Point = point;
            Size = size;
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="rect">コピー元の長方形</param>
        public Rect(Rect<T> rect)
            : this(rect.Point, rect.Size) { }

        public override bool Equals(object obj)
        {
            var rect = obj as Rect<T>;
            return rect != null &&
                   EqualityComparer<Vector2D<T>>.Default.Equals(Size, rect.Size) &&
                   EqualityComparer<Vector2D<T>>.Default.Equals(Point, rect.Point);
        }

        public override int GetHashCode()
        {
            return -1986401011 ^ Size.GetHashCode() ^ Point.GetHashCode();
        }
    }
}
