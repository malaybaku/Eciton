using System;
using System.Windows;
using Eciton;
using Eciton.IO;

namespace EcitonConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new EcitonCustomObject();

            var mainSeq = new EcitonSequence();
            program.Add(mainSeq);

            var readLine = new ReadLineFunc();
            program.Add(readLine);

            var setter = new EcitonSetter<EcitonString>();
            program.Add(setter);

            var showMsg = new ShowMessageFunc();
            program.Add(showMsg);

            var nameVar = new EcitonVariable<EcitonString>();
            program.Add(nameVar);

            mainSeq.Add(setter);
            mainSeq.Add(showMsg);

            setter.Source.Connect(readLine);
            setter.Target.Connect(nameVar);

            showMsg.Arg1.Connect(nameVar);

            program.EntryPoint.Connect(mainSeq.Evaluator);
            program.Eval();

            //ファイル保存
            new EcitonNetXmlFileSaver().Save("test2.xml", program);

            //ファイルロード(Evalさえできればいいのであまりキャストしないでいい。
            var reproduced = new EcitonFileLoader().LoadFromXml("test2.xml");
            reproduced?.Eval();
        }
    }

    public class ShowMessageFunc : EcitonFunc<EcitonString, EcitonEmpty>
    {
        protected override EcitonEmpty Implement(EcitonString arg1)
        {
            MessageBox.Show(arg1);
            return EcitonEmpty.Empty;
        }
    }

    public class ReadLineFunc : EcitonFunc<EcitonString>
    {
        protected override EcitonString Implement()
        {
            return Console.ReadLine();
        }
    }

}
