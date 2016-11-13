using System.Collections.Generic;

namespace Eciton
{
    public class EcitonForFunction<T> : EcitonObject
    {        
        private readonly EcitonFuncArgument<IEnumerable<T>> _iterable = new EcitonFuncArgument<IEnumerable<T>>();
        private readonly EcitonNullableIn<object> _foreach = new EcitonNullableIn<object>(EcitonEmpty.Empty);
        private readonly EcitonVariableOut<T> _current = new EcitonVariableOut<T>();

        public IEcitonIn<IEnumerable<T>> In => _iterable;
        public IEcitonIn<object> ForEach => _foreach;
        public IEcitonOut<T> Current => _current;


        public override object Eval()
        {
            try
            {
                var iterable = _iterable.PullArg();
                foreach (var elem in iterable)
                {
                    _current.Value = elem;
                    _foreach.GetValueOrDefault();
                }

                //TODO: 最後に評価した値を返す方がカッコいいんじゃなかったっけか
                return EcitonEmpty.Empty;
            }
            finally
            {
                //GC対策
                _current.Value = default(T);
            }
        }
    }

    public class EcitonVariableOut<T> : IEcitonOut<T>
    {
        public T Value { get; set; } = default(T);

        public T Send() => Value;
    }



    //public class EcitonForFunction<EO, TRes> : EcitonObject
    //{
    //    public IEcitonOut<IEcitonIterator<EO>> IterableSource { get; set; }
    //    public EcitonFunction<EO, TRes> IterationProcess { get; set; }

    //    public EO Current { get; }

    //    public override IEcitonOut<IEcitonIterator<EO>> Arg1
    //    {
    //        set { IterableSource = value; }
    //    }

    //    public override IEcitonOut<EcitonFunction<EO, TRes>> Arg2
    //    {
    //        set { IterationProcess = value; }
    //    }

    //    private EO _current;

    //    public override TRes Call()
    //    {
    //        throw new NotImplementedException();
    //        var iterator = IterableSource.Send();

    //        while (iterator.MoveNext())
    //        {
    //            _current = iterator.Current;
    //        }
    //    }

    //}
}
