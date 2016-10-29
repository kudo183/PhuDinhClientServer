using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TMatHangViewModel : BaseViewModel<TMatHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TMatHangDto dto);
        partial void ProcessNewAddedDtoPartial(TMatHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderComboBoxFilterModel _MaLoaiFilter;
        HeaderTextFilterModel _SoKyFilter;
        HeaderTextFilterModel _SoMetFilter;
        HeaderTextFilterModel _TenMatHangFilter;
        HeaderTextFilterModel _TenMatHangDayDuFilter;
        HeaderTextFilterModel _TenMatHangInFilter;

        public TMatHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TMatHang_Ma, nameof(TMatHangDto.Ma), typeof(int));

            _MaLoaiFilter = new HeaderComboBoxFilterModel(
                TextManager.TMatHang_MaLoai, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TMatHangDto.MaLoai),
                typeof(int),
                nameof(RLoaiHangDto.TenHienThi),
                nameof(RLoaiHangDto.Ma));
            _MaLoaiFilter.AddCommand = new SimpleCommand("MaLoaiAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RLoaiHangView(), "RLoaiHang", ReferenceDataManager<RLoaiHangDto>.Instance.Load)
            );
            _MaLoaiFilter.ItemSource = ReferenceDataManager<RLoaiHangDto>.Instance.Get();

            _SoKyFilter = new HeaderTextFilterModel(TextManager.TMatHang_SoKy, nameof(TMatHangDto.SoKy), typeof(int));

            _SoMetFilter = new HeaderTextFilterModel(TextManager.TMatHang_SoMet, nameof(TMatHangDto.SoMet), typeof(int));

            _TenMatHangFilter = new HeaderTextFilterModel(TextManager.TMatHang_TenMatHang, nameof(TMatHangDto.TenMatHang), typeof(string));

            _TenMatHangDayDuFilter = new HeaderTextFilterModel(TextManager.TMatHang_TenMatHangDayDu, nameof(TMatHangDto.TenMatHangDayDu), typeof(string));

            _TenMatHangInFilter = new HeaderTextFilterModel(TextManager.TMatHang_TenMatHangIn, nameof(TMatHangDto.TenMatHangIn), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaLoaiFilter);
            AddHeaderFilter(_SoKyFilter);
            AddHeaderFilter(_SoMetFilter);
            AddHeaderFilter(_TenMatHangFilter);
            AddHeaderFilter(_TenMatHangDayDuFilter);
            AddHeaderFilter(_TenMatHangInFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RLoaiHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TMatHangDto dto)
        {
            dto.MaLoaiSources = ReferenceDataManager<RLoaiHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TMatHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaLoaiFilter.FilterValue != null)
            {
                dto.MaLoai = (int)_MaLoaiFilter.FilterValue;
            }
            if (_SoKyFilter.FilterValue != null)
            {
                dto.SoKy = (int)_SoKyFilter.FilterValue;
            }
            if (_SoMetFilter.FilterValue != null)
            {
                dto.SoMet = (int)_SoMetFilter.FilterValue;
            }
            if (_TenMatHangFilter.FilterValue != null)
            {
                dto.TenMatHang = (string)_TenMatHangFilter.FilterValue;
            }
            if (_TenMatHangDayDuFilter.FilterValue != null)
            {
                dto.TenMatHangDayDu = (string)_TenMatHangDayDuFilter.FilterValue;
            }
            if (_TenMatHangInFilter.FilterValue != null)
            {
                dto.TenMatHangIn = (string)_TenMatHangInFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
