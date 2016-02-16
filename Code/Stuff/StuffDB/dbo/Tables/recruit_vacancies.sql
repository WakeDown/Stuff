CREATE TABLE [dbo].[recruit_vacancies] (
    [id]                   INT          IDENTITY (1, 1) NOT NULL,
    [dattim1]              DATETIME     CONSTRAINT [DF_recruit_vacancies_dattim1] DEFAULT (getdate()) NOT NULL,
    [dattim2]              DATETIME     CONSTRAINT [DF_recruit_vacancies_dattim2] DEFAULT ('3.3.3333') NOT NULL,
    [enabled]              BIT          CONSTRAINT [DF_recruit_vacancies_enabled] DEFAULT ((1)) NOT NULL,
    [creator_sid]          VARCHAR (46) NOT NULL,
    [author_sid]           VARCHAR (46) NULL,
    [id_position]          INT          NOT NULL,
    [id_department]        INT          NOT NULL,
    [chief_sid]            VARCHAR (46) NULL,
    [id_cause]             INT          NOT NULL,
    [matcher_sid]          VARCHAR (46) NULL,
    [personal_manager_sid] VARCHAR (46) NULL,
    [deadline_date]        DATETIME     NULL,
    [end_date]             DATETIME     NULL,
    [id_state]             INT          NULL,
    [state_change_date]    DATETIME     NULL,
    [state_changer_sid]    VARCHAR (46) NULL,
    [deleter_sid]          VARCHAR (46) NULL,
    [order_end_date]       DATE         NULL,
    [claim_end_date]       DATE         NULL,
    [id_city]              INT          CONSTRAINT [DF_recruit_vacancies_id_city] DEFAULT ((1)) NULL,
    [id_branch_office]     INT          CONSTRAINT [DF_recruit_vacancies_id_branch_office] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_recruit_vacancies] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160113-230058]
    ON [dbo].[recruit_vacancies]([enabled] DESC);

