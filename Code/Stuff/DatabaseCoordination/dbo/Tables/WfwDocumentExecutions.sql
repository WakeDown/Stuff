-- процесс исполнения по документу - 
CREATE TABLE [dbo].[WfwDocumentExecutions] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [Stage]     INT      NOT NULL,
    [StartDate] DATETIME CONSTRAINT [DK_Executions_CreateDate] DEFAULT (getdate()) NOT NULL,
    [CreaterId] INT      NOT NULL,
    [EndDate]   DATETIME NOT NULL,
    [Enabled]   BIT      CONSTRAINT [DK_Executions_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Executions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Executions_Employee_Creator] FOREIGN KEY ([CreaterId]) REFERENCES [dbo].[employees] ([Id])
);

