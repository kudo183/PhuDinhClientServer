using Client.Abstraction;
using Client.ViewModel;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RNuocView.xaml
    /// </summary>
    public partial class RNuocView : BaseView<DTO.RNuocDto>
    {
        public RNuocView() : base("RNuocView")
        {
            InitializeComponent();
            
            var vm = new RNuocViewModel(new ProtoBufDataService<DTO.RNuocDto>("rnuoc"));

            InitView(vm, gridView);
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
