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
-- Create date: <10/04/2020>
-- Description:	<Update status is 2 when delete catalog>
-- =============================================
CREATE PROCEDURE DeleteCatalog
	@id nchar(5)
AS
BEGIN
	UPDATE tbl_catalog SET status = 2 where ID = @id
END
GO
