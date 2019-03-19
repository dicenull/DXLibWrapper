using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphics;

namespace DiagramTest
{
    [TestClass]
    public class IntersectTest
    {
        [TestMethod]
        public void Rect_Rect当たっていない()
        {
            var r1 = new Rectangle(-3, -2, 4, 4);
            var r2 = new Rectangle(2, 0, -4, 10);
            var r3 = new Rectangle(-4, 1, 1, 1);

            Assert.IsFalse(r1.Intersects(r2));
            Assert.IsFalse(r1.Intersects(r3));
            Assert.IsFalse(r2.Intersects(r3));
        }

        [TestMethod]
        public void Rect_Rect当たっている()
        {
            var r1 = new Rectangle(-3, -2, 4, 4);
            var r2 = new Rectangle(0, -4, 1, 10);
            var r3 = new Rectangle(-2, 0, 2, 1);
            var r4 = new Rectangle(-4, -3, 2, 2);

            Assert.IsTrue(r1.Intersects(r2));
            Assert.IsTrue(r1.Intersects(r3));
            Assert.IsTrue(r1.Intersects(r4));
        }

        [TestMethod]
        public void Rect_Line当たっていない()
        {
            var rect = new Rectangle(-3, -2, 4, 4);
            var line1 = new Line(-2, -6, -6, 3);
            var line2 = new Line(-4, 3, 2, 3);
            var line3 = new Line(1, -3, 2, -2);

            Assert.IsFalse(rect.Intersects(line1));
            Assert.IsFalse(rect.Intersects(line2));
            Assert.IsFalse(rect.Intersects(line3));
        }

        [TestMethod]
        public void Rect_Line当たっている()
        {
            var rect = new Rectangle(-3, -2, 4, 4);
            var line1 = new Line(-1, -6, -4, 1);
            var line2 = new Line(-4, 2, 1, 1);
            var line3 = new Line(0, -2, 1, -1);

            Assert.IsTrue(rect.Intersects(line1));
            Assert.IsTrue(rect.Intersects(line2));
            Assert.IsTrue(rect.Intersects(line3));
        }

        [TestMethod]
        public void Rect_Circle当たっていない()
        {
            var rect = new Rectangle(-3, -2, 4, 4);
            var c1 = new Circle(-7, 5, 3);
            var c2 = new Circle(-1, -4, 1);
            var c3 = new Circle(4, 1, 2);

            Assert.IsFalse(rect.Intersects(c1));
            Assert.IsFalse(rect.Intersects(c2));
            Assert.IsFalse(rect.Intersects(c3));
        }

        [TestMethod]
        public void Rect_Circle当たっている()
        {
            var rect = new Rectangle(-3, -2, 4, 4);
            var c1 = new Circle(-7, 5, 7);
            var c2 = new Circle(-1, -2, 1);
            var c3 = new Circle(3, 1, 2);
            var c4 = new Circle(-1, 0, 3);

            Assert.IsTrue(rect.Intersects(c1));
            Assert.IsTrue(rect.Intersects(c2));
            Assert.IsTrue(rect.Intersects(c3));
            Assert.IsTrue(rect.Intersects(c4));
        }

        [TestMethod]
        public void Rect_Triangle当たっていない()
        {
            var rect = new Rectangle(-3, -2, 4, 4);
            var t1 = new Triangle(-6, -4, -2, -4, -6, 1);
            var t2 = new Triangle(-4, 2, 2, 3, -4, 3);
            var t3 = new Triangle(2, -4, 4, -4, 4, -2);

            Assert.IsFalse(rect.Intersects(t1));
            Assert.IsFalse(rect.Intersects(t2));
            Assert.IsFalse(rect.Intersects(t3));
        }

        [TestMethod]
        public void Rect_Triangle当たっている()
        {
            var rect = new Rectangle(-3, -2, 4, 4);
            var t1 = new Triangle(-6, -4, -1, -4, -6, 1);
            var t2 = new Triangle(-4, 1, 5, 3, -4, 3);
            var t3 = new Triangle(-6, -4, 4, -4, 3, 5);

            Assert.IsTrue(rect.Intersects(t1));
            Assert.IsTrue(rect.Intersects(t2));
            Assert.IsTrue(rect.Intersects(t3));
        }

        [TestMethod]
        public void Circle_Circle当たっていない()
        {
            var circles = new[]
            {
                new Circle(-1, -2, 1),
                new Circle(2, 0, 2),
                new Circle(-3, 2, 3)
            };

            for (int i = 0; i < circles.Length; i++)
            {
                for (int j = 0; j < circles.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    Assert.IsFalse(circles[i].Intersects(circles[j]));
                }
            }
        }

