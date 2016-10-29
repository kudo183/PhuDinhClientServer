using Client.Abstraction;
namespace Client.View
{
    public partial class TChiTietDonHangView : BaseView<DTO.TChiTietDonHangDto>
    {
        partial void InitUIPartial();

        public TChiTietDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
