using Server.Entities;

namespace Server.DTOs
{
    public class KhoHangDto : huypq.SwaMiddleware.SwaIDto<KhoHang>
    {
        public int Ma { get; set; }
        public string TenKho { get; set; }
        public bool TrangThai { get; set; }

        public void FromEntity(KhoHang entity)
        {
            Ma = entity.Ma;
            TenKho = entity.TenKho;
            TrangThai = entity.TrangThai;
        }

        public KhoHang ToEntity()
        {
            return new KhoHang()
            {
                Ma = Ma,
                TenKho = TenKho,
                TrangThai = TrangThai
            };
        }
    }
}
