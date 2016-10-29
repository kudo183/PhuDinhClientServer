using Client.Abstraction;
namespace Client.View
{
    public partial class RNuocView : BaseView<DTO.RNuocDto>
    {
        partial void InitUIPartial();

        public RNuocView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
