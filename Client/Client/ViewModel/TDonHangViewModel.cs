using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;
using System.Linq;

namespace Client.ViewModel
{
    public class TDonHangViewModel : BaseViewModel<TDonHangDto>
    {
        private HeaderComboBoxFilterModel _chanhFilter;
        private HeaderComboBoxFilterModel _khachHangFilter;
        private HeaderComboBoxFilterModel _khoHangFilter;

        public TDonHangViewModel() : base()
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

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(TDonHangDto.Ma), typeof(int)));
            AddHeaderFilter(new HeaderDateFilterModel("Ngay", nameof(TDonHangDto.Ngay), typeof(System.DateTime)));
            AddHeaderFilter(_khachHangFilter);
            AddHeaderFilter(_khoHangFilter);
            AddHeaderFilter(_chanhFilter);
            AddHeaderFilter(new HeaderTextFilterModel("So Luong", nameof(TDonHangDto.TongSoLuong), typeof(int)));
            AddHeaderFilter(new HeaderCheckFilterModel("Xong", nameof(TDonHangDto.Xong), typeof(bool)));
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
            ReferenceDataManager<RKhachHangChanhDto>.Instance.Load();
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RChanhDto>.Instance.Load();
        }

        protected override void ProcessDtoBeforeAddToEntities(TDonHangDto dto)
        {
            dto.KhachHangs = ReferenceDataManager<RKhachHangDto>.Instance.Get();
            dto.KhoHangs = ReferenceDataManager<RKhoHangDto>.Instance.Get();
            UpdateChanhs(dto);

            dto.PropertyChanged += Dto_PropertyChanged;
        }

        private void Dto_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as TDonHangDto;
            switch(e.PropertyName)
            {
                case nameof(TDonHangDto.MaKhachHang):
                    UpdateChanhs(dto);
                    break;
            }
        }

        protected override void ProcessNewAddedDto(TDonHangDto dto)
        {
            dto.Ngay = System.DateTime.UtcNow;
            if (_chanhFilter.FilterValue != null)
            {
                dto.MaChanh = (int)_chanhFilter.FilterValue;
            }
            if (_khachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_khachHangFilter.FilterValue;
            }
            if (_khoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_khoHangFilter.FilterValue;
            }
            dto.KhachHangs = ReferenceDataManager<RKhachHangDto>.Instance.Get();
            dto.KhoHangs = ReferenceDataManager<RKhoHangDto>.Instance.Get();

            dto.PropertyChanged += Dto_PropertyChanged;
        }

        void ProcessMaKhachHangChanged(TDonHangDto dto)
        {
            UpdateChanhs(dto);
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
    }
}
