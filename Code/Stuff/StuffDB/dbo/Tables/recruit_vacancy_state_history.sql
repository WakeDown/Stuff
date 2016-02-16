CREATE TABLE [dbo].[recruit_vacancy_state_history] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [id_vacancy]  INT            NOT NULL,
    [dattim1]     DATETIME       CONSTRAINT [DF_recruit_vacancy_state_history_dattim1] DEFAULT (getdate()) NOT NULL,
    [creator_sid] VARCHAR (46)   NOT NULL,
    [id_state]    INT            NOT NULL,
    [descr]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_recruit_vacancy_state_history] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160113-230118]
    ON [dbo].[recruit_vacancy_state_history]([id_vacancy] DESC);

