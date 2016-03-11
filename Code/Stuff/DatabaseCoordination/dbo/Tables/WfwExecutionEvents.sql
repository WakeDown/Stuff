-- события исполнения
CREATE TABLE [dbo].[WfwExecutionEvents] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [WfwDocumentWorkStagesId] INT           NOT NULL,
    [Date]        DATETIMEOFFSET(4)      CONSTRAINT [DK_WfwExecutionEvents_CREATEDate] DEFAULT (getutcdate()) NOT NULL,
    [CreaterSid]   VARCHAR(46)   COLLATE SQL_Latin1_General_CP1_CI_AS        NOT NULL,
	[RoleId] INT           NULL,
    [AlternateId] INT      NULL,
	[ResultId]    INT      NOT NULL,
    [Comment]     VARCHAR (MAX) NULL,
    CONSTRAINT [PK_WfwExecutionEvents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WfwExecutionEvents_WfwDocumentWorkStagesId] FOREIGN KEY ([WfwDocumentWorkStagesId]) REFERENCES [dbo].[WfwDocumentWorkStages] ([Id]),
    CONSTRAINT [FK_WfwExecutionEvents_WfwEventsResults] FOREIGN KEY ([ResultId]) REFERENCES [dbo].[WfwEventsResults] ([Id])
);
GO
/*
CREATE Trigger [dbo].[WfwExecutionEventsCreaterIdTrigger] ON [dbo].[WfwExecutionEvents] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT ad_sid FROM [Stuff].[dbo].[employees] WHERE ad_sid in (SELECT CreaterSid FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [WfwExecutionEvents] - no [CreaterSid]',16,1)
   END
END
GO

CREATE Trigger [dbo].[WfwExecutionEventsRoleIdTrigger] ON [dbo].[WfwExecutionEvents] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT Id FROM [Stuff].[dbo].[employeeRoles] WHERE Id in (SELECT [RoleId] FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [WfwExecutionEvents] - no [RoleId]',16,1)
   END
END
GO

CREATE Trigger [dbo].[WfwExecutionEventsAlternatesIdTrigger] ON [dbo].[WfwExecutionEvents] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT Id FROM [Stuff].[dbo].[employeeAlternates] WHERE Id in (SELECT [AlternateId] FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [WfwExecutionEvents] - no [AlternateId]',16,1)
   END
END
GO
*/