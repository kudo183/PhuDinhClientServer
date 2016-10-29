using Client.Abstraction;
namespace Client.View
{
    public partial class TChuyenHangDonHangView : BaseView<DTO.TChuyenHangDonHangDto>
    {
        partial void InitUIPartial();

        public TChuyenHangDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
