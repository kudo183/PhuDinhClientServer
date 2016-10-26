using SimpleDataGrid.ViewModel;
using DTO;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class RChanhViewModel : BaseViewModel<RChanhDto>
    {
        private HeaderComboBoxFilterModel _baiXeFilter;

        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RChanhDto dto);

        public RChanhViewModel() : base()
        {
            InitFilterPartial();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RChanhDto.Ma), typeof(int)));
            AddHeaderFilter(_baiXeFilter);
            AddHeaderFilter(new HeaderTextFilterModel("Ten Chanh", nameof(RChanhDto.TenChanh), typeof(string)));
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RBaiXeDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RChanhDto dto)
        {
            dto.BaiXes = ReferenceDataManager<RBaiXeDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RChanhDto dto)
        {
            if (_baiXeFilter.FilterValue != null)
            {
                dto.MaBaiXe = (int)_baiXeFilter.FilterValue;
            }
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
