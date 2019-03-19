using Utilities;
using DxLibDLL;

namespace Graphics
{
    public partial class Line : IDiagram
    {
        public void Draw(Color color)
        {
            DxDrawer.Instance.DrawDiagram(this, color, false);
        }

        public void DrawFrame(Color color)
        {
            DxDrawer.Instance.DrawDiagram(this, color, false);
        }
    }
}
