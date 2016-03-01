CREATE TABLE [dbo].[recruit_vacancy_states] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (150) NOT NULL,
    [sys_name]         NVARCHAR (50)  NULL,
    [order_num]        INT            CONSTRAINT [DF_recruit_vacancy_states_order_num] DEFAULT ((500)) NOT NULL,
    [enabled]          BIT            CONSTRAINT [DF_recruit_vacancy_states_enabled] DEFAULT ((1)) NOT NULL,
    [is_active]        BIT            CONSTRAINT [DF_recruit_vacancy_states_is_active] DEFAULT ((1)) NOT NULL,
    [is_end]           BIT            CONSTRAINT [DF_recruit_vacancy_states_is_end] DEFAULT ((0)) NOT NULL,
    [background_color] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_recruit_vacancy_states] PRIMARY KEY CLUSTERED ([id] ASC)
);

