using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public partial class Circle
    {
        /// <summary>
        /// 中心座標
        /// </summary>
        public Vector2D Center { get; set; }

        /// <summary>
        /// 半径
        /// </summary>
        public int Radius { get; set; }

        public Circle(int r)
        {
            Radius = r;
        }

        public Circle(int x, int y, int r)
            : this(new Vector2D(x, y), r) { }

        public Circle(Vector2D center, int r)
        {
            Center = center;
            Radius = r;
        }

        public static bool operator==(Circle c1, Circle c2)
        {
            return c1.Center == c2.Center && c1.Radius == c2.Radius;
        }

        public static bool operator!= (Circle c1, Circle c2)
        {
            return !(c1 == c2);
        }

        public Circle MovedBy(int x, int y)
        {
            return new Circle(Center + (x, y), Radius);
        }

        public Circle MovedBy(Vector2D vector)
        {
            return MovedBy(vector.X, vector.Y);
        }

        public void MoveBy(int x, int y)
        {
            Center.MoveBy(x, y);
        }

        public void MoveBy(Vector2D vector)
        {
            Center.MoveBy(vector);
        }

        public Vector2D Top
        {
            get
            {
                return new Vector2D(Center.X, Center.Y - Radius); ;
            }
        }

        public Vector2D Right
        {
            get
            {
                return new Vector2D(Center.X + Radius, Center.Y);
            }
        }

        public Vector2D Bottom
        {
            get
            {
                return new Vector2D(Center.X, Center.Y + Radius);
            }
        }

        public Vector2D Left
        {
            get
            {
                return new Vector2D(Center.X - Radius, Center.Y);
            }
        }
    }
}
