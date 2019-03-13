using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DxLibUtilities
{
    public class Key : IInput
    {
        public Key()
        {
            Update();
        }

        public bool IsDown(int code)
        {
            return keys[code][prev] == 0 && keys[code][flip] != 0;
        }

        public bool IsPressed(int code)
        {
            return keys[code][flip] != 0;
        }

        public bool IsRelease(int code)
        {
            return keys[code][flip] == 0;
        }

        public bool IsUp(int code)
        {
            return keys[code][prev] != 0 && keys[code][flip] == 0;
        }

        public void Update()
        {
            flip = 1 - flip;
            
            DX.GetHitKeyStateAll(keys[flip]);
        }

        private byte[][] keys = { new byte[256], new byte[256] };
        private int flip = 0;
        private int prev { get { return 1 - flip; } }
    }
}
