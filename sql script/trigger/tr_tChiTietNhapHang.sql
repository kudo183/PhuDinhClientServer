USE [PhuDinh]
GO

DROP TRIGGER [dbo].[tr_tChiTietNhapHang]
GO

/****** Object:  Trigger [dbo].[tr_tChiTietNhapHang]    Script Date: 29/12/2016 6:39:18 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_tChiTietNhapHang]
	ON [dbo].[tChiTietNhapHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		print('trigger [tr_tChiTietNhapHang]')
		IF trigger_nestlevel() > 1
			return
					
		print('update SoLuong of tTonKho')		
		-- this query will wrong when inserted have multiple row with same MaDonHang and MaMatHang (only first (order by asc Ma) SoLuong is use)
		--update tk
		--set tk.SoLuong = tk.SoLuong - i.SoLuong
		--from inserted i join tDonHang dh on i.MaDonHang = dh.Ma
		--join tTonKho tk on tk.MaMatHang = i.MaMatHang and tk.MaKhoHang = dh.MaKhoHang
		--where tk.Ngay >= dh.Ngay
		;with cte as (
				select sum(t.SoLuong) as SoLuong, dh.Ngay, dh.MaKhoHang, t.MaMatHang
				from(select SoLuong, MaNhapHang, MaMatHang from inserted
					union
					select -SoLuong, MaNhapHang, MaMatHang from deleted) as t
				join tNhapHang dh on t.MaNhapHang = dh.Ma
				group by dh.MaKhoHang, t.MaMatHang, dh.Ngay
			)
		update tk
		set tk.SoLuong = tk.SoLuong + cte.SoLuong
		from tTonKho tk, cte		
		where tk.Ngay>=cte.Ngay and tk.MaKhoHang=cte.MaKhoHang and tk.MaMatHang=cte.MaMatHang
	END
 	



GO

ALTER TABLE [dbo].[tChiTietNhapHang] ENABLE TRIGGER [tr_tChiTietNhapHang]
GO

