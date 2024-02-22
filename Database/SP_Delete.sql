USE [TESTDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteEmployee]    Script Date: 2/22/2024 3:56:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--SET QUOTED_IDENTIFIER ON|OFF
--SET ANSI_NULLS ON|OFF
--GO
CREATE PROCEDURE [dbo].[sp_DeleteEmployee] @EmployeeID AS INT = NULL, @MessageCode as VARCHAR(250) = NULL OUTPUT
-- WITH ENCRYPTION, RECOMPILE, EXECUTE AS CALLER|SELF|OWNER| 'user_name'
AS
BEGIN
    DELETE FROM [dbo].[Employees]
    WHERE [Employees].[EmployeeID] = @EmployeeID;

	SET @MessageCode = IIF(@@ROWCOUNT > 0, 'SUCCESS', 'FAILED')
END;
GO

