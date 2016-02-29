CREATE TABLE [dbo].[employeeAlternates] (
    [Id]                  INT      IDENTITY (1000, 1) NOT NULL,
    [EmployeeSid]         VARCHAR(46) NOT NULL,
    [AlternateEmployeeSid] VARCHAR(46) NOT NULL,
    [StartDate]           DATETIME NULL,
    [EndDate]             DATETIME NULL,
    [Notify]              BIT      CONSTRAINT [DK_EmployeeAlternates_Notify] DEFAULT ((1)) NOT NULL,
    [Unlimited]           BIT      NULL,
    [Enabled]             BIT      CONSTRAINT [DK_EmployeeAlternates_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EmployeeAlternates] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_EmployeeAlternates_Date_Unlimited] CHECK ([StartDate] IS NOT NULL AND [EndDate] IS NOT NULL AND ([Unlimited] IS NULL OR [Unlimited]=(0)) OR [StartDate] IS NULL AND [EndDate] IS NULL AND [Unlimited] IS NOT NULL AND [Unlimited]=(1)),
    CONSTRAINT [FK_EmployeeAlternates_Employee_AlternateEmployeeId] FOREIGN KEY ([AlternateEmployeeSid]) REFERENCES [dbo].[employees] ([ad_sid]),
    CONSTRAINT [FK_EmployeeAlternates_Employee_EmployeeId] FOREIGN KEY ([EmployeeSid]) REFERENCES [dbo].[employees] ([ad_sid])
);
/*GO

CREATE Trigger [dbo].[EmployeeAlternatesAlternateEmployeeSidTrigger] ON [dbo].[EmployeeAlternates] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT ad_sid FROM [Stuff].[dbo].[employees] WHERE ad_sid in (SELECT [AlternateEmployeeSid] FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [EmployeeAlternates] - no [AlternateEmployeeId]',16,1)
   END
END
GO

CREATE Trigger [dbo].[EmployeeEmployeeSidTrigger] ON [dbo].[EmployeeAlternates] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT ad_sid FROM [Stuff].[dbo].[employees] WHERE ad_sid in (SELECT EmployeeSid FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [EmployeeAlternates] - no [EmployeeSid]',16,1)
   END
END
*/