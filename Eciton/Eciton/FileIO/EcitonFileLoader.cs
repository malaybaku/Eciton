using System.IO;
using System.Runtime.Serialization;

namespace Eciton.IO
{
    /// <summary>EcitonのプログラムをJSONファイルからロードするクラスを表します。</summary>
    public class EcitonFileLoader
    {
        public object LoadFromXml(string fileName)
        {
            var serializer = new NetDataContractSerializer();
            using (var sw = new StreamReader(fileName))
            {
                return serializer.Deserialize(sw.BaseStream);
            }
        }
    }
}
