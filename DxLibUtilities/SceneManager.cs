using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DxLibUtilities
{
    public class SceneManager
    {
        private SceneBase currentScene;
        
        public SceneManager(SceneBase scene)
        {
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.ChangeWindowMode(DX.TRUE);

            DX.DxLib_Init();

            currentScene = scene;
        }

        public bool Update()
        {
            
            if(DX.ProcessMessage() == -1)
            {
                DX.DxLib_End();
                return false;
            }
            InputManager.Update();

            currentScene.Draw();
            var nextScene = currentScene.Update();

            if(nextScene == null)
            {
                DX.DxLib_End();
                return false;
            }

            currentScene = nextScene;
            return true;
        }
    }
}
