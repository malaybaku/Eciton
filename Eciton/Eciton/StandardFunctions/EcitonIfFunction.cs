using System;

namespace Eciton
{
    public class EcitonIfFunction : EcitonObject
    {
        public IEcitonIn<bool> Condition => _condition;
        public IEcitonIn<object> Then => _then;
        public IEcitonIn<object> Else => _else;

        private readonly IEcitonInImpl<bool> _condition 
            = new EcitonIn<bool>();

        private readonly IEcitonInImpl<object> _then
            = new EcitonInWithDefault<object>(new EcitonIn<object>(), EcitonEmpty.Empty);

        private readonly IEcitonInImpl<object> _else 
            = new EcitonInWithDefault<object>(new EcitonIn<object>(), EcitonEmpty.Empty);

        public override object Eval()
            => (_condition.Pull()) ? _then.Pull() : _else.Pull();
    }

    public class EcitonInWithDefault<T> : IEcitonInImpl<T>
    {
        public EcitonInWithDefault(IEcitonInImpl<T> ecitonIn, IEcitonOut<T> defaultOut)
        {
            _ecitonIn = ecitonIn;
        }

        private readonly IEcitonInImpl<T> _ecitonIn;

        private IEcitonInImpl<T> _defaultValue = new EcitonIn<T>();
        public IEcitonIn<T> DefaultValue => _defaultValue;

        private IEcitonOut<T> _source;

        public void Connect(IEcitonOut<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            _source = source;
            _ecitonIn.Connect(source);
        }
        public void Disconnect()
        {
            _source = null;
            _ecitonIn.Disconnect();
        }

        public T Pull()
            => (_source == null) ? _defaultValue.Pull() : _ecitonIn.Pull();
    }
    
}
