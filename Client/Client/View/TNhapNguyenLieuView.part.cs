﻿using Client.Abstraction;

namespace Client.View
{
    public partial class TNhapNguyenLieuView : BaseView<DTO.TNhapNguyenLieuDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[1].DisplayIndex = 3;
            datagrid.Columns[3].DisplayIndex = 1;
        }
    }
}
