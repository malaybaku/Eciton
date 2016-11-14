using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eciton
{
    public class EcitonTupleFunction<T1, T2> : EcitonFunc<T1, T2, Tuple<T1, T2>>
    {
        public EcitonTupleFunction() 
            : base((item1, item2) => Tuple.Create(item1, item2))
        {
        }
    }

    public class EcitonTupleFunction<T1, T2, T3> : EcitonFunc<T1, T2, T3, Tuple<T1, T2, T3>>
    {
        public EcitonTupleFunction() 
            : base((item1, item2, item3) => Tuple.Create(item1, item2, item3))
        {
        }
    }
}
