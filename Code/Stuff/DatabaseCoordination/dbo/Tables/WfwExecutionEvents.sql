-- события исполнения
CREATE TABLE [dbo].[WfwExecutionEvents] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [ExecutionId] INT           NOT NULL,
    [Date]        DATETIME      CONSTRAINT [DK_WfwExecutionEvents_CreateDate] DEFAULT (getdate()) NOT NULL,
    [CreaterId]   INT           NOT NULL,
    [ResultId]    INT           NOT NULL,
    [Comment]     VARCHAR (MAX) NULL,
    [Enabled]     BIT           CONSTRAINT [DK_WfwExecutionEvents_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_WfwExecutionEvents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WfwExecutionEvents_WfwDocumentExecutions] FOREIGN KEY ([ExecutionId]) REFERENCES [dbo].[WfwDocumentExecutions] ([Id]),
    CONSTRAINT [FK_WfwExecutionEvents_WfwEventsResults] FOREIGN KEY ([ResultId]) REFERENCES [dbo].[WfwEventsResults] ([Id])
);




GO
Create Trigger [dbo].[WfwExecutionEventsCreaterIdTrigger] ON [dbo].[WfwExecutionEvents] After Insert, Update
As
Begin
   If NOT Exists(select Id from [Stuff].[dbo].[employees] where Id in (Select CreaterId from inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR (-1,-1,-1, 'Cannot insert [WfwDocumentExecutions] - no [CreaterId]');
   END
END