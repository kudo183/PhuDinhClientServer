using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RLoaiHangView.xaml
    /// </summary>
    public partial class RLoaiHangView : BaseView<DTO.RLoaiHangDto>
    {
        public RLoaiHangView() : base()
        {
            InitializeComponent();

            var vm = new RLoaiHangViewModel();

            InitView(vm, gridView);
        }
    }
}
