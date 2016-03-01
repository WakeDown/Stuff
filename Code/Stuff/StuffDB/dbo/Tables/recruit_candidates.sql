CREATE TABLE [dbo].[recruit_candidates] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [surname]          NVARCHAR (50)  NOT NULL,
    [name]             NVARCHAR (50)  NOT NULL,
    [patronymic]       NVARCHAR (50)  NULL,
    [display_name]     NVARCHAR (55)  NOT NULL,
    [male]             BIT            NOT NULL,
    [dattim1]          DATETIME       CONSTRAINT [DF_recruit_candidates_dattim1] DEFAULT (getdate()) NOT NULL,
    [dattim2]          DATETIME       CONSTRAINT [DF_recruit_candidates_dattim2] DEFAULT ('3.3.3333') NOT NULL,
    [enabled]          BIT            CONSTRAINT [DF_recruit_candidates_enabled] DEFAULT ((1)) NOT NULL,
    [creator_sid]      VARCHAR (46)   NOT NULL,
    [id_came_resource] INT            NOT NULL,
    [birth_date]       DATE           NULL,
    [deleter_sid]      VARCHAR (46)   NULL,
    [phone]            NVARCHAR (500) NULL,
    [email]            NVARCHAR (500) NULL,
    [id_came_type]     INT            NULL,
    CONSTRAINT [PK_recruit_candidates] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160113-230044]
    ON [dbo].[recruit_candidates]([enabled] DESC);

