namespace EcitonEditor
{
    /// <summary>出力端子のビューモデルです。</summary>
    public class EcitonOutViewModel : EcitonTerminalViewModelBase
    {
        public EcitonOutViewModel(EcitonObjectViewModel parent, int index)
            : base(parent,
                  EcitonTerminalOffsetCalculator.GetOffsetX(EcitonTerminalTypes.Out, index),
                  EcitonTerminalOffsetCalculator.GetOffsetY(EcitonTerminalTypes.Out, index)
                  )
        { }
    }
}
