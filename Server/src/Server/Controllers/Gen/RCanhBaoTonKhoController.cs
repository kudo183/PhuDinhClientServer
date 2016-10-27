using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RCanhBaoTonKhoController : SwaEntityBaseController<PhuDinhServerContext, RCanhBaoTonKho, RCanhBaoTonKhoDto>
    {
        public override RCanhBaoTonKhoDto ConvertToDto(RCanhBaoTonKho entity)
        {
            var dto = new RCanhBaoTonKhoDto();
            dto.Ma = entity.Ma;
            dto.MaKhoHang = entity.MaKhoHang;
            dto.MaMatHang = entity.MaMatHang;
            dto.TonCaoNhat = entity.TonCaoNhat;
            dto.TonThapNhat = entity.TonThapNhat;
            return dto;
        }

        public override RCanhBaoTonKho ConvertToEntity(RCanhBaoTonKhoDto dto)
        {
            var entity = new RCanhBaoTonKho();
            entity.Ma = dto.Ma;
            entity.MaKhoHang = dto.MaKhoHang;
            entity.MaMatHang = dto.MaMatHang;
            entity.TonCaoNhat = dto.TonCaoNhat;
            entity.TonThapNhat = dto.TonThapNhat;
            return entity;
        }
    }
}
