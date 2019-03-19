using Utilities;
using DxLibDLL;

namespace Graphics
{
    /// <summary>
    /// 四角形クラス描画部
    /// </summary>
    public partial class Rectangle
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
