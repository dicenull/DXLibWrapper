using Utilities;
using DxLibDLL;
using DxLibUtilities;

namespace Diagram
{
    /// <summary>
    /// 四角形クラス描画部
    /// </summary>
    public partial class Rectangle
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
