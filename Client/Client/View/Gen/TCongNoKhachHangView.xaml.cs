using Client.Abstraction;
namespace Client.View
{
    public partial class TCongNoKhachHangView : BaseView<DTO.TCongNoKhachHangDto>
    {
        partial void InitUIPartial();

        public TCongNoKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
