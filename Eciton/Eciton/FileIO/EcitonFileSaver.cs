using System.IO;
using System.Runtime.Serialization;

namespace Eciton.IO
{
    /// <summary>Ecitonのプログラムを保存するオブジェクトを表します。</summary>
    public class EcitonFileSaver
    {
        public void SaveAsXml(string fileName, EcitonObject[] programs)
        {
            var serializer = new NetDataContractSerializer();
            using (var sw = new StreamWriter(fileName))
            {
                serializer.Serialize(sw.BaseStream, programs);
            }
        }
    }
}
