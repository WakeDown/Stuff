-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[statement_printed_save] 
	@id_statement_type INT,
	@employee_sid VARCHAR(46),
	@date_begin DATETIME = NULL,
	@date_end DATETIME = NULL,
	@duration_hours INT = NULL,
	@duration_days INT = NULL,
	@cause NVARCHAR(MAX) = NULL,
	@id_department INT = NULL,
	@id_organization INT = NULL,
	@creator_sid VARCHAR(46) = NULL,
	@confirmed bit = null,
	@date_confirm datetime = null
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @id INT
	INSERT INTO dbo.statement_printed
	        ( id_statement_type ,
	          employee_sid ,
	          date_begin ,
	          date_end ,
	          duration_hours ,
	          duration_days ,
	          cause ,
	          id_department ,
	          id_organization ,	          
	          creator_sid ,
			  confirmed,
			  date_confirm
	        )
	VALUES  ( @id_statement_type , -- id_statement_type - int
	          @employee_sid , -- employee_sid - varchar(46)
	          @date_begin , -- date_begin - datetime
	          @date_end , -- date_end - datetime
	          @duration_hours , -- duration_hours - int
	          @duration_days , -- duration_days - int
	          @cause , -- cause - nvarchar(max)
	          @id_department , -- id_department - int
	          @id_organization , -- id_organization - int
	          @creator_sid  -- creator_sid - varchar(46)	
			  ,@confirmed,
			       @date_confirm     
	        )

			set @id = SCOPE_IDENTITY()
			SELECT @id AS id
END
