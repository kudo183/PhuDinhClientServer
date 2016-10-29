using Client.Abstraction;
namespace Client.View
{
    public partial class RLoaiNguyenLieuView : BaseView<DTO.RLoaiNguyenLieuDto>
    {
        partial void InitUIPartial();

        public RLoaiNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
