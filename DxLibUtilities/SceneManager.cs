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
        
        public SceneManager(SceneBase startScene)
        {
            currentScene = startScene;
        }

        public void Update()
        {
            currentScene.Draw();
            var nextScene = currentScene.Update();

            if(nextScene == null)
            {
                DxSystem.Exit();
            }

            currentScene = nextScene;
        }
    }
}
