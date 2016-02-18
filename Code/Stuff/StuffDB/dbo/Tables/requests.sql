CREATE TABLE [dbo].[requests]
(
	[id] INT NOT NULL IDENTITY(1,1),
	-- должность
    [id_position] INT NULL, 
    -- причина поиска
	[id_reason] INT NULL, 
    -- цель
	[aim] VARCHAR(MAX) NULL, 
    -- руководитель
	[id_manager] INT NULL, 
    -- наставник
	[id_teacher] INT NULL, 
    -- отдел
	[id_department] INT NULL, 
    -- есть ли подчиненные
	[is_subordinates] BIT NULL, 
    -- перечисление подчиненных
	[subordinates] VARCHAR(MAX) NULL, 
    -- возлагаемые функции
	[functions] VARCHAR(MAX) NULL, 
	-- взаимодействия
	[interactions] VARCHAR(MAX) NULL,
	-- есть ли должностные инструкции
	[is_instructions] BIT NULL,
	-- показатели успешности
	[success_rates] VARCHAR(MAX) NULL,
	-- план на испытательном сроке
	[plan_to_test] VARCHAR(MAX) NULL,
	-- план после испытательного срока
	[plan_after_test] VARCHAR(MAX) NULL,
---------------------------------------------------------------------
	-- место работы
	[work_place] VARCHAR(MAX) NULL,
	-- режим работы
	[work_mode] VARCHAR(MAX) NULL,
	-- отпуск
	[holiday] VARCHAR(MAX) NULL,
	-- больничные 
	[hospital] VARCHAR(MAX) NULL,
	-- командировки
	[business_trip] VARCHAR(MAX) NULL,
	-- сверхурочная работа
	[overtime_work] VARCHAR(MAX) NULL,
	-- компенсации
	[compensations] VARCHAR(MAX) NULL,
	-- испытательный срок
	[probation] INT NULL,
	-- зп на испытательном
	[salary_to_test] VARCHAR(MAX) NULL,
	-- зп после
	[salary_after_test] VARCHAR(MAX) NULL,
	-- бонусы
	[bonuses] VARCHAR(MAX) NULL,
----------------------------------------------------------------------
	-- пол
	[sex] BIT NULL,
	-- возраст от
	[age_from] INT NULL,
	-- возраст до
	[age_to] INT NULL,
	-- образование
	[education] VARCHAR(MAX) NULL,
	-- предыдущие работы
	[last_work] VARCHAR(MAX) NULL,
	-- обязательные требования
	[requirements] VARCHAR(MAX) NULL,
	-- навыки и знания
	[knowledge] VARCHAR(MAX) NULL,
	-- дополнительные пожелания
	[suggestions] VARCHAR(MAX) NULL,
	-- рабочее место
	[workplace] VARCHAR(MAX) NULL,
	-- надо ли мебель
	[is_furniture] BIT NULL,
	-- мебель
	[furniture] VARCHAR(MAX) NULL,
	-- надо ли ПК
	[is_pc] BIT NULL,
	-- надо ли телефон
	[is_telephone] BIT NULL,
	-- эталон
	[is_ethalon] BIT NULL,
	-- сроки выхода на рабору
	[appearance] DATE NULL,
	-- контактное лицо по собеседованию
	[id_contact_person] INT NULL,
	-- оценщик на итоговом собеседовании
	[id_responsible_person] INT NULL,

    [Enabled]        BIT CONSTRAINT [DK_requests_Enabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_requests] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_requests_id_position] FOREIGN KEY ([id_position]) REFERENCES [dbo].[positions] ([id]),
    CONSTRAINT [FK_requests_id_reason] FOREIGN KEY ([id_reason]) REFERENCES [dbo].[request_reasons] ([id]),
	CONSTRAINT [FK_requests_id_manager] FOREIGN KEY ([id_manager]) REFERENCES [dbo].[employees] ([id]),
	CONSTRAINT [FK_requests_id_teacher] FOREIGN KEY ([id_teacher]) REFERENCES [dbo].[employees] ([id]),
	CONSTRAINT [FK_requests_id_department] FOREIGN KEY ([id_department]) REFERENCES [dbo].[departments] ([id]),
	CONSTRAINT [FK_requests_id_contact_person] FOREIGN KEY ([id_contact_person]) REFERENCES [dbo].[employees] ([id]),
	CONSTRAINT [FK_requests_id_responsible_person] FOREIGN KEY ([id_responsible_person]) REFERENCES [dbo].[employees] ([id]),
);
