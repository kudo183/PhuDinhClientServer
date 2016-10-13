using Client.Abstraction;
using Client.ViewModel;
using System.Windows;

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

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
