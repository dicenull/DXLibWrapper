using Utilities;
using DxLibDLL;
using DxLibUtilities;

namespace Diagram
{
    public partial class Circle
    {
        public void Draw(Color color)
        {
            DxDrawer.Instance.AddDiagram(this, color, true);
        }

        public void DrawFrame(Color color)
        {
            DxDrawer.Instance.AddDiagram(this, color, false);
        }
    }
}
