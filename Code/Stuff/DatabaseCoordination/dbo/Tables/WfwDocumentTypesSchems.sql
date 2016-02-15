-- связь типа документа со схемой исполнения
CREATE TABLE [dbo].[WfwDocumentTypesSchems] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [DocumentTypeId] INT NOT NULL,
    [SchemeId]       INT NOT NULL,
    [Enabled]        BIT CONSTRAINT [DK_WfwDocumentTypesSchems_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_WfwDocumentTypesSchems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WfwDocumentTypesSchems_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [dbo].[DocumentTypes] ([Id]),
    CONSTRAINT [FK_WfwDocumentTypesSchems_SchemeId] FOREIGN KEY ([SchemeId]) REFERENCES [dbo].[WfwScheme] ([Id]),
    CONSTRAINT [AK_WfwDocumentTypesSchems_DocumentTypeId_SchemeId] UNIQUE NONCLUSTERED ([DocumentTypeId] ASC, [SchemeId] ASC)
);

