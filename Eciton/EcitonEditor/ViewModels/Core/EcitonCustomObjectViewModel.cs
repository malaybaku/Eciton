using System.Collections.ObjectModel;
using Eciton;

namespace EcitonEditor
{
    public class EcitonCustomObjectViewModel : EcitonViewModelBase
    {
        public EcitonCustomObjectViewModel(EcitonCustomObject model)
        {
            
        }

        public ObservableCollection<EcitonObjectViewModel> EcitonObjects { get; }
            = new ObservableCollection<EcitonObjectViewModel>();

        public ObservableCollection<EcitonEdgeViewModel> EcitonEdges { get; }
            = new ObservableCollection<EcitonEdgeViewModel>();
    }
}
