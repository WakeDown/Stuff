CREATE TABLE [dbo].[branch_offices] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [name]      NVARCHAR (150) NOT NULL,
    [enabled]   BIT            CONSTRAINT [DF_branch_offices_enabled] DEFAULT ((1)) NOT NULL,
    [order_num] INT            CONSTRAINT [DF_branch_offices_order_num] DEFAULT ((500)) NOT NULL,
    CONSTRAINT [PK_branch_offices] PRIMARY KEY CLUSTERED ([id] ASC)
);

