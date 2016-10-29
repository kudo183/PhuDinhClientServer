using Client.Abstraction;
namespace Client.View
{
    public partial class RBaiXeView : BaseView<DTO.RBaiXeDto>
    {
        partial void InitUIPartial();

        public RBaiXeView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
