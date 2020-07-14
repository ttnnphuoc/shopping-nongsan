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
-- Description:	<Update Product by Id>
-- =============================================
CREATE PROCEDURE UpdateProduct
	@id nchar(10),
	@catalog_id nchar(5),
	@name nvarchar(500),
	@price decimal(18,0),
	@description text,
	@discount nchar(10),
	@image varchar(50),
	@imageList text,
	@status int

AS
BEGIN
	UPDATE tbl_product SET CATALOG_ID = @catalog_id, NAME = @name, PRICE = @price, DESCRIPTION = @description, DISCOUNT = @discount,
	IMAGE_LINK = @image, IMAGE_LIST = @imageList, STATUS = @status WHERE ID = @id

END
GO
