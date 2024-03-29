USE [SinhVien]
GO
/****** Object:  Table [dbo].[Diemhoctap]    Script Date: 26/01/2024 2:14:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diemhoctap](
	[Diemthi] [float] NOT NULL,
	[Diemquatrinh] [float] NULL,
	[Sinhvien_Id] [int] NULL,
	[Monhoc_Id] [int] NULL,
	[masv] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Diemthi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diemrenluyen]    Script Date: 26/01/2024 2:14:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diemrenluyen](
	[diemrenluyen] [int] NOT NULL,
	[Hoten] [nvarchar](50) NULL,
	[Sinhvien_Id] [int] NULL,
	[masv] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[diemrenluyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ketquahoctap]    Script Date: 26/01/2024 2:14:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ketquahoctap](
	[Diemtongket] [int] IDENTITY(1,1) NOT NULL,
	[Hocky] [int] NULL,
	[Sinhvien_Id] [int] NULL,
	[Monhoc_Id] [int] NULL,
	[masv] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Diemtongket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lichhoc]    Script Date: 26/01/2024 2:14:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lichhoc](
	[mamonhoc] [int] IDENTITY(1,1) NOT NULL,
	[thuhoc] [nvarchar](50) NULL,
	[giobatdau] [datetime] NULL,
	[gioketthuc] [datetime] NULL,
	[phonghoc] [nvarchar](50) NULL,
	[Monhoc_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mamonhoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 26/01/2024 2:14:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[malop] [int] IDENTITY(1,1) NOT NULL,
	[tenlop] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[malop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monhoc]    Script Date: 26/01/2024 2:14:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monhoc](
	[mamonhoc] [int] IDENTITY(1,1) NOT NULL,
	[tenmh] [nvarchar](50) NULL,
	[sotinchi] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mamonhoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sinhvien]    Script Date: 26/01/2024 2:14:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sinhvien](
	[masv] [int] IDENTITY(1,1) NOT NULL,
	[hoten] [nvarchar](50) NULL,
	[ngaysinh] [datetime] NULL,
	[gioitinh] [nvarchar](50) NULL,
	[Lop_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[masv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 26/01/2024 2:14:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Lichhoc] ON 

INSERT [dbo].[Lichhoc] ([mamonhoc], [thuhoc], [giobatdau], [gioketthuc], [phonghoc], [Monhoc_Id]) VALUES (1, N'Thứ 2', CAST(N'2024-01-24T07:43:00.000' AS DateTime), CAST(N'2024-01-24T10:43:00.000' AS DateTime), N'L.612', 1)
INSERT [dbo].[Lichhoc] ([mamonhoc], [thuhoc], [giobatdau], [gioketthuc], [phonghoc], [Monhoc_Id]) VALUES (2, N'Thứ 4', CAST(N'2024-01-24T12:13:00.000' AS DateTime), CAST(N'2024-01-24T12:17:00.000' AS DateTime), N'L.211', 2)
INSERT [dbo].[Lichhoc] ([mamonhoc], [thuhoc], [giobatdau], [gioketthuc], [phonghoc], [Monhoc_Id]) VALUES (3, N'Thứ 6', CAST(N'2024-01-24T09:40:00.000' AS DateTime), CAST(N'2024-01-24T00:10:00.000' AS DateTime), N'L.512', 3)
INSERT [dbo].[Lichhoc] ([mamonhoc], [thuhoc], [giobatdau], [gioketthuc], [phonghoc], [Monhoc_Id]) VALUES (4, N'Thứ 2', CAST(N'2024-01-26T07:00:00.000' AS DateTime), CAST(N'2024-01-26T11:00:00.000' AS DateTime), N'L.612', 5)
INSERT [dbo].[Lichhoc] ([mamonhoc], [thuhoc], [giobatdau], [gioketthuc], [phonghoc], [Monhoc_Id]) VALUES (5, N'Thứ 4', CAST(N'2024-01-26T12:22:00.000' AS DateTime), CAST(N'2024-01-26T16:20:00.000' AS DateTime), N'L.513', 6)
INSERT [dbo].[Lichhoc] ([mamonhoc], [thuhoc], [giobatdau], [gioketthuc], [phonghoc], [Monhoc_Id]) VALUES (6, N'Thứ 6', CAST(N'2024-01-26T09:40:00.000' AS DateTime), CAST(N'2024-01-26T00:10:00.000' AS DateTime), N'L.213', 8)
INSERT [dbo].[Lichhoc] ([mamonhoc], [thuhoc], [giobatdau], [gioketthuc], [phonghoc], [Monhoc_Id]) VALUES (7, N'Thứ 7', CAST(N'2024-01-26T15:10:00.000' AS DateTime), CAST(N'2024-01-26T17:40:00.000' AS DateTime), N'L.812', 7)
SET IDENTITY_INSERT [dbo].[Lichhoc] OFF
GO
SET IDENTITY_INSERT [dbo].[Lop] ON 

INSERT [dbo].[Lop] ([malop], [tenlop]) VALUES (1, N'22DTH3C')
INSERT [dbo].[Lop] ([malop], [tenlop]) VALUES (2, N'22DTH1A')
INSERT [dbo].[Lop] ([malop], [tenlop]) VALUES (3, N'22DTH3A')
INSERT [dbo].[Lop] ([malop], [tenlop]) VALUES (4, N'22DTH2C')
SET IDENTITY_INSERT [dbo].[Lop] OFF
GO
SET IDENTITY_INSERT [dbo].[Monhoc] ON 

INSERT [dbo].[Monhoc] ([mamonhoc], [tenmh], [sotinchi]) VALUES (5, N'Kĩ năng giao tiếp', 2)
INSERT [dbo].[Monhoc] ([mamonhoc], [tenmh], [sotinchi]) VALUES (6, N'Kĩ thuật lập trình', 3)
INSERT [dbo].[Monhoc] ([mamonhoc], [tenmh], [sotinchi]) VALUES (7, N'Giải thuật', 4)
INSERT [dbo].[Monhoc] ([mamonhoc], [tenmh], [sotinchi]) VALUES (8, N'Lập trình web', 4)
SET IDENTITY_INSERT [dbo].[Monhoc] OFF
GO
SET IDENTITY_INSERT [dbo].[Sinhvien] ON 

INSERT [dbo].[Sinhvien] ([masv], [hoten], [ngaysinh], [gioitinh], [Lop_Id]) VALUES (1, N'Sơn Tùng', CAST(N'2004-03-12T09:51:00.000' AS DateTime), N'Nam', 1)
INSERT [dbo].[Sinhvien] ([masv], [hoten], [ngaysinh], [gioitinh], [Lop_Id]) VALUES (2, N'Huy Hoàng', CAST(N'2004-06-22T09:51:00.000' AS DateTime), N'Nam', 3)
INSERT [dbo].[Sinhvien] ([masv], [hoten], [ngaysinh], [gioitinh], [Lop_Id]) VALUES (3, N'Phương Ly', CAST(N'2004-08-19T09:52:00.000' AS DateTime), N'Nữ', 4)
INSERT [dbo].[Sinhvien] ([masv], [hoten], [ngaysinh], [gioitinh], [Lop_Id]) VALUES (4, N'Hải Tú', CAST(N'2004-10-21T09:53:00.000' AS DateTime), N'Nữ', 2)
SET IDENTITY_INSERT [dbo].[Sinhvien] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Name], [Email], [Password], [Role]) VALUES (1, N'admin', N'admin@gmail.com', N'admin@123', N'Administrator')
INSERT [dbo].[User] ([ID], [Name], [Email], [Password], [Role]) VALUES (2, N'user', N'guest@gmail.com', N'123456', N'User')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
