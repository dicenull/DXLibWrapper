using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public partial class Line
    {
        /// <summary>
        /// 開始点
        /// </summary>
        public Vector2D Begin { get; set; }

        /// <summary>
        /// 終点
        /// </summary>
        public Vector2D End { get; set; }

        #region コンストラクタ
        public Line()
        {
            Begin = new Vector2D();
            End = new Vector2D();
        }

        public Line(int x0, int y0, int x1, int y1)
            : this(new Vector2D(x0, y0), new Vector2D(x1, y1))
        { }

        public Line(Vector2D begin, int x1, int y1)
            : this(begin, new Vector2D(x1, y1))
        { }

        public Line(int x0, int y0, Vector2D end)
            : this(new Vector2D(x0, y0), end)
        { }

        public Line(Vector2D begin, Vector2D end)
        {
            Begin = begin;
            End = end;
        }
        #endregion

        public Line MovedBy(int x, int y)
        {
            return new Line(Begin.MovedBy(x, y), End.MovedBy(x, y));
        }

        public Line MovedBy(Vector2D vector)
        {
            return MovedBy(vector.X, vector.Y);
        }

        public void MoveBy(int x, int y)
        {
            Begin.MoveBy(x, y);
            End.MoveBy(x, y);
        }

        public void MoveBy(Vector2D vector)
        {
            MoveBy(vector.X, vector.Y);
        }

        public Vector2D Vector()
        {
            return End - Begin;
        }

        public Line Reversed()
        {
            return new Line(End, Begin);
        }

        public void Reverse()
        {
            var t = Begin;
            Begin = End;
            End = t;
        }

        public double Length()
        {
            return Begin.DistanceFrom(End);
        }

        public Vector2D Center()
        {
            return (Begin + End) / 2;
        }


        public static bool operator ==(Line l1, Line l2)
        {
            return l1.Begin == l2.Begin
                && l1.End == l2.End;
        }

        public static bool operator !=(Line l1, Line l2)
        {
            return !(l1 == l2);
        }

        public override bool Equals(object obj)
        {
            var line = obj as Line;

            return line != null && 
                line.Begin == Begin && line.End == End;
        }

        public override int GetHashCode()
        {
            return 1903003160 ^ Begin.GetHashCode() ^ End.GetHashCode();
        }
    }
}
