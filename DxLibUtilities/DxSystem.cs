using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DxLibUtilities
{
    public static class DxSystem
    {
        public static bool Update()
        {
            if (DX.ProcessMessage() == -1)
            {
                return false;
            }

            if(!canUpdate)
            {
                return false;
            }

            InputManager.Update();

            return true;
        }

        public static void Exit()
        {
            canUpdate = false;
        }

        private static bool canUpdate = true;
    }
}
