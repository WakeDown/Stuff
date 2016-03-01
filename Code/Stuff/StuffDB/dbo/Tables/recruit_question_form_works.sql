CREATE TABLE [dbo].[recruit_question_form_works] (
    [id]                INT             IDENTITY (1, 1) NOT NULL,
    [id_question_form]  INT             NOT NULL,
    [dattim1]           DATETIME        CONSTRAINT [DF_recruit_question_form_works_dattim1] DEFAULT (getdate()) NOT NULL,
    [date_start]        DATE            NULL,
    [date_end]          DATE            NULL,
    [address]           NVARCHAR (500)  NULL,
    [phone]             NVARCHAR (50)   NULL,
    [organization_name] NVARCHAR (500)  NULL,
    [business_type]     NVARCHAR (150)  NULL,
    [position]          NVARCHAR (150)  NULL,
    [salary]            MONEY           NULL,
    [subordinates]      NVARCHAR (4000) NULL,
    [duties]            NVARCHAR (MAX)  NULL,
    [achivements]       NVARCHAR (MAX)  NULL,
    [search_cause]      NVARCHAR (500)  NULL,
    CONSTRAINT [PK_recruit_question_form_works] PRIMARY KEY CLUSTERED ([id] ASC)
);

