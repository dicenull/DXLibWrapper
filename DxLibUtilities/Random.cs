using DxLibDLL;

namespace DxLibUtilities
{
    public static class Random
    {
        /// <returns>0からint最大値までの乱数</returns>
        public static int Next()
        {
            return DX.GetRand(int.MaxValue);
        }

        /// <param name="maxValue">乱数の最大値</param>
        /// <returns>0から指定した値までの乱数</returns>
        public static int Next(int maxValue)
        {
            return DX.GetRand(maxValue);
        }

        /// <param name="minValue">乱数の最小値</param>
        /// <param name="maxValue">乱数の最大値</param>
        /// <returns>指定した範囲の乱数</returns>
        public static int Next(int minValue, int maxValue)
        {
            return DX.GetRand(maxValue - minValue) + minValue;
        }
    }
}
