CREATE TABLE [dbo].[budget] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (500) NOT NULL,
    [dattim1]     DATETIME       DEFAULT (getdate()) NOT NULL,
    [dattim2]     DATETIME       DEFAULT ('3.3.3333') NOT NULL,
    [enabled]     BIT            DEFAULT ((1)) NOT NULL,
    [creator_sid] VARCHAR (46)   NOT NULL,
    [order_num]   INT            DEFAULT ((500)) NOT NULL,
    [descr]       NVARCHAR (MAX) NULL,
    [deleter_sid] VARCHAR (46)   NULL,
    [id_parent]   INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

