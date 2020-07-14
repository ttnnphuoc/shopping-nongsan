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
-- Create date: <04/10/2020>
-- Description:	<Update Catalog>
-- =============================================
CREATE PROCEDURE UpdateCatalog
	@id nchar(5),
	@name nvarchar(200),
	@parent_id nchar(5),
	@status int
AS

BEGIN
	UPDATE tbl_catalog SET NAME = @name, PARENT_ID = @parent_id, STATUS = @status WHERE ID = @id
END
GO
