using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;
using QueryBuilder;
using System.Collections.Generic;

namespace Client.ViewModel
{
    public partial class TChuyenHangDonHangViewModel : BaseViewModel<TChuyenHangDonHangDto>
    {
        IDataService<TDonHangDto> _donHangDataService = ServiceLocator.Instance.GetInstance<IDataService<TDonHangDto>>();
        List<TDonHangDto> donHangsChuaXong;

        public List<TDonHangDto> DonHangsChuaXong
        {
            get { return donHangsChuaXong; }
        }

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
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChuyenHangDonHangDto dto)
        {
            if (dto.TChuyenHang != null)
            {
                dto.TChuyenHang.RNhanVien = ReferenceDataManager<RNhanVienDto>.Instance.GetByID(dto.TChuyenHang.MaNhanVienGiaoHang);
            }

            if (dto.TDonHang != null && dto.TDonHang.Xong == true)
            {
                var donHangs = new List<TDonHangDto>();
                dto.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetByID(dto.TDonHang.MaKhachHang);
                dto.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetByID(dto.TDonHang.MaKhoHang);
                donHangs.Add(dto.TDonHang);

                dto.MaDonHangSources = donHangs;
            }
            else
            {
                dto.MaDonHangSources = donHangsChuaXong;
            }
        }

        protected override void BeforeLoad()
        {
            var qe = new QueryExpression();
            qe.AddWhereOption<WhereExpression.WhereOptionBool, bool>(
                  WhereExpression.Equal, nameof(TDonHangDto.Xong), false);
            qe.AddWhereOption<WhereExpression.WhereOptionDate, System.DateTime>(
                WhereExpression.LessThanOrEqual, "Ngay", System.DateTime.Now.Date);
            qe.AddOrderByOption("Ngay", false);
            donHangsChuaXong = _donHangDataService.Get(qe).Items;

            foreach (var item in donHangsChuaXong)
            {
                item.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetByID(item.MaKhachHang);
                item.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetByID(item.MaKhoHang);
            }
        }
    }
}
