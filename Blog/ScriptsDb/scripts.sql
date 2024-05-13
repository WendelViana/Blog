Create database blog;

CREATE TABLE [dbo].[Users] (
    [Id]       INT             NOT NULL IDENTITY,
    [Name]     VARCHAR (MAX) NOT NULL,
    [Username] VARCHAR (50)    NOT NULL,
    [Password] VARCHAR (MAX)   NOT NULL,
    [Email]    VARCHAR (MAX)   NOT NULL,
    [Ddd]      CHAR (2)        NULL,
    [Phone]    VARCHAR (20)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Posts]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Title] VARCHAR(255) NOT NULL, 
    [Content] VARCHAR(MAX) NOT NULL, 
    [Image] VARBINARY(MAX) NULL,
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME NULL,
	[UserId] INT NOT NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Posts_ToTUser] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])

)
