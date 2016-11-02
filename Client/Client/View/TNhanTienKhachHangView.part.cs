﻿using Client.Abstraction;

namespace Client.View
{
    public partial class TNhanTienKhachHangView : BaseView<DTO.TNhanTienKhachHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[1].DisplayIndex = 2;
        }
    }
}