using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TPhuThuKhachHangViewModel : BaseViewModel<TPhuThuKhachHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TPhuThuKhachHangDto dto);
        partial void ProcessNewAddedDtoPartial(TPhuThuKhachHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _GhiChuFilter;
        HeaderComboBoxFilterModel _MaKhachHangFilter;
        HeaderDateFilterModel _NgayFilter;
        HeaderTextFilterModel _SoTienFilter;

        public TPhuThuKhachHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TPhuThuKhachHang_Ma, nameof(TPhuThuKhachHangDto.Ma), typeof(int));
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.TPhuThuKhachHang_GhiChu, nameof(TPhuThuKhachHangDto.GhiChu), typeof(string));
            _NgayFilter = new HeaderDateFilterModel(TextManager.TPhuThuKhachHang_Ngay, nameof(TPhuThuKhachHangDto.Ngay), typeof(System.DateTime));
            _SoTienFilter = new HeaderTextFilterModel(TextManager.TPhuThuKhachHang_SoTien, nameof(TPhuThuKhachHangDto.SoTien), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_GhiChuFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoTienFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TPhuThuKhachHangDto dto)
        {
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TPhuThuKhachHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_GhiChuFilter.FilterValue != null)
            {
                dto.GhiChu = (string)_GhiChuFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_SoTienFilter.FilterValue != null)
            {
                dto.SoTien = (int)_SoTienFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
