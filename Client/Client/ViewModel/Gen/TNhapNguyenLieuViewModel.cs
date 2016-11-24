using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TNhapNguyenLieuViewModel : BaseViewModel<TNhapNguyenLieuDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TNhapNguyenLieuDto dto);
        partial void ProcessNewAddedDtoPartial(TNhapNguyenLieuDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaNguyenLieuFilter;
        HeaderFilterBaseModel _MaNhaCungCapFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _SoLuongFilter;

        public TNhapNguyenLieuViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.TNhapNguyenLieu_ID, nameof(TNhapNguyenLieuDto.ID), typeof(int));

            _MaNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.TNhapNguyenLieu_MaNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TNhapNguyenLieuDto.MaNguyenLieu),
                typeof(int),
                nameof(RNguyenLieuDto.TenHienThi),
                nameof(RNguyenLieuDto.ID))
            {
                AddCommand = new SimpleCommand("MaNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RNguyenLieuView(), "RNguyenLieu", ReferenceDataManager<RNguyenLieuDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RNguyenLieuDto>.Instance.Get()
            };

            _MaNhaCungCapFilter = new HeaderComboBoxFilterModel(
                TextManager.TNhapNguyenLieu_MaNhaCungCap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TNhapNguyenLieuDto.MaNhaCungCap),
                typeof(int),
                nameof(RNhaCungCapDto.TenHienThi),
                nameof(RNhaCungCapDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhaCungCapAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RNhaCungCapView(), "RNhaCungCap", ReferenceDataManager<RNhaCungCapDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RNhaCungCapDto>.Instance.Get()
            };

            _NgayFilter = new HeaderDateFilterModel(TextManager.TNhapNguyenLieu_Ngay, nameof(TNhapNguyenLieuDto.Ngay), typeof(System.DateTime));

            _SoLuongFilter = new HeaderTextFilterModel(TextManager.TNhapNguyenLieu_SoLuong, nameof(TNhapNguyenLieuDto.SoLuong), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaNguyenLieuFilter);
            AddHeaderFilter(_MaNhaCungCapFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoLuongFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RNguyenLieuDto>.Instance.Load();
            ReferenceDataManager<RNhaCungCapDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TNhapNguyenLieuDto dto)
        {
            dto.MaNguyenLieuSources = ReferenceDataManager<RNguyenLieuDto>.Instance.Get();
            dto.MaNhaCungCapSources = ReferenceDataManager<RNhaCungCapDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TNhapNguyenLieuDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaNguyenLieuFilter.FilterValue != null)
            {
                dto.MaNguyenLieu = (int)_MaNguyenLieuFilter.FilterValue;
            }
            if (_MaNhaCungCapFilter.FilterValue != null)
            {
                dto.MaNhaCungCap = (int)_MaNhaCungCapFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dto.SoLuong = (int)_SoLuongFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
