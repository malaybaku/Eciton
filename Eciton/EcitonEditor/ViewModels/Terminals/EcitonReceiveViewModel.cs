namespace EcitonEditor
{
    /// <summary>押し込みデータを受信する端子のビューモデルです。</summary>
    public class EcitonReceiveViewModel : EcitonTerminalViewModelBase
    {
        public EcitonReceiveViewModel(EcitonObjectViewModel parent, int index)
            : base(parent,
                  EcitonTerminalOffsetCalculator.GetOffsetX(EcitonTerminalTypes.Receive, index),
                  EcitonTerminalOffsetCalculator.GetOffsetY(EcitonTerminalTypes.Receive, index)
                  )
        { }

    }
}
