using System;

namespace Eciton
{
    public class EcitonInt : EcitonObject, IEcitonOut<EcitonInt>
    {
        public EcitonInt(int value) { Value = value; }
        public int Value { get; }

        public EcitonInt Send() => this;

        public override string ToString() => Value.ToString();

        public static implicit operator int(EcitonInt v) => v.Value;
    }
}
