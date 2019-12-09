CREATE TABLE [dbo].[Products] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Key]            NVARCHAR (MAX)  NULL,
    [Price_Value]    DECIMAL (18, 2) NULL,
    [Price_Discount] DECIMAL (18, 2) NULL,
    [Size]           INT             NOT NULL,
    [ArticleId]      INT             NOT NULL,
    [ColorId]        INT             NOT NULL,
    [DeliveryTimeId] INT             NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_Articles_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_Colors_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_DeliveryTimes_DeliveryTimeId] FOREIGN KEY ([DeliveryTimeId]) REFERENCES [dbo].[DeliveryTimes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Products_DeliveryTimeId]
    ON [dbo].[Products]([DeliveryTimeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Products_ColorId]
    ON [dbo].[Products]([ColorId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Products_ArticleId]
    ON [dbo].[Products]([ArticleId] ASC);

