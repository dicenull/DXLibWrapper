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
            currentScene = scene;
        }

        public bool Update()
        {
            if(DX.ProcessMessage() == -1)
            {
                return false;
            }

            InputManager.Update();

            currentScene.Draw();
            var nextScene = currentScene.Update();

            if(nextScene == null)
            {
                return false;
            }

            currentScene = nextScene;
            return true;
        }
    }
}
