using System;
using System.Runtime.Serialization;

namespace Eciton
{
    /// <summary>値を手続き的に保持できる変数を表します。</summary>
    [DataContract]
    public class EcitonVariable<T> : EcitonObject, IEcitonOut<T>, IEcitonReceive<T>
       // where T : EcitonObject
    {
        public EcitonVariable()
        {
            _content = default(T);
            _isInitialized = false;
        }

        private T _content;
        private bool _isInitialized = false;

        /// <summary>現在格納している値を取得、設定します。</summary>
        [IgnoreDataMember] //NOTE: 保持値はプログラム実行するまで初期状態のままなのでファイル保存は絶対に不要
        public T Value
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new EcitonVariableNotInitializedException();
                }
                return _content;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                _content = value;
                _isInitialized = true;
            }
        }

        public T Send() => Value;
        public void Receive(T data) => Value = data;

        public override object Eval() => Value;

    }

}
