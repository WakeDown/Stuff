CREATE VIEW [EmployeeAlternates]
AS
SELECT 
	[Id],
	[EmployeeId],
	[AlternateEmployeeId],
	[StartDate],
	[EndDate],
	[Notify],
	[Unlimited]
	FROM [Stuff].[dbo].[EmployeeAlternates]
	WHERE [Enabled] = 1