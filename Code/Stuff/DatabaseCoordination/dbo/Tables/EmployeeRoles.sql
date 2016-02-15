--роли сотрудников в согласовании
CREATE TABLE [dbo].[EmployeeRoles] (
    [Id]         INT           IDENTITY (1000, 1) NOT NULL,
    [Name]       VARCHAR (200) NOT NULL,
    [EmployeeId] INT           NOT NULL,
    [Enabled]    BIT           CONSTRAINT [DK_EmployeeRoles_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EmployeeRoles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmployeeRoles_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[employees] ([Id]),
    CONSTRAINT [AK_EmployeeRoles_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

