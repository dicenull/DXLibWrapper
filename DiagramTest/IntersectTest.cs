using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagram;

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
    }
}
