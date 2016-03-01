CREATE TABLE [dbo].[engeneer_states] (
    [id]                    INT                        IDENTITY (1, 1) NOT NULL,
    [engeneer_sid]          VARCHAR (46)               NOT NULL,
    [id_vendor]             INT                        NOT NULL,
    [descr]                 NVARCHAR (MAX)             NULL,
    [date_end]              DATETIME                   NOT NULL,
    [id_organization]       INT                        NOT NULL,
    [id_language]           INT                        NOT NULL,
    [dattim1]               DATETIME                   DEFAULT (getdate()) NOT NULL,
    [dattim2]               DATETIME                   DEFAULT ('3.3.3333') NOT NULL,
    [enabled]               BIT                        DEFAULT ((1)) NOT NULL,
    [creator_sid]           VARCHAR (46)               NOT NULL,
    [deleter_sid]           VARCHAR (46)               NULL,
    [old_id]                INT                        NULL,
    [pic_data]              VARBINARY (MAX) FILESTREAM NULL,
    [pic_guid]              UNIQUEIDENTIFIER           DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [expired_delivery_sent] BIT                        DEFAULT ((0)) NOT NULL,
    [name]                  NVARCHAR (150)             NULL,
    [new_delivery_sent]     BIT                        DEFAULT ((0)) NOT NULL,
    [update_delivery_sent]  BIT                        DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([pic_guid] ASC)
) FILESTREAM_ON [ImageFileGroup];

