using System;
using System.Windows;
using Eciton;
using Eciton.IO;

namespace EcitonContoleSample
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

            var ioCable1 = new EcitonIOCable<EcitonString>(readLine, setter.Source);
            var prCable1 = new EcitonPRCable<EcitonString>(setter.Setter, nameVar);
            var ioCable2 = new EcitonIOCable<EcitonString>(nameVar, showMsg.Arg1);

            mainSeq.Eval();

            //ファイル保存ためしてみようぜ！
            new EcitonFileSaver().Save("test.xml", new EcitonObject[]
            {
                //すべて線でつながってるのでこれで保存できるとｳﾚｼｲﾅｰ
                mainSeq
            });
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
