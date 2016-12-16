using Client.Abstraction;
using DTO;
using QueryBuilder;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModel
{
    public partial class TChiTietToaHangViewModel : BaseViewModel<TChiTietToaHangDto>
    {
        IDataService<TChiTietDonHangDto> _chiTietDonHangDataService = ServiceLocator.Instance.GetInstance<IDataService<TChiTietDonHangDto>>();
        List<TChiTietDonHangDto> chiTietDonHangsGanDay;

        partial void InitFilterPartial()
        {
            _MaToaHangFilter = new HeaderTextFilterModel(TextManager.TChiTietToaHang_MaToaHang, nameof(TChiTietToaHangDto.MaToaHang), typeof(int));
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<TMatHangDto>.Instance.Load();
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietToaHangDto dto)
        {
            if (dto.TToaHang != null)
            {
                dto.TToaHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetByID(dto.TToaHang.MaKhachHang);
            }

            dto.MaChiTietDonHangSources = chiTietDonHangsGanDay;
        }

        protected override void BeforeLoad()
        {
            var qe = new QueryExpression();
            var toaHang = ParentItem as TToaHangDto;
            if (toaHang != null)
            {
                qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                  WhereExpression.Equal, "MaDonHangNavigation.MaKhachHang", toaHang.MaKhachHang);
            }
            qe.AddWhereOption<WhereExpression.WhereOptionDate, System.DateTime>(
                WhereExpression.GreaterThanOrEqual, "MaDonHangNavigation.Ngay", System.DateTime.Now.Date.AddDays(-7));
            qe.AddOrderByOption("MaDonHangNavigation.Ngay", false);
            chiTietDonHangsGanDay = _chiTietDonHangDataService.Get(qe).Items;

            foreach (var item in chiTietDonHangsGanDay)
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
