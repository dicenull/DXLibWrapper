
namespace DxLogic
{
	/// <summary>
	/// シーン遷移を管理する
	/// </summary>
	/// <typeparam name="T">シーン間で共有するデータ</typeparam>
    public class SceneManager<T>
    {
        private SceneBase<T> currentScene;
        
        public SceneManager(SceneBase<T> startScene)
        {
            currentScene = startScene;
        }

		/// <summary>
		/// 描画処理がして、次のシーンに更新する
		/// </summary>
        public void DrawAndUpdate()
        {
			Draw(); Update();
        }

		public void Draw()
		{
			currentScene.Draw();
		}

		public void Update()
		{
			var nextScene = currentScene.Update();

			if (nextScene == null)
			{
				DxSystem.Exit();
			}

			currentScene = nextScene;
		}
    }
}
