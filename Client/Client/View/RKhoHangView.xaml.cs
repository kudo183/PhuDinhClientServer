using Client.Abstraction;
using Client.ViewModel;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RKhoHangView.xaml
    /// </summary>
    public partial class RKhoHangView : BaseView<DTO.RKhoHangDto>
    {
        public RKhoHangView() : base("RKhoHangView")
        {
            InitializeComponent();
            
            var vm = new RKhoHangViewModel(new ProtoBufDataService<DTO.RKhoHangDto>("rkhohang"));

            InitView(vm, gridView);
        }
        
        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
