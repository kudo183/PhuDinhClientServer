﻿using Client.Abstraction;

namespace Client.View
{
    public partial class TChiTietNhapHangView : BaseView<DTO.TChiTietNhapHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            datagrid.dataGrid.Columns[2] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = datagrid.dataGrid.Columns[2].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietNhapHangDto.TNhapHang) + "." + nameof(DTO.TNhapHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };

            datagrid.Columns[1].DisplayIndex = 2;
        }
    }
}
