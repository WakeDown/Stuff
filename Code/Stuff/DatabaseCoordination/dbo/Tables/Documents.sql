--Документы для согласования
CREATE TABLE [dbo].[Documents] (
    [Id]          VARCHAR (50)  NOT NULL,
    [LinkToDoc]   VARCHAR (MAX) NULL,
	[LinkToDocId]   INT NOT NULL,
    [Name]        VARCHAR (200) NOT NULL,
    [TypeId]      INT           NOT NULL,
    [ExecutionId] INT           NULL,
    [Enabled]     BIT           CONSTRAINT [DK_Documents_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Documents_ExecutionId] FOREIGN KEY ([ExecutionId]) REFERENCES [dbo].[WfwDocumentExecutions] ([Id]),
    CONSTRAINT [FK_Documents_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[DocumentTypes] ([Id])
);





