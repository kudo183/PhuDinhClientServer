using Client.Abstraction;
namespace Client.View
{
    public partial class UserView : BaseView<DTO.UserDto>
    {
        partial void InitUIPartial();

        public UserView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
