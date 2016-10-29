using Client.Abstraction;
namespace Client.View
{
    public partial class RKhoHangView : BaseView<DTO.RKhoHangDto>
    {
        partial void InitUIPartial();

        public RKhoHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
