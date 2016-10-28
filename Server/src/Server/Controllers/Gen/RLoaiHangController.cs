﻿using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RLoaiHangController : SwaEntityBaseController<PhuDinhServerContext, RLoaiHang, RLoaiHangDto>
    {
        public override RLoaiHangDto ConvertToDto(RLoaiHang entity)
        {
            var dto = new RLoaiHangDto();
            dto.Ma = entity.Ma;
            dto.HangNhaLam = entity.HangNhaLam;
            dto.TenLoai = entity.TenLoai;
            return dto;
        }

        public override RLoaiHang ConvertToEntity(RLoaiHangDto dto)
        {
            var entity = new RLoaiHang();
            entity.Ma = dto.Ma;
            entity.HangNhaLam = dto.HangNhaLam;
            entity.TenLoai = dto.TenLoai;
            return entity;
        }
    }
}