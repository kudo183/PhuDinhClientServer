using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietToaHangViewModel : BaseViewModel<TChiTietToaHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietToaHangDto dto);
        partial void ProcessNewAddedDtoPartial(TChiTietToaHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _GiaTienFilter;
        HeaderComboBoxFilterModel _MaChiTietDonHangFilter;
        HeaderComboBoxFilterModel _MaToaHangFilter;

        public TChiTietToaHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChiTietToaHang_Ma, nameof(TChiTietToaHangDto.Ma), typeof(int));
            _GiaTienFilter = new HeaderTextFilterModel(TextManager.TChiTietToaHang_GiaTien, nameof(TChiTietToaHangDto.GiaTien), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_GiaTienFilter);
            AddHeaderFilter(_MaChiTietDonHangFilter);
            AddHeaderFilter(_MaToaHangFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TChiTietDonHangDto>.Instance.Load();
            ReferenceDataManager<TToaHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiTietToaHangDto dto)
        {
            dto.MaChiTietDonHangSources = ReferenceDataManager<TChiTietDonHangDto>.Instance.Get();
            dto.MaToaHangSources = ReferenceDataManager<TToaHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChiTietToaHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_GiaTienFilter.FilterValue != null)
            {
                dto.GiaTien = (int)_GiaTienFilter.FilterValue;
            }
            if (_MaChiTietDonHangFilter.FilterValue != null)
            {
                dto.MaChiTietDonHang = (int)_MaChiTietDonHangFilter.FilterValue;
            }
            if (_MaToaHangFilter.FilterValue != null)
            {
                dto.MaToaHang = (int)_MaToaHangFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
