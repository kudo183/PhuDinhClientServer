using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RNguyenLieuViewModel : BaseViewModel<RNguyenLieuDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RNguyenLieuDto dto);
        partial void ProcessNewAddedDtoPartial(RNguyenLieuDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _DuongKinhFilter;
        HeaderComboBoxFilterModel _MaLoaiNguyenLieuFilter;

        public RNguyenLieuViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RNguyenLieu_Ma, nameof(RNguyenLieuDto.Ma), typeof(int));
            _DuongKinhFilter = new HeaderTextFilterModel(TextManager.RNguyenLieu_DuongKinh, nameof(RNguyenLieuDto.DuongKinh), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_DuongKinhFilter);
            AddHeaderFilter(_MaLoaiNguyenLieuFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RNguyenLieuDto dto)
        {
            dto.MaLoaiNguyenLieuSources = ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RNguyenLieuDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_DuongKinhFilter.FilterValue != null)
            {
                dto.DuongKinh = (int)_DuongKinhFilter.FilterValue;
            }
            if (_MaLoaiNguyenLieuFilter.FilterValue != null)
            {
                dto.MaLoaiNguyenLieu = (int)_MaLoaiNguyenLieuFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
