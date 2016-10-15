using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RKhachHangView.xaml
    /// </summary>
    public partial class RKhachHangView : BaseView<DTO.RKhachHangDto>
    {
        public RKhachHangView() : base()
        {
            InitializeComponent();

            var vm = new RKhachHangViewModel();

            InitView(vm, gridView);
        }
    }
}
