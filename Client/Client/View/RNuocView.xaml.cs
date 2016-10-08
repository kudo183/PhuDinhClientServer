using Client.Abstraction;
using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for RNuocView.xaml
    /// </summary>
    public partial class RNuocView : BaseView<DTO.RNuocDto>
    {
        public RNuocView() : base()
        {
            InitializeComponent();

            var vm = new RNuocViewModel();

            InitView(vm, gridView);
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            ProcessMenuButtonClick(sender, e);
        }
    }
}
