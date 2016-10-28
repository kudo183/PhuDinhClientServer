using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TNhanTienKhachHangViewModel : BaseViewModel<TNhanTienKhachHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TNhanTienKhachHangDto dto);
        partial void ProcessNewAddedDtoPartial(TNhanTienKhachHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderComboBoxFilterModel _MaKhachHangFilter;
        HeaderDateFilterModel _NgayFilter;
        HeaderTextFilterModel _SoTienFilter;

        public TNhanTienKhachHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TNhanTienKhachHang_Ma, nameof(TNhanTienKhachHangDto.Ma), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.TNhanTienKhachHang_Ngay, nameof(TNhanTienKhachHangDto.Ngay), typeof(System.DateTime));
            _SoTienFilter = new HeaderTextFilterModel(TextManager.TNhanTienKhachHang_SoTien, nameof(TNhanTienKhachHangDto.SoTien), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoTienFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TNhanTienKhachHangDto dto)
        {
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TNhanTienKhachHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
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
