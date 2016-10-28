using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RChanhViewModel : BaseViewModel<RChanhDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RChanhDto dto);
        partial void ProcessNewAddedDtoPartial(RChanhDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderComboBoxFilterModel _MaBaiXeFilter;
        HeaderTextFilterModel _TenChanhFilter;

        public RChanhViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RChanh_Ma, nameof(RChanhDto.Ma), typeof(int));
            _TenChanhFilter = new HeaderTextFilterModel(TextManager.RChanh_TenChanh, nameof(RChanhDto.TenChanh), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaBaiXeFilter);
            AddHeaderFilter(_TenChanhFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RBaiXeDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RChanhDto dto)
        {
            dto.MaBaiXeSources = ReferenceDataManager<RBaiXeDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RChanhDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaBaiXeFilter.FilterValue != null)
            {
                dto.MaBaiXe = (int)_MaBaiXeFilter.FilterValue;
            }
            if (_TenChanhFilter.FilterValue != null)
            {
                dto.TenChanh = (string)_TenChanhFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
