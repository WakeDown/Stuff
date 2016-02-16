CREATE TABLE [dbo].[recruit_candidate_resume_files] (
    [id]           INT              IDENTITY (1, 1) NOT NULL,
    [id_candidate] INT              NOT NULL,
    [sid]          UNIQUEIDENTIFIER CONSTRAINT [DF_recruit_candidate_resume_files_sid] DEFAULT (newid()) NOT NULL,
    [data]         VARBINARY (MAX)  NOT NULL,
    [dattim1]      DATETIME         CONSTRAINT [DF_recruit_candidate_resume_files_dattim1] DEFAULT (getdate()) NOT NULL,
    [creator_sid]  VARCHAR (46)     NOT NULL,
    [file_name]    NVARCHAR (500)   NULL,
    [enabled]      BIT              CONSTRAINT [DF_recruit_candidate_resume_files_enabled] DEFAULT ((1)) NULL,
    [dattim2]      DATETIME         CONSTRAINT [DF_recruit_candidate_resume_files_dattim2] DEFAULT ('3.3.3333') NULL,
    [deleter_sid]  VARCHAR (46)     NULL,
    CONSTRAINT [PK_recruit_candidate_resume_files] PRIMARY KEY CLUSTERED ([id] ASC)
);

