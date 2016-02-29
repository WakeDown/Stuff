-- события исполнения
CREATE TABLE [dbo].[WfwExecutionEvents] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [ExecutionId] INT           NOT NULL,
    [Date]        DATETIME      CONSTRAINT [DK_WfwExecutionEvents_CREATEDate] DEFAULT (getdate()) NOT NULL,
    [CreaterSid]   VARCHAR(46)   COLLATE SQL_Latin1_General_CP1_CI_AS        NOT NULL,
    [ResultId]    INT           NOT NULL,
    [Comment]     VARCHAR (MAX) NULL,
    [Enabled]     BIT           CONSTRAINT [DK_WfwExecutionEvents_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_WfwExecutionEvents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WfwExecutionEvents_WfwDocumentExecutions] FOREIGN KEY ([ExecutionId]) REFERENCES [dbo].[WfwDocumentExecutions] ([Id]),
    CONSTRAINT [FK_WfwExecutionEvents_WfwEventsResults] FOREIGN KEY ([ResultId]) REFERENCES [dbo].[WfwEventsResults] ([Id])
);
GO

CREATE Trigger [dbo].[WfwExecutionEventsCreaterIdTrigger] ON [dbo].[WfwExecutionEvents] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT ad_sid FROM [Stuff].[dbo].[employees] WHERE ad_sid in (SELECT CreaterSid FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [WfwDocumentExecutions] - no [CreaterId]',16,1)
   END
END