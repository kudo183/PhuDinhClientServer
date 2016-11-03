﻿using Client.Abstraction;

namespace Client.View
{
    public partial class TChuyenHangDonHangView : BaseView<DTO.TChuyenHangDonHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            datagrid.dataGrid.Columns[1] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = datagrid.dataGrid.Columns[1].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChuyenHangDonHangDto.TChuyenHang) + "." + nameof(DTO.TChuyenHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };

            datagrid.dataGrid.Columns[2].Width = 250;

            datagrid.dataGrid.Columns[3].IsReadOnly = true;
            datagrid.dataGrid.Columns[4].IsReadOnly = true;
        }
    }
}