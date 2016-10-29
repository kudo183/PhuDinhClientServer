using Client.Abstraction;
namespace Client.View
{
    public partial class RChanhView : BaseView<DTO.RChanhDto>
    {
        partial void InitUIPartial();

        public RChanhView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
