CREATE TABLE [dbo].[employeeAlternates] (
    [Id]                  INT      IDENTITY (1000, 1) NOT NULL,
    [EmployeeId]          INT      NOT NULL,
    [AlternateEmployeeId] INT      NOT NULL,
    [StartDate]           DATETIME NULL,
    [EndDate]             DATETIME NULL,
    [Notify]              BIT      CONSTRAINT [DK_EmployeeAlternates_Notify] DEFAULT ((1)) NOT NULL,
    [Unlimited]           BIT      NULL,
    [Enabled]             BIT      CONSTRAINT [DK_EmployeeAlternates_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EmployeeAlternates] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_EmployeeAlternates_Date_Unlimited] CHECK ([StartDate] IS NOT NULL AND [EndDate] IS NOT NULL AND ([Unlimited] IS NULL OR [Unlimited]=(0)) OR [StartDate] IS NULL AND [EndDate] IS NULL AND [Unlimited] IS NOT NULL AND [Unlimited]=(1)),
    CONSTRAINT [FK_EmployeeAlternates_Employee_AlternateEmployeeId] FOREIGN KEY ([AlternateEmployeeId]) REFERENCES [dbo].[employees] ([id]),
    CONSTRAINT [FK_EmployeeAlternates_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[employees] ([id])
);

