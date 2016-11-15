using System;
using System.Runtime.Serialization;

namespace Eciton
{
    /// <summary>Ecitonの関数引数を受け取る標準的な入力端子を表します。</summary>
    /// <typeparam name="T">引数</typeparam>
    [DataContract]
    public class EcitonIn<T> : IEcitonInImpl<T>
    {
        public void Connect(IEcitonOut<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            _source = source;
        }
        public void Disconnect()
        {
            _source = null;
        }

        /// <summary>既定値あるいはケーブル接続先から入力値を取得します。</summary>
        /// <returns>入力値。入力が必須ではなく入力線が存在しない場合はあらかじめ設定した既定値を返します。</returns>
        public T Pull()
        {
            //必要な入力がない
            if (_source == null)
            {
                throw new EcitonInNotAssignedException();
            }
            return _source.Send();
        }

        [DataMember]
        private IEcitonOut<T> _source;
    }


}
