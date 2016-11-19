using Reactive.Bindings;
using System.Windows;
using System;

namespace EcitonEditor
{
    /// <summary>EcitonEditorでノードどうしをつなぐ線を表します。</summary>
    public class EcitonEdgeViewModel : EcitonViewModelBase
    {

        public EcitonEdgeViewModel(EcitonTerminalViewModelBase src, EcitonTerminalViewModelBase dest)
        {
            Source = src;
            Dest = dest;

            StartPos.Value = new Point(Source.X.Value, Source.Y.Value);
            EndPos.Value = new Point(Dest.X.Value, Dest.Y.Value);

            Source.X.Subscribe(x =>
            {
                if (x != StartPos.Value.X)
                {
                    StartPos.Value = new Point(x, StartPos.Value.Y);
                }
            });
            Source.Y.Subscribe(y =>
            {
                if (y != StartPos.Value.Y)
                {
                    StartPos.Value = new Point(StartPos.Value.X, y);
                }
            });
            Dest.X.Subscribe(x =>
            {
                if (x != EndPos.Value.X)
                {
                    EndPos.Value = new Point(x, EndPos.Value.Y);
                }
            });
            Dest.Y.Subscribe(y =>
            {
                if (y != EndPos.Value.Y)
                {
                    EndPos.Value = new Point(EndPos.Value.X, y);
                }
            });
        }

        public ReactiveProperty<Point> StartPos { get; } = new ReactiveProperty<Point>();
        public ReactiveProperty<Point> EndPos { get; } = new ReactiveProperty<Point>();

        public EcitonTerminalViewModelBase Source { get; }
        public EcitonTerminalViewModelBase Dest { get; }
    }
}
