CREATE TABLE [dbo].[document_meets] (
    [id]               INT          IDENTITY (1, 1) NOT NULL,
    [id_doc_meet_link] INT          NOT NULL,
    [employee_sid]     VARCHAR (46) NOT NULL,
    [dattim1]          DATETIME     CONSTRAINT [DF_document_meets_dattim1] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_document_meets] PRIMARY KEY CLUSTERED ([id] ASC)
);

