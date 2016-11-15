using System.Runtime.Serialization;

namespace Eciton
{
    /// <summary>Ecitonの標準的な関数を表します。</summary>
    /// <typeparam name="T">戻り値</typeparam>
    [DataContract]
    public abstract class EcitonFunc<T> : EcitonObject, IEcitonOut<T>
    {
        protected abstract T Implement();

        public T Send() => Implement();
        public override object Eval() => Send();
    }

    /// <summary>Ecitonの標準的な関数を表します。</summary>
    /// <typeparam name="TArg1">引数</typeparam>
    /// <typeparam name="T">戻り値</typeparam>
    [DataContract]
    public abstract class EcitonFunc<TArg1, T> : EcitonObject, IEcitonOut<T>
    {
        protected abstract T Implement(TArg1 arg1);

        [DataMember]
        protected readonly IEcitonInImpl<TArg1> _arg1 = new EcitonIn<TArg1>();
        public IEcitonIn<TArg1> Arg1 => _arg1;

        public T Send() => Implement(_arg1.Pull());
        public override object Eval() => Send();
    }

    /// <summary>Ecitonの標準的な関数を表します。</summary>
    /// <typeparam name="TArg1">引数</typeparam>
    /// <typeparam name="TArg2">引数</typeparam>
    /// <typeparam name="T">戻り値</typeparam>
    [DataContract]
    public abstract class EcitonFunc<TArg1, TArg2, T> : EcitonObject, IEcitonOut<T>
    {
        protected abstract T Implement(TArg1 arg1, TArg2 arg2);

        [DataMember]
        protected readonly IEcitonInImpl<TArg1> _arg1 = new EcitonIn<TArg1>();
        [DataMember]
        protected readonly IEcitonInImpl<TArg2> _arg2 = new EcitonIn<TArg2>();
        public IEcitonIn<TArg1> Arg1 => _arg1;
        public IEcitonIn<TArg2> Arg2 => _arg2;

        public T Send() => Implement(_arg1.Pull(), _arg2.Pull());
        public override object Eval() => Send();
    }

    /// <summary>Ecitonの標準的な関数を表します。</summary>
    /// <typeparam name="TArg1">引数</typeparam>
    /// <typeparam name="TArg2">引数</typeparam>
    /// <typeparam name="TArg3">引数</typeparam>
    /// <typeparam name="T">戻り値</typeparam>
    [DataContract]
    public abstract class EcitonFunc<TArg1, TArg2, TArg3, T> : EcitonObject, IEcitonOut<T>
    {
        protected abstract T Implement(TArg1 arg1, TArg2 arg2, TArg3 arg3);

        [DataMember]
        protected readonly IEcitonInImpl<TArg1> _arg1 = new EcitonIn<TArg1>();
        [DataMember]
        protected readonly IEcitonInImpl<TArg2> _arg2 = new EcitonIn<TArg2>();
        [DataMember]
        protected readonly IEcitonInImpl<TArg3> _arg3 = new EcitonIn<TArg3>();

        public IEcitonIn<TArg1> Arg1 => _arg1;
        public IEcitonIn<TArg2> Arg2 => _arg2;
        public IEcitonIn<TArg3> Arg3 => _arg3;

        public T Send() => Implement(_arg1.Pull(), _arg2.Pull(), _arg3.Pull());
        public override object Eval() => Send();
    }

    /// <summary>Ecitonの標準的な関数を表します。</summary>
    /// <typeparam name="TArg1">引数</typeparam>
    /// <typeparam name="TArg2">引数</typeparam>
    /// <typeparam name="TArg3">引数</typeparam>
    /// <typeparam name="TArg4">引数</typeparam>
    /// <typeparam name="T">戻り値</typeparam>
    [DataContract]
    public abstract class EcitonFunc<TArg1, TArg2, TArg3, TArg4, T> : EcitonObject, IEcitonOut<T>
    {
        protected abstract T Implement(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);

        [DataMember]
        protected readonly IEcitonInImpl<TArg1> _arg1 = new EcitonIn<TArg1>();
        [DataMember]
        protected readonly IEcitonInImpl<TArg2> _arg2 = new EcitonIn<TArg2>();
        [DataMember]
        protected readonly IEcitonInImpl<TArg3> _arg3 = new EcitonIn<TArg3>();
        [DataMember]
        protected readonly IEcitonInImpl<TArg4> _arg4 = new EcitonIn<TArg4>();

        public IEcitonIn<TArg1> Arg1 => _arg1;
        public IEcitonIn<TArg2> Arg2 => _arg2;
        public IEcitonIn<TArg3> Arg3 => _arg3;
        public IEcitonIn<TArg4> Arg4 => _arg4;

        public T Send() => Implement(_arg1.Pull(), _arg2.Pull(), _arg3.Pull(), _arg4.Pull());
        public override object Eval() => Send();
    }

}
