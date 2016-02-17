CREATE VIEW [EmployeeAlternates]
AS
SELECT 
	[Id],
	[EmployeeId],
	[AlternateEmployeeId],
	[StartDate],
	[EndDate],
	[Notify],
	[Unlimited],
	[Enabled]
	FROM [$(StuffDB)].[dbo].[EmployeeAlternates]