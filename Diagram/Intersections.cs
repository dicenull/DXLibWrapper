using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public static class Intersections
    {
        public static bool Intersects(Rectangle r1, Rectangle r2)
        {
            return r1.TopLeft.X < r2.BottomRight.X
                && r2.TopLeft.X < r1.BottomRight.X
                && r1.TopLeft.Y < r2.BottomRight.Y
                && r2.TopLeft.Y < r1.BottomRight.Y;
        }

        public static bool Intersects(Circle c1, Circle c2)
        {
            var dx = c1.Center.X - c2.Center.X;
            var dy = c1.Center.Y - c2.Center.Y;
            var sumR = c1.Radius + c2.Radius;

            return (dx * dx + dy * dy) <= sumR * sumR;
        }

        //
        // http://www5d.biglobe.ne.jp/~tomoya03/shtml/algorithm/Intersection.htm
        //
        public static bool Intersects(Line l1, Line l2)
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
        public static bool Intersects(Triangle tri1, Triangle tri2)
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

                    if(s2Min > s1Max)
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
                    else if(d3 < s2Max)
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
