--Типы документов для согласования
CREATE TABLE [dbo].[DocumentTypes] (
    [Id]          INT           IDENTITY (1000, 1) NOT NULL,
	[SchemeId] INT NOT NULL,
    [Name]        VARCHAR (200) NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    [Enabled]     BIT           CONSTRAINT [DK_DocumentTupes_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_DocumentTupes] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [AK_DocumentTupes_Name] UNIQUE NONCLUSTERED ([Name] ASC),
	CONSTRAINT [FK_DocumentTypes_ExecutionSchemeId] FOREIGN KEY ([SchemeId]) REFERENCES [dbo].[WfwScheme] ([Id]),
);

