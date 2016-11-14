namespace Eciton
{
    public class EcitonBool : EcitonObject, IEcitonOut<EcitonBool>
    {
        private EcitonBool(bool value) { Value = value; }

        public bool Value { get; }

        public EcitonBool Send() => this;

        public static EcitonBool True { get; } = new EcitonBool(true);
        public static EcitonBool False { get; } = new EcitonBool(false);

        public static implicit operator bool(EcitonBool v) => v.Value;
        public static implicit operator EcitonBool(bool v) => v ? True : False;
    }
}
