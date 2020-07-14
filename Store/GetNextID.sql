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
-- Create date: <2020/04/06>
-- Description:	<Get next id of table>
-- =============================================
Create PROCEDURE GetNextID @tableName nchar(50)
AS
BEGIN
	DECLARE @sqlCommand NVARCHAR(max) = 'SELECT Max(ID) as ID FROM [dbo].[' + @tableName + ']'
	print @sqlCommand
	EXEC (@sqlCommand)
END
GO
