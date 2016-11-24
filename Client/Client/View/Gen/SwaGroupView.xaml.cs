using Client.Abstraction;
namespace Client.View
{
    public partial class SwaGroupView : BaseView<DTO.SwaGroupDto>
    {
        partial void InitUIPartial();

        public SwaGroupView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
