using Client.Abstraction;
namespace Client.View
{
    public partial class GroupView : BaseView<DTO.GroupDto>
    {
        partial void InitUIPartial();

        public GroupView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
