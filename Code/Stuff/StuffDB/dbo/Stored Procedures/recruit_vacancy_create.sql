-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_vacancy_create] 
	@creator_sid VARCHAR(46),
	@author_sid VARCHAR(46),
	@id_position INT,
	@id_department INT,
	@chief_sid VARCHAR(46),
	@id_cause INT,
	@matcher_sid  VARCHAR(46),
	@personal_manager_sid VARCHAR(46) = null,
	@deadline_date DATETIME = NULL,
	@order_end_date date = null,
	@claim_end_date date = null,
	@id_city int = null,
	@id_branch_office int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @id INT
    
	BEGIN TRY
	BEGIN TRAN vac

	
   INSERT INTO [dbo].[recruit_vacancies]
           (
           [creator_sid]
           ,[author_sid]
           ,[id_position]
           ,[id_department]
           ,[chief_sid]
           ,[id_cause]
           ,[matcher_sid]
           ,[personal_manager_sid]
           ,[deadline_date], order_end_date, claim_end_date, id_city, id_branch_office)
     VALUES
           (@creator_sid
           ,@author_sid
           ,@id_position
           ,@id_department
           ,@chief_sid
           ,@id_cause
           ,@matcher_sid
           ,@personal_manager_sid
           ,@deadline_date, @order_end_date, @claim_end_date, @id_city, @id_branch_office)

		   SET @id = SCOPE_IDENTITY()

		   EXEC recruit_vacancy_set_state @id=@id,@state_sys_name='NEW', @creator_sid=@creator_sid

		   COMMIT TRAN vac
END TRY
BEGIN CATCH     
	 IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN vac;
		throw
END CATCH

		   SELECT @id AS id
END
