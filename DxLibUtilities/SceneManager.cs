using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxLibUtilities
{
    public class SceneManager
    {
        private IScene currentScene;
        
        public SceneManager(IScene scene)
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
