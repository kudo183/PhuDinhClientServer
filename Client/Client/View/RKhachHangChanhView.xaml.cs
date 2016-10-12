using Client.Abstraction;
using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RKhachHangChanhView.xaml
    /// </summary>
    public partial class RKhachHangChanhView : BaseView<DTO.RKhachHangChanhDto>
    {
        public RKhachHangChanhView() : base()
        {
            InitializeComponent();

            var vm = new RKhachHangChanhViewModel();

            InitView(vm, gridView);
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
