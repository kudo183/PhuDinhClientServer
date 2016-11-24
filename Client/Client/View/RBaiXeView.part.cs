using Client.Abstraction;

namespace Client.View
{
    public partial class RBaiXeView : BaseView<DTO.RBaiXeDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.RBaiXeDto.ID):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.RBaiXeDto.DiaDiemBaiXe):
                        column.DisplayIndex = 1;
                        break;
                }
            }
        }
    }
}
