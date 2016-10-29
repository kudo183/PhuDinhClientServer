using Client.Abstraction;
namespace Client.View
{
    public partial class RNhanVienView : BaseView<DTO.RNhanVienDto>
    {
        partial void InitUIPartial();

        public RNhanVienView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
