using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagram;

namespace DiagramTest
{
    public static class DiagramTestUtility<T>
    {
        public static void Move(IDiagram<T> diagram)
        {
            var position = diagram.Center;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var preDiagram = (IDiagram<T>)diagram.Clone();

                    position += new Vector2D(x, y);
                    diagram.MoveBy(x, y);

                    Assert.AreEqual(position, diagram.Center);

                    Assert.AreEqual(diagram, preDiagram.MovedBy(x, y));
                }
            }
        }
    }
}
