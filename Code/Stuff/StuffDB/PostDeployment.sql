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
SET IDENTITY_INSERT [dbo].[request_statuses] ON
GO

INSERT INTO [dbo].[request_statuses](Id, Name, Description) 
VALUES 
(1, N'Новая', N'Только созданная заявка')
,(2, N'Согласовано', N'Заявка удачно прошедшая этап согласования')
,(3, N'Отклонено', N'Заявка не удачно прошедшая этап согласования')
,(4, N'В работе', N'Заявка по которой начата работа')
,(5, N'Завершено', N'Заявка по которой завершена работа')
GO

SET IDENTITY_INSERT [dbo].[request_statuses] OFF
GO

SET IDENTITY_INSERT [dbo].[request_reasons] ON
GO

INSERT INTO [dbo].[request_reasons](Id, Name, Description) 
VALUES 
(1, N'Увольнение', N'')
,(2, N'Расширение', N'')
,(3, N'Открытие филиала', N'')
GO

SET IDENTITY_INSERT [dbo].[request_reasons] OFF
GO