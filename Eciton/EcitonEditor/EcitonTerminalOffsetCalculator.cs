using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcitonEditor
{
    /// <summary>
    /// EcitonEditorで端子の左上から見て端子の位置のオフセットを求める処理を提供します。
    /// NOTE: この処理はViewデザインと一貫する必要があり、かつ利用者はViewModelである疎結合破壊処理であるため、
    ///         MVVM警察に見つかると怒られます。
    /// </summary>
    public static class EcitonTerminalOffsetCalculator
    {
        public static double GetOffsetX(EcitonTerminalTypes terminalType, int index) => 0;
        public static double GetOffsetY(EcitonTerminalTypes terminalType, int index) => 0;
    }

    public enum EcitonTerminalTypes
    {
        In,
        Out,
        Push,
        Receive
    }

}
