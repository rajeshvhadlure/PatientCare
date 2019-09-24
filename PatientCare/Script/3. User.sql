CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Mobile] [nvarchar](15) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Pincode] [nvarchar](10) NOT NULL,
	[Country] [int] NOT NULL,
	[State] [int] NOT NULL,
	[City] [int] NOT NULL,
	[Parliamentry] [nvarchar](max) NOT NULL,
	[Legilative] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


