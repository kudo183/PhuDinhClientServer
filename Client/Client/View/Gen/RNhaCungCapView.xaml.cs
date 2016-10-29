using Client.Abstraction;
namespace Client.View
{
    public partial class RNhaCungCapView : BaseView<DTO.RNhaCungCapDto>
    {
        partial void InitUIPartial();

        public RNhaCungCapView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
