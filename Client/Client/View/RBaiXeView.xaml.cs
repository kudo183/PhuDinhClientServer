using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RBaiXeView.xaml
    /// </summary>
    public partial class RBaiXeView : BaseView<DTO.RBaiXeDto>
    {
        public RBaiXeView() : base()
        {
            InitializeComponent();
            
            var vm = new RBaiXeViewModel();

            InitView(vm, gridView);
        }
    }
}
