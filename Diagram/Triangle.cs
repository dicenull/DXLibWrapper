using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public partial class Triangle : IDiagram<Triangle>
    {
        public Vector2D Pos0 { get; set; }
        public Vector2D Pos1 { get; set; }
        public Vector2D Pos2 { get; set; }

        public Vector2D Origin
        {
            get
            {
                return (Pos0 + Pos1 + Pos2) / 3;
            }
        }
        
        public Triangle()
         : this(Vector2D.GetZero, Vector2D.GetZero, Vector2D.GetZero) { }

        public Triangle(Triangle triangle)
           : this(triangle.Pos0, triangle.Pos1, triangle.Pos2) { }

        public Triangle(int x0, int y0, int x1, int y1, int x2, int y2)
            : this(new Vector2D(x0, y0), new Vector2D(x1, y1), new Vector2D(x2, y2)) { }

        public Triangle(Vector2D p0, Vector2D p1, Vector2D p2)
        {
            Pos0 = p0;
            Pos1 = p1;
            Pos2 = p2;
        }

        public void MoveBy(int x, int y)
        {
            Pos0 = Pos0.MovedBy(x, y);
            Pos1 = Pos1.MovedBy(x, y);
            Pos2 = Pos2.MovedBy(x, y);
        }

        public void MoveBy(Vector2D vector)
        {
            MoveBy(vector.X, vector.Y);
        }

        public Triangle MovedBy(int x, int y)
        {
            return new Triangle(Pos0.MovedBy(x, y), Pos1.MovedBy(x, y), Pos2.MovedBy(x, y));
        }

        public Triangle MovedBy(Vector2D vector)
        {
            return MovedBy(vector.X, vector.Y);
        }

        public object Clone()
        {
            return new Triangle(this);
        }
    }
}
