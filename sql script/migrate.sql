--select *
--from sys.tables tb
--inner join sys.schemas sc on tb.schema_id = sc.schema_id
--inner join sys.columns col on tb.object_id = col.object_id

drop table webpages_UsersInRoles;
drop table webpages_OAuthMembership
drop table webpages_Membership
drop table webpages_Roles
drop table UserProfile

DROP TRIGGER tChiTietChuyenHangDonHang_trUpdateTongSoLuongThucTe
DROP TRIGGER tChiTietChuyenHangDonHang_trUpdateSoLuongTheoDonHang
DROP TRIGGER tChiTietChuyenHangDonHang_trUpdateXong
DROP TRIGGER tChiTietChuyenKho_trUpdateTonKho
DROP TRIGGER tChiTietDonHang_trUpdateTonKho
DROP TRIGGER tChiTietDonHang_trUpdateCongNo
DROP TRIGGER tChiTietDonHang_trUpdateDonHangTongSoLuong
DROP TRIGGER tChiTietDonHang_trUpdateXong
DROP TRIGGER tChiTietDonHang_trUpdateChiTietChuyenHangDonHangSoLuongTheoDonHang
DROP TRIGGER tChiTietNhapHang_trUpdateTonKho
DROP TRIGGER tChiTietToaHang_trUpdateCongNo
DROP TRIGGER tChuyenHangDonHang_trUpdateChuyenHang_TongDonHang
DROP TRIGGER tChuyenHangDonHang_trUpdateTongSoLuongTheoDonHang
DROP TRIGGER tChuyenKho_trUpdateTonKho
DROP TRIGGER tDonHang_trUpdateTonKho
DROP TRIGGER tDonHang_trUpdateTongSoLuongTheoDonHang
DROP TRIGGER tGiamTruKhachHang_trUpdateCongNo
DROP TRIGGER tNhanTienKhachHang_trUpdateCongNo
DROP TRIGGER tNhapHang_trUpdateTonKho
DROP TRIGGER tPhuThuKhachHang_trUpdateCongNo

exec sp_msforeachtable 'alter table ? add GroupID int not null default 1';

GO
/****** Object:  Table [dbo].[SwaGroup]    Script Date: 11/22/2016 2:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SwaGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[GroupName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SwaUser]    Script Date: 11/22/2016 2:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SwaUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[PasswordHash] [varchar](128) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SwaUserGroup]    Script Date: 11/22/2016 2:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SwaUserGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
	[IsGroupOwner] [bit] NOT NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SwaGroup] ADD  CONSTRAINT [DF_SwaGroup_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[SwaUser] ADD  CONSTRAINT [DF_SwaUser_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[SwaUserGroup]  WITH CHECK ADD  CONSTRAINT [FK_SwaUserGroup_SwaGroup] FOREIGN KEY([GroupID])
REFERENCES [dbo].[SwaGroup] ([ID])
GO
ALTER TABLE [dbo].[SwaUserGroup] CHECK CONSTRAINT [FK_SwaUserGroup_SwaGroup]
GO
ALTER TABLE [dbo].[SwaUserGroup]  WITH CHECK ADD  CONSTRAINT [FK_SwaUserGroup_SwaUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[SwaUser] ([ID])
GO
ALTER TABLE [dbo].[SwaUserGroup] CHECK CONSTRAINT [FK_SwaUserGroup_SwaUser]
GO

INSERT [dbo].[SwaGroup] ([GroupName]) VALUES (N'vinhphat')
INSERT [dbo].[SwaUser] ([Email], [PasswordHash]) VALUES (N'huy', N'GIM2I1LihP/Im/zVlMLZIJcN7EgWdFbWH3jN0HXIF3u2NHxd1FiJef4b01PiGwxH')--nobita
INSERT [dbo].[SwaUserGroup] ([UserID], [GroupID], [IsGroupOwner]) VALUES (1, 1, 1)
