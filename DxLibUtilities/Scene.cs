using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DxLibUtilities
{
    public abstract class SceneBase<T>
    {
        protected static T Data;

        public abstract SceneBase<T> Update();

        protected abstract void draw();
        
        public void Draw()
        {
            DX.ClearDrawScreen();

            draw();

            DX.ScreenFlip();
        }
    }
}
