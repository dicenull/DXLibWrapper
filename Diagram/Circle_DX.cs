using Utilities;
using DxLibDLL;

namespace Graphics
{
    public partial class Circle
    {
        public void Draw(Color color)
        {
            DxDrawer.Instance.DrawDiagram(this, color, true);
        }

        public void DrawFrame(Color color)
        {
            DxDrawer.Instance.DrawDiagram(this, color, false);
        }
    }
}
