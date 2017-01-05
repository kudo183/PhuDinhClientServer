using Client.Abstraction;
using Client.ViewModel;
using DTO;
using System.Linq;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for complexDonHangView.xaml
    /// </summary>
    public partial class complexDonHangView : BaseComplexView
    {
        public complexDonHangView()
        {
            InitializeComponent();
        }

        protected override void OnAfterSave(IBaseView previousView, IBaseView currentView, IBaseView nextView)
        {
            base.OnAfterSave(previousView, currentView, nextView);

            if (currentView is TChiTietDonHangView)
            {
                var view = currentView as TChiTietDonHangView;
                var viewModel = view.DataContext as TChiTietDonHangViewModel;
                var dto = viewModel.ParentItem as TDonHangDto;
                dto.TongSoLuong = viewModel.Entities.Sum(p => p.SoLuong);
            }
        }
    }
}
