using System;
using System.Runtime.Serialization;

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
    
    [DataContract]
    public class EcitonInWithDefault<T> : IEcitonInImpl<T>
    {
        public EcitonInWithDefault(IEcitonInImpl<T> ecitonIn, IEcitonOut<T> defaultOut)
        {
            if (ecitonIn == null || defaultOut == null) throw new ArgumentNullException();

            _ecitonIn = ecitonIn;
            DefaultValue.Connect(defaultOut);
        }

        [DataMember]
        private readonly IEcitonInImpl<T> _ecitonIn;

        [DataMember]
        private IEcitonInImpl<T> _defaultValue = new EcitonIn<T>();
        public IEcitonIn<T> DefaultValue => _defaultValue;

        public void Connect(IEcitonOut<T> source) => _ecitonIn.Connect(source);
        public void Disconnect() => _ecitonIn.Disconnect();
        public bool IsConnected => _ecitonIn.IsConnected;

        public T Pull() => (_ecitonIn.IsConnected) ? _ecitonIn.Pull() : _defaultValue.Pull();
    }
    
}
