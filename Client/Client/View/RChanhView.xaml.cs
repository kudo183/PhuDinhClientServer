using Client.Abstraction;
using Client.ViewModel;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RChanhView.xaml
    /// </summary>
    public partial class RChanhView : BaseView<DTO.RChanhDto>
    {
        public RChanhView() : base("RChanhView")
        {
            InitializeComponent();

            var vm = new RChanhViewModel(new ProtoBufDataService<DTO.RChanhDto>("RChanh"));

            InitView(vm, gridView);
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
