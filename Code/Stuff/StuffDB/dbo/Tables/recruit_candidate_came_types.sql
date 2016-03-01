CREATE TABLE [dbo].[recruit_candidate_came_types] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [name]      NVARCHAR (150) NOT NULL,
    [sys_name]  NVARCHAR (50)  NULL,
    [order_num] INT            CONSTRAINT [DF_recruit_candidate_came_type_order_num] DEFAULT ((500)) NOT NULL,
    [enabled]   BIT            CONSTRAINT [DF_recruit_candidate_came_type_enabled] DEFAULT ((1)) NOT NULL,
    [visible]   BIT            CONSTRAINT [DF_recruit_candidate_came_types_visiable] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_recruit_candidate_came_type] PRIMARY KEY CLUSTERED ([id] ASC)
);

