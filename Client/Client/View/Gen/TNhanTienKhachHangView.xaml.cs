using Client.Abstraction;
namespace Client.View
{
    public partial class TNhanTienKhachHangView : BaseView<DTO.TNhanTienKhachHangDto>
    {
        partial void InitUIPartial();

        public TNhanTienKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
