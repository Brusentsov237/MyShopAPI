CREATE TABLE [dbo].[Order] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [CustomerId] INT  NULL,
    [SellDate]   DATE NOT NULL,
    [CityId]     INT  NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_City] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id]),
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[User] ([Id])
);

