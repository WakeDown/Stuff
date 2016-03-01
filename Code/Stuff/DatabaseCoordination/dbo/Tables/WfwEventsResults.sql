-- результаты события исполнения
CREATE TABLE [dbo].[WfwEventsResults] (
    [Id]          INT           IDENTITY (1000, 1) NOT NULL,
    [Name]        VARCHAR (200) NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    [Success]     BIT           NOT NULL,
    [Enabled]     BIT           CONSTRAINT [DK_WfwEventsResults_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_WfwEventsResults] PRIMARY KEY CLUSTERED ([Id] ASC)
);

