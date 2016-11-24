using Client.Abstraction;
namespace Client.View
{
    public partial class SwaUserGroupView : BaseView<DTO.SwaUserGroupDto>
    {
        partial void InitUIPartial();

        public SwaUserGroupView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
