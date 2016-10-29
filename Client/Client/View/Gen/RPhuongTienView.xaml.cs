using Client.Abstraction;
namespace Client.View
{
    public partial class RPhuongTienView : BaseView<DTO.RPhuongTienDto>
    {
        partial void InitUIPartial();

        public RPhuongTienView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
