using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for TDonHangView.xaml
    /// </summary>
    public partial class TDonHangView : BaseView<DTO.TDonHangDto>
    {
        public TDonHangView() : base()
        {
            InitializeComponent();

            var vm = new TDonHangViewModel();

            InitView(vm, gridView);
        }
    }
}
