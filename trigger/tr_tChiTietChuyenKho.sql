USE [PhuDinh]
GO

/****** Object:  Trigger [dbo].[tr_tChiTietChuyenKho]    Script Date: 29/12/2016 6:38:49 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tr_tChiTietChuyenKho]
	ON [dbo].[tChiTietChuyenKho]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		
		print('trigger [tr_tChiTietChuyenKho]')
		IF trigger_nestlevel() > 1
			return

		print('update SoLuong of tTonKho')
		-- this query will wrong if have multiple row with same MaDonHang and MaMatHang (only first (order by asc Ma) SoLuong is use)
		--update tk
		--set tk.SoLuong = tk.SoLuong - ct.SoLuong
		--from inserted i join tChiTietDonHang ct on i.Ma = ct.MaDonHang
		--join tTonKho tk on tk.MaMatHang = ct.MaMatHang and tk.MaKhoHang = i.MaKhoHang
		--where tk.Ngay >= i.Ngay
		;with cte as (
			select sum(t.SoLuong) as SoLuong, ck.Ngay, ck.MaKhoHangNhap as MaKhoHang, t.MaMatHang
			from(select SoLuong, MaChuyenKho, MaMatHang from inserted
				union
				select -SoLuong, MaChuyenKho, MaMatHang from deleted) as t
			join tChuyenKho ck on t.MaChuyenKho = ck.Ma
			group by ck.MaKhoHangNhap, t.MaMatHang, ck.Ngay
			union
			select sum(t.SoLuong) as SoLuong, ck.Ngay, ck.MaKhoHangXuat as MaKhoHang, t.MaMatHang
			from(select SoLuong, MaChuyenKho, MaMatHang from deleted
				union
				select -SoLuong, MaChuyenKho, MaMatHang from inserted) as t
			join tChuyenKho ck on t.MaChuyenKho = ck.Ma
			group by ck.MaKhoHangXuat, t.MaMatHang, ck.Ngay
		)
		update tk
		set tk.SoLuong = tk.SoLuong + cte.SoLuong
		from tTonKho tk, cte		
		where tk.Ngay>=cte.Ngay and tk.MaKhoHang=cte.MaKhoHang and tk.MaMatHang=cte.MaMatHang
	END
 	




GO

ALTER TABLE [dbo].[tChiTietChuyenKho] ENABLE TRIGGER [tr_tChiTietChuyenKho]
GO

