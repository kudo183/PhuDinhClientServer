using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;
using QueryBuilder;
using System.Collections.Generic;

namespace Client.ViewModel
{
    public partial class TChiTietChuyenHangDonHangViewModel : BaseViewModel<TChiTietChuyenHangDonHangDto>
    {
        IDataService<TChiTietDonHangDto> _chiTietDonHangDataService = ServiceLocator.Instance.GetInstance<IDataService<TChiTietDonHangDto>>();
        List<TChiTietDonHangDto> chiTietDonHangsChuaXong;

        partial void InitFilterPartial()
        {
            _MaChuyenHangDonHangFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenHangDonHang_MaChuyenHangDonHang, nameof(TChiTietChuyenHangDonHangDto.MaChuyenHangDonHang), typeof(int));
            _MaChiTietDonHangFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenHangDonHang_MaChiTietDonHang, nameof(TChiTietChuyenHangDonHangDto.MaChiTietDonHang), typeof(int));
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RNhanVienDto>.Instance.Load();
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
            ReferenceDataManager<TMatHangDto>.Instance.Load();
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietChuyenHangDonHangDto dto)
        {
            if (dto.TChuyenHangDonHang != null)
            {
                dto.TChuyenHangDonHang.TChuyenHang.RNhanVien = ReferenceDataManager<RNhanVienDto>.Instance.GetByID(dto.TChuyenHangDonHang.TChuyenHang.MaNhanVienGiaoHang);
                dto.TChuyenHangDonHang.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetByID(dto.TChuyenHangDonHang.TDonHang.MaKhachHang);
                dto.TChuyenHangDonHang.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetByID(dto.TChuyenHangDonHang.TDonHang.MaKhoHang);
            }

            if (dto.TChiTietDonHang != null && dto.TChiTietDonHang.Xong == true)
            {
                dto.TChiTietDonHang.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>
                    .Instance.GetByID(dto.TChiTietDonHang.TDonHang.MaKhachHang);
                dto.TChiTietDonHang.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>
                    .Instance.GetByID(dto.TChiTietDonHang.TDonHang.MaKhoHang);

                dto.TChiTietDonHang.TMatHang = ReferenceDataManager<TMatHangDto>
                    .Instance.GetByID(dto.TChiTietDonHang.MaMatHang);

                var chiTietDonHangs = new List<TChiTietDonHangDto>();
                chiTietDonHangs.Add(dto.TChiTietDonHang);
                dto.MaChiTietDonHangSources = chiTietDonHangs;
            }
            else
            {
                dto.MaChiTietDonHangSources = chiTietDonHangsChuaXong;
            }
        }

        protected override void BeforeLoad()
        {
            var qe = new QueryExpression();
            var chdh = ParentItem as TChuyenHangDonHangDto;
            if (chdh != null)
            {
                qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                    WhereExpression.Equal, nameof(TChiTietDonHangDto.MaDonHang), chdh.MaDonHang);
            }
            qe.AddWhereOption<WhereExpression.WhereOptionBool, bool>(
                  WhereExpression.Equal, nameof(TChiTietDonHangDto.Xong), false);
            chiTietDonHangsChuaXong = _chiTietDonHangDataService.Get(qe).Items;

            foreach (var item in chiTietDonHangsChuaXong)
            {
                if (item.TDonHang != null)
                {
                    item.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetByID(item.TDonHang.MaKhachHang);
                    item.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetByID(item.TDonHang.MaKhoHang);
                }
                item.TMatHang = ReferenceDataManager<TMatHangDto>.Instance.GetByID(item.MaMatHang);
            }
        }
    }
}
