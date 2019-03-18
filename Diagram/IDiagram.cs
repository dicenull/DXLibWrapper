using System;
using Utilities;

namespace Diagram
{
    public interface IDiagram : ICloneable
    {
        void MoveBy(int x, int y);
        void MoveBy(Vector2D vector);

        IDiagram MovedBy(int x, int y);
        IDiagram MovedBy(Vector2D vector);

        /// <summary>
        /// 図形の中心
        /// </summary>
        Vector2D Center { get; }
    }
}
