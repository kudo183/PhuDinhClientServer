using Client.Abstraction;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RDiaDiemView.xaml
    /// </summary>
    public partial class RDiaDiemView : BaseView<DTO.RDiaDiemDto>
    {
        public RDiaDiemView() : base()
        {
            InitializeComponent();

            var vm = new RDiaDiemViewModel();

            InitView(vm, gridView);
        }
    }
}
