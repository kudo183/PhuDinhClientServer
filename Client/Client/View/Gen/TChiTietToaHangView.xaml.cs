using Client.Abstraction;
namespace Client.View
{
    public partial class TChiTietToaHangView : BaseView<DTO.TChiTietToaHangDto>
    {
        partial void InitUIPartial();

        public TChiTietToaHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
