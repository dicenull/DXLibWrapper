namespace DxLogic
{
	/// <summary>
	/// シーン遷移のためのクラス
	/// </summary>
	/// <typeparam name="T">シーン間で共有するデータ</typeparam>
	public abstract class SceneBase<T>
    {
		protected static T Data;

        public abstract SceneBase<T> Update();

        public abstract void Draw();
    }
}
