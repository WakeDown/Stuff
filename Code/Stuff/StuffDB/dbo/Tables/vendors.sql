CREATE TABLE [dbo].[vendors] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (150) NOT NULL,
    [dattim1]     DATETIME       DEFAULT (getdate()) NOT NULL,
    [dattim2]     DATETIME       DEFAULT ('3.3.3333') NOT NULL,
    [creator_sid] VARCHAR (46)   NOT NULL,
    [deleter_sid] VARCHAR (46)   NULL,
    [enabled]     BIT            DEFAULT ((1)) NOT NULL,
    [descr]       NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

