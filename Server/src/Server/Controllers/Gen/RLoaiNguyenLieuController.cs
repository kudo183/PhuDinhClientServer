using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RLoaiNguyenLieuController : SwaEntityBaseController<PhuDinhServerContext, RLoaiNguyenLieu, RLoaiNguyenLieuDto>
    {
        public override RLoaiNguyenLieuDto ConvertToDto(RLoaiNguyenLieu entity)
        {
            var dto = new RLoaiNguyenLieuDto();
            dto.Ma = entity.Ma;
            dto.TenLoai = entity.TenLoai;
            return dto;
        }

        public override RLoaiNguyenLieu ConvertToEntity(RLoaiNguyenLieuDto dto)
        {
            var entity = new RLoaiNguyenLieu();
            entity.Ma = dto.Ma;
            entity.TenLoai = dto.TenLoai;
            return entity;
        }
    }
}
