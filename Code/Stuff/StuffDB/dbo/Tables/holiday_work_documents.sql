CREATE TABLE [dbo].[holiday_work_documents] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [dattim1]     DATETIME     CONSTRAINT [DF_holiday_work_delivery_dattim1] DEFAULT (getdate()) NOT NULL,
    [enabled]     BIT          CONSTRAINT [DF_holiday_work_delivery_enabled] DEFAULT ((1)) NOT NULL,
    [date_start]  DATE         NOT NULL,
    [date_end]    DATE         NOT NULL,
    [creator_sid] VARCHAR (46) NOT NULL,
    CONSTRAINT [PK_holiday_work_delivery] PRIMARY KEY CLUSTERED ([id] ASC)
);

