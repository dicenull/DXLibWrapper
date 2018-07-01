using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public struct Point<T> where T : struct
    {
        public static readonly Point<int> Zero = new Point<int>(0, 0);

        public T X { get; set; }
        public T Y { get; set; }
        
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }
        
        public Point(Point<T> size)
        {
            X = size.X;
            Y = size.Y;
        }
        
    }
}
