using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagram;
using DxLibDLL;
using DxLibUtilities;
using Utilities;

namespace Diagram
{
    public class DxDrawer
    {
        public static DxDrawer Instance { get; } = new DxDrawer();

        private List<(IDiagram diagram, Color color, bool isFill)> drawDiagrams
            = new List<(IDiagram, Color, bool)>();

        private DxDrawer() { }

        private void drawDiagram(IDiagram diagram, Color color, bool isFill)
        {
            int fillFlag = (isFill) ? 1 : 0;

            switch (diagram)
            {
                case Line l:
                    DX.DrawLine(l.Begin.X, l.Begin.Y, l.End.X, l.End.Y, color.ToDxColor());
                    break;

                case Rectangle r:
                    int x = r.TopLeft.X, y = r.TopLeft.Y;
                    int w = r.Size.w, h = r.Size.h;

                    DX.DrawBox(x, y, x + w, y + h, color.ToDxColor(), fillFlag);
                    break;

                case Circle c:
                    DX.DrawCircle(c.Center.X, c.Center.Y, c.Radius, color.ToDxColor(), fillFlag);
                    break;

                case Triangle t:
                    DX.DrawTriangle(
                        t.Pos0.X, t.Pos0.Y,
                        t.Pos1.X, t.Pos1.Y,
                        t.Pos2.X, t.Pos2.Y, color.ToDxColor(), fillFlag);
                    break;
            }
        }

        public void Draw()
        {
            DX.ClearDrawScreen();

            foreach (var drawData in drawDiagrams)
            {
                drawDiagram(drawData.diagram, drawData.color, drawData.isFill);
            }

            drawDiagrams.Clear();
        }

        public void AddDiagram(IDiagram diagram, Color color, bool isFill)
        {
            drawDiagrams.Add((diagram, color, isFill));
        }
    }
}
