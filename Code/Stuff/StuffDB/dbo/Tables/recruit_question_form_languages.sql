CREATE TABLE [dbo].[recruit_question_form_languages] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (150) NULL,
    [expirence]        INT            NULL,
    [comment]          NVARCHAR (500) NULL,
    [id_question_form] INT            NOT NULL,
    [dattim1]          DATETIME       CONSTRAINT [DF_recruit_question_form_languages_dattim1] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_recruit_question_form_languages] PRIMARY KEY CLUSTERED ([id] ASC)
);

