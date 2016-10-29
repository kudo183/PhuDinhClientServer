using Client.Abstraction;
namespace Client.View
{
    public partial class TToaHangView : BaseView<DTO.TToaHangDto>
    {
        partial void InitUIPartial();

        public TToaHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
