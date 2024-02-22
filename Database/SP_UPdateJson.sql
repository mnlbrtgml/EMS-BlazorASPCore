USE [TESTDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateJsonEmployee]    Script Date: 2/22/2024 3:57:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateJsonEmployee]
(
    @JData AS VARCHAR(MAX),
    @MessageCode AS VARCHAR(255) OUTPUT
)
AS
BEGIN

    IF (ISJSON(@JData) = 0)
    BEGIN
        SET @MessageCode = 'INVALID JSON DATA';
        RETURN;
    END;

    SELECT [EmployeeID],
           [EmployeeName],
           [EmployeeAge],
           [EmployeeGender],
           [EmployeeStatus],
           [EmployeeDateOfBirth]
    INTO [#TempEmployees]
    FROM
        OPENJSON(@JData)
        WITH
        (
            [EmployeeID] [INT] '$.EmployeeID',
            [EmployeeName] [VARCHAR](255) '$.EmployeeName',
            [EmployeeAge] [INT] '$.EmployeeAge',
            [EmployeeGender] [CHAR](1) '$.EmployeeGender',
            [EmployeeStatus] [BIT] '$.EmployeeStatus',
            [EmployeeDateOfBirth] [DATE] '$.EmployeeDateOfBirth'
        );


    IF ((SELECT COUNT(*)FROM [#TempEmployees]) = 0)
    BEGIN
        SET @MessageCode = 'NO RECORDS FOUND';
        RETURN;
    END;

    UPDATE [dbo].[Employees]
    SET [EmployeeName] = [#TempEmployees].[EmployeeName],
        [EmployeeAge] = [#TempEmployees].[EmployeeAge],
        [EmployeeGender] = [#TempEmployees].[EmployeeGender],
        [EmployeeStatus] = [#TempEmployees].[EmployeeStatus],
        [EmployeeDateOfBirth] = [#TempEmployees].[EmployeeDateOfBirth]
    FROM [dbo].[Employees]
        INNER JOIN [#TempEmployees]
            ON [EmployeeID] = [#TempEmployees].[EmployeeID]
    WHERE [Employees].[EmployeeID] = [#TempEmployees].[EmployeeID];

    SET @MessageCode = IIF(@@ROWCOUNT > 0, 'SUCCESS', 'FAILED');

    DROP TABLE [#TempEmployees];

END;
GO

