CREATE TABLE [dbo].[org_state_images] (
    [id]              INT                        IDENTITY (1, 1) NOT NULL,
    [id_organization] INT                        NOT NULL,
    [data]            VARBINARY (MAX) FILESTREAM NOT NULL,
    [enabled]         BIT                        DEFAULT ((1)) NOT NULL,
    [data_sid]        UNIQUEIDENTIFIER           DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [dattim1]         DATETIME                   DEFAULT (getdate()) NOT NULL,
    [dattim2]         DATETIME                   DEFAULT ('3.3.3333') NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([data_sid] ASC)
) FILESTREAM_ON [ImageFileGroup];

