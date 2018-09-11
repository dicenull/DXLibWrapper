using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Utilities;

namespace Diagram
{
    public class Rectangle<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// 長方形の大きさ
        /// </summary>
        public Vector2D<T> Size { get; set; }

        /// <summary>
        /// 長方形の左上の座標
        /// </summary>
        public Vector2D<T> Point { get; set; }

        #region コンストラクタ
        
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Rectangle()
        { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="size">大きさ</param>
        public Rectangle(Vector2D<T> size)
            : this(Vector2D<T>.GetZero, size) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        public Rectangle(T w, T h)
            : this(Vector2D<T>.GetZero, new Vector2D<T>(w, h)) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="x">基準となる位置のX座標</param>
        /// <param name="y">基準となる位置のY座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(T x, T y, T w, T h, Location pos = Location.TopLeft)
            : this(new Vector2D<T>(x, y), new Vector2D<T>(w, h), pos) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="x">基準となる位置のX座標</param>
        /// <param name="y">基準となる位置のY座標</param>
        /// <param name="size">大きさ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(T x, T y, Vector2D<T> size, Location pos = Location.TopLeft)
            : this(new Vector2D<T>(x, y), size, pos) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="point">基準となる位置</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(Vector2D<T> point, T w, T h, Location pos = Location.TopLeft)
            : this(point, new Vector2D<T>(w, h), pos) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="point">基準となる位置</param>
        /// <param name="size">大きさ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(Vector2D<T> point, Vector2D<T> size, Location pos = Location.TopLeft)
        {
            point = point.ToTopLeft(size, pos);
            Point = point;
            Size = size;
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="rectangle">コピー元の長方形</param>
        public Rectangle(Rectangle<T> rectangle)
            : this(rectangle.Point, rectangle.Size) { }

        #endregion

        public static bool operator ==(Rectangle<T> r1, Rectangle<T> r2)
        {
            return r1.Point == r2.Point 
                   && r1.Size == r2.Size;
        }

        public static bool operator !=(Rectangle<T> r1, Rectangle<T> r2)
        {
            return !(r1 == r2);
        }

        public Rectangle<T> MovedBy(T x, T y)
        {
            return this;
        }

        public Rectangle<T> MovedBy(Vector2D<T> v)
        {
            return this;
        }

        public void MoveBy(T x, T y)
        {

        }

        public void MoveBy(Vector2D<T> v)
        {

        }

        public Rectangle<T> Stretched(T xy)
        {
            return this;
        }

        public Rectangle<T> Stretched(T x, T y)
        {
            return this;
        }

        public Rectangle<T> Stretched(Vector2D<T> xy)
        {
            return this;
        }

        public Rectangle<T> Stretched(T top, T right, T bottom, T left)
        {
            return this;
        }

        public Rectangle<double> Scaled(double s)
        {
            return new Rectangle<double>();
        }

        public Rectangle<double> Scaled(double sx, double sy)
        {
            return new Rectangle<double>();
        }

        public Rectangle<double> Scaled(Vector2D<double> s)
        {
            return new Rectangle<double>();
        }

        public Rectangle<double> ScaledAt(double x, double y, double s)
        {
            return new Rectangle<double>();
        }

        public Rectangle<double> ScaledAt(double x, double y, double sx, double sy)
        {
            return new Rectangle<double>();
        }

        public Rectangle<double> ScaledAt(double x, double y, Vector2D<double> s)
        {
            return new Rectangle<double>();
        }

        public Rectangle<double> ScaledAt(Vector2D<double> pos, double s)
        {
            return new Rectangle<double>();
        }

        public Rectangle<double> ScaledAt(Vector2D<double> pos, double sx, double sy)
        {
            return new Rectangle<double>();
        }

        public Rectangle<double> ScaledAt(Vector2D<double> pos, Vector2D<double> s)
        {
            return new Rectangle<double>();
        }

        public override bool Equals(object obj)
        {
            var rect = obj as Rectangle<T>;
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
