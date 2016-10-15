using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RKhoHangView.xaml
    /// </summary>
    public partial class RKhoHangView : BaseView<DTO.RKhoHangDto>
    {
        public RKhoHangView() : base()
        {
            InitializeComponent();
            
            var vm = new RKhoHangViewModel();

            InitView(vm, gridView);
        }
    }
}
