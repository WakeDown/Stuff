-- результаты события исполнения
CREATE TABLE [dbo].[request_history] (
    [Id]			INT           IDENTITY (1, 1) NOT NULL,
    [RequestId]     INT    NOT NULL,
    [RequestOldStatusId]          INT    NOT NULL,
    [RequestNewStatusId]          INT    NOT NULL,
    [CrteatorSid]	VARCHAR(46)	  NOT NULL,
	[Date]			DATETIME	  NOT NULL,
    CONSTRAINT [PK_request_history] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_request_history_EmployeeId] FOREIGN KEY ([CrteatorSid]) REFERENCES [dbo].[employees] ([ad_sid]),
	CONSTRAINT [FK_request_history_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[requests] ([id]),
	CONSTRAINT [FK_request_history_RequestOldStatusId] FOREIGN KEY ([RequestOldStatusId]) REFERENCES [dbo].[request_statuses] ([Id]),
	CONSTRAINT [FK_request_history_RequestNewStatusId] FOREIGN KEY ([RequestNewStatusId]) REFERENCES [dbo].[request_statuses] ([Id]),
);