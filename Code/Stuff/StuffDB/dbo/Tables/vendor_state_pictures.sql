CREATE TABLE [dbo].[vendor_state_pictures] (
    [id]              INT                        IDENTITY (1, 1) NOT NULL,
    [id_vendor_state] INT                        NOT NULL,
    [file_data]       VARBINARY (MAX) FILESTREAM NOT NULL,
    [enabled]         BIT                        DEFAULT ((1)) NOT NULL,
    [file_fuid]       UNIQUEIDENTIFIER           DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [file_name]       NVARCHAR (500)             NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([file_fuid] ASC)
) FILESTREAM_ON [ImageFileGroup];

