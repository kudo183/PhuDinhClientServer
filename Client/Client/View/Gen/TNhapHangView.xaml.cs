using Client.Abstraction;
namespace Client.View
{
    public partial class TNhapHangView : BaseView<DTO.TNhapHangDto>
    {
        partial void InitUIPartial();

        public TNhapHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
