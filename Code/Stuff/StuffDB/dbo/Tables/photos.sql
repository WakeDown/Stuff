CREATE TABLE [dbo].[photos] (
    [id]           INT             IDENTITY (1, 1) NOT NULL,
    [id_employee]  INT             NOT NULL,
    [enabled]      BIT             DEFAULT ((1)) NOT NULL,
    [dattim1]      DATETIME        DEFAULT (getdate()) NOT NULL,
    [dattim2]      DATETIME        DEFAULT ('3.3.3333') NOT NULL,
    [path]         NVARCHAR (4000) NULL,
    [picture]      IMAGE           NULL,
    [picture_name] NVARCHAR (100)  NULL,
    [creator_sid]  VARCHAR (46)    NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_photos_id_employee]
    ON [dbo].[photos]([id_employee] ASC);

