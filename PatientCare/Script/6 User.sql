/****** Object:  Table [dbo].[User]    Script Date: 10/1/2019 6:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Address] [nvarchar](max) NULL,
	[Pincode] [nvarchar](10) NULL,
	[Country] [nvarchar](250) NULL,
	[State] [nvarchar](250) NULL,
	[City] [nvarchar](250) NULL,
	[Parliamentry] [nvarchar](max) NULL,
	[Legilative] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
