using Client.Abstraction;
using Client.ViewModel;
using DTO;
using System.Linq;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for complexChuyenHangView.xaml
    /// </summary>
    public partial class complexChuyenHangView : BaseComplexView
    {
        public complexChuyenHangView()
        {
            InitializeComponent();
        }

        protected override void OnMoveFocus(IBaseView currentView, IBaseView nextView)
        {
            if (currentView is TChuyenHangDonHangView)
            {
                System.Windows.Input.Keyboard.Focus(nextView.GridView.dataGrid);
                return;
            }

            base.OnMoveFocus(currentView, nextView);
        }

        protected override void OnAfterSave(IBaseView previousView, IBaseView currentView, IBaseView nextView)
        {
            base.OnAfterSave(previousView, currentView, nextView);

            if (currentView is TChuyenHangDonHangView)
            {
                var view = currentView as TChuyenHangDonHangView;
                var viewModel = view.DataContext as TChuyenHangDonHangViewModel;
                var dto = viewModel.ParentItem as TChuyenHangDto;
                dto.TongDonHang = viewModel.Entities.Count;
                dto.TongSoLuongTheoDonHang = viewModel.Entities.Sum(p => p.TongSoLuongTheoDonHang);
                dto.TongSoLuongThucTe = viewModel.Entities.Sum(p => p.TongSoLuongThucTe);
            }
            else if (currentView is TChiTietChuyenHangDonHangView)
            {
                var view = currentView as TChiTietChuyenHangDonHangView;
                var viewModel = view.DataContext as TChiTietChuyenHangDonHangViewModel;
                var dto = viewModel.ParentItem as TChuyenHangDonHangDto;
                dto.TongSoLuongThucTe = viewModel.Entities.Sum(p => p.SoLuong);

                var viewCHDH = previousView as TChuyenHangDonHangView;
                var vmCHDH = viewCHDH.DataContext as TChuyenHangDonHangViewModel;
                var dtoCH = vmCHDH.ParentItem as TChuyenHangDto;
                dtoCH.TongSoLuongTheoDonHang = vmCHDH.Entities.Sum(p => p.TongSoLuongTheoDonHang);
                dtoCH.TongSoLuongThucTe = vmCHDH.Entities.Sum(p => p.TongSoLuongThucTe);
            }
        }
    }
}
