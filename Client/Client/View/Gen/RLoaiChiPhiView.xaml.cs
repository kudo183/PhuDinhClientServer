using Client.Abstraction;
namespace Client.View
{
    public partial class RLoaiChiPhiView : BaseView<DTO.RLoaiChiPhiDto>
    {
        partial void InitUIPartial();

        public RLoaiChiPhiView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
