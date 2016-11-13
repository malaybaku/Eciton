using System;

namespace Eciton
{
    public class EcitonIfFunction : EcitonObject
    {
        public IEcitonIn<bool> Condition => _condition;
        public IEcitonIn<object> Then => _then;
        public IEcitonIn<object> Else => _else;

        private readonly EcitonFuncArgument<bool> _condition = new EcitonFuncArgument<bool>();
        private readonly EcitonNullableIn<object> _then = new EcitonNullableIn<object>(EcitonEmpty.Empty);
        private readonly EcitonNullableIn<object> _else = new EcitonNullableIn<object>(EcitonEmpty.Empty);

        public override object Eval()
            => (_condition.PullArg()) ?
            _then.GetValueOrDefault() :
            _else.GetValueOrDefault();
    }

    public class EcitonNullableIn<T> : IEcitonIn<T>
    {
        public EcitonNullableIn(T defaultValue)
        {
            _defaultValue = defaultValue;
        }

        private T _defaultValue;

        private IEcitonCable<T> _cable;

        public void Connect(IEcitonCable<T> cable)
        {
            if (cable == null)
            {
                throw new ArgumentNullException();
            }
            _cable = cable;
        }

        public void Disconnect()
        {
            _cable = null;
        }

        public T GetValueOrDefault()
        {
            if (_cable?.Source != null)
            {
                return _cable.Source.Send();
            }
            else
            {
                return _defaultValue;
            }
        }
    }
    
}
