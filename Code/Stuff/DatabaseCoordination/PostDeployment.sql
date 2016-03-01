/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT [dbo].[WfwEventsResults] ON
GO

INSERT INTO [dbo].[WfwEventsResults]([Id], [Name], [Description], [Success]) 
VALUES 
(1, N'Одобрить', N'Дать свое согласие',1)
,(2, N'На доработку', N'Послать документ на переделку или доработку',0)
,(3, N'Категорически отклонить', N'Отклонить эту заявку и не продолжать по ней работу',0)

GO

SET IDENTITY_INSERT [dbo].[WfwEventsResults] OFF
GO

