using Client.Abstraction;
namespace Client.View
{
    public partial class TChiTietChuyenHangDonHangView : BaseView<DTO.TChiTietChuyenHangDonHangDto>
    {
        partial void InitUIPartial();

        public TChiTietChuyenHangDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
