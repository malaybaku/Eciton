using System;

namespace Eciton
{
    /// <summary>値を手続き的に保持できるメモリを表します。</summary>
    public class EcitonVariable<T> : EcitonObject
        where T : EcitonObject
    {
        public EcitonVariable()
        {
            _getter = new EcitonVariableGetter<T>(this);
            _setter = new EcitonVariableSetter<T>(this);
        }

        private T _content;

        public T Value
        {
            get
            {
                if (_content == null)
                {
                    throw new EcitonVariableNotInitializedException();
                }
                return _content;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                _content = value;
            }
        }

        private readonly EcitonVariableGetter<T> _getter;
        private readonly EcitonVariableSetter<T> _setter;

        public IEcitonOut<T> Getter => _getter;
        public IEcitonOut<EcitonVariable<T>> Setter => _setter;

        public override object Eval() => Value;

        class EcitonVariableGetter<U> : IEcitonOut<U>
            where U : EcitonObject
        {
            public EcitonVariableGetter(EcitonVariable<U> source)
            {
                _source = source;
            }
            private readonly EcitonVariable<U> _source;

            public U Send() => _source.Value;
        }

        class EcitonVariableSetter<U> : IEcitonOut<EcitonVariable<U>>
            where U : EcitonObject
        {
            public EcitonVariableSetter(EcitonVariable<U> target)
            {
                _target = target;
            }

            private readonly EcitonVariable<U> _target;

            public EcitonVariable<U> Send() => _target;
        }
    }

}
