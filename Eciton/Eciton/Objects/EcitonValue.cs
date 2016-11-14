namespace Eciton
{
    /// <summary>
    /// 変化しない値を表します。
    /// 参照型を保持した場合、そのメンバーまでは不変にならないことに注意してください。
    /// </summary>
    /// <typeparam name="T">保持するデータの型</typeparam>
    public class EcitonValue<T> : EcitonObject, IEcitonOut<T>
    {
        public EcitonValue(T val)
        {
            Value = val;
        }

        public T Value { get; }

        public T Send() => Value;

        public override object Eval() => Value;
    }
}
