using Client.Abstraction;
namespace Client.View
{
    public partial class TMatHangView : BaseView<DTO.TMatHangDto>
    {
        partial void InitUIPartial();

        public TMatHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
