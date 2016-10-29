using Client.Abstraction;
namespace Client.View
{
    public partial class TChuyenKhoView : BaseView<DTO.TChuyenKhoDto>
    {
        partial void InitUIPartial();

        public TChuyenKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
