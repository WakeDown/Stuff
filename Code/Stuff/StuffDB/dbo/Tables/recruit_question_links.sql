CREATE TABLE [dbo].[recruit_question_links] (
    [id]           INT              IDENTITY (1, 1) NOT NULL,
    [id_selection] INT              NOT NULL,
    [sid]          UNIQUEIDENTIFIER CONSTRAINT [DF_recruit_question_links_sid] DEFAULT (newid()) NOT NULL,
    [enabled]      BIT              CONSTRAINT [DF_recruit_question_links_enabled] DEFAULT ((1)) NOT NULL,
    [dattim1]      DATETIME         CONSTRAINT [DF_recruit_question_links_dattim1] DEFAULT (getdate()) NOT NULL,
    [creator_sid]  VARCHAR (46)     NOT NULL,
    [dattim2]      DATETIME         CONSTRAINT [DF_recruit_question_links_dattim2] DEFAULT ('3.3.3333') NOT NULL,
    [deleter_sid]  VARCHAR (46)     NULL,
    CONSTRAINT [PK_recruit_question_links] PRIMARY KEY CLUSTERED ([id] ASC)
);

