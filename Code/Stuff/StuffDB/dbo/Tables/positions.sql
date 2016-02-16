CREATE TABLE [dbo].[positions] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (500) NOT NULL,
    [enabled]     BIT            DEFAULT ((1)) NOT NULL,
    [dattim1]     DATETIME       DEFAULT (getdate()) NOT NULL,
    [dattim2]     DATETIME       DEFAULT ('3.3.3333') NOT NULL,
    [order_num]   INT            DEFAULT ((500)) NOT NULL,
    [creator_sid] VARCHAR (46)   NULL,
    [name_rod]    NVARCHAR (500) NULL,
    [name_dat]    NVARCHAR (500) NULL,
    [sys_name]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

