using Utilities;

namespace Diagram
{
    public partial class Circle : IDiagram<Circle>
    {
        /// <summary>
        /// 中心座標
        /// </summary>
        public Vector2D Center { get; set; }

        /// <summary>
        /// 半径
        /// </summary>
        public int Radius { get; set; }

        public Circle()
            : this(Vector2D.GetZero, 1) { }

        public Circle(Circle circle)
            : this(circle.Center, circle.Radius) { }

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
            if(c1 as object == null || c2 as object == null)
            {
                return false;
            }

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
            Center = Center.MovedBy(x, y);
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

        public override bool Equals(object obj)
        {
            var circle = obj as Circle;

            return circle != null &&
                circle.Center == Center && circle.Radius == Radius;
        }

        public object Clone()
        {
            return new Circle(this);
        }

        //  当たり判定

        public bool Intersects(Rectangle rect)
        {
            return Intersections.Intersect(this, rect);
        }

        public bool Intersects(Triangle triangle)
        {
            return Intersections.Intersect(this, triangle);
        }

        public bool Intersects(Line line)
        {
            return Intersections.Intersect(this, line);
        }

        public bool Intersects(Circle circle)
        {
            return Intersections.Intersect(this, circle);
        }
    }
}
