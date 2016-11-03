using Client.Abstraction;
using DTO;
using QueryBuilder;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;

namespace Client.ViewModel
{
    public partial class TChiTietToaHangViewModel : BaseViewModel<TChiTietToaHangDto>
    {
        QueryExpression qe;
        IDataService<TChiTietDonHangDto> _chiTietDonHangDataService = ServiceLocator.Instance.GetInstance<IDataService<TChiTietDonHangDto>>();
        List<TChiTietDonHangDto> chiTietDonHangsChuaXong;

        partial void InitFilterPartial()
        {
            _MaToaHangFilter = new HeaderTextFilterModel(TextManager.TChiTietToaHang_MaToaHang, nameof(TChiTietToaHangDto.MaToaHang), typeof(int));
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
            ReferenceDataManager<RKhoHangDto>.Instance.Load();

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

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietToaHangDto dto)
        {
            if (dto.TToaHang != null)
            {
                dto.TToaHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetList().Find(p => p.Ma == dto.TToaHang.MaKhachHang);
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
                    item.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetList().Find(p => p.Ma == item.TDonHang.MaKhachHang);
                    item.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetList().Find(p => p.Ma == item.TDonHang.MaKhoHang);
                }
                item.TMatHang = ReferenceDataManager<TMatHangDto>.Instance.GetList().Find(p => p.Ma == item.MaMatHang);
            }
            dto.MaChiTietDonHangSources = chiTietDonHangs;
        }
    }
}
