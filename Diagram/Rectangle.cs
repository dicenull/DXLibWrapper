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
        {
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="size">大きさ</param>
        public Rectangle(Vector2D<T> size)
            : this(Vector2D<T>.GetZero, size)
        {
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        public Rectangle(T w, T h)
            : this(Vector2D<T>.GetZero, new Vector2D<T>(w, h))
        {
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="x">基準となる位置のX座標</param>
        /// <param name="y">基準となる位置のY座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(T x, T y, T w, T h, Location pos = Location.TopLeft)
            : this(new Vector2D<T>(x, y), new Vector2D<T>(w, h), pos)
        {
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="x">基準となる位置のX座標</param>
        /// <param name="y">基準となる位置のY座標</param>
        /// <param name="size">大きさ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(T x, T y, Vector2D<T> size, Location pos = Location.TopLeft)
            : this(new Vector2D<T>(x, y), size, pos)
        {
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="point">基準となる位置</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(Vector2D<T> point, T w, T h, Location pos = Location.TopLeft)
            : this(point, new Vector2D<T>(w, h), pos)
        {
        }

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
            : this(rectangle.Point, rectangle.Size)
        {
        }

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
            return new Rectangle<T>(Point.MovedBy(x, y), Size);
        }

        public Rectangle<T> MovedBy(Vector2D<T> v)
        {
            return MovedBy(v.X, v.Y);
        }

        public void MoveBy(T x, T y)
        {
            Point.MoveBy(x, y);
        }

        public void MoveBy(Vector2D<T> v)
        {
            MoveBy(v.X, v.Y);
        }

        public Rectangle<T> Stretched(T xy)
        {
            return Stretched(new Vector2D<T>(xy, xy));
        }

        public Rectangle<T> Stretched(T x, T y)
        {
            return Stretched(new Vector2D<T>(x, y));
        }

        public Rectangle<T> Stretched(Vector2D<T> xy)
        {
            var two = (T) Convert.ChangeType(2, typeof(T));
            return new Rectangle<T>(Point - xy, Size + xy * two);
        }

        public Rectangle<T> Stretched(T top, T right, T bottom, T left)
        {
            var add = Operator<T>.Add;
            var sub = Operator<T>.Subtract;

            return new Rectangle<T>(sub(Point.X, left), sub(Point.Y, top),
                add(Size.X, add(left, right)), add(Size.Y, add(top, bottom)));
        }

        public Rectangle<double> Scaled(double s)
        {
            return Scaled(s, s);
        }

        public Rectangle<double> Scaled(double sx, double sy)
        {
            var point = new Vector2D<double>(Convert.ToDouble(Point.X), Convert.ToDouble(Point.Y));
            var size = new Vector2D<double>(Convert.ToDouble(Size.X), Convert.ToDouble(Size.Y));

            return new Rectangle<double>(point.X + size.X * 0.5, point.Y + size.X * 0.5, size.Y * sx, size.Y * sy);
        }

        public Rectangle<double> Scaled(Vector2D<double> s)
        {
            return Scaled(s.X, s.Y);
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

        public Vector2D<T> TopRight => Point;

        public Vector2D<T> BottomLeft
        {
            get
            {
                var add = Operator<T>.Add;
                return new Vector2D<T>(Point.X, add(Point.Y, Size.Y));
            }
        }

        public Vector2D<T> BottomRight
        {
            get
            {
                var add = Operator<T>.Add;
                return new Vector2D<T>(add(Point.X, Size.X), add(Point.Y, Size.Y));
            }
        }

        public Vector2D<T> TopCenter
        {
            get
            {
                var add = Operator<T>.Add;
                var div = Operator<T>.Divide;
                var two = (T) Convert.ChangeType(2, typeof(T));
                return new Vector2D<T>(add(Point.X, div(Size.X, two)), Point.Y);
            }
        }

        public Vector2D<T> BottomCenter
        {
            get
            {
                var add = Operator<T>.Add;
                var div = Operator<T>.Divide;
                var two = (T) Convert.ChangeType(2, typeof(T));
                return new Vector2D<T>(add(Point.X, div(Size.X, two)), add(Point.Y, Size.Y));
            }
        }

        public Vector2D<T> LeftCenter
        {
            get
            {
                var add = Operator<T>.Add;
                var div = Operator<T>.Divide;
                var two = (T) Convert.ChangeType(2, typeof(T));
                return new Vector2D<T>(Point.X, add(Point.Y, div(Size.Y, two)));
            }
        }

        public Vector2D<T> RightCenter
        {
            get
            {
                var add = Operator<T>.Add;
                var div = Operator<T>.Divide;
                var two = (T) Convert.ChangeType(2, typeof(T));
                return new Vector2D<T>(add(Point.X, Size.X), add(Point.Y, div(Size.Y, two)));
            }
        }

        public Vector2D<T> Center
        {
            get
            {
                var add = Operator<T>.Add;
                var div = Operator<T>.Divide;
                var two = (T) Convert.ChangeType(2, typeof(T));
                return new Vector2D<T>(add(Point.X, div(Size.X, two)), add(Point.Y, div(Size.Y, two)));
            }
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