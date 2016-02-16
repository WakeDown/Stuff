CREATE TABLE [dbo].[recruit_question_form_relatives] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [id_question_form] INT            NOT NULL,
    [relation_degree]  NVARCHAR (50)  NULL,
    [name]             NVARCHAR (250) NULL,
    [birth_date]       DATE           NULL,
    [birth_place]      NVARCHAR (500) NULL,
    [work_place]       NVARCHAR (500) NULL,
    [address]          NVARCHAR (500) NULL,
    [dattim1]          DATETIME       CONSTRAINT [DF_recruit_question_form_relatives_dattim1] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_recruit_question_form_relatives] PRIMARY KEY CLUSTERED ([id] ASC)
);

