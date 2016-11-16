using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Eciton
{
    /// <summary>内部がEcitonのグラフで構成されるようなオブジェクトを表します。</summary>
    [DataContract]
    public class EcitonCustomObject : EcitonObject, ICollection<EcitonObject>
    {
        //NOTE: プログラムとしての保存/ロード機能を考えると想定は以下の通り。
        //  1. EntryPointに繋がったグラフは_nodesに入って無くても保存できるかもしれないが、それに頼るのはダメ
        //  2. 想定としては_nodesにプログラムで使ってる全ノードを突っこんでもらう

        [DataMember]
        private readonly ICollection<EcitonObject> _nodes = new HashSet<EcitonObject>();
        [DataMember]
        private readonly IEcitonInImpl<object> _entryPoint 
            = new EcitonInWithDefault<object>(new EcitonIn<object>(), EcitonEmpty.Empty);

        [IgnoreDataMember]
        public IEcitonIn<object> EntryPoint => _entryPoint;

        public override object Eval() => _entryPoint.Pull();

        #region ICollection
        [IgnoreDataMember]
        public int Count => _nodes.Count;
        [IgnoreDataMember]
        public bool IsReadOnly => _nodes.IsReadOnly;

        public void Add(EcitonObject item) => _nodes.Add(item);
        public void Clear() => _nodes.Clear();
        public bool Contains(EcitonObject item) => _nodes.Contains(item);
        public void CopyTo(EcitonObject[] array, int arrayIndex) => _nodes.CopyTo(array, arrayIndex);
        public bool Remove(EcitonObject item) => _nodes.Remove(item);

        public IEnumerator<EcitonObject> GetEnumerator() => _nodes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _nodes.GetEnumerator();
        #endregion
    }
}
