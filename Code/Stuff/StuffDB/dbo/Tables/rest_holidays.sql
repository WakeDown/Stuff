CREATE TABLE [dbo].[rest_holidays] (
    [id]                   INT           IDENTITY (1, 1) NOT NULL,
    [employee_sid]         VARCHAR (46)  NOT NULL,
    [start_date]           DATETIME      NOT NULL,
    [end_date]             DATETIME      NOT NULL,
    [duration]             INT           NOT NULL,
    [can_edit]             BIT           DEFAULT ((1)) NOT NULL,
    [dattim1]              DATETIME      DEFAULT (getdate()) NOT NULL,
    [dattim2]              DATETIME      DEFAULT ('3.3.3333') NOT NULL,
    [creator_sid]          VARCHAR (46)  NOT NULL,
    [deleter_sid]          NVARCHAR (46) NULL,
    [enabled]              BIT           DEFAULT ((1)) NOT NULL,
    [year]                 INT           NULL,
    [confirmed]            BIT           DEFAULT ((0)) NOT NULL,
    [confirmator_sid]      VARCHAR (46)  NULL,
    [can_edit_creator_sid] VARCHAR (46)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

