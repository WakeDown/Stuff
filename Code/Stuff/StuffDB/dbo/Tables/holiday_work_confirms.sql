CREATE TABLE [dbo].[holiday_work_confirms] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [employee_sid]   VARCHAR (46)   NULL,
    [id_hw_document] INT            NULL,
    [dattim1]        DATETIME       CONSTRAINT [DF_holiday_work_confirms_dattim1] DEFAULT (getdate()) NOT NULL,
    [full_name]      NVARCHAR (150) NOT NULL,
    [enabled]        BIT            DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_holiday_work_confirms] PRIMARY KEY CLUSTERED ([id] ASC)
);

