namespace Eciton
{
    /// <summary>何かしらのデータを自発的に出力する端子を定義します。</summary>
    /// <typeparam name="T">出力可能な値</typeparam>
    public interface IEcitonPush<T>
    {
        void Connect(IEcitonReceive<T> receiver);
        void Disconnect(IEcitonReceive<T> receiver);
    }

    /// <summary><see cref="IEcitonPush{T}"/>について、値を押し出す処理を定義します。</summary>
    /// <typeparam name="T"></typeparam>
    public interface IEcitonPushable<T>
    {
        void Push(T data);
    }

    public interface IEcitonPushImpl<T> : IEcitonPush<T>, IEcitonPushable<T>
    {
    }

    /// <summary>何かしらのデータを自発的に出力する端子を定義します。</summary>
    /// <typeparam name="T">出力可能な値</typeparam>
    public interface IEcitonReceive<T>
    {
        void Receive(T data);
    }
}
