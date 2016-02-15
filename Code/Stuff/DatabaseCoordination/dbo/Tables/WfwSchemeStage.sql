--этап исполнения
CREATE TABLE [dbo].[WfwSchemeStage] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (200) NOT NULL,
    [Level]         INT           NOT NULL,
    [RoleId]        INT           NULL,
    [CoordinatorId] INT           NULL,
    [SchemeId]      INT           NOT NULL,
    [Enabled]       BIT           CONSTRAINT [DK_WfwSchemeStage_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_WfwSchemeStage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_WfwSchemeStage_RoleId_CoordinatorId] CHECK ([RoleId] IS NOT NULL AND [CoordinatorId] IS NULL OR [RoleId] IS NULL AND [CoordinatorId] IS NOT NULL),
    CONSTRAINT [FK_WfwSchemeStage_EmployeeRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[EmployeeRoles] ([Id]),
    CONSTRAINT [FK_WfwSchemeStage_WfwScheme] FOREIGN KEY ([SchemeId]) REFERENCES [dbo].[WfwScheme] ([Id])
);

