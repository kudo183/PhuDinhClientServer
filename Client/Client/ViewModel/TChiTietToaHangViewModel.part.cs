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

            var list = new List<TChiTietDonHangDto>(chiTietDonHangsGanDay);
            var ctdh = dto.TChiTietDonHang;
            if (ctdh != null && list.Any(p => p.ID == dto.MaChiTietDonHang) == false)
            {
                if (ctdh.TDonHang != null)
                {
                    ctdh.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetByID(ctdh.TDonHang.MaKhachHang);
                    ctdh.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetByID(ctdh.TDonHang.MaKhoHang);
                }
                ctdh.TMatHang = ReferenceDataManager<TMatHangDto>.Instance.GetByID(ctdh.MaMatHang);
                list.Add(ctdh);
            }

            dto.MaChiTietDonHangSources = list;
            dto.PropertyChanged += Dto_PropertyChanged;
        }

        void Dto_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as TChiTietToaHangDto;
            switch (e.PropertyName)
            {
                case nameof(TChiTietToaHangDto.MaChiTietDonHang):
                    dto.TChiTietDonHang = chiTietDonHangsGanDay.Find(p => p.Ma == dto.MaChiTietDonHang);
                    dto.OnPropertyChanged(nameof(TChiTietToaHangDto.ThanhTien));
                    break;
                case nameof(TChiTietToaHangDto.GiaTien):
                    dto.OnPropertyChanged(nameof(TChiTietToaHangDto.ThanhTien));
                    break;
            }
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
