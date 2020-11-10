CREATE TABLE [dbo].[User] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [RoleId]   INT           NOT NULL,
    [Name]     NVARCHAR (20) NOT NULL,
    [Email]    NVARCHAR (20) NOT NULL,
    [Phone]    NVARCHAR (20) NOT NULL,
    [Password] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]),
    CONSTRAINT [AK_Customer_Email] UNIQUE NONCLUSTERED ([Email] ASC)
);

