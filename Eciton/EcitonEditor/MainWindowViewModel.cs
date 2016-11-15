using System;
using System.Windows.Input;

namespace EcitonEditor
{
    public class MainWindowViewModel
    {
        public ICommand SaveFileCommand { get; }
        public ICommand LoadFileCommand { get; }
        //Livet入れないとやりづらいやつだっけコレ
        public ICommand CloseCommand { get; }

        //これは実装自体は難しくないハズ(というかVMで工夫必要になったらおかしい)
        public ICommand RunProgramCommand { get; }

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
