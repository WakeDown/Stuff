CREATE TABLE [dbo].[recruit_question_form_further_educations] (
    [id]               INT             IDENTITY (1, 1) NOT NULL,
    [date_start]       NVARCHAR (50)   NULL,
    [duration]         NVARCHAR (50)   NULL,
    [place]            NVARCHAR (500)  NULL,
    [cource_name]      NVARCHAR (2000) NULL,
    [id_question_form] INT             NOT NULL,
    [dattim1]          DATETIME        CONSTRAINT [DF_recruit_question_form_further_educations_dattim1] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_recruit_question_form_further_educations] PRIMARY KEY CLUSTERED ([id] ASC)
);

