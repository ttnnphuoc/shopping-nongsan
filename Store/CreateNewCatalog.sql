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
-- Author:		<Tran Ngoc Phuo>
-- Create date: <09/04/2020>
-- Description:	<Create new catalog>
-- =============================================
Create PROCEDURE CreateNewCatalog 
	@id nchar(5),
	@name nvarchar(200),
	@parent_id nchar(5),
	@status int
AS
BEGIN
	INSERT tbl_catalog VALUES(@id,@name,@parent_id,@status)
END
GO
