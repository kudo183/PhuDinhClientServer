using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RCanhBaoTonKhoController : SwaEntityBaseController<PhuDinhServerContext, RCanhBaoTonKho, RCanhBaoTonKhoDto>
    {
        partial void ConvertToDtoPartial(ref RCanhBaoTonKhoDto dto, RCanhBaoTonKho entity);
        partial void ConvertToEntityPartial(ref RCanhBaoTonKho entity, RCanhBaoTonKhoDto dto);

        public override RCanhBaoTonKhoDto ConvertToDto(RCanhBaoTonKho entity)
        {
            var dto = new RCanhBaoTonKhoDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaKhoHang = entity.MaKhoHang;
            dto.MaMatHang = entity.MaMatHang;
            dto.TonCaoNhat = entity.TonCaoNhat;
            dto.TonThapNhat = entity.TonThapNhat;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RCanhBaoTonKho ConvertToEntity(RCanhBaoTonKhoDto dto)
        {
            var entity = new RCanhBaoTonKho();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.MaKhoHang = dto.MaKhoHang;
            entity.MaMatHang = dto.MaMatHang;
            entity.TonCaoNhat = dto.TonCaoNhat;
            entity.TonThapNhat = dto.TonThapNhat;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}
