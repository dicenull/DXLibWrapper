using System.Collections.Generic;
using System.Threading.Tasks;
using DxLibDLL;
using Utilities;
using DxLibUtilities;
using System;

namespace Graphics
{
    public class DxDrawer
    {
        public static DxDrawer Instance { get; } = new DxDrawer();

        private DxDrawer() { }

        public void DrawDiagram(IDiagram diagram, Color color, bool isFill)
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

        public void DrawTexture(Texture texture, Vector2D pos)
        {
            var scale = texture.Scale;
            var degree = texture.Degree;
            var handle = texture.Handle;
            var scaledSize = texture.ScaledSize;

            var center = pos + scaledSize / 2;

            if (degree % 360 == 0)
            {
                DX.DrawExtendGraph(pos.X, pos.Y, pos.X + scaledSize.X, pos.Y + scaledSize.Y, handle, DX.TRUE);
            }
            else
            {
                DX.DrawRotaGraph3(center.X, center.Y, scaledSize.X / 2, scaledSize.X / 2,
                                scale.w, scale.h, Math.PI / 180.0 * degree, handle, DX.TRUE);
            }
        }
    }
}
