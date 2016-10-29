using Client.Abstraction;
namespace Client.View
{
    public partial class TChiPhiView : BaseView<DTO.TChiPhiDto>
    {
        partial void InitUIPartial();

        public TChiPhiView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
