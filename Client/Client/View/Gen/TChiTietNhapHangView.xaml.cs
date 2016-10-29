using Client.Abstraction;
namespace Client.View
{
    public partial class TChiTietNhapHangView : BaseView<DTO.TChiTietNhapHangDto>
    {
        partial void InitUIPartial();

        public TChiTietNhapHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
