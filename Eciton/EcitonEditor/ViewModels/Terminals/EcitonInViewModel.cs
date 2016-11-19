using System;

namespace EcitonEditor
{
    /// <summary>入力端子のビューモデルです。</summary>
    public class EcitonInViewModel : EcitonTerminalViewModelBase
    {
        public EcitonInViewModel(EcitonObjectViewModel parent, int index)
            : base(parent,
                  EcitonTerminalOffsetCalculator.GetOffsetX(EcitonTerminalTypes.In, index),
                  EcitonTerminalOffsetCalculator.GetOffsetY(EcitonTerminalTypes.In, index)
                  )
        { }
    }
}
