namespace Eciton
{
    /// <summary>Out端子の出力をアップキャストするアダプターです。</summary>
    /// <typeparam name="T">入力元端子からの出力データ型</typeparam>
    /// <typeparam name="U">出力先が要求しているデータ型</typeparam>
    public class EcitonOutAdapter<T, U> : EcitonIn<T>, IEcitonOut<U>
        where T : U
    {
        public U Send() => Pull();
    }
}
