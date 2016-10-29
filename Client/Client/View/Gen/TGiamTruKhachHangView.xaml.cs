using Client.Abstraction;
namespace Client.View
{
    public partial class TGiamTruKhachHangView : BaseView<DTO.TGiamTruKhachHangDto>
    {
        partial void InitUIPartial();

        public TGiamTruKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
