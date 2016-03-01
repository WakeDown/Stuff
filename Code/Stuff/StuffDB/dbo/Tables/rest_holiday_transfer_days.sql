CREATE TABLE [dbo].[rest_holiday_transfer_days] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [date]        DATE           NOT NULL,
    [descr]       NVARCHAR (500) NULL,
    [creator_sid] VARCHAR (46)   NOT NULL,
    [enabled]     BIT            CONSTRAINT [DF_rest_holiday_transfer_days_enabled] DEFAULT ((1)) NOT NULL,
    [dattim1]     DATETIME       CONSTRAINT [DF_rest_holiday_transfer_days_dattim1] DEFAULT (getdate()) NOT NULL,
    [dattim2]     DATETIME       CONSTRAINT [DF_rest_holiday_transfer_days_dattim2] DEFAULT ('3.3.3333') NULL,
    [deleter_sid] VARCHAR (46)   NULL,
    CONSTRAINT [PK_rest_holiday_transfer_days] PRIMARY KEY CLUSTERED ([id] ASC)
);

