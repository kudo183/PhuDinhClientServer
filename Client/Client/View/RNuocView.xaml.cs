using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RNuocView.xaml
    /// </summary>
    public partial class RNuocView : BaseView<DTO.RNuocDto>
    {
        public RNuocView() : base()
        {
            InitializeComponent();

            var vm = new RNuocViewModel();

            InitView(vm, gridView);
        }
    }
}
