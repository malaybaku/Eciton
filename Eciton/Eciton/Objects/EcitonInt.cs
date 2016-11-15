using System.Runtime.Serialization;

namespace Eciton
{
    [DataContract]
    public class EcitonInt : EcitonValue<int>
    {
        public EcitonInt(int val) : base(val)
        {
        }

        public static implicit operator int(EcitonInt v) => v.Value;
        public static implicit operator EcitonInt(int v) => new EcitonInt(v);
    }
}
