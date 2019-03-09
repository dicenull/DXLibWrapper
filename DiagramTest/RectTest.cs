using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagram;

namespace DiagramTest
{
    using Rect = Rectangle;
    using Point = Vector2D;

    [TestClass]
    public class RectTest
    {
        [TestMethod]
        public void 基本のコンストラクタ()
        {
            var r1 = new Rect(1, 2);
            var r2 = new Rect(r1);
            Assert.IsTrue(r1.Equals(r2), $"{r1} : {r2}");

            r1 = new Rect(1, 1, 1, 2);
            r2 = new Rect(new Point(1, 1), 1, 2);
            Assert.AreEqual(r1, r2);
        }

        [TestMethod]
        public void 原点の異なるコンストラクタ()
        {
            var size = new Point(4, 4);
            var r1 = new Rect(new Point(0, 0), size);
            Assert.AreEqual(r1, new Rect(2, 0, size, Location.TopCenter));
            Assert.AreEqual(r1, new Rect(4, 0, size, Location.TopRight));
            Assert.AreEqual(r1, new Rect(4, 2, size, Location.RightCenter));
            Assert.AreEqual(r1, new Rect(4, 4, size, Location.BottomRight));
            Assert.AreEqual(r1, new Rect(2, 4, size, Location.BottomCenter));
            Assert.AreEqual(r1, new Rect(0, 4, size, Location.BottomLeft));
            Assert.AreEqual(r1, new Rect(0, 2, size, Location.LeftCenter));
            Assert.AreEqual(r1, new Rect(2, 2, size, Location.Center));
        }

        [TestMethod]
        public void 大きさ()
        {
            int w = 5, h = 3;
            var rect = new Rect(w, h);

            Assert.AreEqual(w, rect.Size.w);
            Assert.AreEqual(h, rect.Size.h);
        }

        [TestMethod]
        public void 座標を変えても大きさは変わらない()
        {
            var size = (5, 3);
            var rect = new Rect(size);

            for(int x = -50; x <= 50; x++)
            {
                for (int y = -50; y < 50;y++)
                {
                    rect.Point = new Point(x, y);

                    Assert.AreEqual(size, rect.Size);
                }
            }
        }
        
        [TestMethod]
        public void 等価()
        {
            var point = new Point(-3, 5);
            var size = (4, 7);

            var r1 = new Rect(point, size);
            var r2 = new Rect(point, size);

            Assert.IsTrue(r1 == r2);
        }

        [TestMethod]
        public void 移動()
        {
            var rect = new Rect(size: (3, 5));

            var position = new Point(0, 0);
            for(int x = 0; x < 10;x++)
            {
                for(int y = 0;y < 10;y++)
                {
                    position += new Point(x, y);
                    rect.MoveBy(x, y);

                    Assert.AreEqual(position, rect.Point);
                }
            }
        }

        [TestMethod]
        public void 伸縮()
        {
            var pos = new Point(1, 3);
            (int x, int y) size = (5, 7);

            var rect = new Rect(point: pos, size: size);

            Assert.AreEqual(new Rect(pos - (1, 1), (size.x + 2, size.y + 2)), rect.Stretched(1));

            Assert.AreEqual(new Rect(pos - (1, 1), (size.x, size.y + 2)), rect.Stretched(1, -1, 1, 1));
        }
    }
}
