using System;
using System.Runtime.Serialization;

namespace Eciton
{
    /// <summary>プログラム内の要素として扱えるEcitonの値の基底型を表します。</summary>
    [DataContract]
    public class EcitonObject
    {
        /// <summary>
        /// プログラム上に要素として配置された際の
        /// デフォルトでの評価値を返します(値なら値自身、関数ならバインド済み引数を使った呼び出し、など)
        /// </summary>
        /// <returns>評価値</returns>
        public virtual object Eval() => this;

        [IgnoreDataMember]
        private EcitonObjectEvalOut _evaluator;
        [IgnoreDataMember]
        public IEcitonOut<object> Evaluator
            => _evaluator ?? (_evaluator = new EcitonObjectEvalOut(this));

        [DataContract]
        class EcitonObjectEvalOut : IEcitonOut<object>
        {
            public EcitonObjectEvalOut(EcitonObject obj)
            {
                _obj = obj;
            }
            [DataMember]
            private readonly EcitonObject _obj;
            public object Send() => _obj.Eval();
        }
    }
}
