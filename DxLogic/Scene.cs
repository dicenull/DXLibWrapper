using DxLibDLL;

namespace DxLogic
{
    public abstract class SceneBase<T>
    {
        protected static T Data;

        public abstract SceneBase<T> Update();

        public abstract void Draw();
    }
}
