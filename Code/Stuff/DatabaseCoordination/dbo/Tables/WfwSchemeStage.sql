--этап исполнения
CREATE TABLE [dbo].[WfwSchemeStage] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (200) NOT NULL,
    [Level]         INT           NOT NULL,
    [RoleId]        INT           NULL,
    [CoordinatorSid] VARCHAR (46) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [SchemeId]      INT           NOT NULL,
    [Enabled]       BIT           CONSTRAINT [DK_WfwSchemeStage_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_WfwSchemeStage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_WfwSchemeStage_RoleId_CoordinatorId] CHECK ([RoleId] IS NOT NULL AND [CoordinatorSid] IS NULL OR [RoleId] IS NULL AND [CoordinatorSid] IS NOT NULL),
    CONSTRAINT [FK_WfwSchemeStage_WfwScheme] FOREIGN KEY ([SchemeId]) REFERENCES [dbo].[WfwScheme] ([Id])
);
GO
CREATE Trigger [dbo].[WfwSchemeStageEmployeeRolesTrigger] ON [dbo].[WfwSchemeStage] After Insert, Update
AS
BEGIN
   If ( NOT EXISTS(SELECT [Id] FROM [Stuff].[dbo].[EmployeeRoles] WHERE [Id] in (SELECT [RoleId] FROM inserted WHERE [RoleId] is not NULL)) ) AND
	  ( NOT Exists(SELECT [ad_sid] FROM [Stuff].[dbo].[employees] WHERE [ad_sid] in (SELECT [CoordinatorSid] FROM inserted WHERE [CoordinatorSid] is not NULL)) ) BEGIN
      -- Handle the Referential Error Here
		RAISERROR ('Cannot insert [WfwSchemeStage] - no [EmployeeRoles] or [CoordinatorSid] ',16,1)
   END
END
