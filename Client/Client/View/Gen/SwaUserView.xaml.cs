using Client.Abstraction;
namespace Client.View
{
    public partial class SwaUserView : BaseView<DTO.SwaUserDto>
    {
        partial void InitUIPartial();

        public SwaUserView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
