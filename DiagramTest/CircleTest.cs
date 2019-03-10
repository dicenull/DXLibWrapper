using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagram;

namespace DiagramTest
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void コンストラクタ()
        {
            Assert.IsTrue(new Circle(1, -2, 3) == new Circle(new Vector2D(1, -2), 3));
        }

        [TestMethod]
        public void 移動()
        {
            DiagramTestUtility<Circle>.Move(new Circle(1, -2, 3));
        }
    }
}
