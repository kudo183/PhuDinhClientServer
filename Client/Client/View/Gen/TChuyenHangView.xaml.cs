using Client.Abstraction;
namespace Client.View
{
    public partial class TChuyenHangView : BaseView<DTO.TChuyenHangDto>
    {
        partial void InitUIPartial();

        public TChuyenHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
