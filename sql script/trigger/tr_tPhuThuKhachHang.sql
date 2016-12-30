USE [PhuDinh]
GO

DROP TRIGGER [dbo].[tr_tPhuThuKhachHang]
GO

/****** Object:  Trigger [dbo].[tr_tPhuThuKhachHang]    Script Date: 29/12/2016 6:41:21 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_tPhuThuKhachHang]
	ON [dbo].[tPhuThuKhachHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON

		print('trigger [tr_tPhuThuKhachHang]')
		IF trigger_nestlevel() > 1
			return
		
		;with cte as(
			select Ngay, isnull(sum(SoTien),0) as SoTien, MaKhachHang
			from(
				SELECT SoTien, Ngay, MaKhachHang FROM inserted
				union
				SELECT -SoTien, Ngay, MaKhachHang FROM deleted) as t
			group by Ngay, MaKhachHang) 
		update cn
		set cn.SoTien = cn.SoTien + cte.SoTien
		from tCongNoKhachHang cn, cte
		where cn.Ngay>=cte.Ngay and cn.MaKhachHang=cte.MaKhachHang
	END
GO

ALTER TABLE [dbo].[tPhuThuKhachHang] ENABLE TRIGGER [tr_tPhuThuKhachHang]
GO

