using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eciton
{
    /// <summary>並列処理を表します。</summary>
    public class EcitonParallel : EcitonObject
    {
        //TODO: ほんとはList相当な処理が欲しい？
        private readonly List<EcitonObject> _process = new List<EcitonObject>();

        public int Count => _process.Count;

        public void Add(EcitonObject statement) => _process.Add(statement);
        public void Insert(int position, EcitonObject statement)
        {
            if (position >= Count)
            {
                Add(statement);
            }
            else
            {
                _process.Insert(position, statement);
            }
        }

        public override object Eval()
        {
            var result = new object[Count];
            var tasks = new Task[Count];
            for(int i = 0; i < Count; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    result[i] = _process[i].Eval();
                });
            }
            Task.WaitAll(tasks);
            return result;
        }

    }
}
