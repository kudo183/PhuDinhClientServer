using Client.Abstraction;
namespace Client.View
{
    public partial class TDonHangView : BaseView<DTO.TDonHangDto>
    {
        partial void InitUIPartial();

        public TDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
