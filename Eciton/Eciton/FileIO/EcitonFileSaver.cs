using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Eciton.IO
{
    /// <summary>Ecitonのプログラムを保存するオブジェクトを表します。</summary>
    public class EcitonNetXmlFileSaver
    {
        public void Save(string fileName, EcitonObject saveObj)
        {
            var serializer = new NetDataContractSerializer();
            using (var sw = new StreamWriter(fileName))
            {
                serializer.Serialize(sw.BaseStream, saveObj);
            }
        }
    }
}
