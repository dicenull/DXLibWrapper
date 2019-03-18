using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagram;
using Utilities;

namespace DiagramTest
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void コンストラクタ()
        {
            var line1 = new Line(1, 0, -1, 2);
            var line2 = new Line(new Vector2D(1, 0), new Vector2D(-1, 2));

            Assert.IsTrue(line1 == line2);
        }
        
        [TestMethod]
        public void 移動()
        {
            DiagramTestUtility.Move(new Line(1, 0, -1, 2));
        }

        [TestMethod]
        public void 距離()
        {
            var begin = new Vector2D(-1, -1);
            var end = new Vector2D(2, 3);
            var line = new Line(begin, end);

            Assert.AreEqual(new Vector2D(end.X - begin.X, end.Y - begin.Y), line.Vector());
        }

        [TestMethod]
        public void 反転()
        {
            var line = new Line(-1, 1, 2, -3);
            
            Assert.AreEqual(line, line.Reversed().Reversed());

            var preLine = new Line(line);
            line.Reverse();
            Assert.AreEqual(line, preLine.Reversed());
        }
    }
}
