using Client.Abstraction;
namespace Client.View
{
    public partial class TTonKhoView : BaseView<DTO.TTonKhoDto>
    {
        partial void InitUIPartial();

        public TTonKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
