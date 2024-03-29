USE [HS]
GO
/****** Object:  StoredProcedure [dbo].[DanhmucItem_Select_ByID]    Script Date: 07/20/2013 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on 20/07/2013 11:40:40 AM .
-- Template: Retrieve Row by Primary Key
-- Purpose: Get an existing row in table DanhMuc_Item.

CREATE PROCEDURE [dbo].[DanhmucItem_Select_ByDanhMuc]
	@MaLoaiDanhMuc VARCHAR(150)
AS
	SELECT di.[MaLoaiDanhMuc],
	       di.[MaDanhMuc],
	       di.[TenDanhMuc],
	       di.[ThuTu],
	       di.[IntVal1],
	       di.[IntVal2],
	       di.[IntVal3],
	       di.[DecVal1],
	       di.[DecVal2],
	       di.[DecVal3],
	       di.[StrVal1],
	       di.[StrVal2],
	       di.[StrVal3]
	FROM   [DanhMuc_Item] di
	WHERE  MaLoaiDanhMuc = @MaLoaiDanhMuc