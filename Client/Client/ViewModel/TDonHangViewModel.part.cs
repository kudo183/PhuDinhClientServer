using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;
using System.Linq;
using System;

namespace Client.ViewModel
{
    public partial class TDonHangViewModel : BaseViewModel<TDonHangDto>
    {
        partial void InitFilterPartial()
        {
            _MaChanhFilter = new HeaderComboBoxFilterModel(
                TextManager.TDonHang_MaChanh, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TDonHangDto.MaChanh),
                typeof(int?),
                nameof(RChanhDto.TenHienThi),
                nameof(RChanhDto.ID))
            {
                AddCommand = new SimpleCommand("ChanhAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhachHangChanhView(), "Khach Hang Chanh", AfterKhachHangChanhDialog)),
                ItemSource = ReferenceDataManager<RChanhDto>.Instance.Get()
            };

            _NgayFilter.IsSorted = false;
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RKhachHangChanhDto>.Instance.Load();
            ReferenceDataManager<RBaiXeDto>.Instance.Load();
        }

        partial void ProcessNewAddedDtoPartial(TDonHangDto dto)
        {
            dto.Xong = false;
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TDonHangDto dto)
        {
            if (dto.MaKhoHang == 0)
            {
                dto.MaKhoHang = Settings.Instance.DefaultMaKhoHang;
            }

            if (dto.MaKhachHang == 0)
            {
                dto.MaKhachHang = Settings.Instance.DefaultMaKhachHang;
            }

            UpdateChanhs(dto);

            dto.PropertyChanged += Dto_PropertyChanged;
        }

        void AfterKhachHangChanhDialog()
        {
            ReferenceDataManager<RChanhDto>.Instance.Load();
            ReferenceDataManager<RKhachHangChanhDto>.Instance.Load();
            foreach (var dto in Entities)
            {
                UpdateChanhs(dto);
            }
        }

        void UpdateChanhs(TDonHangDto dto)
        {
            var khachHangChanhs = ReferenceDataManager<RKhachHangChanhDto>.Instance.GetList()
                 .Where(p => p.MaKhachHang == dto.MaKhachHang);

            var chanhs = new System.Collections.Generic.List<RChanhDto>();
            foreach (var item in khachHangChanhs)
            {
                var chanh = ReferenceDataManager<RChanhDto>.Instance.GetByID(item.MaChanh);
                if (item.LaMacDinh == true)
                {
                    chanhs.Insert(0, chanh);
                }
                else
                {
                    chanhs.Add(chanh);
                }
            }
            dto.MaChanhSources = chanhs;
            if (chanhs.Count > 0)
            {
                dto.MaChanh = chanhs[0].ID;
            }
            else
            {
                dto.MaChanh = null;
            }
        }

        void Dto_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as TDonHangDto;
            switch (e.PropertyName)
            {
                case nameof(TDonHangDto.MaKhachHang):
                    UpdateChanhs(dto);
                    break;
            }
        }
    }
}
