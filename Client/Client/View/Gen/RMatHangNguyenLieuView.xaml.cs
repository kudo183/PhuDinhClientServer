using Client.Abstraction;
namespace Client.View
{
    public partial class RMatHangNguyenLieuView : BaseView<DTO.RMatHangNguyenLieuDto>
    {
        partial void InitUIPartial();

        public RMatHangNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
