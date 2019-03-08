using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Utilities;

namespace Diagram
{
    /// <summary>
    /// 四角形クラスロジック部
    /// </summary>
    public partial class Rectangle
    {
        /// <summary>
        /// 長方形の大きさ
        /// </summary>
        public Vector2D Size { get; set; }

        /// <summary>
        /// 長方形の左上の座標
        /// </summary>
        public Vector2D Point { get; set; }

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
        public Rectangle(Vector2D size)
            : this(Vector2D.GetZero, size)
        {
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        public Rectangle(int w, int h)
            : this(Vector2D.GetZero, new Vector2D(w, h))
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
        public Rectangle(int x, int y, int w, int h, Location pos = Location.TopLeft)
            : this(new Vector2D(x, y), new Vector2D(w, h), pos)
        {
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="x">基準となる位置のX座標</param>
        /// <param name="y">基準となる位置のY座標</param>
        /// <param name="size">大きさ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(int x, int y, Vector2D size, Location pos = Location.TopLeft)
            : this(new Vector2D(x, y), size, pos)
        {
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="point">基準となる位置</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(Vector2D point, int w, int h, Location pos = Location.TopLeft)
            : this(point, new Vector2D(w, h), pos)
        {
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="point">基準となる位置</param>
        /// <param name="size">大きさ</param>
        /// <param name="pos">起点の位置</param>
        public Rectangle(Vector2D point, Vector2D size, Location pos = Location.TopLeft)
        {
            point = point.ToTopLeft(size, pos);
            Point = point;
            Size = size;
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="rectangle">コピー元の長方形</param>
        public Rectangle(Rectangle rectangle)
            : this(rectangle.Point, rectangle.Size)
        {
        }

        #endregion

        public static bool operator ==(Rectangle r1, Rectangle r2)
        {
            if(r1 as object == null || r2 as object == null)
            {
                return false; 
            }

            return r1.Point == r2.Point
                   && r1.Size == r2.Size;
        }

        public static bool operator !=(Rectangle r1, Rectangle r2)
        {
            return !(r1 == r2);
        }

        public Rectangle MovedBy(int x, int y)
        {
            return new Rectangle(Point.MovedBy(x, y), Size);
        }

        public Rectangle MovedBy(Vector2D v)
        {
            return MovedBy(v.X, v.Y);
        }

        public void MoveBy(int x, int y)
        {
            Point = Point.MovedBy(x, y);
        }

        public void MoveBy(Vector2D v)
        {
            MoveBy(v.X, v.Y);
        }

        public Rectangle Stretched(int xy)
        {
            return Stretched(new Vector2D(xy, xy));
        }

        public Rectangle Stretched(int x, int y)
        {
            return Stretched(new Vector2D(x, y));
        }

        public Rectangle Stretched(Vector2D xy)
        {
            return new Rectangle(Point - xy, Size + xy * 2);
        }

        public Rectangle Stretched(int top, int right, int bottom, int left)
        {
            return new Rectangle(
                Point.X - left, 
                Point.Y - top, 
                Size.X + left + right, 
                Size.Y + top + bottom);
        }

        public Rectangle Scaled(double s)
        {
            return Scaled(s, s);
        }

        public Rectangle Scaled(double sx, double sy)
        {
            return new Rectangle(
                Point.X + Size.X / 2,
                Point.Y + Size.X / 2, 
                (int)(Size.X * sx), 
                (int)(Size.Y * sy));
        }

        public Rectangle Scaled(Vector2D s)
        {
            return Scaled(s.X, s.Y);
        }

        public Rectangle ScaledAt(double x, double y, double s)
        {
            return ScaledAt(x, y, s, s);
        }

        public Rectangle ScaledAt(double x, double y, double sx, double sy)
        {
            return new Rectangle(
                (int)(x + (Point.X - x) * sx),
                (int)(y + (Point.Y - y) * sy),
                (int)(Size.X * sx),
                (int)(Size.Y * sy));
        }

        public Rectangle ScaledAt(double x, double y, Vector2D s)
        {
            return ScaledAt(x, y, s.X, s.Y);
        }

        public Rectangle ScaledAt(Vector2D pos, double s)
        {
            return ScaledAt(pos.X, pos.Y, s, s);
        }

        public Rectangle ScaledAt(Vector2D pos, double sx, double sy)
        {
            return ScaledAt(pos.X, pos.Y, sx, sy);
        }

        public Rectangle ScaledAt(Vector2D pos, Vector2D s)
        {
            return ScaledAt(pos.X, pos.Y, s.X, s.Y);
        }

        #region 座標取得
        public Vector2D TopRight => Point;

        public Vector2D BottomLeft
        {
            get
            {
                return new Vector2D(Point.X, Point.Y + Size.Y);
            }
        }

        public Vector2D BottomRight
        {
            get
            {
                return new Vector2D(Point.X + Size.X, Point.Y + Size.Y);
            }
        }

        public Vector2D TopCenter
        {
            get
            {
                return new Vector2D(Point.X + Size.X / 2, Point.Y);
            }
        }

        public Vector2D BottomCenter
        {
            get
            {
                return new Vector2D(Point.X + Size.X / 2, Point.Y + Size.Y);
            }
        }

        public Vector2D LeftCenter
        {
            get
            {
                return new Vector2D(Point.X, Point.Y + Size.Y / 2);
            }
        }

        public Vector2D RightCenter
        {
            get
            {
                return new Vector2D(Point.X + Size.X, Point.Y + Size.Y / 2);
            }
        }

        public Vector2D Center
        {
            get
            {
                return new Vector2D(Point.X + Size.X / 2, Point.Y + Size.Y / 2);
            }
        }

        #endregion

        public override bool Equals(object obj)
        {
            var rect = obj as Rectangle;
            return rect != null && Size.Equals(rect.Size) && Point.Equals(rect.Point);
        }

        public override int GetHashCode()
        {
            return -1986401011 ^ Size.GetHashCode() ^ Point.GetHashCode();
        }
    }
}