CREATE TABLE [dbo].[recruit_question_form_educations] (
    [id]               INT             IDENTITY (1, 1) NOT NULL,
    [id_question_form] INT             NOT NULL,
    [dattim1]          DATETIME        CONSTRAINT [DF_recruit_question_form_educations_dattim1] DEFAULT (getdate()) NOT NULL,
    [year_start]       INT             NULL,
    [year_end]         INT             NULL,
    [place]            NVARCHAR (2000) NULL,
    [study_type]       NVARCHAR (50)   NULL,
    [faculty]          NVARCHAR (500)  NULL,
    [speciality]       NVARCHAR (2000) NULL,
    CONSTRAINT [PK_recruit_question_form_educations] PRIMARY KEY CLUSTERED ([id] ASC)
);

