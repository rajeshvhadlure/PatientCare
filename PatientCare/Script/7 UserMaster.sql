/****** Object:  Table [dbo].[UserMaster]    Script Date: 10/1/2019 6:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[EmailID] [nvarchar](100) NULL,
	[MobileNumber] [nvarchar](15) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nvarchar](250) NULL,
	[State] [nvarchar](250) NULL,
	[Country] [nvarchar](250) NULL,
	[Pincode] [varchar](10) NULL,
	[ClinicName] [nvarchar](250) NULL,
	[Username] [nvarchar](10) NULL,
	[Password] [nvarchar](250) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO