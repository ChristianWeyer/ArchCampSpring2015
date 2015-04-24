USE [ConfDudeLive]
GO
/****** Object:  Table [dbo].[Speakers]    Script Date: 24.04.2015 12:01:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speakers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Birthday] [datetime2](7) NOT NULL,
	[Bio] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Speakers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Speakers] ON 

GO
INSERT [dbo].[Speakers] ([Id], [FirstName], [LastName], [Birthday], [Bio]) VALUES (1, N'Andreas', N'Straßer', CAST(0x070000000000000000 AS DateTime2), NULL)
GO
INSERT [dbo].[Speakers] ([Id], [FirstName], [LastName], [Birthday], [Bio]) VALUES (2, N'Martin', N'Jäger', CAST(0x070000000000000000 AS DateTime2), NULL)
GO
INSERT [dbo].[Speakers] ([Id], [FirstName], [LastName], [Birthday], [Bio]) VALUES (3, N'Jörg', N'Neumann', CAST(0x070000000000000000 AS DateTime2), NULL)
GO
INSERT [dbo].[Speakers] ([Id], [FirstName], [LastName], [Birthday], [Bio]) VALUES (4, N'Gert', N'Löwe', CAST(0x070000000000000000 AS DateTime2), NULL)
GO
INSERT [dbo].[Speakers] ([Id], [FirstName], [LastName], [Birthday], [Bio]) VALUES (5, N'Christian', N'Gaal', CAST(0x070000000000000000 AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[Speakers] OFF
GO
