using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RChanhViewModel : BaseViewModel<RChanhDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RChanhDto dto);
        partial void ProcessNewAddedDtoPartial(RChanhDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaBaiXeFilter;
        HeaderFilterBaseModel _TenChanhFilter;

        public RChanhViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.RChanh_ID, nameof(RChanhDto.ID), typeof(int));

            _MaBaiXeFilter = new HeaderComboBoxFilterModel(
                TextManager.RChanh_MaBaiXe, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RChanhDto.MaBaiXe),
                typeof(int),
                nameof(RBaiXeDto.TenHienThi),
                nameof(RBaiXeDto.ID))
            {
                AddCommand = new SimpleCommand("MaBaiXeAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RBaiXeView(), "RBaiXe", ReferenceDataManager<RBaiXeDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RBaiXeDto>.Instance.Get()
            };

            _TenChanhFilter = new HeaderTextFilterModel(TextManager.RChanh_TenChanh, nameof(RChanhDto.TenChanh), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
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
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
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
