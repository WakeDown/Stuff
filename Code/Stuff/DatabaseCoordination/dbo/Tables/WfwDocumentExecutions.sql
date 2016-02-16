-- процесс исполнения по документу - 
CREATE TABLE [dbo].[WfwDocumentExecutions] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [Stage]     INT      NOT NULL,
    [StartDate] DATETIME CONSTRAINT [DK_Executions_CreateDate] DEFAULT (getdate()) NOT NULL,
    [CreaterId] INT      NOT NULL,
    [EndDate]   DATETIME NOT NULL,
    [Enabled]   BIT      CONSTRAINT [DK_Executions_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Executions] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
Create Trigger [dbo].[WfwDocumentExecutionsCreaterIdTrigger] ON [dbo].[WfwDocumentExecutions] After Insert, Update
As
Begin
   If NOT Exists(select Id from [Stuff].[dbo].[employees] where Id in (Select CreaterId from inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR (-1,-1,-1, 'Cannot insert [WfwDocumentExecutions] - no [CreaterId]');
   END
END