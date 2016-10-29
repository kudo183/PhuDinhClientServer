using Client.Abstraction;
namespace Client.View
{
    public partial class TChiTietChuyenKhoView : BaseView<DTO.TChiTietChuyenKhoDto>
    {
        partial void InitUIPartial();

        public TChiTietChuyenKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
