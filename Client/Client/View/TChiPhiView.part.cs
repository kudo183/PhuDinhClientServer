using Client.Abstraction;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Client.View
{
    public partial class TChiPhiView : BaseView<DTO.TChiPhiDto>
    {
        partial void InitUIPartial()
        {
            foreach (var column in GridView.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.TChiPhiDto.ID):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.TChiPhiDto.Ngay):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.TChiPhiDto.MaLoaiChiPhi):
                        column.DisplayIndex = 2;
                        break;
                    case nameof(DTO.TChiPhiDto.MaNhanVienGiaoHang):
                        column.DisplayIndex = 3;
                        break;
                    case nameof(DTO.TChiPhiDto.SoTien):
                        column.DisplayIndex = 4;
                        (column as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
                        break;
                    case nameof(DTO.TChiPhiDto.GhiChu):
                        column.DisplayIndex = 5;
                        break;
                }
            }
            
            var tb = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 14,
                Foreground = Brushes.Blue
            };
            tb.SetBinding(TextBlock.TextProperty, "Msg");
            GridView.CustomMenuItems.Add(tb);
        }
    }
}
