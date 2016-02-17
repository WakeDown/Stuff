-- процесс исполнения по документу - 
CREATE TABLE [dbo].[WfwDocumentExecutions] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [Level]     INT      NOT NULL,
    [StartDate] DATETIME CONSTRAINT [DK_Executions_CREATEDate] DEFAULT (getdate()) NOT NULL,
    [CreaterId] INT      NOT NULL,
    [EndDate]   DATETIME NOT NULL,
    [Enabled]   BIT      CONSTRAINT [DK_Executions_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Executions] PRIMARY KEY CLUSTERED ([Id] ASC)
);






GO
CREATE Trigger [dbo].[WfwDocumentExecutionsCreaterIdTrigger] ON [dbo].[WfwDocumentExecutions] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT Id FROM [Stuff].[dbo].[employees] WHERE Id in (SELECT CreaterId FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [WfwDocumentExecutions] - no [CreaterId]',16,1)
   END
END