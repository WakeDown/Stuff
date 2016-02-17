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
    CONSTRAINT [FK_WfwSchemeStage_WfwScheme] FOREIGN KEY ([SchemeId]) REFERENCES [dbo].[WfwScheme] ([Id])
);






GO
CREATE Trigger [dbo].[WfwSchemeStageEmployeeRolesTrigger] ON [dbo].[WfwSchemeStage] After Insert, Update
AS
BEGIN
   If ( NOT EXISTS(SELECT [Id] FROM [Stuff].[dbo].[EmployeeRoles] WHERE Id in (SELECT [RoleId] FROM inserted WHERE [RoleId] is not NULL)) ) AND
	  ( NOT Exists(SELECT [Id] FROM [Stuff].[dbo].[employees] WHERE Id in (SELECT [CoordinatorId] FROM inserted WHERE [CoordinatorId] is not NULL)) ) BEGIN
      -- Handle the Referential Error Here
		RAISERROR ('Cannot insert [WfwSchemeStage] - no [EmployeeRoles] or [CoordinatorId]',16,1)
   END
END