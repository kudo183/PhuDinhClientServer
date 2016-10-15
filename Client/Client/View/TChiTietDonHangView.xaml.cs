using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for TChiTietDonHangView.xaml
    /// </summary>
    public partial class TChiTietDonHangView : BaseView<DTO.TChiTietDonHangDto>
    {
        public TChiTietDonHangView() : base()
        {
            InitializeComponent();

            var vm = new TChiTietDonHangViewModel();

            InitView(vm, gridView);
        }
    }
}
