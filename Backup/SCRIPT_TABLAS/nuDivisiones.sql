USE [SLTESTAPP]
GO

/****** Object:  Table [dbo].[nuDivisiones]    Script Date: 01/19/2013 10:02:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[nuDivisiones](
	[DivID] [char](4) NOT NULL,
	[Division] [char](50) NULL,
	[Sub] [char](24) NULL,
	[ValidaPresup] [char](10) NULL,
	[CpnyID] [char](10) NULL,
	[Crtd_DateTime] [smalldatetime] NULL,
	[Crtd_Prog] [char](8) NULL,
	[Crtd_User] [char](10) NULL,
	[LUpd_DateTime] [smalldatetime] NULL,
	[LUpd_Prog] [char](8) NULL,
	[LUpd_User] [char](10) NULL,
	[NoteID] [int] NULL,
	[S4Future01] [char](30) NULL,
	[S4Future02] [char](30) NULL,
	[S4Future03] [float] NULL,
	[S4Future04] [float] NULL,
	[S4Future05] [float] NULL,
	[S4Future06] [float] NULL,
	[S4Future07] [smalldatetime] NULL,
	[S4Future08] [smalldatetime] NULL,
	[S4Future09] [int] NULL,
	[S4Future10] [int] NULL,
	[S4Future11] [char](10) NULL,
	[S4Future12] [char](10) NULL,
	[User1] [char](30) NULL,
	[User2] [char](30) NULL,
	[User3] [float] NULL,
	[User4] [float] NULL,
	[User5] [float] NULL,
	[User6] [float] NULL,
	[User7] [char](10) NULL,
	[User8] [char](10) NULL,
	[User9] [char](10) NULL,
	[User10] [smalldatetime] NULL,
	[User11] [smalldatetime] NULL,
	[User12] [smalldatetime] NULL,
	[tstamp] [timestamp] NULL,
 CONSTRAINT [nuDivisiones0] PRIMARY KEY CLUSTERED 
(
	[DivID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

