using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public static class Intersections
    {
        public static bool Intersects(Rectangle rect1, Rectangle rect2)
        {
            return false;
        }

        public static bool Intersects(Circle circle1, Circle circle2)
        {
            return false;
        }

        public static bool Intersects(Line line1, Line line2)
        {
            return false;
        }

        public static bool Intersects(Triangle triangle1, Triangle triangle2)
        {
            return false;
        }

        public static bool Intersects(Rectangle rect, Circle circle)
        {
            return false;
        }

        public static bool Intersects(Rectangle rect, Line line)
        {
            return false;
        }
        
        public static bool Intersects(Rectangle rect, Triangle triangle)
        {
            return false;
        }

        public static bool Intersects(Circle circle, Line line)
        {
            return false;
        }

        public static bool Intersects(Circle circle, Triangle triangle)
        {
            return false;
        }

        public static bool Intersects(Line line, Triangle triangle)
        {
            return false;
        }

        public static bool Intersects(Triangle triangle, Rectangle rect)
        {
            return Intersects(rect, triangle);
        }

        public static bool Intersects(Line line, Rectangle rect)
        {
            return Intersects(rect, line);
        }

        public static bool Intersects(Circle circle, Rectangle rect)
        {
            return Intersects(rect, circle);
        }

        public static bool Intersects(Line line, Circle circle)
        {
            return Intersects(circle, line);
        }

        public static bool Intersects(Triangle triangle, Circle circle)
        {
            return Intersects(circle, triangle);
        }

        public static bool Intersects(Triangle triangle, Line line)
        {
            return Intersects(line, triangle);
        }
    }
}
