
namespace DxLogic
{
    public class SceneManager<T>
    {
        private SceneBase<T> currentScene;
        
        public SceneManager(SceneBase<T> startScene)
        {
            currentScene = startScene;
        }

        public void UpdateAndDraw()
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
