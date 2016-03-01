CREATE TABLE [dbo].[recruit_question_form_facts] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [id_question_form] INT           NOT NULL,
    [dattim1]          DATETIME      CONSTRAINT [DF_recruit_question_form_facts_dattim1] DEFAULT (getdate()) NOT NULL,
    [name]             NVARCHAR (50) NULL,
    [rate]             INT           NULL,
    CONSTRAINT [PK_recruit_question_form_facts] PRIMARY KEY CLUSTERED ([id] ASC)
);

