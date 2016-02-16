CREATE TABLE [dbo].[document_meet_links] (
    [id]            INT          IDENTITY (1, 1) NOT NULL,
    [id_document]   INT          NOT NULL,
    [id_department] INT          NULL,
    [id_position]   INT          NULL,
    [id_employee]   INT          NULL,
    [dattim1]       DATETIME     CONSTRAINT [DF_document_links_dattim1] DEFAULT (getdate()) NOT NULL,
    [creator_sid]   VARCHAR (46) NOT NULL,
    [enabled]       BIT          CONSTRAINT [DF_document_meet_links_enabled] DEFAULT ((1)) NOT NULL,
    [dattim2]       DATETIME     CONSTRAINT [DF_document_meet_links_dattim2] DEFAULT ('3.3.3333') NOT NULL,
    [deleter_sid]   VARCHAR (46) NULL,
    CONSTRAINT [PK_document_links] PRIMARY KEY CLUSTERED ([id] ASC)
);

