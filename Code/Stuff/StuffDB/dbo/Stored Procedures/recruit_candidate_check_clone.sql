-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_candidate_check_clone] 
	@surname NVARCHAR(50),
	@name NVARCHAR(50),
	@patronymic NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM dbo.recruit_candidates WHERE enabled=1 and LOWER(surname) = LOWER(@surname) AND LOWER(name) = LOWER(@name) AND LOWER(patronymic) = LOWER(@patronymic))
	BEGIN
		SELECT top 1 id FROM dbo.recruit_candidates WHERE enabled=1 and LOWER(surname) = LOWER(@surname) AND LOWER(name) = LOWER(@name) AND LOWER(patronymic) = LOWER(@patronymic)
	END
    
END
