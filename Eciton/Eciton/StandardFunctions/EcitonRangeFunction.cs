using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Eciton
{
    [DataContract]
    public class EcitonRangeFunction : EcitonFunc<EcitonInt, EcitonInt, EcitonInt, IEnumerable<EcitonInt>>
    {
        protected override IEnumerable<EcitonInt> Implement(EcitonInt start, EcitonInt end, EcitonInt step)
            => new EcitonRange(start, end, step);
    }
}
