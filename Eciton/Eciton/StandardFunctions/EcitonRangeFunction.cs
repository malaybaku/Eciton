using System.Collections.Generic;

namespace Eciton
{
    public class EcitonRangeFunction : EcitonFunc<EcitonInt, EcitonInt, EcitonInt, IEnumerable<EcitonInt>>
    {
        public EcitonRangeFunction() : base((start, end, step) => new EcitonRange(start, end, step))
        {
        }        
    }
}
