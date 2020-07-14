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
-- Create date: <04/07/2020>
-- Description:	<Change Password User>
-- =============================================
Create PROCEDURE ChangedPasswordUser
	-- Add the parameters for the stored procedure here
	@id nchar(10),
	@password varchar(50)
AS
BEGIN
	UPDATE tbl_user SET PASSWORD = @password WHERE ID = @id
END
GO
