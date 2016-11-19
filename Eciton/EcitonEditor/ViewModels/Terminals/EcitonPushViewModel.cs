namespace EcitonEditor
{
    /// <summary>データ押し込みを行う端子のビューモデルです。</summary>
    public class EcitonPushViewModel : EcitonTerminalViewModelBase
    {
        public EcitonPushViewModel(EcitonObjectViewModel parent, int index)
            : base(parent,
                  EcitonTerminalOffsetCalculator.GetOffsetX(EcitonTerminalTypes.Push, index),
                  EcitonTerminalOffsetCalculator.GetOffsetY(EcitonTerminalTypes.Push, index)
                  )
        { }
    }
}
