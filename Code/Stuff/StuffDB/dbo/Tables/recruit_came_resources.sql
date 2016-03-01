CREATE TABLE [dbo].[recruit_came_resources] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50)  NULL,
    [dattim1]     DATETIME       CONSTRAINT [DF_recruit_came_resources_dattim1] DEFAULT (getdate()) NOT NULL,
    [dattim2]     DATETIME       CONSTRAINT [DF_recruit_came_resources_dattim2] DEFAULT ('3.3.3333') NOT NULL,
    [enabled]     BIT            CONSTRAINT [DF_recruit_came_resources_enabled] DEFAULT ((1)) NOT NULL,
    [creator_sid] VARCHAR (46)   NOT NULL,
    [descr]       NVARCHAR (MAX) NULL,
    [order_num]   INT            CONSTRAINT [DF_recruit_came_resources_order_num] DEFAULT ((500)) NOT NULL,
    CONSTRAINT [PK_recruit_came_resources] PRIMARY KEY CLUSTERED ([id] ASC)
);

