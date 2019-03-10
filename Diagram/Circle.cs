using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public partial class Circle : IDiagram<Circle>
    {
        /// <summary>
        /// 中心座標
        /// </summary>
        public Vector2D Origin { get; set; }

        /// <summary>
        /// 半径
        /// </summary>
        public int Radius { get; set; }

        public Circle()
            : this(Vector2D.GetZero, 1) { }

        public Circle(Circle circle)
            : this(circle.Origin, circle.Radius) { }

        public Circle(int r)
        {
            Radius = r;
        }

        public Circle(int x, int y, int r)
            : this(new Vector2D(x, y), r) { }

        public Circle(Vector2D center, int r)
        {
            Origin = center;
            Radius = r;
        }

        public static bool operator==(Circle c1, Circle c2)
        {
            if(c1 as object == null || c2 as object == null)
            {
                return false;
            }

            return c1.Origin == c2.Origin && c1.Radius == c2.Radius;
        }

        public static bool operator!= (Circle c1, Circle c2)
        {
            return !(c1 == c2);
        }
        
        public Circle MovedBy(int x, int y)
        {
            return new Circle(Origin + (x, y), Radius);
        }

        public Circle MovedBy(Vector2D vector)
        {
            return MovedBy(vector.X, vector.Y);
        }

        public void MoveBy(int x, int y)
        {
            Origin = Origin.MovedBy(x, y);
        }

        public void MoveBy(Vector2D vector)
        {
            Origin.MoveBy(vector);
        }

        public Vector2D Top
        {
            get
            {
                return new Vector2D(Origin.X, Origin.Y - Radius); ;
            }
        }

        public Vector2D Right
        {
            get
            {
                return new Vector2D(Origin.X + Radius, Origin.Y);
            }
        }

        public Vector2D Bottom
        {
            get
            {
                return new Vector2D(Origin.X, Origin.Y + Radius);
            }
        }

        public Vector2D Left
        {
            get
            {
                return new Vector2D(Origin.X - Radius, Origin.Y);
            }
        }

        public override bool Equals(object obj)
        {
            var circle = obj as Circle;

            return circle != null &&
                circle.Origin == Origin && circle.Radius == Radius;
        }

        public object Clone()
        {
            return new Circle(this);
        }
    }
}
