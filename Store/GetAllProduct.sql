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
-- Create date: <13/04/2020>
-- Description:	<Get all prodct>
-- =============================================
CREATE PROCEDURE GetAllProduct
	@id nchar(10)
AS
BEGIN
	SELECT ROW_NUMBER() OVER(ORDER BY tbl_product.ID ASC) AS IDX, tbl_product.*, tbl_catalog.NAME as CATALOG_NAME, tbl_status.NAME AS STATUS_NAME FROM tbl_product 
	LEFT JOIN tbl_catalog on tbl_catalog.ID = tbl_product.CATALOG_ID
	LEFT JOIN tbl_status ON tbl_product.STATUS = tbl_status.ID WHERE (@id = '' or @id = tbl_product.ID)
END
GO
