namespace Eciton
{
    public class EcitonPushAdapter<T, U> : EcitonPush<U>, IEcitonReceive<T>
        where T : U
    {
        /// <summary>受信したデータをより一般的なデータ型にキャストして送信します。</summary>
        /// <param name="data"></param>
        public void Receive(T data) => Push(data);
    }
}
