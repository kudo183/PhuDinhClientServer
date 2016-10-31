﻿using Client.Abstraction;

namespace Client.View
{
    public partial class TNhapHangView : BaseView<DTO.TNhapHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[4].DisplayIndex = 1;
            datagrid.Columns[3].DisplayIndex = 2;
            datagrid.Columns[2].DisplayIndex = 3;
        }
    }
}
