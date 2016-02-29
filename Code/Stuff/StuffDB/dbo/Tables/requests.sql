CREATE TABLE [dbo].[requests]
(
	[id] INT NOT NULL IDENTITY(1,1),
	-- должность
    [id_position] INT NULL, 
    -- причина поиска
	[id_reason] INT NULL, 
    -- цель
	[aim] NVARCHAR(MAX) NULL, 
    -- руководитель
	[sid_manager] VARCHAR(46) NULL, 
    -- наставник
	[sid_teacher] VARCHAR(46) NULL, 
    -- отдел
	[id_department] INT NULL, 
    -- есть ли подчиненные
	[is_subordinates] BIT NULL, 
    -- перечисление подчиненных
	[subordinates] NVARCHAR(MAX) NULL, 
    -- возлагаемые функции
	[functions] NVARCHAR(MAX) NULL, 
	-- взаимодействия
	[interactions] NVARCHAR(MAX) NULL,
	-- есть ли должностные инструкции
	[is_instructions] BIT NULL,
	-- показатели успешности
	[success_rates] NVARCHAR(MAX) NULL,
	-- план на испытательном сроке
	[plan_to_test] NVARCHAR(MAX) NULL,
	-- план после испытательного срока
	[plan_after_test] NVARCHAR(MAX) NULL,
---------------------------------------------------------------------
	-- место работы
	[work_place] NVARCHAR(MAX) NULL,
	-- режим работы
	[work_mode] NVARCHAR(MAX) NULL,
	-- отпуск
	[holiday] NVARCHAR(MAX) NULL,
	-- больничные 
	[hospital] NVARCHAR(MAX) NULL,
	-- командировки
	[business_trip] NVARCHAR(MAX) NULL,
	-- сверхурочная работа
	[overtime_work] NVARCHAR(MAX) NULL,
	-- компенсации
	[compensations] NVARCHAR(MAX) NULL,
	-- испытательный срок
	[probation] INT NULL,
	-- зп на испытательном
	[salary_to_test] NVARCHAR(MAX) NULL,
	-- зп после
	[salary_after_test] NVARCHAR(MAX) NULL,
	-- бонусы
	[bonuses] NVARCHAR(MAX) NULL,
----------------------------------------------------------------------
	-- пол
	[sex] BIT NULL,
	-- возраст от
	[age_from] INT NULL,
	-- возраст до
	[age_to] INT NULL,
	-- образование
	[education] NVARCHAR(MAX) NULL,
	-- предыдущие работы
	[last_work] NVARCHAR(MAX) NULL,
	-- обязательные требования
	[requirements] NVARCHAR(MAX) NULL,
	-- навыки и знания
	[knowledge] NVARCHAR(MAX) NULL,
	-- дополнительные пожелания
	[suggestions] NVARCHAR(MAX) NULL,
	-- рабочее место
	[workplace] NVARCHAR(MAX) NULL,
	-- надо ли мебель
	[is_furniture] BIT NULL,
	-- мебель
	[furniture] NVARCHAR(MAX) NULL,
	-- надо ли ПК
	[is_pc] BIT NULL,
	-- надо ли телефон
	[is_telephone] BIT NULL,
	-- эталон
	[is_ethalon] BIT NULL,
	-- сроки выхода на рабору
	[appearance] DATE NULL,
	-- дата создания
	[create_datetime] DATETIME NULL,
	-- дата последнего изменения
	[last_change_datetime] DATETIME NULL,
	-- контактное лицо по собеседованию
	[sid_contact_person] VARCHAR(46) NULL, 
	-- оценщик на итоговом собеседовании
	[sid_responsible_person] VARCHAR(46) NULL, 
	-- статус заявки
	[id_status] INT NOT NULL,
    [HaveCoordination]        BIT CONSTRAINT [DK_requests_HaveCoordination] DEFAULT ((0)) NOT NULL,
    [Enabled]        BIT CONSTRAINT [DK_requests_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_requests] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_requests_id_position] FOREIGN KEY ([id_position]) REFERENCES [dbo].[positions] ([id]),
    CONSTRAINT [FK_requests_id_reason] FOREIGN KEY ([id_reason]) REFERENCES [dbo].[request_reasons] ([id]),
	CONSTRAINT [FK_requests_id_status] FOREIGN KEY ([id_status]) REFERENCES [dbo].[request_statuses] ([id]),
	CONSTRAINT [FK_requests_id_manager] FOREIGN KEY ([sid_manager]) REFERENCES [dbo].[employees] ([ad_sid]),
	CONSTRAINT [FK_requests_id_teacher] FOREIGN KEY ([sid_teacher]) REFERENCES [dbo].[employees] ([ad_sid]),
	CONSTRAINT [FK_requests_id_department] FOREIGN KEY ([id_department]) REFERENCES [dbo].[departments] ([id]),
	CONSTRAINT [FK_requests_id_contact_person] FOREIGN KEY ([sid_contact_person]) REFERENCES [dbo].[employees] ([ad_sid]),
	CONSTRAINT [FK_requests_id_responsible_person] FOREIGN KEY ([sid_responsible_person]) REFERENCES [dbo].[employees] ([ad_sid]),
);
/*GO

CREATE Trigger [dbo].[requestssid_managerTrigger] ON [dbo].[requests] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT ad_sid FROM [Stuff].[dbo].[employees] WHERE ad_sid in (SELECT [sid_manager] FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [requests] - no [sid_manager]',16,1)
   END
END

GO

CREATE Trigger [dbo].[requestssid_teacherTrigger] ON [dbo].[requests] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT ad_sid FROM [Stuff].[dbo].[employees] WHERE ad_sid in (SELECT [sid_teacher] FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [requests] - no [sid_teacher]',16,1)
   END
END

GO

CREATE Trigger [dbo].[requestssid_contact_personTrigger] ON [dbo].[requests] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT ad_sid FROM [Stuff].[dbo].[employees] WHERE ad_sid in (SELECT [sid_contact_person] FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [requests] - no [sid_contact_person]',16,1)
   END
END

GO

CREATE Trigger [dbo].[requestssid_responsible_personTrigger] ON [dbo].[requests] After Insert, Update
AS
BEGIN
   If NOT Exists(SELECT ad_sid FROM [Stuff].[dbo].[employees] WHERE ad_sid in (SELECT [sid_responsible_person] FROM inserted)) BEGIN
      -- Handle the Referential Error Here
	  RAISERROR ('Cannot insert [requests] - no [sid_responsible_person]',16,1)
   END
END
*/