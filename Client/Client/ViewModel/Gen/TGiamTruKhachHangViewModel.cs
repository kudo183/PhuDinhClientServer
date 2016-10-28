﻿using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TGiamTruKhachHangViewModel : BaseViewModel<TGiamTruKhachHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TGiamTruKhachHangDto dto);
        partial void ProcessNewAddedDtoPartial(TGiamTruKhachHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _GhiChuFilter;
        HeaderComboBoxFilterModel _MaKhachHangFilter;
        HeaderDateFilterModel _NgayFilter;
        HeaderTextFilterModel _SoTienFilter;

        public TGiamTruKhachHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TGiamTruKhachHang_Ma, nameof(TGiamTruKhachHangDto.Ma), typeof(int));
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.TGiamTruKhachHang_GhiChu, nameof(TGiamTruKhachHangDto.GhiChu), typeof(string));
            _NgayFilter = new HeaderDateFilterModel(TextManager.TGiamTruKhachHang_Ngay, nameof(TGiamTruKhachHangDto.Ngay), typeof(System.DateTime));
            _SoTienFilter = new HeaderTextFilterModel(TextManager.TGiamTruKhachHang_SoTien, nameof(TGiamTruKhachHangDto.SoTien), typeof(int));

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

        protected override void ProcessDtoBeforeAddToEntities(TGiamTruKhachHangDto dto)
        {
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TGiamTruKhachHangDto dto)
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