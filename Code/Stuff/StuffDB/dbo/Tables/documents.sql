CREATE TABLE [dbo].[documents] (
    [id]          INT                        IDENTITY (1, 1) NOT NULL,
    [data_sid]    UNIQUEIDENTIFIER           DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [summary]     VARBINARY (MAX)            NULL,
    [data]        VARBINARY (MAX) FILESTREAM NULL,
    [name]        NVARCHAR (500)             NOT NULL,
    [dattim1]     DATETIME                   CONSTRAINT [DF_documents_dattim1] DEFAULT (getdate()) NOT NULL,
    [dattim2]     DATETIME                   CONSTRAINT [DF_documents_dattim2] DEFAULT ('3.3.3333') NOT NULL,
    [enabled]     BIT                        CONSTRAINT [DF_documents_enabled] DEFAULT ((1)) NOT NULL,
    [creator_sid] VARCHAR (46)               NOT NULL,
    [deleter_sid] VARCHAR (46)               NULL,
    CONSTRAINT [PK_documents] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [UQ__document__CC80C6D41F98B2C1] UNIQUE NONCLUSTERED ([data_sid] ASC)
) FILESTREAM_ON [ImageFileGroup];

