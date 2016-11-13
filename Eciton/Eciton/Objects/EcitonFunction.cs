using System;

namespace Eciton
{
    /// <summary>Ecitonの標準的な関数を表します。</summary>
    /// <typeparam name="T">戻り値</typeparam>
    public class EcitonFunc<T> : EcitonObject, IEcitonOut<T>
    {
        public EcitonFunc(Func<T> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException();
            }
            _func = func;
        }

        private readonly Func<T> _func;

        public override object Eval() => Send();

        public T Send() => _func();
    }

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

        private IEcitonCable<T> _cable;

        public T PullArg()
        {
            if (_cable == null)
            {
                throw new EcitonCableNotAssignedException();
            }
            if (_cable.Source == null)
            {
                throw new EcitonCableSourceNullException();
            }

            return _cable.Source.Send();
        }
    }

    /// <summary>Ecitonの標準的な関数を表します。</summary>
    /// <typeparam name="TArg1">引数</typeparam>
    /// <typeparam name="T">戻り値</typeparam>
    public class EcitonFunc<TArg1, T> : EcitonObject, IEcitonOut<T>
    {
        public EcitonFunc(Func<TArg1, T> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException();
            }
            _func = func;
        }

        private readonly Func<TArg1, T> _func;
        protected readonly EcitonFuncArgument<TArg1> _arg1 = new EcitonFuncArgument<TArg1>();

        public IEcitonIn<TArg1> Arg1 => _arg1;

        public T Send() => _func(_arg1.PullArg());

        public override object Eval() => Send();
    }

    /// <summary>Ecitonの標準的な関数を表します。</summary>
    /// <typeparam name="TArg1">引数</typeparam>
    /// <typeparam name="TArg2">引数</typeparam>
    /// <typeparam name="T">戻り値</typeparam>
    public class EcitonFunc<TArg1, TArg2, T> : EcitonObject, IEcitonOut<T>
    {
        public EcitonFunc(Func<TArg1, TArg2, T> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException();
            }
            _func = func;
        }

        private readonly Func<TArg1, TArg2, T> _func;
        protected readonly EcitonFuncArgument<TArg1> _arg1 = new EcitonFuncArgument<TArg1>();
        protected readonly EcitonFuncArgument<TArg2> _arg2 = new EcitonFuncArgument<TArg2>();

        public IEcitonIn<TArg1> Arg1 => _arg1;
        public IEcitonIn<TArg2> Arg2 => _arg2;

        public T Send() => _func(_arg1.PullArg(), _arg2.PullArg());

        public override object Eval() => Send();
    }

    /// <summary>Ecitonの標準的な関数を表します。</summary>
    /// <typeparam name="TArg1">引数</typeparam>
    /// <typeparam name="TArg2">引数</typeparam>
    /// <typeparam name="TArg3">引数</typeparam>
    /// <typeparam name="T">戻り値</typeparam>
    public class EcitonFunc<TArg1, TArg2, TArg3, T> : EcitonObject, IEcitonOut<T>
    {
        public EcitonFunc(Func<TArg1, TArg2, TArg3, T> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException();
            }
            _func = func;
        }

        private readonly Func<TArg1, TArg2, TArg3, T> _func;
        protected readonly EcitonFuncArgument<TArg1> _arg1 = new EcitonFuncArgument<TArg1>();
        protected readonly EcitonFuncArgument<TArg2> _arg2 = new EcitonFuncArgument<TArg2>();
        protected readonly EcitonFuncArgument<TArg3> _arg3 = new EcitonFuncArgument<TArg3>();

        public IEcitonIn<TArg1> Arg1 => _arg1;
        public IEcitonIn<TArg2> Arg2 => _arg2;
        public IEcitonIn<TArg3> Arg3 => _arg3;

        public T Send() => _func(_arg1.PullArg(), _arg2.PullArg(), _arg3.PullArg());

        public override object Eval() => Send();
    }


}
