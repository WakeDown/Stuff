CREATE TABLE [dbo].[departments] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (150) NOT NULL,
    [id_parent]   INT            DEFAULT ((0)) NOT NULL,
    [enabled]     BIT            DEFAULT ((1)) NOT NULL,
    [dattim1]     DATETIME       DEFAULT (getdate()) NOT NULL,
    [dattim2]     DATETIME       DEFAULT ('3.3.3333') NOT NULL,
    [id_chief]    INT            DEFAULT ((0)) NOT NULL,
    [creator_sid] VARCHAR (46)   NULL,
    [hidden]      BIT            DEFAULT ((0)) NOT NULL,
    [sys_name]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_departments_id_parent]
    ON [dbo].[departments]([id_parent] ASC);

