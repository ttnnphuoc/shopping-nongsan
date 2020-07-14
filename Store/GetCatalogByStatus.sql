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
-- Create date: <11/04/2020>
-- Description:	<Get catalog by status>
-- =============================================
CREATE PROCEDURE GetCatalogByStatus
	@status int
AS
BEGIN
	SELECT * FROM tbl_catalog where STATUS  = @status
END
GO
