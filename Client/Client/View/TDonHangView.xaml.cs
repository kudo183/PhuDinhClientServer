using Client.Abstraction;
using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for TDonHangView.xaml
    /// </summary>
    public partial class TDonHangView : BaseView<DTO.TDonHangDto>
    {
        public TDonHangView() : base()
        {
            InitializeComponent();

            var vm = new TDonHangViewModel();

            InitView(vm, gridView);
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
