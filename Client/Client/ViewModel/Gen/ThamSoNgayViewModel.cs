﻿using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class ThamSoNgayViewModel : BaseViewModel<ThamSoNgayDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(ThamSoNgayDto dto);
        partial void ProcessNewAddedDtoPartial(ThamSoNgayDto dto);

        HeaderFilterBaseModel _GiaTriFilter;
        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _TenFilter;

        public ThamSoNgayViewModel() : base()
        {
            _GiaTriFilter = new HeaderDateFilterModel(TextManager.ThamSoNgay_GiaTri, nameof(ThamSoNgayDto.GiaTri), typeof(System.DateTime));

            _MaFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_Ma, nameof(ThamSoNgayDto.Ma), typeof(int));

            _TenFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_Ten, nameof(ThamSoNgayDto.Ten), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_GiaTriFilter);
            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_TenFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(ThamSoNgayDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(ThamSoNgayDto dto)
        {
            if (_GiaTriFilter.FilterValue != null)
            {
                dto.GiaTri = (System.DateTime)_GiaTriFilter.FilterValue;
            }
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_TenFilter.FilterValue != null)
            {
                dto.Ten = (string)_TenFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
