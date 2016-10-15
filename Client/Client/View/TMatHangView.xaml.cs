using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for TMatHangView.xaml
    /// </summary>
    public partial class TMatHangView : BaseView<DTO.TMatHangDto>
    {
        public TMatHangView() : base()
        {
            InitializeComponent();

            var vm = new TMatHangViewModel();

            InitView(vm, gridView);
        }
    }
}
