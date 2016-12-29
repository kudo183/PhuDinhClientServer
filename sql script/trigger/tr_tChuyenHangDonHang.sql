USE [PhuDinh]
GO

/****** Object:  Trigger [dbo].[tr_tChuyenHangDonHang]    Script Date: 29/12/2016 6:39:54 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tr_tChuyenHangDonHang]
	ON [dbo].[tChuyenHangDonHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		print('trigger [tr_tChuyenHangDonHang]');
		IF trigger_nestlevel() > 1
			return

		SET NOCOUNT ON
		
		print('update TongSoLuongTheoDonHang of tChuyenHangDonHang');
		update tChuyenHangDonHang
		set TongSoLuongTheoDonHang = (select TongSoLuong from tDonHang where Ma = tChuyenHangDonHang.MaDonHang)
		where tChuyenHangDonHang.Ma in (select distinct(Ma) from inserted union select distinct(Ma) from deleted)

		print('update TongSoLuongTheoDonHang, TongDonHang of tChuyenHang')
		update tChuyenHang
		set TongSoLuongTheoDonHang = (select ISNULL(sum(TongSoLuongTheoDonHang), 0) from tChuyenHangDonHang where MaChuyenHang = tChuyenHang.Ma)
			,TongDonHang = (select count(distinct(MaDonHang)) from tChuyenHangDonHang where MaChuyenHang = tChuyenHang.Ma)
		where tChuyenHang.Ma in (select distinct(MaChuyenHang) from inserted union select distinct(MaChuyenHang) from deleted)
	END
GO

ALTER TABLE [dbo].[tChuyenHangDonHang] ENABLE TRIGGER [tr_tChuyenHangDonHang]
GO

