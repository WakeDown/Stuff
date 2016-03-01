CREATE TABLE [dbo].[recruit_selections] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [id_candidate]      INT            NOT NULL,
    [id_vacancy]        INT            NOT NULL,
    [dattim1]           DATETIME       CONSTRAINT [DF_recruit_selections_dattim1] DEFAULT (getdate()) NOT NULL,
    [dattim2]           DATETIME       CONSTRAINT [DF_recruit_selections_dattim2] DEFAULT ('3.3.3333') NOT NULL,
    [enabled]           BIT            CONSTRAINT [DF_recruit_selections_enabled] DEFAULT ((1)) NOT NULL,
    [creator_sid]       VARCHAR (46)   NOT NULL,
    [deleter_sid]       VARCHAR (46)   NULL,
    [id_state]          INT            NULL,
    [state_change_date] DATETIME       NULL,
    [state_changer_sid] VARCHAR (46)   NULL,
    [state_descr]       NVARCHAR (MAX) NULL,
    [id_came_type]      INT            NULL,
    CONSTRAINT [PK_recruit_selections] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160113-225931]
    ON [dbo].[recruit_selections]([id_candidate] DESC);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160113-230007]
    ON [dbo].[recruit_selections]([id_vacancy] DESC);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160113-230025]
    ON [dbo].[recruit_selections]([enabled] DESC);

