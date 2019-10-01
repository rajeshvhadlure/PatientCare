/****** Object:  Table [dbo].[ExceptionMaster]    Script Date: 10/1/2019 6:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[ControllerName] [nvarchar](250) NULL,
	[FunctionName] [nvarchar](500) NULL,
	[StackTrace] [nvarchar](max) NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_ExceptionMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO