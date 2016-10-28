using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TTonKhoViewModel : BaseViewModel<TTonKhoDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TTonKhoDto dto);
        partial void ProcessNewAddedDtoPartial(TTonKhoDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderComboBoxFilterModel _MaKhoHangFilter;
        HeaderComboBoxFilterModel _MaMatHangFilter;
        HeaderDateFilterModel _NgayFilter;
        HeaderTextFilterModel _SoLuongFilter;
        HeaderTextFilterModel _SoLuongCuFilter;

        public TTonKhoViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TTonKho_Ma, nameof(TTonKhoDto.Ma), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.TTonKho_Ngay, nameof(TTonKhoDto.Ngay), typeof(System.DateTime));
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.TTonKho_SoLuong, nameof(TTonKhoDto.SoLuong), typeof(int));
            _SoLuongCuFilter = new HeaderTextFilterModel(TextManager.TTonKho_SoLuongCu, nameof(TTonKhoDto.SoLuongCu), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_SoLuongCuFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<TMatHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TTonKhoDto dto)
        {
            dto.MaKhoHangSources = ReferenceDataManager<RKhoHangDto>.Instance.Get();
            dto.MaMatHangSources = ReferenceDataManager<TMatHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TTonKhoDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dto.SoLuong = (int)_SoLuongFilter.FilterValue;
            }
            if (_SoLuongCuFilter.FilterValue != null)
            {
                dto.SoLuongCu = (int)_SoLuongCuFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
