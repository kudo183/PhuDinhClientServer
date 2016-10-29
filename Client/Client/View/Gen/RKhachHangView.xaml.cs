using Client.Abstraction;
namespace Client.View
{
    public partial class RKhachHangView : BaseView<DTO.RKhachHangDto>
    {
        partial void InitUIPartial();

        public RKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
