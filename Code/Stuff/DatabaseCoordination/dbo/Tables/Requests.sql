--вид документа - заявка на нового сотрудника
CREATE TABLE [dbo].[Requests](
	[Id] INT IDENTITY(1,1) NOT NULL,
	CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Request_Documents] FOREIGN KEY ([Id]) REFERENCES Documents([Id]),
)
