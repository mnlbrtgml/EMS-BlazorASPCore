USE [TESTDB]
GO

/****** Object:  Table [dbo].[Employees]    Script Date: 2/22/2024 3:56:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](250) NULL,
	[EmployeeAge] [int] NULL,
	[EmployeeGender] [char](1) NULL,
	[EmployeeStatus] [bit] NULL,
	[EmployeeDateOfBirth] [date] NULL
) ON [PRIMARY]
GO

