using Client.Abstraction;
namespace Client.View
{
    public partial class UserView : BaseView<DTO.UserDto>
    {
        public UserView() : base()
        {
            InitializeComponent();
        }
    }
}
