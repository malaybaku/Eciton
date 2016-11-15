using System.Runtime.Serialization;

namespace Eciton
{
    [DataContract]
    public class EcitonString : EcitonValue<string>
    {
        public EcitonString(string val) : base(val)
        {
        }

        public static implicit operator string(EcitonString v) => v.Value;
        public static implicit operator EcitonString(string v) => new EcitonString(v);
    }
}
