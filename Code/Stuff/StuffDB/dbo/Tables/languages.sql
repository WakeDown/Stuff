CREATE TABLE [dbo].[languages] (
    [id]        INT           NOT NULL,
    [name]      NVARCHAR (50) NOT NULL,
    [order_num] INT           DEFAULT ((500)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

