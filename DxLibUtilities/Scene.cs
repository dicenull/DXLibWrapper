using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DxLibUtilities
{
    public abstract class SceneBase
    {
        protected abstract SceneBase update();

        protected abstract void draw();

        public SceneBase()
        {
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.ChangeWindowMode(DX.TRUE);

            DX.DxLib_Init();
        }

        public void Draw()
        {
            DX.ClearDrawScreen();

            draw();

            DX.ScreenFlip();
        }

        public SceneBase Update()
        {
            if(DX.ProcessMessage() == -1)
            {
                throw new Exception("DX ERROR");
            }

            return update();
        }
    }
}
