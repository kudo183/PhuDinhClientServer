USE [PhuDinh]
GO

DROP TRIGGER [dbo].[tr_tChiTietToaHang]
GO

/****** Object:  Trigger [dbo].[tr_tChiTietToaHang]    Script Date: 29/12/2016 6:39:33 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_tChiTietToaHang]
	ON [dbo].[tChiTietToaHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		print('trigger [tr_tChiTietToaHang]')
		IF trigger_nestlevel() > 1
			return

		print('update SoTien of tCongNoKhachHang')
		-- this query will wrong when inserted have multiple row with same MaToaHang (only first (order by asc Ma) SoTien is use)
		--update cn
		--set cn.SoTien = cn.SoTien + (i.GiaTien*ct.SoLuong)
		--from inserted i join tToaHang th on i.MaToaHang = th.Ma
		--join tCongNoKhachHang cn on cn.MaKhachHang = th.MaKhachHang
		--join tChiTietDonHang ct on i.MaChiTietDonHang = ct.Ma
		--where cn.Ngay >= th.Ngay

		;with cte as(
			select Ngay, isnull(sum(GiaTien*ctdh.SoLuong),0) as SoTien, MaKhachHang
			from(
				SELECT GiaTien, MaToaHang, MaChiTietDonHang FROM inserted
				union
				SELECT -GiaTien, MaToaHang, MaChiTietDonHang FROM deleted) as t
			JOIN tChiTietDonHang ctdh on ctdh.Ma=t.MaChiTietDonHang
			JOIN tToaHang th on th.Ma=t.MaToaHang
			group by Ngay, MaKhachHang) 
		update cn
		set cn.SoTien = cn.SoTien + cte.SoTien
		from tCongNoKhachHang cn, cte
		where cn.Ngay>=cte.Ngay and cn.MaKhachHang=cte.MaKhachHang
	END


GO

ALTER TABLE [dbo].[tChiTietToaHang] ENABLE TRIGGER [tr_tChiTietToaHang]
GO

