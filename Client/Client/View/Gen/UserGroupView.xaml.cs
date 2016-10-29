using Client.Abstraction;
namespace Client.View
{
    public partial class UserGroupView : BaseView<DTO.UserGroupDto>
    {
        partial void InitUIPartial();

        public UserGroupView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
