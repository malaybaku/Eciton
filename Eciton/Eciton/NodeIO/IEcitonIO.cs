namespace Eciton
{
    /// <summary>何かしらのデータ出力が可能な端子を定義します。</summary>
    /// <typeparam name="T">出力可能な値</typeparam>
    public interface IEcitonOut<T>
    {
        /// <summary>要求されると値を返します。</summary>
        /// <returns>端子からの出力値</returns>
        T Send();
    }

    /// <summary>何かしらのデータ入力を受け付ける端子を定義します。</summary>
    /// <typeparam name="T">受信したい値</typeparam>
    public interface IEcitonIn<T>
    {
        /// <summary>データ受信用の配線を接続します。</summary>
        /// <param name="source">データの送信元</param>
        void Connect(IEcitonOut<T> source);
        /// <summary>データ受信用の配線を取り外します。</summary>
        void Disconnect();

        /// <summary>出力に対して既に何かの端子が接続済みであるかを取得します。<summary>
        bool IsConnected { get; }
    }

    /// <summary><see cref="IEcitonIn{T}"/>の使用者から見たインターフェースで、値の取得処理が追加で必要となります。</summary>
    /// <typeparam name="T">データ内容</typeparam>
    public interface IEcitonInImpl<T> : IEcitonIn<T>
    {
        /// <summary>必要になったデータを取得します。</summary>
        /// <returns>送信元あるいはデフォルト値などのデータ</returns>
        T Pull();
    }
}
