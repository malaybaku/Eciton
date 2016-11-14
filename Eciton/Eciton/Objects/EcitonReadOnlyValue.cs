namespace Eciton
{
    /// <summary>
    /// 最初に呼ばれたときだけ指定された初期化元による初期化を行い、その後は値を更新しないデータを表します。
    /// 参照型を保持した場合、そのメンバーまでは不変にならないことに注意してください。
    /// </summary>
    /// <typeparam name="T">保持するデータの型</typeparam>
    public class EcitonReadOnlyValue<T> : EcitonObject, IEcitonOut<T>
    {
        public IEcitonIn<T> Source => _source;

        private EcitonFuncArgument<T> _source = new EcitonFuncArgument<T>();
        private bool _isInitialized = false;

        private T _readonlyValue;
        public T Value
        {
            get
            {
                if (!_isInitialized)
                {
                    _readonlyValue = _source.PullArg();
                    _isInitialized = true;
                }
                return _readonlyValue;
            }
        }

        public T Send() => Value;

        public override object Eval() => Value;
    }
}
