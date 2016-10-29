using Client.Abstraction;
namespace Client.View
{
    public partial class TPhuThuKhachHangView : BaseView<DTO.TPhuThuKhachHangDto>
    {
        partial void InitUIPartial();

        public TPhuThuKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
