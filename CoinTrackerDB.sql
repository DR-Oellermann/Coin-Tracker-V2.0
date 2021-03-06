USE [SilverTracker]
GO
/****** Object:  Table [dbo].[tblCoin]    Script Date: 2021/06/08 09:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCoin](
	[Coin_ID] [int] IDENTITY(1,1) NOT NULL,
	[Type_ID] [int] NOT NULL,
	[Composition_ID] [int] NOT NULL,
	[Coin_Name] [nvarchar](50) NOT NULL,
	[Coin_Description] [nvarchar](max) NULL,
	[Purchase_Date] [date] NOT NULL,
	[Purchase_Amount] [float] NOT NULL,
	[Face_Value] [float] NULL,
	[Image_Path] [nvarchar](max) NULL,
	[Coin_Weight] [float] NOT NULL,
 CONSTRAINT [PK_tblCoin] PRIMARY KEY CLUSTERED 
(
	[Coin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCoinComposition]    Script Date: 2021/06/08 09:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCoinComposition](
	[Composition_ID] [int] IDENTITY(1,1) NOT NULL,
	[Composition_Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblCoinComposition] PRIMARY KEY CLUSTERED 
(
	[Composition_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCoinType]    Script Date: 2021/06/08 09:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCoinType](
	[Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Type_Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblCoinType] PRIMARY KEY CLUSTERED 
(
	[Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblCoin]  WITH CHECK ADD  CONSTRAINT [FK_tblCoin_tblCoinComposition] FOREIGN KEY([Composition_ID])
REFERENCES [dbo].[tblCoinComposition] ([Composition_ID])
GO
ALTER TABLE [dbo].[tblCoin] CHECK CONSTRAINT [FK_tblCoin_tblCoinComposition]
GO
ALTER TABLE [dbo].[tblCoin]  WITH CHECK ADD  CONSTRAINT [FK_tblCoin_tblCoinType] FOREIGN KEY([Type_ID])
REFERENCES [dbo].[tblCoinType] ([Type_ID])
GO
ALTER TABLE [dbo].[tblCoin] CHECK CONSTRAINT [FK_tblCoin_tblCoinType]
GO
