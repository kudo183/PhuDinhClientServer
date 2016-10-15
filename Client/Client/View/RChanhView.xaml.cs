using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RChanhView.xaml
    /// </summary>
    public partial class RChanhView : BaseView<DTO.RChanhDto>
    {
        public RChanhView() : base()
        {
            InitializeComponent();

            var vm = new RChanhViewModel();

            InitView(vm, gridView);
        }
    }
}
