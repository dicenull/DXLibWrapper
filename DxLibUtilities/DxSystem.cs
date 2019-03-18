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

            Input.Update();

            return true;
        }

        /// <summary>
        /// 指定した時間待つ
        /// </summary>
        /// <param name="ms">待つ時間[ミリ秒]</param>
        public static void Sleep(int ms)
        {
            DX.WaitTimer(ms);
        }
        
        public static void Exit()
        {
            canUpdate = false;
        }
        private static bool canUpdate = true;
    }
}
