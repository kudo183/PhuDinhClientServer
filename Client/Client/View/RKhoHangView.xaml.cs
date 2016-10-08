using Client.Abstraction;
using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RKhoHangView.xaml
    /// </summary>
    public partial class RKhoHangView : BaseView<DTO.RKhoHangDto>
    {
        public RKhoHangView() : base()
        {
            InitializeComponent();
            
            var vm = new RKhoHangViewModel();

            InitView(vm, gridView);
        }
        
        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
