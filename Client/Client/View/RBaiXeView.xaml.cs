using Client.Abstraction;
using Client.ViewModel;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RBaiXeView.xaml
    /// </summary>
    public partial class RBaiXeView : BaseView<DTO.RBaiXeDto>
    {
        public RBaiXeView() : base("RBaiXeView")
        {
            InitializeComponent();
            
            var vm = new RBaiXeViewModel(new ProtoBufDataService<DTO.RBaiXeDto>("RBaiXe"));

            InitView(vm, gridView);
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
