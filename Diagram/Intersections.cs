using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public static class Intersections
    {
        static double Sign(Vector2D p1, Vector2D p2, Vector2D p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        public static bool Intersect(Rectangle r1, Rectangle r2)
        {
            return r1.TopLeft.X < r2.BottomRight.X
                && r2.TopLeft.X < r1.BottomRight.X
                && r1.TopLeft.Y < r2.BottomRight.Y
                && r2.TopLeft.Y < r1.BottomRight.Y;
        }

        public static bool Intersect(Circle c1, Circle c2)
        {
            var dx = c1.Center.X - c2.Center.X;
            var dy = c1.Center.Y - c2.Center.Y;
            var sumR = c1.Radius + c2.Radius;

            return (dx * dx + dy * dy) <= sumR * sumR;
        }

        //
        // http://www5d.biglobe.ne.jp/~tomoya03/shtml/algorithm/Intersection.htm
        //
        public static bool Intersect(Line l1, Line l2)
        {
            var ta = (l2.Begin.X - l2.End.X) * (l1.Begin.Y - l2.Begin.Y) + (l2.Begin.Y - l2.End.Y) * (l2.Begin.X - l1.Begin.X);
            var tb = (l2.Begin.X - l2.End.X) * (l1.End.Y - l2.Begin.Y) + (l2.Begin.Y - l2.End.Y) * (l2.Begin.X - l1.End.X);
            var tc = (l1.Begin.X - l1.End.X) * (l2.Begin.Y - l1.Begin.Y) + (l1.Begin.Y - l1.End.Y) * (l1.Begin.X - l2.Begin.X);
            var td = (l1.Begin.X - l1.End.X) * (l2.End.Y - l1.Begin.Y) + (l1.Begin.Y - l1.End.Y) * (l1.Begin.X - l2.End.X);

            return tc * td < 0 && ta * tb < 0;
        }

        // 
        // http://marupeke296.com/COL_2D_TriTri.html
        //
        public static bool Intersect(Triangle tri1, Triangle tri2)
        {
            int[] other =  { 1, 2, 0 };
            int[] pindex = { 1, 2, 0, 1 };
            Triangle[] tri = { tri1, tri2, tri1 };
            
            for(int t = 0;t < 2;t++)
            {
                var ta = tri[t];
                var tb = tri[t + 1];

                double Dot((double x, double y) v1, Vector2D v2)
                    => v1.x * v2.X + v1.y * v2.Y;

                for(int i = 0;i < 3;i++)
                {
                    var vec = (ta.Pos[pindex[i + 1]] - ta.Pos[pindex[i]]).Normalized();
                    (double X, double Y) sepVec = (vec.Y, -vec.X);

                    var s1Min = Dot(sepVec, ta.Pos[i]);
                    var s1Max = Dot(sepVec, ta.Pos[other[i]]);

                    if(s1Min > s1Max)
                    {
                        // swap
                        var tmp = s1Min;
                        s1Min = s1Max;
                        s1Max = tmp;
                    }

                    var s2Min = Dot(sepVec, tb.Pos[0]);
                    var s2Max = Dot(sepVec, tb.Pos[1]);

                    if(s2Min > s2Max)
                    {
                        // swap
                        var tmp = s2Min;
                        s2Min = s2Max;
                        s2Max = tmp;
                    }

                    var d3 = Dot(sepVec, tb.Pos[2]);

                    if(d3 < s2Min)
                    {
                        s2Min = d3;
                    }
                    else if(d3 > s2Max)
                    {
                        s2Max = d3;
                    }

                    if((s2Min <= s1Min && s1Min <= s2Max)
                        || (s2Min <= s1Max && s1Max <= s2Max)
                        || (s1Min <= s2Min && s2Min <= s1Max)
                        || (s1Min <= s2Max && s2Max <= s1Max))
                    {
                        continue;
                    }

                    return false;
                }
            }

            return true;
        }

        public static bool Intersect(Rectangle rect, Circle circle)
        {
            var harfW = rect.Size.w * 0.5;
            var harfH = rect.Size.h * 0.5;
            var cX = Math.Abs(circle.Center.X - rect.TopLeft.X - harfW);
            var cY = Math.Abs(circle.Center.Y - rect.TopLeft.Y - harfH);

            if(cX > (harfW + circle.Radius) || cY > (harfH + circle.Radius))
            {
                return false;
            }

            if(cX <= (harfW) || cY <= (harfH))
            {
                return true;
            }

            var a = cX - harfW;
            var b = cY - harfH;
            var c = circle.Radius;

            return (a * a) + (b * b) <= (c * c);
        }

        public static bool Intersect(Rectangle rect, Line line)
        {
            if(Intersect(line.Begin, rect) || Intersect(line.End, rect))
            {
                return true;
            }

            Vector2D tl = rect.TopLeft,     tr = rect.TopRight,
                     br = rect.BottomRight, bl = rect.BottomLeft;

            return Intersect(line, new Line(tl, tr))
                || Intersect(line, new Line(tr, br))
                || Intersect(line, new Line(br, bl))
                || Intersect(line, new Line(bl, tl));
        }

        private static bool Intersect(Vector2D vec, Rectangle rect)
        {
            return rect.TopLeft.X <= vec.X && vec.X < rect.BottomRight.X
                && rect.TopLeft.Y <= vec.Y && vec.Y < rect.BottomRight.Y;
        }

        private static bool Intersect(Vector2D vec, Triangle triangle)
        {
            bool b1 = Sign(vec, triangle.Pos0, triangle.Pos1) < 0.0;
            bool b2 = Sign(vec, triangle.Pos1, triangle.Pos2) < 0.0;
            bool b3 = Sign(vec, triangle.Pos2, triangle.Pos0) < 0.0;

            return ((b1 == b2) && (b2 == b3));
        }

        public static bool Intersect(Rectangle rect, Triangle triangle)
        {
            return Intersect(new Triangle(rect.TopLeft, rect.TopRight, rect.BottomLeft), triangle)
                || Intersect(new Triangle(rect.BottomLeft, rect.TopRight, rect.BottomRight), triangle);
        }

        public static bool Intersect(Circle circle, Line line)
        {
            var ab = line.End - line.Begin;
            var ac = circle.Center - line.Begin;
            var bc = circle.Center - line.End;

            var e = ac.Dot(ab);
            var rr = circle.Radius * circle.Radius;

            if(e <= 0)
            {
                return ac.Dot(ac) <= rr;
            }

            double f = ab.Dot(ab);

            if(e >= f)
            {
                return bc.Dot(bc) <= rr;
            }

            return ac.Dot(ac) - e * e / f <= rr;
        }

        // 
        // http://www.phatcode.net/articles.php?id=459
        // 
        public static bool Intersect(Circle circle, Triangle triangle)
        {
            int[] cx = new int[3];
            int[] cy = new int[3];
            int[] cSqr = new int[3];

            for (int i = 0; i < 3; i++)
            {
                cx[i] = circle.Center.X - triangle.Pos[i].X;
                cy[i] = circle.Center.Y - triangle.Pos[i].Y;
                var radiusSqr = circle.Radius * circle.Radius;
                cSqr[i] = cx[i] * cx[i] + cy[i] * cy[i] - radiusSqr;

                if (cSqr[i] <= 0)
                {
                    return true;
                }
            }


            Vector2D[] e =
                {
                triangle.Pos1 - triangle.Pos0,
                triangle.Pos2 - triangle.Pos1,
                triangle.Pos0 - triangle.Pos2
                };

            if (e[0].Y * cx[0] >= e[0].X * cy[0]
                && e[1].Y * cx[1] >= e[1].X * cy[1]
                && e[2].Y * cx[2] >= e[2].X * cy[2])
            {
                return true;
            }


            for(int i = 0;i < 3;i++)
            {
                var k = cx[i] * e[i].X + cy[i] * e[i].Y;

                if (k > 0)
                {
                    var len = e[i].X * e[i].X + e[i].Y * e[i].Y;

                    if ((k < len) && (cSqr[i] * len <= k * k))
                    {
                        return true;
                    }
                }
            }

            if(Intersect(circle.Center, triangle))
            {
                return true;
            }

            return false;
        }

        public static bool Intersect(Line line, Triangle triangle)
        {
            if(Intersect(line.Begin, triangle) || Intersect(line.End, triangle))
            {
                return true;
            }

            return Intersect(line, new Line(triangle.Pos0, triangle.Pos1))
                || Intersect(line, new Line(triangle.Pos1, triangle.Pos2))
                || Intersect(line, new Line(triangle.Pos2, triangle.Pos0));
        }

        public static bool Intersect(Triangle triangle, Rectangle rect)
        {
            return Intersect(rect, triangle);
        }

        public static bool Intersect(Line line, Rectangle rect)
        {
            return Intersect(rect, line);
        }

        public static bool Intersect(Circle circle, Rectangle rect)
        {
            return Intersect(rect, circle);
        }

        public static bool Intersect(Line line, Circle circle)
        {
            return Intersect(circle, line);
        }

        public static bool Intersect(Triangle triangle, Circle circle)
        {
            return Intersect(circle, triangle);
        }

        public static bool Intersect(Triangle triangle, Line line)
        {
            return Intersect(line, triangle);
        }
    }
}
