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
-- Create date: <2020/06/04>
-- Description:	<Add new user>
-- =============================================
CREATE PROCEDURE CreateUser
	@ID nchar(10),
	@USERNAME NVARCHAR(50),
	@EMAIL NVARCHAR(50),
	@PHONE NVARCHAR(50),
	@ADDRESS NVARCHAR(max),
	@PASSWORD NVARCHAR(50),
	@CREATED DATETIME
AS
BEGIN
INSERT INTO [dbo].[tbl_user]
           ([ID]
           ,[USERNAME]
           ,[EMAIL]
           ,[PHONE]
           ,[ADDRESS]
           ,[PASSWORD]
           ,[CREATED])
     VALUES
           (@ID
           ,@USERNAME
           ,@EMAIL
           ,@PHONE
           ,@ADDRESS
           ,@PASSWORD
           ,@CREATED)

END
GO
