using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    using Unary = Func<ParameterExpression, UnaryExpression>;
    using Binary = Func<ParameterExpression, ParameterExpression, BinaryExpression>;
    
    public static class Operator<T>
    {
        /// <summary>
        /// 引数xの式
        /// </summary>
        static readonly ParameterExpression x = Expression.Parameter(typeof(T), "x");

        /// <summary>
        /// 引数yの式
        /// </summary>
        static readonly ParameterExpression y = Expression.Parameter(typeof(T), "y");
        
        /// <summary>
        /// 入力1,出力1のラムダ式を取得
        /// </summary>
        /// <param name="ex">演算子の元</param>
        /// <returns>ラムダ式</returns>
        private static Func<T, T> GetLambda(Unary ex)
        {
            return Expression.Lambda<Func<T, T>>(ex(x), x).Compile();
        }

        /// <summary>
        /// 入力2,出力1のラムダ式を取得
        /// </summary>
        /// <param name="ex">演算子の元</param>
        /// <returns>ラムダ式</returns>
        private static Func<T, T, T> GetLambda(Binary ex)
        {
            return Expression.Lambda<Func<T, T, T>>(ex(x, y), x, y).Compile();
        }
        
        public static readonly Func<T, T, T> Add = GetLambda(Expression.Add);
        public static readonly Func<T, T, T> Subtract = GetLambda(Expression.Subtract);
        public static readonly Func<T, T, T> Multiply = GetLambda(Expression.Multiply);
        public static readonly Func<T, T, T> Divide = GetLambda(Expression.Divide);
        public static readonly Func<T, T, T> Modulo = GetLambda(Expression.Modulo);
        public static readonly Func<T, T> Plus = GetLambda(Expression.UnaryPlus);
        public static readonly Func<T, T> Negate = GetLambda(Expression.Negate);
    }
}
