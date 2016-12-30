USE [PhuDinh]
GO

DROP TRIGGER [dbo].[tr_tNhapHang]
GO

/****** Object:  Trigger [dbo].[tr_tNhapHang]    Script Date: 29/12/2016 6:41:04 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_tNhapHang]
	ON [dbo].[tNhapHang]
	after UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		
		print('trigger [tr_tNhapHang]')
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
				select sum(t.SoLuong) as SoLuong, t.Ngay, t.MaKhoHang, t.MaMatHang
				from(select SoLuong, MaKhoHang, MaMatHang, Ngay from inserted i join tChiTietNhapHang ct on i.Ma = ct.MaNhapHang
					union
					select -SoLuong, MaKhoHang, MaMatHang, Ngay from deleted d join tChiTietNhapHang ct on d.Ma = ct.MaNhapHang) as t
				group by t.MaKhoHang, t.MaMatHang, t.Ngay
			)
		update tk
		set tk.SoLuong = tk.SoLuong - cte.SoLuong
		from tTonKho tk, cte		
		where tk.Ngay>=cte.Ngay and tk.MaKhoHang=cte.MaKhoHang and tk.MaMatHang=cte.MaMatHang
	END
 	



GO

ALTER TABLE [dbo].[tNhapHang] ENABLE TRIGGER [tr_tNhapHang]
GO

