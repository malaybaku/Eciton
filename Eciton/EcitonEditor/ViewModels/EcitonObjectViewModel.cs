using System;
using System.Collections.ObjectModel;
using Reactive.Bindings;
using System.Linq;
using System.Collections.Generic;

namespace EcitonEditor
{
    /// <summary>EcitonEditorでノードとして配置される要素を表します。</summary>
    public class EcitonObjectViewModel : EcitonViewModelBase
    {
        public EcitonObjectViewModel()
        {
            //dummy to test.
            EcitonIn.Add(new EcitonInViewModel(this, 0));
            EcitonIn.Add(new EcitonInViewModel(this, 1));

            EcitonOut.Add(new EcitonOutViewModel(this, 0));
            EcitonOut.Add(new EcitonOutViewModel(this, 1));

            EcitonReceiver.Add(new EcitonReceiveViewModel(this, 0));
            EcitonReceiver.Add(new EcitonReceiveViewModel(this, 1));

            EcitonPush.Add(new EcitonPushViewModel(this, 0));
            EcitonPush.Add(new EcitonPushViewModel(this, 1));

            foreach(var t in _terminals)
            {
                t.Selected += OnEcitonTerminalSelected;
            }
        }

        private void OnEcitonTerminalSelected(object sender, EventArgs e)
        {
            TerminalSelected?.Invoke(
                this, new EcitonTerminalSelectedEventArgs(sender as EcitonTerminalViewModelBase)
                );
        }

        //private double _x;
        //private double _y;

        ///// <summary>グラフィック的にノード左端の位置を表します。</summary>
        //public double X
        //{
        //    get { return _x; }
        //    set
        //    {
        //        if (value != _x)
        //        {
        //            _x = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
        //        }
        //    }
        //}
        ///// <summary>グラフィック的なノード上端の位置を表します。</summary>
        //public double Y
        //{
        //    get { return _y; }
        //    set
        //    {
        //        if (value != _y)
        //        {
        //            _y = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
        //        }
        //    }
        //}

        public ReactiveProperty<double> X { get; } = new ReactiveProperty<double>();
        public ReactiveProperty<double> Y { get; } = new ReactiveProperty<double>();

        //TODO: EO自身がIn/Out/Push/Receive実装している場合は下のOCとは別に扱うべきだよなあ…

        /// <summary>入力端子の一覧を取得します。</summary>
        public ObservableCollection<EcitonInViewModel> EcitonIn { get; }
            = new ObservableCollection<EcitonInViewModel>();
        /// <summary>出力端子の一覧を取得します。</summary>
        public ObservableCollection<EcitonOutViewModel> EcitonOut { get; }
            = new ObservableCollection<EcitonOutViewModel>();
        /// <summary>データ押し込み端子一覧を取得します。</summary>
        public ObservableCollection<EcitonPushViewModel> EcitonPush { get; }
            = new ObservableCollection<EcitonPushViewModel>();
        /// <summary>押し込みデータの受信端子一覧を取得します。</summary>
        public ObservableCollection<EcitonReceiveViewModel> EcitonReceiver { get; }
            = new ObservableCollection<EcitonReceiveViewModel>();

        private IEnumerable<EcitonTerminalViewModelBase> _terminals
            => EcitonIn
            .Concat<EcitonTerminalViewModelBase>(EcitonOut)
            .Concat(EcitonPush)
            .Concat(EcitonReceiver);

        public event EventHandler<EcitonTerminalSelectedEventArgs> TerminalSelected;
    }

    public class EcitonTerminalSelectedEventArgs : EventArgs
    {
        public EcitonTerminalSelectedEventArgs(EcitonTerminalViewModelBase vm)
        {
            Source = vm;
        }

        public EcitonTerminalViewModelBase Source { get; }
    }
}
