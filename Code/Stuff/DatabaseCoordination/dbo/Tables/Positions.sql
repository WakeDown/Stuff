-- результаты события исполнения
CREATE TABLE [dbo].[Positions]
(
    [Id]          INT           IDENTITY (1000, 1) NOT NULL,
    [Name]        VARCHAR (200) NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    [Enabled]     BIT CONSTRAINT [DK_Positions_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

