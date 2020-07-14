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
-- Description:	<Create new product>
-- =============================================
CREATE PROCEDURE CreateNewProduct 
	@id nchar(10),
	@catalog_id nchar(5),
	@name nvarchar(500),
	@price decimal(18,0),
	@description text,
	@discount nchar(10),
	@image varchar(50),
	@imageList text,
	@created datetime,
	@view int,
	@status int
AS
BEGIN
	INSERT INTO tbl_product VALUES(@id,@catalog_id,@name,@price,@description,@discount,@image,@imageList,@created,@view,@status)
END
GO
