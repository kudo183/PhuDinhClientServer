using Client.Abstraction;
namespace Client.View
{
    public partial class RCanhBaoTonKhoView : BaseView<DTO.RCanhBaoTonKhoDto>
    {
        partial void InitUIPartial();

        public RCanhBaoTonKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
