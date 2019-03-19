using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphics;
using Utilities;

namespace DiagramTest
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void コンストラクタ()
        {
            var triangle1 = new Triangle(new Vector2D(-2, -1), new Vector2D(0, 1), new Vector2D(2, 3));
            var triangle2 = new Triangle(-2, -1, 0, 1, 2, 3);

            Assert.IsTrue(triangle1 == triangle2);
        }

        [TestMethod]
        public void 移動()
        {
            DiagramTestUtility.Move(new Triangle(-2, 1, 0, 3, 2, -1));
        }
    }
}
