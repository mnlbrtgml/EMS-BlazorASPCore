USE [TESTDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetEmployees]    Script Date: 2/22/2024 3:56:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--SET QUOTED_IDENTIFIER ON|OFF
--SET ANSI_NULLS ON|OFF
--GO
CREATE PROCEDURE [dbo].[sp_GetEmployees]
(
    @Filter AS VARCHAR(50) = NULL,
    @Value AS VARCHAR(50) = NULL
)
-- WITH ENCRYPTION, RECOMPILE, EXECUTE AS CALLER|SELF|OWNER| 'user_name'
AS
BEGIN
    DECLARE @Condition AS VARCHAR(250),
            @Query AS VARCHAR(MAX);

    SET @Condition = IIF(@Value <> '', ' WHERE [Employees].', '');
	SET @Filter = IIF(@Filter <> '' AND @Value = '', '', @Filter);

    IF (@Filter = 'Name')
    BEGIN
        SET @Condition = @Condition + '[EmployeeName] LIKE ''%' + @Value + '%''';
    END;
	IF (@Filter = 'Age')
    BEGIN
        SET @Condition = @Condition + '[EmployeeAge] = ' + @Value;
    END;
    IF (@Filter = 'Gender')
    BEGIN
        SET @Condition = @Condition + '[EmployeeGender] = ''' + @Value + '''';
    END;
    IF (@Filter = 'Status')
    BEGIN
        SET @Condition = @Condition + '[EmployeeStatus] = ' + @Value;
    END;
    IF (@Filter = 'DateOfBirth')
    BEGIN
        SET @Condition = @Condition + '[EmployeeDateOfBirth] = ' + @Value;
    END;

    SET @Query
        = 'SELECT [Employees].[EmployeeID],
           [Employees].[EmployeeName],
		   [Employees].[EmployeeAge],
           IIF(ISNULL([Employees].[EmployeeGender], ''M'') = ''M'', ''Male'', ''Female'') AS [EmployeeGender],
           IIF(ISNULL([Employees].[EmployeeStatus], 0) = 1, ''Active'', ''Inactive'') AS [EmployeeStatus],
           [Employees].[EmployeeDateOfBirth]
	FROM [dbo].[Employees]' + @Condition + ' ORDER BY [Employees].[EmployeeID]';

    EXEC(@Query);
END;
GO

