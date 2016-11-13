namespace Eciton
{
    //public class EcitonWhileFunction : EcitonFunction
    //{
    //    public override bool IsArgumentCountFixed => true;
    //    public override int ArgumentCount => 2;

    //    public override void Bind(int index, EcitonObject source)
    //    {
    //        if (source == null || index >= ArgumentCount) return;

    //        if (index == 0)
    //        {
    //            _condition = source;
    //        }
    //        else //if (index == 1)
    //        {
    //            _loopContent = source;
    //        }
    //    }

    //    public IEcitonOut<EcitonBool> Condition { get; set; } = EcitonBool.False;
    //    private EcitonObject _loopContent = EcitonEmpty.Empty;

    //    public override EcitonObject Eval()
    //    {
    //        if (!(_condition is EcitonBool))
    //        {
    //            return EcitonEmpty.Empty;
    //        }

    //        EcitonObject result = EcitonEmpty.Empty;
    //        while ((_condition as EcitonBool).Value)
    //        {
    //            EcitonObject current = _loopContent.Eval();
    //            if (current == EcitonConst.Break)
    //            {
    //                break;
    //            }

    //            result = current;
    //        }

    //        return result;
    //    }
    //}
}
