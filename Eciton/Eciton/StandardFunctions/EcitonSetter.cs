using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Eciton
{
    [DataContract]
    public class EcitonSetter<T> : EcitonObject
    {
        [DataMember]
        private readonly IEcitonInImpl<T> _source = new EcitonIn<T>();
        [DataMember]
        private readonly IEcitonPushImpl<T> _target = new EcitonPush<T>();

        public IEcitonIn<T> Source => _source;
        public IEcitonPush<T> Target => _target;

        public override object Eval()
        {
            _target.Push(_source.Pull());
            //NOTE: いまは空値を返しているが、setした値を流す手もあることに注意(代入式の手口)
            return EcitonEmpty.Empty;
        }
    }

    [DataContract]
    public class EcitonPush<T> : IEcitonPushImpl<T>
    {
        [DataMember]
        private HashSet<IEcitonReceive<T>> _receivers = new HashSet<IEcitonReceive<T>>();

        public void Connect(IEcitonReceive<T> receiver)
        {
            if (receiver == null) throw new ArgumentNullException();
            _receivers.Add(receiver);
        }

        public void Disconnect(IEcitonReceive<T> receiver)
        {
            if (receiver == null) throw new ArgumentNullException();
            _receivers.Remove(receiver);
        }

        public void Push(T value)
        {
            foreach (var receiver in _receivers)
            {
                receiver.Receive(value);
            }
        }
    }
}
