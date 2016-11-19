using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace EcitonEditor
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnEcitonObjectDragDelta(object sender, DragDeltaEventArgs e)
        {
            var vm = (sender as FrameworkElement)?.DataContext as EcitonObjectViewModel;
            if (vm == null) return;

            vm.X.Value += e.HorizontalChange;
            vm.Y.Value += e.VerticalChange;
        }
    }
}
