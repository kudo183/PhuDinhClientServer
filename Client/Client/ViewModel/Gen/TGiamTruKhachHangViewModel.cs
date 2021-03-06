﻿using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TGiamTruKhachHangViewModel : BaseViewModel<TGiamTruKhachHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TGiamTruKhachHangDto dto);
        partial void ProcessNewAddedDtoPartial(TGiamTruKhachHangDto dto);

        HeaderFilterBaseModel _GhiChuFilter;
        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _SoTienFilter;

        public TGiamTruKhachHangViewModel() : base()
        {
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.TGiamTruKhachHang_GhiChu, nameof(TGiamTruKhachHangDto.GhiChu), typeof(string));

            _MaFilter = new HeaderTextFilterModel(TextManager.TGiamTruKhachHang_Ma, nameof(TGiamTruKhachHangDto.Ma), typeof(int));

            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TGiamTruKhachHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TGiamTruKhachHangDto.MaKhachHang),
                typeof(int),
                nameof(RKhachHangDto.TenHienThi),
                nameof(RKhachHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhachHangView(), "RKhachHang", ReferenceDataManager<RKhachHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get()
            };

            _NgayFilter = new HeaderDateFilterModel(TextManager.TGiamTruKhachHang_Ngay, nameof(TGiamTruKhachHangDto.Ngay), typeof(System.DateTime));

            _SoTienFilter = new HeaderTextFilterModel(TextManager.TGiamTruKhachHang_SoTien, nameof(TGiamTruKhachHangDto.SoTien), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_GhiChuFilter);
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

        protected override void ProcessDtoBeforeAddToEntities(TGiamTruKhachHangDto dto)
        {
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TGiamTruKhachHangDto dto)
        {
            if (_GhiChuFilter.FilterValue != null)
            {
                dto.GhiChu = (string)_GhiChuFilter.FilterValue;
            }
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
