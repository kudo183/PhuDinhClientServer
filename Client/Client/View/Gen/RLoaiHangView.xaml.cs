using Client.Abstraction;
namespace Client.View
{
    public partial class RLoaiHangView : BaseView<DTO.RLoaiHangDto>
    {
        partial void InitUIPartial();

        public RLoaiHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
