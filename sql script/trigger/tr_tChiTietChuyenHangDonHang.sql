USE [PhuDinh]
GO

DROP TRIGGER [dbo].[tr_tChiTietChuyenHangDonHang]
GO

/****** Object:  Trigger [dbo].[tr_tChiTietChuyenHangDonHang]    Script Date: 29/12/2016 6:37:58 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_tChiTietChuyenHangDonHang]
	ON [dbo].[tChiTietChuyenHangDonHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		print('trigger [tr_tChiTietChuyenHangDonHang]');
		IF trigger_nestlevel() > 1
			return

		SET NOCOUNT ON
		
		print('update SoLuongTheoDonHang of tChiTietChuyenHangDonHang')
		update tChiTietChuyenHangDonHang
		set SoLuongTheoDonHang = (select SoLuong from tChiTietDonHang where Ma = tChiTietChuyenHangDonHang.MaChiTietDonHang)
		from inserted i
		where tChiTietChuyenHangDonHang.Ma = i.Ma

		print('update Xong of tChiTietDonHang')
		update [dbo].[tChiTietDonHang]
		set Xong = 0
		from (select distinct(MaChiTietDonHang) as Ma from inserted
			union select distinct( MaChiTietDonHang) as Ma from deleted) as t
		where [dbo].[tChiTietDonHang].Ma = t.Ma and Xong = 1
		and SoLuong <> (select isnull(sum(SoLuong), -1) from [dbo].[tChiTietChuyenHangDonHang] where MaChiTietDonHang = t.Ma)
		
		update [dbo].[tChiTietDonHang]
		set Xong = 1
		from (select distinct(MaChiTietDonHang) as Ma from inserted
			union select distinct(MaChiTietDonHang) as Ma from deleted) as t
		where [dbo].[tChiTietDonHang].Ma = t.Ma and Xong = 0
		and SoLuong = (select isnull(sum(SoLuong),-1) from [dbo].[tChiTietChuyenHangDonHang] where MaChiTietDonHang = t.Ma)
		
		print('update Xong of tDonHang')
		;with cte as(
			select distinct(chdh.MaDonHang)
			from (select MaChuyenHangDonHang from inserted union select MaChuyenHangDonHang from deleted) as t
			join tChuyenHangDonHang chdh on t.MaChuyenHangDonHang = chdh.Ma
		)
		update dh
		set Xong = case when exists(select * from tChiTietDonHang where MaDonHang=dh.Ma and Xong=0)
						then 0
						else 1
					end
		from tDonHang dh, cte
		where dh.Ma = cte.MaDonHang

		print('update TongSoLuongThucTe of tChuyenHangDonHang')
		update tChuyenHangDonHang
		set TongSoLuongThucTe = (select ISNULL(sum(SoLuong), 0) from tChiTietChuyenHangDonHang where MaChuyenHangDonHang = tChuyenHangDonHang.Ma)
		where tChuyenHangDonHang.Ma in (select distinct(MaChuyenHangDonHang) from inserted union select distinct(MaChuyenHangDonHang) from deleted)

		print('update TongSoLuongThucTe of tChuyenHang')
		;with cte as(
			select MaChuyenHang, ISNULL(sum(chdh.TongSoLuongThucTe), 0) TongSoLuongThucTe
			from (select distinct(MaChuyenHangDonHang) from inserted union select distinct(MaChuyenHangDonHang) from deleted) as t
			join tChuyenHangDonHang chdh on t.MaChuyenHangDonHang = chdh.Ma
			group by chdh.MaChuyenHang
		)
		update ch
		set TongSoLuongThucTe = cte.TongSoLuongThucTe
		from tChuyenHang ch, cte	
		where ch.Ma = cte.MaChuyenHang
	END
GO

ALTER TABLE [dbo].[tChiTietChuyenHangDonHang] ENABLE TRIGGER [tr_tChiTietChuyenHangDonHang]
GO

