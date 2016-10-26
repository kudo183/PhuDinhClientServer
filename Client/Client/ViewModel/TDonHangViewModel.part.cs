using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;
using System.Linq;

namespace Client.ViewModel
{
    public partial class TDonHangViewModel : BaseViewModel<TDonHangDto>
    {
        partial void InitFilterPartial()
        {
            _khachHangFilter = new HeaderComboBoxFilterModel(
                "Khach Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TDonHangDto.MaKhachHang),
                typeof(int),
                nameof(RKhachHangDto.TenKhachHang),
                nameof(RKhachHangDto.Ma));
            _khachHangFilter.AddCommand = new SimpleCommand("KhachHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                  new View.RKhachHangView(), "Khach Hang Chanh", ReferenceDataManager<RKhachHangDto>.Instance.Load)
            );
            _khachHangFilter.ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            _khoHangFilter = new HeaderComboBoxFilterModel(
                "Kho Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TDonHangDto.MaKhoHang),
                typeof(int),
                nameof(RKhoHangDto.TenKho),
                nameof(RKhoHangDto.Ma));
            _khoHangFilter.AddCommand = new SimpleCommand("KhoHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                  new View.RKhoHangView(), "Kho Hang", ReferenceDataManager<RKhoHangDto>.Instance.Load)
            );
            _khoHangFilter.ItemSource = ReferenceDataManager<RKhoHangDto>.Instance.Get();

            _chanhFilter = new HeaderComboBoxFilterModel(
                "Chanh", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TDonHangDto.MaChanh),
                typeof(int?),
                nameof(RChanhDto.TenChanh),
                nameof(RChanhDto.Ma));
            _chanhFilter.AddCommand = new SimpleCommand("ChanhAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RKhachHangChanhView(), "Khach Hang Chanh", AfterKhachHangChanhDialog)
            );
            _chanhFilter.ItemSource = ReferenceDataManager<RChanhDto>.Instance.Get();
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RKhachHangChanhDto>.Instance.Load();
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TDonHangDto dto)
        {
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

            var chanhs = new System.Collections.Generic.List<DTO.RChanhDto>();
            foreach (var item in khachHangChanhs)
            {
                var chanh = ReferenceDataManager<RChanhDto>.Instance.GetList().First(p => p.Ma == item.MaChanh);
                if (item.LaMacDinh == true)
                {
                    chanhs.Insert(0, chanh);
                }
                else
                {
                    chanhs.Add(chanh);
                }
            }
            dto.Chanhs = chanhs;
            if (chanhs.Count > 0)
            {
                dto.MaChanh = chanhs[0].Ma;
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
