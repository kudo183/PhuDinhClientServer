using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;
using QueryBuilder;
using System.Collections.Generic;

namespace Client.ViewModel
{
    public partial class TChuyenHangDonHangViewModel : BaseViewModel<TChuyenHangDonHangDto>
    {
        QueryExpression qe;
        IDataService<TDonHangDto> _donHangDataService = ServiceLocator.Instance.GetInstance<IDataService<TDonHangDto>>();
        List<TDonHangDto> donHangsChuaXong;

        partial void InitFilterPartial()
        {
            _MaChuyenHangFilter = new HeaderTextFilterModel(TextManager.TChuyenHangDonHang_MaChuyenHang, nameof(TChuyenHangDonHangDto.MaChuyenHang), typeof(int));
            _MaDonHangFilter = new HeaderTextFilterModel(TextManager.TChuyenHangDonHang_MaDonHang, nameof(TChuyenHangDonHangDto.MaDonHang), typeof(int));
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RNhanVienDto>.Instance.Load();
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RKhachHangDto>.Instance.Load();

            if (qe == null)
            {
                qe = new QueryExpression();
                qe.WhereOptions.Add(new WhereExpression.WhereOptionBool()
                {
                    Predicate = "=",
                    PropertyPath = nameof(TDonHangDto.Xong),
                    Value = false
                });
            }
            donHangsChuaXong = _donHangDataService.Get(qe).Items;
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChuyenHangDonHangDto dto)
        {
            if (dto.TChuyenHang != null)
            {
                dto.TChuyenHang.RNhanVien = ReferenceDataManager<RNhanVienDto>.Instance.GetList().Find(p => p.ID == dto.TChuyenHang.MaNhanVienGiaoHang);
            }

            var donHangs = new List<TDonHangDto>();
            if (dto.TDonHang != null)
            {
                donHangs.Add(dto.TDonHang);
            }
            donHangs.AddRange(donHangsChuaXong);

            foreach (var item in donHangs)
            {
                item.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetList().Find(p => p.ID == item.MaKhachHang);
                item.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetList().Find(p => p.ID == item.MaKhoHang);
            }
            dto.MaDonHangSources = donHangs;
        }
    }
}
