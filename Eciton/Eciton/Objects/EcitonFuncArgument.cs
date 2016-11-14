using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: 設計問題あり、デフォルト値もケーブル+ソースオブジェクトでうまくさばけないか？

namespace Eciton
{
    /// <summary>Ecitonの関数引数を受け取る標準的な入力端子を表します。</summary>
    /// <typeparam name="T">引数</typeparam>
    public class EcitonFuncArgument<T> : IEcitonIn<T>
    {
        public void Connect(IEcitonCable<T> cable)
        {
            if (cable == null)
            {
                throw new ArgumentNullException();
            }
            _cable = cable;
        }

        public void Disconnect()
        {
            _cable = null;
        }

        /// <summary>入力端子への入力が必須であるかどうかを取得、設定します。</summary>
        public bool IsConnectionRequired { get; set; }

        /// <summary>入力が必須でないとき、入力が存在しない際の既定値を取得、設定します。</summary>
        public T DefaultValue
        {
            get { return _defaultValue; }
            set { _isDefaultValueAssigned = true; _defaultValue = value; }
        }

        private T _defaultValue;
        private bool _isDefaultValueAssigned;

        private bool HasValidInputSource => _cable?.Source != null;
        private bool HasValidDefaultValue => _isDefaultValueAssigned;

        /// <summary>既定値あるいはケーブル接続先から入力値を取得します。</summary>
        /// <returns>入力値。入力が必須ではなく入力線が存在しない場合はあらかじめ設定した既定値を返します。</returns>
        public T PullArg()
        {
            //必要な入力がない
            if (_cable == null && IsConnectionRequired)
            {
                throw new EcitonCableNotAssignedException();
            }
            if (_cable.Source == null && IsConnectionRequired)
            {
                throw new EcitonCableSourceNullException();
            }

            //既定値を許可しているがその既定値が未設定
            if (!HasValidInputSource && !IsConnectionRequired && !HasValidDefaultValue)
            {
                throw new EcitonDefaultInputNotInitializedException();
            }

            return HasValidInputSource ? _cable.Source.Send() : DefaultValue;
        }


        private IEcitonCable<T> _cable;

    }


}
