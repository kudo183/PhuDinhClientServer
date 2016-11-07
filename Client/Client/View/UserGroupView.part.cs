using Client.Abstraction;

namespace Client.View
{
    public partial class UserGroupView : BaseView<DTO.UserGroupDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.UserGroupDto.Ma):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.UserGroupDto.MaUser):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.UserGroupDto.MaGroup):
                        column.DisplayIndex = 2;
                        break;
                    case nameof(DTO.UserGroupDto.LaChuGroup):
                        column.DisplayIndex = 3;
                        break;
                }
            }
        }
    }
}
