using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxLibUtilities
{
    public static class Input
    {
        public static Key Key { get; } = new Key();

        public static Mouse Mouse { get; } = new Mouse();

        public static void Update()
        {
            Key.Update();
            Mouse.Update();
        }
    }
}
