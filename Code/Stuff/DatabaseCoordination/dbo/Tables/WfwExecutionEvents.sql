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
    CONSTRAINT [FK_WfwExecutionEvents_Employee] FOREIGN KEY ([CreaterId]) REFERENCES [dbo].[employees] ([Id]),
    CONSTRAINT [FK_WfwExecutionEvents_WfwDocumentExecutions] FOREIGN KEY ([ExecutionId]) REFERENCES [dbo].[WfwDocumentExecutions] ([Id]),
    CONSTRAINT [FK_WfwExecutionEvents_WfwEventsResults] FOREIGN KEY ([ResultId]) REFERENCES [dbo].[WfwEventsResults] ([Id])
);

