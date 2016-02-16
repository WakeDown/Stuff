CREATE TABLE [dbo].[employee_states] (
    [id]              INT           NOT NULL,
    [name]            NVARCHAR (50) NOT NULL,
    [sys_name]        NVARCHAR (50) NOT NULL,
    [enabled]         BIT           DEFAULT ((1)) NOT NULL,
    [dattim1]         DATETIME      DEFAULT (getdate()) NOT NULL,
    [dattim2]         DATETIME      DEFAULT ('3.3.3333') NOT NULL,
    [display_in_list] BIT           DEFAULT ((1)) NOT NULL,
    [order_num]       INT           DEFAULT ((500)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

