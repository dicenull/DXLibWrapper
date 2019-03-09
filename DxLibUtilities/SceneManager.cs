using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
