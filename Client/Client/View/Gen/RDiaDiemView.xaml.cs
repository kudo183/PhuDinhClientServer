using Client.Abstraction;
namespace Client.View
{
    public partial class RDiaDiemView : BaseView<DTO.RDiaDiemDto>
    {
        partial void InitUIPartial();

        public RDiaDiemView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
