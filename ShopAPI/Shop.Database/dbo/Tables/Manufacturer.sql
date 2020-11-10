CREATE TABLE [dbo].[Manufacturer] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AK_Manufacturer] UNIQUE NONCLUSTERED ([Name] ASC)
);

