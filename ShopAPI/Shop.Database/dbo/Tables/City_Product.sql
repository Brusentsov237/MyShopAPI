CREATE TABLE [dbo].[City_Product] (
    [Id]        INT       IDENTITY (1, 1) NOT NULL,
    [CityId]    INT       NOT NULL,
    [ProductId] INT       NOT NULL,
    [Quantity]  INT       NOT NULL,
    [Color]     NCHAR (6) NULL,
    CONSTRAINT [PK_City_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_City_Product_City] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id]),
    CONSTRAINT [FK_City_Product_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [AK_City_Product] UNIQUE NONCLUSTERED ([CityId] ASC, [ProductId] ASC)
);

