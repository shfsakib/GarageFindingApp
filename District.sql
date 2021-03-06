USE [Location]
GO
/****** Object:  Table [dbo].[District]    Script Date: 3/29/2021 3:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[Id] [int] NOT NULL,
	[DivisionId] [int] NOT NULL,
	[District] [varchar](30) NOT NULL,
	[lat] [nvarchar](50) NULL,
	[lon] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (1, 3, N'Dhaka', N'23.7115253', N'90.4111451')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (2, 3, N'Faridpur', N'23.6070822', N'89.8429406')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (3, 3, N'Gazipur', N'24.0022858', N'90.4264283')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (4, 3, N'Gopalganj', N'23.0050857', N'89.8266059')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (5, 8, N'Jamalpur', N'24.9375330', N'89.9377750')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (6, 3, N'Kishoreganj', N'24.4449370', N'90.7765750')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (7, 3, N'Madaripur', N'23.1641020', N'90.1896805')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (8, 3, N'Manikganj', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (9, 3, N'Munshiganj', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (10, 8, N'Mymensingh', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (11, 3, N'Narayanganj', N'23.6336600', N'90.4964820')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (12, 3, N'Narsingdi', N'23.9322330', N'90.7154100')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (13, 8, N'Netrokona', N'24.8709550', N'90.7278870')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (14, 3, N'Rajbari', N'23.7574305', N'89.6444665')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (15, 3, N'Shariatpur', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (16, 8, N'Sherpur', N'25.0204933', N'90.0152966')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (17, 3, N'Tangail', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (18, 5, N'Bogra', N'24.8465228', N'89.3777550')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (19, 5, N'Joypurhat', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (20, 5, N'Naogaon', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (21, 5, N'Natore', N'24.4205560', N'89.0002820')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (22, 5, N'Nawabganj', N'24.5965034', N'88.2775122')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (23, 5, N'Pabna', N'23.9985240', N'89.2336450')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (24, 5, N'Rajshahi', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (25, 5, N'Sirajgonj', N'24.4533978', N'89.7006815')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (26, 6, N'Dinajpur', N'25.6217061', N'88.6354504')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (27, 6, N'Gaibandha', N'25.3287510', N'89.5280880')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (28, 6, N'Kurigram', N'25.8054450', N'89.6361740')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (29, 6, N'Lalmonirhat', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (30, 6, N'Nilphamari', N'25.9317940', N'88.8560060')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (31, 6, N'Panchagarh', N'26.3411000', N'88.5541606')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (32, 6, N'Rangpur', N'25.7558096', N'89.2444620')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (33, 6, N'Thakurgaon', N'26.0336945', N'88.4616834')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (34, 1, N'Barguna', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (35, 1, N'Barisal', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (36, 1, N'Bhola', N'22.6859230', N'90.6481790')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (37, 1, N'Jhalokati', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (38, 1, N'Patuakhali', N'22.3596316', N'90.3298712')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (39, 1, N'Pirojpur', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (40, 2, N'Bandarban', N'22.1953275', N'92.2183773')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (41, 2, N'Brahmanbaria', N'23.9570904', N'91.1119286')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (42, 2, N'Chandpur', N'23.2332585', N'90.6712912')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (43, 2, N'Chittagong', N'22.3351090', N'91.8340730')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (44, 2, N'Comilla', N'23.4682747', N'91.1788135')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (45, 2, N'Cox''s Bazar', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (46, 2, N'Feni', N'23.0232310', N'91.3840844')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (47, 2, N'Khagrachari', N'23.1192850', N'91.9846630')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (48, 2, N'Lakshmipur', N'22.9424770', N'90.8411840')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (49, 2, N'Noakhali', N'22.8695630', N'91.0993980')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (50, 2, N'Rangamati', N'0.0000000', N'0.0000000')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (51, 7, N'Habiganj', N'24.3749450', N'91.4155300')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (52, 7, N'Maulvibazar', N'24.4829340', N'91.7774170')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (53, 7, N'Sunamganj', N'25.0658042', N'91.3950115')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (54, 7, N'Sylhet', N'24.8897956', N'91.8697894')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (55, 4, N'Bagerhat', N'22.6515680', N'89.7859380')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (56, 4, N'Chuadanga', N'23.6401961', N'88.8418410')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (57, 4, N'Jessore', N'23.1664300', N'89.2081126')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (58, 4, N'Jhenaidah', N'23.5448176', N'89.1539213')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (59, 4, N'Khulna', N'22.8157740', N'89.5686790')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (60, 4, N'Kushtia', N'23.9012580', N'89.1204820')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (61, 4, N'Magura', N'23.4873370', N'89.4199560')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (62, 4, N'Meherpur', N'23.7622130', N'88.6318210')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (63, 4, N'Narail', N'23.1725340', N'89.5126720')
INSERT [dbo].[District] ([Id], [DivisionId], [District], [lat], [lon]) VALUES (64, 4, N'Satkhira', N'0.0000000', N'0.0000000')
GO
