CREATE TABLE [dbo].[Product] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (20)   NOT NULL,
    [ManufacturerId]      INT             NOT NULL,
    [Price]               DECIMAL (18, 2) NOT NULL,
    [Weight]              DECIMAL (18)    NOT NULL,
    [Xrange]              DECIMAL (18)    NOT NULL,
    [Yrange]              DECIMAL (18)    NOT NULL,
    [Zrange]              DECIMAL (18)    NOT NULL,
    [Freezer]             NVARCHAR (6)    NULL,
    [HasNoFrost]          BIT             NULL,
    [HasFreshZone]        BIT             NULL,
    [HasSafetyShutDown]   BIT             NULL,
    [HasSpit]             BIT             NULL,
    [HasMicrowaveMod]     BIT             NULL,
    [SwitchType]          NVARCHAR (12)   NULL,
    [SpeedModQuantity]    INT             NULL,
    [VentingMod]          NVARCHAR (12)   NULL,
    [MaximumProductivity] INT             NULL,
    [ProgramQuantity]     INT             NULL,
    [PanelMaterial]       NVARCHAR (20)   NULL,
    [PanelType]           NVARCHAR (20)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Product] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturer] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-(ManufacturerId)]
    ON [dbo].[Product]([ManufacturerId] ASC)
    INCLUDE([Name], [Price]);

