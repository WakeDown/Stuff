CREATE TABLE [dbo].[employeeRoles] (
    [Id]         INT           IDENTITY (1000, 1) NOT NULL,
    [Name]       NVARCHAR(200) NOT NULL,
    [EmployeeSid] VARCHAR(46) NOT NULL,
    [Enabled]    BIT           CONSTRAINT [DK_EmployeeRoles_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EmployeeRoles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmployeeRoles_Employee_EmployeeId] FOREIGN KEY ([EmployeeSid]) REFERENCES [dbo].[employees] ([ad_sid]),
    CONSTRAINT [AK_EmployeeRoles_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);
/*GO

CREATE Trigger [dbo].[employeeRolesEmployeeSidTrigger] ON [dbo].[employeeRoles] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT ad_sid FROM [Stuff].[dbo].[employees] WHERE ad_sid in (SELECT [EmployeeSid] FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [EmployeeAlternates] - no [AlternateEmployeeId]',16,1)
   END
END
GO
*/
