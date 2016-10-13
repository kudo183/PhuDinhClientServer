using Client.Abstraction;
using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for TMatHangView.xaml
    /// </summary>
    public partial class TMatHangView : BaseView<DTO.TMatHangDto>
    {
        public TMatHangView() : base()
        {
            InitializeComponent();

            var vm = new TMatHangViewModel();

            InitView(vm, gridView);
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
