using Client.Abstraction;
namespace Client.View
{
    public partial class ThamSoNgayView : BaseView<DTO.ThamSoNgayDto>
    {
        partial void InitUIPartial();

        public ThamSoNgayView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
