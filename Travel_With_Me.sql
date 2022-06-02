USE [TravelWithMe]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 13/12/2020 18:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_ID] [nchar](10) NOT NULL,
	[Nama] [varchar](50) NOT NULL,
	[Tujuan] [varchar](50) NOT NULL,
	[Jenis_Airlane] [varchar](50) NOT NULL,
	[Jenis_Tiket] [varchar](50) NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Harga] [int] NOT NULL,
	[Payment] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destination]    Script Date: 13/12/2020 18:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destination](
	[Destination_ID] [int] NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[Tujuan] [varchar](50) NOT NULL,
	[Jenis_Airlane] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Destination] PRIMARY KEY CLUSTERED 
(
	[Destination_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 13/12/2020 18:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Invoice_ID] [int] NOT NULL,
	[Order_ID] [int] NOT NULL,
	[Jenis_Tiket] [varchar](50) NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Destination] [varchar](50) NOT NULL,
	[Total_Biaya] [int] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Invoice_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[System]    Script Date: 13/12/2020 18:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[System](
	[Order_ID] [int] NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[Admin] [varchar](50) NOT NULL,
	[Staff] [varchar](50) NOT NULL,
 CONSTRAINT [PK_System] PRIMARY KEY CLUSTERED 
(
	[Order_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
