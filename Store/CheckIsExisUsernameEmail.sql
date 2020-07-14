-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <07/04/2020>
-- Description:	<Check username and email is exist or not>
-- =============================================
Create PROCEDURE CheckIsExisUsernameEmail
	@columnName nchar(10),
	@value nchar(50)
AS
BEGIN
	DECLARE @sqlCommand NVARCHAR(max) = 'SELECT Max(ID) as ID FROM [dbo].[tbl_user] WHERE ' + @columnName + '=''' +@value+ '''';
	print @sqlCommand
	EXEC (@sqlCommand)
END
GO
