using Client.Abstraction;
using Client.ViewModel;
using System.Windows;

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

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
