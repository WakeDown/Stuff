--сотрудники
CREATE TABLE [dbo].[employees] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (200) NOT NULL,
    [Enabled] BIT           CONSTRAINT [DK_employees_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED ([Id] ASC)
);

