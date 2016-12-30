USE [PhuDinh]
GO

DROP TRIGGER [dbo].[tr_tChiTietDonHang]
GO

/****** Object:  Trigger [dbo].[tr_tChiTietDonHang]    Script Date: 29/12/2016 6:39:03 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_tChiTietDonHang]
	ON [dbo].[tChiTietDonHang]
	after UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		
		print('trigger [tr_tChiTietDonHang]')
		IF trigger_nestlevel() > 1
			return

		if(update(SoLuong))
		begin
			print('update Xong of tChiTietDonHang')
			update tChiTietDonHang
			set Xong = case when SoLuong = (select isnull(Sum(SoLuong),-1) from tChiTietChuyenHangDonHang where MaChiTietDonHang = tChiTietDonHang.Ma)
							then 1
							else 0
						end
			where Ma in (select distinct(Ma) from inserted)
		end

		print('update Xong, TongSoLuong of tDonHang')		
		update tDonHang
		set Xong = case when exists(select * from tChiTietDonHang where MaDonHang=Ma and Xong=0)
						then 0
						else 1
					end
			,TongSoLuong = (select ISNULL(sum(SoLuong), 0) from tChiTietDonHang where MaDonHang=Ma)
		where Ma in (select distinct(MaDonHang) from inserted union select distinct(MaDonHang) from deleted)

		print('update SoLuongTheoDonHang of tChiTietChuyenHangDonHang')
		update tChiTietChuyenHangDonHang
		set SoLuongTheoDonHang = i.SoLuong
		from inserted as i
		where tChiTietChuyenHangDonHang.MaChiTietDonHang = i.Ma
		
		print('update TongSoLuongTheoDonHang of tChuyenHangDonHang')
		update tChuyenHangDonHang
		set TongSoLuongTheoDonHang = dh.TongSoLuong
		from (select distinct(MaDonHang) from inserted union select distinct(MaDonHang) from deleted) t
			join tDonHang dh on t.MaDonHang=dh.Ma
		where tChuyenHangDonHang.MaDonHang = dh.Ma
		
		print('update TongSoLuongTheoDonHang of tChuyenHang')
		;with cte as(
			select chdh.MaChuyenHang, isnull(sum(TongSoLuongTheoDonHang),0) as TongSoLuongTheoDonHang
			from (select distinct(MaDonHang) from inserted union select distinct(MaDonHang) from deleted) t
				join tDonHang dh on t.MaDonHang=dh.Ma
				join tChuyenHangDonHang chdh on chdh.MaDonHang=dh.Ma
			group by chdh.MaChuyenHang
		)
		update ch
		set TongSoLuongTheoDonHang = cte.TongSoLuongTheoDonHang
		from tChuyenHang ch, cte
		where ch.Ma=cte.MaChuyenHang

		print('update SoLuong of tTonKho')		
		-- this query will wrong when inserted have multiple row with same MaDonHang and MaMatHang (only first (order by asc Ma) SoLuong is use)
		--update tk
		--set tk.SoLuong = tk.SoLuong - i.SoLuong
		--from inserted i join tDonHang dh on i.MaDonHang = dh.Ma
		--join tTonKho tk on tk.MaMatHang = i.MaMatHang and tk.MaKhoHang = dh.MaKhoHang
		--where tk.Ngay >= dh.Ngay
		;with cte as (
				select sum(t.SoLuong) as SoLuong, dh.Ngay, dh.MaKhoHang, t.MaMatHang
				from(select SoLuong, MaDonHang, MaMatHang from inserted
					union
					select -SoLuong, MaDonHang, MaMatHang from deleted) as t
				join tDonHang dh on t.MaDonHang = dh.Ma
				group by dh.MaKhoHang, t.MaMatHang, dh.Ngay
			)
		update tk
		set tk.SoLuong = tk.SoLuong - cte.SoLuong
		from tTonKho tk, cte		
		where tk.Ngay>=cte.Ngay and tk.MaKhoHang=cte.MaKhoHang and tk.MaMatHang=cte.MaMatHang

		print('update SoTien of tCongNoKhachHang')
		;with cte as(
			select th.Ngay, isnull(sum(ctth.GiaTien*t.SoLuong),0) as SoTien, th.MaKhachHang
			from(
				SELECT SoLuong, Ma FROM inserted
				union
				SELECT -SoLuong, Ma FROM deleted) as t
			join tChiTietToaHang ctth on ctth.MaChiTietDonHang=t.Ma
			join tToaHang th on th.Ma=ctth.MaToaHang
			join tCongNoKhachHang cn on cn.MaKhachHang=th.MaKhachHang
			group by th.Ngay, th.MaKhachHang) 
		update cn
		set cn.SoTien = cn.SoTien + cte.SoTien
		from tCongNoKhachHang cn, cte
		where cn.Ngay>=cte.Ngay and cn.MaKhachHang=cte.MaKhachHang
	END
GO

ALTER TABLE [dbo].[tChiTietDonHang] ENABLE TRIGGER [tr_tChiTietDonHang]
GO

