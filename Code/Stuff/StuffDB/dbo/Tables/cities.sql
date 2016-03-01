CREATE TABLE [dbo].[cities] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50) NOT NULL,
    [enabled]     BIT           DEFAULT ((1)) NOT NULL,
    [dattim1]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [dattim2]     DATETIME      DEFAULT ('3.3.3333') NOT NULL,
    [order_num]   INT           DEFAULT ((500)) NOT NULL,
    [creator_sid] VARCHAR (46)  NULL,
    [sys_name]    NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

