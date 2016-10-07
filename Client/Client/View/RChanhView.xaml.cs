using Client.Abstraction;
using Client.ViewModel;
using System.Windows;

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

            var vm = new RChanhViewModel(new ProtoBufDataService<DTO.RChanhDto>());

            InitView(vm, gridView);
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
