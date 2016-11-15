using System.Collections.Generic;

namespace Eciton
{
    public class EcitonForFunction<T> : EcitonObject
    {        
        private readonly IEcitonInImpl<IEnumerable<T>> _iterable
            = new EcitonIn<IEnumerable<T>>();

        private readonly IEcitonPushImpl<T> _foreach = new EcitonPush<T>();

        public IEcitonIn<IEnumerable<T>> In => _iterable;
        public IEcitonPush<T> ForEach => _foreach;

        public override object Eval()
        {
            foreach (var elem in _iterable.Pull())
            {
                _foreach.Push(elem);
            }
            //TODO: 最後に評価した値を返す方がカッコいいんじゃなかったっけ、というのとReceiverに終了を通知したいような。なんかいい手ないかなあ。
            return EcitonEmpty.Empty;
        }
    }

}
