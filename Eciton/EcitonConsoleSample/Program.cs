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
            var mainSeq = new EcitonSequence();

            var readLine = new ReadLineFunc();

            var setter = new EcitonSetter<EcitonString>();

            var showMsg = new ShowMessageFunc();

            var nameVar = new EcitonVariable<EcitonString>();

            mainSeq.Add(setter);
            mainSeq.Add(showMsg);

            setter.Source.Connect(readLine);
            setter.Setter.Connect(nameVar);

            showMsg.Arg1.Connect(nameVar);

            mainSeq.Eval();

            //ファイル保存ためしてみようぜ！
            new EcitonFileSaver().SaveAsXml("test.xml", new EcitonObject[]
            {
                //すべて線でつながってるのでこれで保存できるとｳﾚｼｲﾅｰ
                mainSeq
            });

            //さらにそれを読みだして使ってみる
            var loaded = new EcitonFileLoader().LoadFromXml("test.xml") as EcitonObject[];
            loaded[0].Eval();
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
