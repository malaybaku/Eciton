using Reactive.Bindings;
using System;

namespace EcitonEditor
{
    public abstract class EcitonTerminalViewModelBase : EcitonViewModelBase
    {
        public EcitonTerminalViewModelBase(EcitonObjectViewModel parent, double offsetX, double offsetY)
        {
            OffsetX = offsetX;
            OffsetY = offsetY;

            parent.X.Subscribe(x => X.Value = OffsetX + x);
            parent.Y.Subscribe(y => Y.Value = OffsetY + y);
        }

        public double OffsetX { get; }
        public double OffsetY { get; }

        public void SelectTerminal() => Selected?.Invoke(this, EventArgs.Empty);
        public event EventHandler Selected;

        public ReactiveProperty<bool> IsSelected { get; } = new ReactiveProperty<bool>();

        public ReactiveProperty<double> X { get; } = new ReactiveProperty<double>();
        public ReactiveProperty<double> Y { get; } = new ReactiveProperty<double>();
    }


}
