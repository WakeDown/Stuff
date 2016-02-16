CREATE TABLE [dbo].[statement_printed] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [id_statement_type] INT            NOT NULL,
    [employee_sid]      VARCHAR (46)   NOT NULL,
    [date_begin]        DATETIME       NULL,
    [date_end]          DATETIME       NULL,
    [duration_hours]    INT            NULL,
    [duration_days]     INT            NULL,
    [cause]             NVARCHAR (MAX) NULL,
    [id_department]     INT            NULL,
    [id_organization]   INT            NULL,
    [enabled]           BIT            CONSTRAINT [DF_statement_printed_enabled] DEFAULT ((1)) NOT NULL,
    [dattim1]           DATETIME       CONSTRAINT [DF_statement_printed_dattim1] DEFAULT (getdate()) NOT NULL,
    [dattim2]           DATETIME       CONSTRAINT [DF_statement_printed_dattim2] DEFAULT ('3.3.3333') NOT NULL,
    [creator_sid]       VARCHAR (46)   NOT NULL,
    [deleter_sid]       VARCHAR (46)   NULL,
    [confirmed]         BIT            CONSTRAINT [DF_statement_printed_confirm] DEFAULT ((0)) NOT NULL,
    [date_confirm]      DATETIME       NULL,
    [confirmator_sid]   VARCHAR (46)   NULL,
    CONSTRAINT [PK_statement_printed] PRIMARY KEY CLUSTERED ([id] ASC)
);

