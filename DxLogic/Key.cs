using System;
using DxLibDLL;

namespace DxLogic
{
    public class Key : IInput<ConsoleKey>
    {
        public Key()
        {
            Update();
        }

        public bool IsDown(ConsoleKey key)
        {
            return keys[prev][key.ToCode()] == 0 && keys[flip][key.ToCode()] != 0;
        }

        public bool IsPressed(ConsoleKey key)
        {
            return keys[flip][key.ToCode()] != 0;
        }

        public bool IsRelease(ConsoleKey key)
        {
            return keys[flip][key.ToCode()] == 0;
        }

        public bool IsUp(ConsoleKey key)
        {
            return keys[prev][key.ToCode()] != 0 && keys[flip][key.ToCode()] == 0;
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
