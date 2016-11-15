using System;
using System.Runtime.Serialization;

namespace Eciton
{
    [DataContract]
    public class EcitonTupleFunction<T1, T2> : EcitonFunc<T1, T2, Tuple<T1, T2>>
    {
        protected override Tuple<T1, T2> Implement(T1 arg1, T2 arg2)
            => Tuple.Create(arg1, arg2);
    }

    [DataContract]
    public class EcitonTupleFunction<T1, T2, T3> : EcitonFunc<T1, T2, T3, Tuple<T1, T2, T3>>
    {
        protected override Tuple<T1, T2, T3> Implement(T1 arg1, T2 arg2, T3 arg3)
            => Tuple.Create(arg1, arg2, arg3); 
    }
}
