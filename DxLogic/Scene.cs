using DxLibDLL;

namespace DxLogic
{
    public abstract class SceneBase<T>
    {
        protected static T Data;

        public abstract SceneBase<T> Update();

        protected abstract void draw();
        
        public void Draw()
        {
            DX.ClearDrawScreen();

            draw();

            DX.ScreenFlip();
        }
    }
}
