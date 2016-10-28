using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RKhoHangViewModel : BaseViewModel<RKhoHangDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RKhoHangDto dto);
        partial void ProcessNewAddedDtoPartial(RKhoHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _TenKhoFilter;
        HeaderCheckFilterModel _TrangThaiFilter;

        public RKhoHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RKhoHang_Ma, nameof(RKhoHangDto.Ma), typeof(int));
            _TenKhoFilter = new HeaderTextFilterModel(TextManager.RKhoHang_TenKho, nameof(RKhoHangDto.TenKho), typeof(string));
            _TrangThaiFilter = new HeaderCheckFilterModel(TextManager.RKhoHang_TrangThai, nameof(RKhoHangDto.TrangThai), typeof(bool));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_TenKhoFilter);
            AddHeaderFilter(_TrangThaiFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RKhoHangDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RKhoHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_TenKhoFilter.FilterValue != null)
            {
                dto.TenKho = (string)_TenKhoFilter.FilterValue;
            }
            if (_TrangThaiFilter.FilterValue != null)
            {
                dto.TrangThai = (bool)_TrangThaiFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
