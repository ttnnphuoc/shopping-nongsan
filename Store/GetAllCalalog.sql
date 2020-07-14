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
-- Create date: <04/09/2020>
-- Description:	<Get all catalog with id is empty, if is not empty then get by id>
-- =============================================
CREATE PROCEDURE GetAllCalalog 
	@id nchar(5)
AS
BEGIN
	SELECT tbl_catalog.*,tbl_status.NAME AS STATUS_NAME FROM tbl_catalog 
	LEFT JOIN tbl_status on tbl_catalog.STATUS = tbl_Status.ID WHERE (@ID = '' OR @id = tbl_catalog.ID) ORDER BY ID
END
GO
