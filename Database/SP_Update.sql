USE [TESTDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 2/22/2024 3:57:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--SET QUOTED_IDENTIFIER ON|OFF
--SET ANSI_NULLS ON|OFF
--GO
CREATE PROCEDURE [dbo].[sp_UpdateEmployee]
(
    @EmployeeID AS INT = NULL,
    @EmployeeName AS VARCHAR(50) = NULL,
    @EmployeeAge AS INT = NULL,
    @EmployeeGender AS CHAR = NULL,
    @EmployeeStatus AS BIT = NULL,
    @EmployeeDateOfBirth AS DATE = NULL,
	@MessageCode as VARCHAR(250) = NULL OUTPUT
)
-- WITH ENCRYPTION, RECOMPILE, EXECUTE AS CALLER|SELF|OWNER| 'user_name'
AS
BEGIN
    UPDATE [dbo].[Employees]
    SET [EmployeeName] = @EmployeeName,
		[EmployeeAge] = @EmployeeAge,
        [EmployeeGender] = @EmployeeGender,
        [EmployeeStatus] = @EmployeeStatus,
        [EmployeeDateOfBirth] = @EmployeeDateOfBirth
    WHERE [Employees].[EmployeeID] = @EmployeeID;

    SET @MessageCode = IIF(@@ROWCOUNT > 0, 'SUCCESS', 'FAILED')
END;
GO

