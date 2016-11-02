﻿using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TPhuThuKhachHangController : SwaEntityBaseController<PhuDinhServerContext, TPhuThuKhachHang, TPhuThuKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref TPhuThuKhachHangDto dto, TPhuThuKhachHang entity);
        partial void ConvertToEntityPartial(ref TPhuThuKhachHang entity, TPhuThuKhachHangDto dto);

        public override TPhuThuKhachHangDto ConvertToDto(TPhuThuKhachHang entity)
        {
            var dto = new TPhuThuKhachHangDto();
            dto.Ma = entity.Ma;
            dto.GhiChu = entity.GhiChu;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.Ngay = entity.Ngay;
            dto.SoTien = entity.SoTien;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TPhuThuKhachHang ConvertToEntity(TPhuThuKhachHangDto dto)
        {
            var entity = new TPhuThuKhachHang();
            entity.Ma = dto.Ma;
            entity.GhiChu = dto.GhiChu;
            entity.MaKhachHang = dto.MaKhachHang;
            entity.Ngay = dto.Ngay;
            entity.SoTien = dto.SoTien;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}
