USE [TESTDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertJsonEmployee]    Script Date: 2/22/2024 3:57:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_InsertJsonEmployee]
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

    SELECT [EmployeeName],
           [EmployeeAge],
           [EmployeeGender],
           [EmployeeStatus],
           [EmployeeDateOfBirth]
    INTO [#TempEmployees]
    FROM
        OPENJSON(@JData)
        WITH
        (
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

    INSERT INTO [dbo].[Employees]
    (
        [EmployeeName],
        [EmployeeAge],
        [EmployeeGender],
        [EmployeeStatus],
        [EmployeeDateOfBirth]
    )
    SELECT [EmployeeName],
           [EmployeeAge],
           [EmployeeGender],
           [EmployeeStatus],
           [EmployeeDateOfBirth]
    FROM [#TempEmployees];

    SET @MessageCode = IIF(@@ROWCOUNT > 0, 'SUCCESS', 'FAILED');

    DROP TABLE [#TempEmployees];
END;
GO