        [TestMethod]
        public void Circle_Circle当たっている()
        {
            var c1 = new Circle(0, -1, 1);
            var c2 = new Circle(2, 0, 2);
            var c3 = new Circle(-4, 2, 4);

            Assert.IsTrue(c1.Intersects(c2));
            Assert.IsTrue(c1.Intersects(c3));
        }

        [TestMethod]
        public void Circle_Line当たっていない()
        {
            var circle = new Circle(-1, -1, 2);
            var lines = new[]
            {
                new Line(-4, -2, -2, 2),
                new Line(2, 2, 2, -4),
                new Line(-2, -3, 0, -4)
            };

            foreach (var line in lines)
            {
                Assert.IsFalse(circle.Intersects(line));
            }
        }

        [TestMethod]
        public void Circle_Line当たっている()
        {
            var circle = new Circle(-1, -1, 2);
            var lines = new[]
            {
                new Line(-2, -4, -3, 1),
                new Line(-3, 2, 2, -3),
                new Line(0, -2, 1, -4)
            };

            foreach (var line in lines)
            {
                Assert.IsTrue(circle.Intersects(line));
            }
        }

        [TestMethod]
        public void Circle_Triangle当たっていない()
        {
            var circle = new Circle(-1, -1, 2);
            var triangles = new[]
            {
                new Triangle(-4, -2, -2, 2, -4, 2),
                new Triangle(0, 2, 2, -1, 4, 2),
                new Triangle(2, -3, 1, -4, 4, -5)
            };

            foreach (var triangle in triangles)
            {
                Assert.IsFalse(circle.Intersects(triangle));
            }
        }

        [TestMethod]
        public void Circle_Triangle当たっている()
        {
            var circle = new Circle(-1, -1, 2);
            var triangles = new[]
            {
                new Triangle(-4, -2, -1, 2, -4, 2),
                new Triangle(-2, 1, 2, -1, 4, 2),
                new Triangle(-3, 1, 4, -5, -2, 2)
            };

            foreach (var triangle in triangles)
            {
                Assert.IsTrue(circle.Intersects(triangle));
            }
        }

        [TestMethod]
        public void Line_Line当たっていない()
        {
            var lines = new[]
            {
                new Line(-1, -1, 2, 1),
                new Line(1, 0, 2, -1),
                new Line(-3, -1, 1, -2),
                new Line(0, 1, -1, 2)
            };

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    Assert.IsFalse(lines[i].Intersects(lines[j]));
                }
            }
        }

        [TestMethod]
        public void Line_Line当たっている()
        {
            var target1 = new Line(0, -2, -2, 1);
            var l1 = new Line(-1, -2, 1, -1);

            Assert.IsTrue(target1.Intersects(l1));

            var target2 = new Line(-1, 3, 4, -1);
            var l2 = new Line(1, 1, 3, 1);
            var l3 = new Line(3, -1, 5, 2);

            Assert.IsTrue(target2.Intersects(l2));
            Assert.IsTrue(target2.Intersects(l3));
        }

        [TestMethod]
        public void Line_Triangle当たっていない()
        {
            var triangle = new Triangle(-2, 1, 0, -2, 1, 2);

            var lines = new[]
            {
                new Line(-2, -1, 1, -3),
                new Line(1, -2, 1, 1),
                new Line(-3, 0, -2, 2)
            };

            foreach(var line in lines)
            {
                Assert.IsFalse(triangle.Intersects(line));
            }
        }

        [TestMethod]
        public void Line_Triangle当たっている()
        {
            var triangle = new Triangle(-3, 1, 0, 3, 3, 0);

            var lines = new[]
            {
                new Line(-2, 1, 1, -3),
                new Line(1, -2, 1, 1),
                new Line(-3, 0, -2, 2)
            };

            foreach (var line in lines)
            {
                Assert.IsTrue(triangle.Intersects(line));
            }
        }

        [TestMethod]
        public void Triangle_Triangle当たっていない()
        {
            var target = new Triangle(-1, 0, 1, -3, 3, -1);
            var triangles = new[]
            {
                new Triangle(-3, 1, -2, -4, -1, 2),
                new Triangle(0, 0, 3, 0, 1, 2),
                new Triangle(2, -3, 3, -3, 3, -2)
            };
            
            foreach(var triangle in triangles)
            {
                Assert.IsFalse(target.Intersects(triangle));
            }
        }

        [TestMethod]
        public void Triangle_Triangle当たっている()
        {
            var target = new Triangle(-1, 0, 1, -3, 3, -1);
            var triangles = new[]
            {
                new Triangle(-3, 1, -2, -4, 4, 1),
                new Triangle(0, -1, 3, 0, 1, 2),
                new Triangle(2, -3, 3, -3, 3, -1)
            };

            foreach (var triangle in triangles)
            {
                Assert.IsTrue(target.Intersects(triangle));
            }
        }
    }
}
