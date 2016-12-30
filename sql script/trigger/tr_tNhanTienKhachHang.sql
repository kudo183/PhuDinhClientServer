USE [PhuDinh]
GO

DROP TRIGGER [dbo].[tr_tNhanTienKhachHang]
GO

/****** Object:  Trigger [dbo].[tr_tNhanTienKhachHang]    Script Date: 29/12/2016 6:40:50 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_tNhanTienKhachHang]
	ON [dbo].[tNhanTienKhachHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		
		print('trigger [tr_tNhanTienKhachHang]')
		IF trigger_nestlevel() > 1
			return
		
		print('update SoTien of tCongNoKhachHang')
		;with cte as(
			select Ngay, isnull(sum(SoTien),0) as SoTien, MaKhachHang
			from(
				SELECT SoTien, Ngay, MaKhachHang FROM inserted
				union
				SELECT -SoTien, Ngay, MaKhachHang FROM deleted) as t
			group by Ngay, MaKhachHang) 
		update cn
		set cn.SoTien = cn.SoTien - cte.SoTien
		from tCongNoKhachHang cn, cte
		where cn.Ngay>=cte.Ngay and cn.MaKhachHang=cte.MaKhachHang
	END
GO

ALTER TABLE [dbo].[tNhanTienKhachHang] ENABLE TRIGGER [tr_tNhanTienKhachHang]
GO

