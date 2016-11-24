using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RKhoHangViewModel : BaseViewModel<RKhoHangDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RKhoHangDto dto);
        partial void ProcessNewAddedDtoPartial(RKhoHangDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenKhoFilter;
        HeaderFilterBaseModel _TrangThaiFilter;

        public RKhoHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.RKhoHang_ID, nameof(RKhoHangDto.ID), typeof(int));

            _TenKhoFilter = new HeaderTextFilterModel(TextManager.RKhoHang_TenKho, nameof(RKhoHangDto.TenKho), typeof(string));

            _TrangThaiFilter = new HeaderCheckFilterModel(TextManager.RKhoHang_TrangThai, nameof(RKhoHangDto.TrangThai), typeof(bool));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenKhoFilter);
            AddHeaderFilter(_TrangThaiFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RKhoHangDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RKhoHangDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
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
