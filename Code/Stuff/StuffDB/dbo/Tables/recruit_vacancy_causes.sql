CREATE TABLE [dbo].[recruit_vacancy_causes] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [name]      NVARCHAR (150) NOT NULL,
    [sys_name]  NVARCHAR (50)  NULL,
    [order_num] INT            CONSTRAINT [DF_recruit_vacansy_causes_order_num] DEFAULT ((500)) NOT NULL,
    [enabled]   BIT            CONSTRAINT [DF_recruit_vacansy_causes_enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_recruit_vacansy_causes] PRIMARY KEY CLUSTERED ([id] ASC)
);

