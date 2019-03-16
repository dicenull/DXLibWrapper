using System;
using Utilities;

namespace Diagram
{
    public interface IDiagram<T> : ICloneable
    {
        void MoveBy(int x, int y);
        void MoveBy(Vector2D vector);

        T MovedBy(int x, int y);
        T MovedBy(Vector2D vector);

        /// <summary>
        /// 図形の中心
        /// </summary>
        Vector2D Center { get; }
    }
}
