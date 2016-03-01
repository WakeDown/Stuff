-- схема исполнения
CREATE TABLE [dbo].[WfwScheme] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (200) NOT NULL,
    [Action]            INT           NOT NULL,
    [ContinueLastStage] BIT           NOT NULL,
    [Enabled]           BIT           CONSTRAINT [DK_WfwScheme_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_WfwScheme] PRIMARY KEY CLUSTERED ([Id] ASC)
);

