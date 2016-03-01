-- результаты события исполнения
CREATE TABLE [dbo].[request_reasons] (
    [Id]          INT           IDENTITY (1000, 1) NOT NULL,
    [Name]        NVARCHAR(200) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Enabled]     BIT           CONSTRAINT [DK_request_reasons_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_request_reasons] PRIMARY KEY CLUSTERED ([Id] ASC)
);