using Utilities;
using DxLibDLL;

namespace Graphics
{
    public partial class Triangle
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
