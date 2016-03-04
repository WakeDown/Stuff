-- события исполнения
CREATE TABLE [dbo].[WfwDocumentWorkStages] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [ExecutionId] INT           NOT NULL,
    [Level]         INT           NOT NULL,
    [RoleId]        INT           NULL,
    [CoordinatorSid] VARCHAR (46) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Date]        DATETIMEOFFSET(4)  NULL,
    [ResultId]    INT           NULL,
    [Comment]     VARCHAR (MAX) NULL,
    [Enabled]     BIT           CONSTRAINT [DK_WfwDocumentWorkStages_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_WfwDocumentWorkStages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WfwDocumentWorkStages_WfwDocumentExecutions] FOREIGN KEY ([ExecutionId]) REFERENCES [dbo].[WfwDocumentExecutions] ([Id]),
    CONSTRAINT [CK_WfwDocumentWorkStages_RoleId_CoordinatorId] CHECK ([RoleId] IS NOT NULL AND [CoordinatorSid] IS NULL OR [RoleId] IS NULL AND [CoordinatorSid] IS NOT NULL),
	CONSTRAINT [FK_WfwDocumentWorkStages_ResultId] FOREIGN KEY ([ResultId]) REFERENCES [dbo].[WfwEventsResults] ([Id]),
    --CONSTRAINT [FK_WfwDocumentWorkSchemes_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[WfwDocumentExecutions] ([Id]),
);
GO
CREATE Trigger [dbo].[WfwDocumentWorkStagesEmployeeRolesTrigger] ON [dbo].[WfwDocumentWorkStages] After Insert, Update
AS
BEGIN
   If ( NOT EXISTS(SELECT [Id] FROM [Stuff].[dbo].[EmployeeRoles] WHERE [Id] in (SELECT [RoleId] FROM inserted WHERE [RoleId] is not NULL)) ) AND
	  ( NOT Exists(SELECT [ad_sid] FROM [Stuff].[dbo].[employees] WHERE [ad_sid] in (SELECT [CoordinatorSid] FROM inserted WHERE [CoordinatorSid] is not NULL)) ) BEGIN
      -- Handle the Referential Error Here
		RAISERROR ('Cannot insert [WfwDocumentWorkStages] - no [EmployeeRoles] or [CoordinatorSid] ',16,1)
   END
END
