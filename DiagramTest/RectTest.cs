using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagram;

namespace DiagramTest
{
    using Rect = Rect<int>;
    using Point = Vector2D<int>;

    [TestClass]
    public class RectTest
    {
        [TestMethod]
        public void コンストラクタ()
        {
            var r1 = new Rect(1, 2);
            var r2 = new Rect(r1);
            Assert.IsTrue(r1.Equals(r2));

            r1 = new Rect(1, 1, 1, 2);
            r2 = new Rect(new Point(1, 1), 1, 2);
            Assert.AreEqual(r1, r2);

            var size = new Point(4, 4);
            r1 = new Rect(new Point(0, 0), size);
            Assert.AreEqual(r1, new Rect(2,0, size, Location.Top));
        }
        
    }
}
