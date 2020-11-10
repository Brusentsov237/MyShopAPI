CREATE TABLE [dbo].[City] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (15) NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AK_City_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

