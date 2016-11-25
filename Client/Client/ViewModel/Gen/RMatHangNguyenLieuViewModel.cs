using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RMatHangNguyenLieuViewModel : BaseViewModel<RMatHangNguyenLieuDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RMatHangNguyenLieuDto dto);
        partial void ProcessNewAddedDtoPartial(RMatHangNguyenLieuDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _MaNguyenLieuFilter;

        public RMatHangNguyenLieuViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RMatHangNguyenLieu_Ma, nameof(RMatHangNguyenLieuDto.Ma), typeof(int));

            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.RMatHangNguyenLieu_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RMatHangNguyenLieuDto.MaMatHang),
                typeof(int),
                nameof(TMatHangDto.TenHienThi),
                nameof(TMatHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TMatHangView(), "TMatHang", ReferenceDataManager<TMatHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TMatHangDto>.Instance.Get()
            };

            _MaNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.RMatHangNguyenLieu_MaNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RMatHangNguyenLieuDto.MaNguyenLieu),
                typeof(int),
                nameof(RNguyenLieuDto.TenHienThi),
                nameof(RNguyenLieuDto.ID))
            {
                AddCommand = new SimpleCommand("MaNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RNguyenLieuView(), "RNguyenLieu", ReferenceDataManager<RNguyenLieuDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RNguyenLieuDto>.Instance.Get()
            };

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_MaNguyenLieuFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TMatHangDto>.Instance.Load();
            ReferenceDataManager<RNguyenLieuDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RMatHangNguyenLieuDto dto)
        {
            dto.MaMatHangSources = ReferenceDataManager<TMatHangDto>.Instance.Get();
            dto.MaNguyenLieuSources = ReferenceDataManager<RNguyenLieuDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RMatHangNguyenLieuDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_MaNguyenLieuFilter.FilterValue != null)
            {
                dto.MaNguyenLieu = (int)_MaNguyenLieuFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
