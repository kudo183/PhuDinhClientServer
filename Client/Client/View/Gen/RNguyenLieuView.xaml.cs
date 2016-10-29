using Client.Abstraction;
namespace Client.View
{
    public partial class RNguyenLieuView : BaseView<DTO.RNguyenLieuDto>
    {
        partial void InitUIPartial();

        public RNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
