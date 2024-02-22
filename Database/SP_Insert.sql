USE [TESTDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertEmployee]    Script Date: 2/22/2024 3:57:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--SET QUOTED_IDENTIFIER ON|OFF
--SET ANSI_NULLS ON|OFF
--GO
CREATE PROCEDURE [dbo].[sp_InsertEmployee]
(
    @EmployeeName AS VARCHAR(250) = NULL,
    @EmployeeAge AS INT = NULL,
    @EmployeeGender AS CHAR = NULL,
    @EmployeeStatus AS BIT = NULL,
    @EmployeeDateOfBirth AS DATE = NULL,
	@MessageCode as VARCHAR(250) = NULL OUTPUT
)
-- WITH ENCRYPTION, RECOMPILE, EXECUTE AS CALLER|SELF|OWNER| 'user_name'
AS
BEGIN
    INSERT INTO [dbo].[Employees]
    (
        [EmployeeName],
        [EmployeeAge],
        [EmployeeGender],
        [EmployeeStatus],
        [EmployeeDateOfBirth]
    )
    VALUES
    (   @EmployeeName,			-- EmployeeName - varchar(30)
		@EmployeeAge,			-- EmployeeAge - int
        @EmployeeGender,		-- EmployeeGender - char(1)
        @EmployeeStatus,		-- EmployeeStatus - bit
        @EmployeeDateOfBirth	-- EmployeeDob - date
    );

    SET @MessageCode = IIF(@@ROWCOUNT > 0, 'SUCCESS', 'FAILED')
END;
GO

