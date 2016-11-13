using System.Collections;
using System.Collections.Generic;

namespace Eciton
{
    public class EcitonRange : IEnumerable<EcitonInt>
    {
        public EcitonRange(int start, int end, int step)
        {
            Start = start;
            End = end;
            Step = step;
        }

        public int Start { get; }
        public int End { get; }
        public int Step { get; }

        public IEnumerator<EcitonInt> GetEnumerator()
            => new EcitonRangeEnumerator(Start, End, Step);

        IEnumerator IEnumerable.GetEnumerator()
            => new EcitonRangeEnumerator(Start, End, Step);
    }

    public class EcitonRangeEnumerator : IEnumerator<EcitonInt>
    {
        internal EcitonRangeEnumerator(int start, int end, int step)
        {
            _start = start;
            _end = end;
            _step = step;

            _current = start - step;
        }
        private readonly int _start;
        private readonly int _end;
        private readonly int _step;
        private int _current;

        public EcitonInt Current => new EcitonInt(_current);

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if ((_start <= _current + _step && _current + _step < _end && _step > 0) ||
                (_start >= _current + _step && _current + _step > _end && _step < 0))
            {
                _current += _step;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            //do nothing;
        }

        public void Reset()
        {
            _current = _start - _step;
        }
    }
}
