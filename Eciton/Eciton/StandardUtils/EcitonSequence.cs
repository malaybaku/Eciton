using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Eciton
{

    /// <summary>登録された処理を複文のスタイルで順に実行し、最後に実行した値を返却する関数を表します。</summary>
    [DataContract]
    public class EcitonSequence : EcitonObject
    {
        //TODO: ほんとはList相当な処理が欲しい？
        [DataMember]
        private readonly List<EcitonObject> _process = new List<EcitonObject>();

        [IgnoreDataMember]
        public int SequenceLength => _process.Count;

        public void Add(EcitonObject statement) => _process.Add(statement);
        public void Insert(int position, EcitonObject statement)
        {
            if (position >= SequenceLength)
            {
                Add(statement);
            }
            else
            {
                _process.Insert(position, statement);
            }
        }

        //TODO: 途中でのreturnとかがうまく捌けてない点に留意せよ。
        public override object Eval()
        {
            object result = EcitonEmpty.Empty;
            foreach (var elem in _process)
            {
                result = elem.Eval();
            }
            return result;
        }


    }
}
