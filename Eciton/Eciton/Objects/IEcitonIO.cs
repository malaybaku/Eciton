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
        /// <param name="cable">データを送る線</param>
        void Connect(IEcitonCable<T> cable);
        /// <summary>データ受信用の配線を取り外します。</summary>
        void Disconnect();
    }

    /// <summary>入出力を接続しデータを送信するケーブルを定義します。</summary>
    /// <typeparam name="T">送信するデータ</typeparam>
    public interface IEcitonCable<T>
    {
        /// <summary>データを出力する送信元を取得します。</summary>
        IEcitonOut<T> Source { get; }

        /// <summary>データ入力を待つ受信先を取得します。</summary>
        IEcitonIn<T> Target { get; }
    }

}
