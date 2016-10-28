using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TNhapHangViewModel : BaseViewModel<TNhapHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TNhapHangDto dto);
        partial void ProcessNewAddedDtoPartial(TNhapHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderComboBoxFilterModel _MaKhoHangFilter;
        HeaderComboBoxFilterModel _MaNhaCungCapFilter;
        HeaderComboBoxFilterModel _MaNhanVienFilter;
        HeaderDateFilterModel _NgayFilter;

        public TNhapHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TNhapHang_Ma, nameof(TNhapHangDto.Ma), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.TNhapHang_Ngay, nameof(TNhapHangDto.Ngay), typeof(System.DateTime));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_MaNhaCungCapFilter);
            AddHeaderFilter(_MaNhanVienFilter);
            AddHeaderFilter(_NgayFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RNhaCungCapDto>.Instance.Load();
            ReferenceDataManager<RNhanVienDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TNhapHangDto dto)
        {
            dto.MaKhoHangSources = ReferenceDataManager<RKhoHangDto>.Instance.Get();
            dto.MaNhaCungCapSources = ReferenceDataManager<RNhaCungCapDto>.Instance.Get();
            dto.MaNhanVienSources = ReferenceDataManager<RNhanVienDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TNhapHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_MaNhaCungCapFilter.FilterValue != null)
            {
                dto.MaNhaCungCap = (int)_MaNhaCungCapFilter.FilterValue;
            }
            if (_MaNhanVienFilter.FilterValue != null)
            {
                dto.MaNhanVien = (int)_MaNhanVienFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
