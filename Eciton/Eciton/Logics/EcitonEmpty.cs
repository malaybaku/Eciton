using System.Runtime.Serialization;

namespace Eciton
{
    [DataContract]
    public sealed class EcitonEmpty : EcitonObject, IEcitonOut<EcitonEmpty>, IEcitonOut<EcitonObject>, IEcitonOut<object>
    {
        private EcitonEmpty() { }

        [IgnoreDataMember]
        //NOTE: 無駄な生成に見えるかもしれないがDataContract的にこっちのほうが見通しがいい
        public static EcitonEmpty Empty => new EcitonEmpty();

        EcitonEmpty IEcitonOut<EcitonEmpty>.Send() => this;
        EcitonObject IEcitonOut<EcitonObject>.Send() => this;
        object IEcitonOut<object>.Send() => this;

        public override object Eval() => Empty;

        public override bool Equals(object obj) => (obj is EcitonEmpty);
        public override int GetHashCode() => 0;
    }
}
