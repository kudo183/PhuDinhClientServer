using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;
using QueryBuilder;
using System.Collections.Generic;

namespace Client.ViewModel
{
    public partial class TChiTietChuyenHangDonHangViewModel : BaseViewModel<TChiTietChuyenHangDonHangDto>
    {
        QueryExpression qe;
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

            if (qe == null)
            {
                qe = new QueryExpression();
                qe.WhereOptions.Add(new WhereExpression.WhereOptionBool()
                {
                    Predicate = "=",
                    PropertyPath = nameof(TChiTietDonHangDto.Xong),
                    Value = false
                });
            }
            chiTietDonHangsChuaXong = _chiTietDonHangDataService.Get(qe).Items;
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietChuyenHangDonHangDto dto)
        {
            if (dto.TChuyenHangDonHang != null)
            {
                dto.TChuyenHangDonHang.TChuyenHang.RNhanVien = ReferenceDataManager<RNhanVienDto>.Instance.GetList().Find(p => p.ID == dto.TChuyenHangDonHang.TChuyenHang.MaNhanVienGiaoHang);
                dto.TChuyenHangDonHang.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetList().Find(p => p.ID == dto.TChuyenHangDonHang.TDonHang.MaKhachHang);
                dto.TChuyenHangDonHang.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetList().Find(p => p.ID == dto.TChuyenHangDonHang.TDonHang.MaKhoHang);
            }

            var chiTietDonHangs = new List<TChiTietDonHangDto>();
            if (dto.TChiTietDonHang != null)
            {
                chiTietDonHangs.Add(dto.TChiTietDonHang);
            }
            chiTietDonHangs.AddRange(chiTietDonHangsChuaXong);

            foreach (var item in chiTietDonHangs)
            {
                if (item.TDonHang != null)
                {
                    item.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetList().Find(p => p.ID == item.TDonHang.MaKhachHang);
                    item.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetList().Find(p => p.ID == item.TDonHang.MaKhoHang);
                }
                item.TMatHang = ReferenceDataManager<TMatHangDto>.Instance.GetList().Find(p => p.ID == item.MaMatHang);
            }
            dto.MaChiTietDonHangSources = chiTietDonHangs;
        }
    }
}
