using Utilities;
using DxLibDLL;
using DxLibUtilities;

namespace Diagram
{
    public partial class Line : IDiagram
    {
        public void Draw(Color color)
        {
            DxDrawer.Instance.AddDiagram(this, color, false);
        }

        public void DrawFrame(Color color)
        {
            DxDrawer.Instance.AddDiagram(this, color, false);
        }
    }
}
