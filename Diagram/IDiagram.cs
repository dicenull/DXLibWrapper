using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public interface IDiagram<T>
    {
        void MoveBy(int x, int y);
        void MoveBy(Vector2D vector);

        T MovedBy(int x, int y);
        T MovedBy(Vector2D vector);
    }
}
