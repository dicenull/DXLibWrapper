using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxLibUtilities
{
    interface IInput
    {
        void Update();

        /// <summary>
        /// 押され始めたか
        /// </summary>
        bool IsDown(int code);

        /// <summary>
        /// 押されているか
        /// </summary>
        bool IsPressed(int code);

        /// <summary>
        /// 離され始めたか
        /// </summary>
        bool IsRelease(int code);

        /// <summary>
        /// 離されているか
        /// </summary>
        bool IsUp(int code);
    }
}
