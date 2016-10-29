using Client.Abstraction;
namespace Client.View
{
    public partial class RKhachHangChanhView : BaseView<DTO.RKhachHangChanhDto>
    {
        partial void InitUIPartial();

        public RKhachHangChanhView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
