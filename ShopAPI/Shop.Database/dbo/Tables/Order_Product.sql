CREATE TABLE [dbo].[Order_Product] (
    [Id]        INT       IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT       NOT NULL,
    [ProductId] INT       NOT NULL,
    [Quantity]  INT       NOT NULL,
    [Color]     NCHAR (6) NULL,
    CONSTRAINT [PK_Order_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Product_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_Order_Product_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [AK_Order_Product] UNIQUE NONCLUSTERED ([OrderId] ASC, [ProductId] ASC)
);

