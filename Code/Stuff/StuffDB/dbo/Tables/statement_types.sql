CREATE TABLE [dbo].[statement_types] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [name]           NVARCHAR (500) NOT NULL,
    [sys_name]       NVARCHAR (50)  NULL,
    [order_num]      INT            CONSTRAINT [DF_statement_types_order_num] DEFAULT ((500)) NOT NULL,
    [enabled]        BIT            CONSTRAINT [DF_statement_types_enabled] DEFAULT ((1)) NOT NULL,
    [group_sys_name] NVARCHAR (50)  NULL,
    [descr]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_statement_types] PRIMARY KEY CLUSTERED ([id] ASC)
);

