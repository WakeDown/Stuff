CREATE TABLE [dbo].[recruit_selection_states] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [name]                NVARCHAR (150) NOT NULL,
    [sys_name]            NVARCHAR (50)  NULL,
    [order_num]           INT            CONSTRAINT [DF_recruit_selection_states_order_num] DEFAULT ((500)) NOT NULL,
    [enabled]             BIT            CONSTRAINT [DF_recruit_selection_states_enabled] DEFAULT ((1)) NOT NULL,
    [show_next_state_btn] BIT            CONSTRAINT [DF_recruit_selection_states_show_next_state_btn] DEFAULT ((1)) NOT NULL,
    [is_active]           BIT            CONSTRAINT [DF_recruit_selection_states_is_active] DEFAULT ((1)) NOT NULL,
    [btn_name]            NVARCHAR (150) NULL,
    [is_accept]           BIT            CONSTRAINT [DF_recruit_selection_states_is_accept] DEFAULT ((0)) NOT NULL,
    [is_cancel]           BIT            CONSTRAINT [DF_recruit_selection_states_is_Cancel] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_recruit_selection_states] PRIMARY KEY CLUSTERED ([id] ASC)
);

