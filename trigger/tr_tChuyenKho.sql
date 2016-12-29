USE [PhuDinh]
GO

/****** Object:  Trigger [dbo].[tr_tChuyenKho]    Script Date: 29/12/2016 6:40:07 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tr_tChuyenKho]
	ON [dbo].[tChuyenKho]
	after UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		
		print('trigger [tr_tChuyenKho]')
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
			select sum(t.SoLuong) as SoLuong, t.Ngay, t.MaKhoHangNhap as MaKhoHang, t.MaMatHang
			from(select SoLuong, MaKhoHangNhap, MaMatHang, Ngay from inserted i join tChiTietChuyenKho ct on i.Ma = ct.MaChuyenKho
				union
				select -SoLuong, MaKhoHangNhap, MaMatHang, Ngay from deleted d join tChiTietChuyenKho ct on d.Ma = ct.MaChuyenKho) as t
			group by t.MaKhoHangNhap, t.MaMatHang, t.Ngay
			union
			select sum(t.SoLuong) as SoLuong, t.Ngay, t.MaKhoHangXuat as MaKhoHang, t.MaMatHang
			from(select SoLuong, MaKhoHangXuat, MaMatHang, Ngay from deleted d join tChiTietChuyenKho ct on d.Ma = ct.MaChuyenKho
				union
				select -SoLuong, MaKhoHangXuat, MaMatHang, Ngay from inserted i join tChiTietChuyenKho ct on i.Ma = ct.MaChuyenKho) as t
			group by t.MaKhoHangXuat, t.MaMatHang, t.Ngay
		)
		update tk
		set tk.SoLuong = tk.SoLuong + cte.SoLuong
		from tTonKho tk, cte		
		where tk.Ngay>=cte.Ngay and tk.MaKhoHang=cte.MaKhoHang and tk.MaMatHang=cte.MaMatHang
	END
 	



GO

ALTER TABLE [dbo].[tChuyenKho] ENABLE TRIGGER [tr_tChuyenKho]
GO

