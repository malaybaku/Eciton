namespace Eciton
{
    public class EcitonString : EcitonObject, IEcitonOut<EcitonString>
    {
        public EcitonString(string value) { Value = value; }

        public string Value { get; }

        public EcitonString Send() => this;

        public override string ToString() => Value;

        public static implicit operator string(EcitonString v) => v.Value;
    }
}
