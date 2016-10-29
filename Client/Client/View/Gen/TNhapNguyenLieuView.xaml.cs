using Client.Abstraction;
namespace Client.View
{
    public partial class TNhapNguyenLieuView : BaseView<DTO.TNhapNguyenLieuDto>
    {
        partial void InitUIPartial();

        public TNhapNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
