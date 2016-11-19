using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EcitonEditor
{
    public class MainWindowViewModel : EcitonViewModelBase
    {
        public MainWindowViewModel()
        {
            //dummy
            EcitonObjects.Add(new EcitonObjectViewModel());
            EcitonObjects.Add(new EcitonObjectViewModel());

            foreach(var eo in EcitonObjects)
            {
                eo.TerminalSelected += OnEcitonObjectTerminalSelected;
            }
        }

        private EcitonTerminalViewModelBase _focusTerminal = null;

        private void OnEcitonObjectTerminalSelected(object sender, EcitonTerminalSelectedEventArgs e)
        {
            //パターンは3個くらい。
            //1. 無選択状態でなんか選んだ
            //2. 選択済み状態でさらに選び、有効な組み合わせによって配線
            //3. 選択済み状態だが無効な組み合わせを選び、何もなかったことに

            //1
            if (_focusTerminal == null)
            {
                _focusTerminal = e.Source;
                return;
            }

            //2
            //TODO: これ、In/OutとPush/Receiveをあまり区別していない挙動だけど直さないと動かない？
            if (_focusTerminal is EcitonInViewModel && e.Source is EcitonOutViewModel)
            {
                EcitonEdges.Add(new EcitonEdgeViewModel(_focusTerminal, e.Source));
            }
            else if (_focusTerminal is EcitonOutViewModel && e.Source is EcitonInViewModel)
            {
                EcitonEdges.Add(new EcitonEdgeViewModel(e.Source, _focusTerminal));
            }
            else if (_focusTerminal is EcitonPushViewModel && e.Source is EcitonReceiveViewModel)
            {
                EcitonEdges.Add(new EcitonEdgeViewModel(_focusTerminal, e.Source));
            }
            else if (_focusTerminal is EcitonReceiveViewModel && e.Source is EcitonPushViewModel)
            {
                EcitonEdges.Add(new EcitonEdgeViewModel(e.Source, _focusTerminal));
            }
            else
            {
                //3. 無効組み合わせ
            }

            _focusTerminal = null;
       }

        //NOTE: BlendでふつうにCallMethodできるからコマンド要らないような気がする。
        public ICommand SaveFileCommand { get; }
        public ICommand LoadFileCommand { get; }
        public ICommand CloseCommand { get; }

        //これは実装自体は難しくないハズ(というかVMで工夫必要になったらおかしい)
        public ICommand RunProgramCommand { get; }

        private EcitonCustomObjectViewModel _currentProgram;
        public EcitonCustomObjectViewModel CurrentProgram
        {
            get { return _currentProgram; }
            set
            {
                if(_currentProgram != value)
                {
                    _currentProgram = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<EcitonObjectViewModel> EcitonObjects { get; }
            = new ObservableCollection<EcitonObjectViewModel>();

        public ObservableCollection<EcitonEdgeViewModel> EcitonEdges { get; }
            = new ObservableCollection<EcitonEdgeViewModel>();

    }

    public class ActionCommand : ICommand
    {
        public ActionCommand(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }
            _target = action;
        }
        private readonly Action _target;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _target();

    }
}
