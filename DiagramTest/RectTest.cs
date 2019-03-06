using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagram;

namespace DiagramTest
{
    using Rect = Rectangle<int>;
    using Point = Vector2D<int>;

    [TestClass]
    public class RectTest
    {
        [TestMethod]
        public void コンストラクタ()
        {
            var r1 = new Rect(1, 2);
            var r2 = new Rect(r1);
            Assert.IsTrue(r1.Equals(r2), $"{r1} : {r2}");

            r1 = new Rect(1, 1, 1, 2);
            r2 = new Rect(new Point(1, 1), 1, 2);
            Assert.AreEqual(r1, r2);

            var size = new Point(4, 4);
            r1 = new Rect(new Point(0, 0), size);
            Assert.AreEqual(r1, new Rect(2, 0, size, Location.TopCenter));
            Assert.AreEqual(r1, new Rect(4, 0, size, Location.TopRight));
            Assert.AreEqual(r1, new Rect(4, 2, size, Location.RightCenter));
            Assert.AreEqual(r1, new Rect(4, 4, size, Location.BottomRight));
            Assert.AreEqual(r1, new Rect(2, 4, size, Location.BottomCenter));
            Assert.AreEqual(r1, new Rect(0, 4, size, Location.BottomLeft));
            Assert.AreEqual(r1, new Rect(0, 2, size, Location.LeftCenter));
            Assert.AreEqual(r1, new Rect(2, 2, size, Location.Center));
        }
    }
}
